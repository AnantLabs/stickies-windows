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

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Net;
using System.Xml.Serialization;

namespace Stickies {
  /// <summary>
  /// Simple utility class that checks for more recent versions of the Stickies
  /// application on the Stickies web site.
  /// </summary>
  public class UpdateChecker {
    /// <summary>
    /// The URL from which we download the version information in XML form.
    /// </summary>
    private string url_;

    /// <summary>
    /// The function we call after the update check is performed.
    /// </summary>
    private Callback callback_;

    /// <summary>
    /// The callback format that receives the version information when it is
    /// downloaded.
    /// </summary>
    public delegate void Callback(VersionInfo versionInfo);

    /// <summary>
    /// Creates a version checker with the given callback. Whenever
    /// CheckVersion is called, if the version download completes
    /// successfully, we call the given callback with the version number.
    /// </summary>
    public UpdateChecker(string url, Callback callback) {
      url_ = url;
      callback_ = callback;
    }

    /// <summary>
    /// Downloads the current version information from the Stickies web site,
    /// calling the callback if the download is successful. We download on a
    /// separate thread to avoid UI latency.
    /// </summary>
    public void Run() {
      try {
        Thread thread = new Thread(new ThreadStart(DownloadVersionCheck));
        thread.Start();
      } catch (Exception e) {
        Debug.WriteLine(e.ToString());
      }
    }

    /// <summary>
    /// Thread function that does the actual XML download of the version
    /// information from the Web. We send the current version of the application
    /// in the URL in case we need it to report the proper information and/or
    /// XML format back to the client in future versions.
    /// </summary>
    private void DownloadVersionCheck() {
      try {
        Debug.WriteLine("Downloading " + url_);
        WebClient webClient = new WebClient();
        using (Stream stream = webClient.OpenRead(url_)) {
          XmlSerializer serializer = new XmlSerializer(typeof(VersionInfo));
          callback_((VersionInfo) serializer.Deserialize(stream));
        }
      } catch (Exception e) {
        Debug.WriteLine(e.ToString());
      }
    }
  }
}
