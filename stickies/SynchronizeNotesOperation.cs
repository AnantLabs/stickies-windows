// Copyright 2007 Bret Taylor
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may
// not use this file except in compliance with the License. You may obtain
// a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations
// under the License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

namespace Stickies {
  /// <summary>
  /// Synchronizes our notes with the Amazon S3 service.  We store all notes in
  /// a single bucket, and we use the Note GUID as the key. The objects are
  /// the GZipped XML form of the note, so you can deserialize notes stored on
  /// Amazon S3 with the standard Note serialization methods using a
  /// GZipStream.
  /// </summary>
  class SynchronizeNotesOperation : AmazonS3Operation {
    private SortedDictionary<string, Note> notes_;

    public SynchronizeNotesOperation(SynchronizationSettings settings, List<Note> notes)
      : base(settings) {
      notes_ = new SortedDictionary<string, Note>();
      foreach (Note note in notes) {
        notes_[note.Guid] = note;
      }
    }

    public override void Run() {
      XmlSerializer serializer = new XmlSerializer(typeof(Note), Settings.XmlNamespace);
      System.Diagnostics.Debug.WriteLine("AMAZON S3 SYNCHRONIZE: " + GetBucketName());

      // Create the bucket
      CreateBucket();

      // List the notes in the bucket
      ListBucketResult listBucketResult = ListBucket();
      SortedDictionary<string, ListEntry> serverKeys = new SortedDictionary<string, ListEntry>();
      SortedDictionary<string, Note> notesToUpload = new SortedDictionary<string, Note>();
      if (listBucketResult.Contents != null) {
        foreach (ListEntry entry in listBucketResult.Contents) {
          serverKeys[entry.Key] = entry;
          bool downloadNote = false;
          if (notes_.ContainsKey(entry.Key)) {
            // If the note exists on our hard disk, only update it if it has changed
            TimeSpan span = entry.LastModified.Subtract(notes_[entry.Key].Modified);
            System.Diagnostics.Debug.WriteLine(String.Format("{0} Server Time Delta: {1}", entry.Key, span.TotalSeconds));
            if (Math.Abs(span.TotalSeconds) > 10) {
              if (entry.LastModified > notes_[entry.Key].Modified) {
                downloadNote = true;
              } else if (entry.LastModified < notes_[entry.Key].Modified) {
                // Save the local copy to S3 if it is newer than the S3 copy
                notesToUpload[entry.Key] = notes_[entry.Key];
              }
            }
          } else {
            // A note on the server may have just been deleted. Only add it if
            // its last modified date is greater than the last time we sync'ed
            if (entry.LastModified > settings_.LastSync) {
              downloadNote = true;
            } else {
              System.Diagnostics.Debug.WriteLine("DELETE " + entry.Key);
              DeleteObject(entry.Key);
            }
          }

          // Download the note if it is new or updated on the server
          if (downloadNote) {
            System.Diagnostics.Debug.WriteLine("DOWNLOAD " + entry.Key);
            GetObjectResult result = GetObject(entry.Key);
            using (MemoryStream stream = new MemoryStream(result.Data)) {
              using (GZipStream decompressionStream = new GZipStream(stream, CompressionMode.Decompress)) {
                Note serverNote = (Note) serializer.Deserialize(decompressionStream);
                serverNote.Modified = result.LastModified;
                notes_[serverNote.Guid] = serverNote;
              }
            }
          }
        }
      }

      // Save all the notes that are not currently on the server
      foreach (string key in notes_.Keys) {
        if (!serverKeys.ContainsKey(key)) {
          notesToUpload[key] = notes_[key];
        }
      }

      // Finally, save the notes to the server
      foreach (Note note in notesToUpload.Values) {
        System.Diagnostics.Debug.WriteLine("UPLOAD " + note.Guid);
        using (MemoryStream stream = new MemoryStream()) {
          using (GZipStream compressionStream = new GZipStream(stream, CompressionMode.Compress)) {
            serializer.Serialize(compressionStream, note);
          }
          PutObjectResult result = PutObject(note.Guid, stream.GetBuffer());
          note.Modified = result.LastModified;
        }
      }
    }

    /// <summary>
    /// The notes after the synchronization. This could contain new notes and
    /// updated notes.
    /// </summary>
    public SortedDictionary<string, Note>.ValueCollection Notes {
      get {
        return notes_.Values;
      }
    }
  }
}
