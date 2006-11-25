// Copyright 2006 Bret Taylor
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

using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace Stickies {
  /// <summary>
  /// A serializable struct representing a single sticky note. We store our
  /// sticky notes on disk using this class.
  /// </summary>
  public class Note : Settings {
    /// <summary>
    /// The unique ID for this note.
    /// </summary>
    public string Guid;

    /// <summary>
    /// The width of this note in pixels.
    /// </summary>
    [DefaultValue(175)]
    public int Width;

    /// <summary>
    /// The height of this note in pixels.
    /// </summary>
    [DefaultValue(175)]
    public int Height;

    /// <summary>
    /// The top pixel of the note.
    /// </summary>
    [DefaultValue(0)]
    public int Top;

    /// <summary>
    /// The left pixel of the note.
    /// </summary>
    [DefaultValue(0)]
    public int Left;

    /// <summary>
    /// The RTF content of this note.
    /// </summary>
    public string Rtf;

    /// <summary>
    /// The border color of this note.
    /// </summary>
    [DefaultValue(-128)]
    public int BorderColor;

    /// <summary>
    /// The background color of this note.
    /// </summary>
    [DefaultValue(-64)]
    public int BackColor;

    /// <summary>
    /// The level of transparency of this note. 0.0 indicates completely
    /// opaque, and 1.0 indicates completely invisible.
    /// </summary>
    [DefaultValue(0.0)]
    public double Transparency;

    /// <summary>
    /// Creates a new note without a GUID. This should only be used by the
    /// XmlSerializer methods; use the constructor that takes a GUID if you
    /// want to create a new Note that can be saved properly.
    /// </summary>
    public Note()
      : base() {
    }

    /// <summary>
    /// Creates a new note with the given GUID.  Use Guid.NewGuid() to create
    /// a new note GUID.
    /// </summary>
    public Note(System.Guid guid)
      : base() {
      this.Guid = guid.ToString();
    }

    /// <summary>
    /// Returns the path where this note is stored on disk.
    /// </summary>
    /// <returns></returns>
    public override string GetPath() {
      return SettingsPath(this.Guid + PathSuffix);
    }

    /// <summary>
    /// Loads the note at the given path from disk.
    /// </summary>
    public static Note Load(string path) {
      return (Note) Settings.Load(path, typeof(Note));
    }

    /// <summary>
    /// The suffix of the Note XML files in the Stickies settings directory.
    /// </summary>
    public const string PathSuffix = ".note.xml";
  }
}