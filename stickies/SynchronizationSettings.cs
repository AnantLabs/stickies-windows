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
using System.ComponentModel;
using System.Xml.Serialization;

namespace Stickies {
  /// <summary>
  /// The Amazon S3 synchronization settings (the Access Key ID and the
  /// Secret Access Key) we use to store sticky notes on the server.
  /// </summary>
  public class SynchronizationSettings {
    public SynchronizationSettings() {
    }

    public SynchronizationSettings(string amazonAccessKeyId, string amazonSecretAccessKey)
      : this(amazonAccessKeyId, amazonSecretAccessKey, DateTime.MinValue) {
    }

    public SynchronizationSettings(string amazonAccessKeyId, string amazonSecretAccessKey, DateTime lastSync) {
      AmazonAccessKeyId = amazonAccessKeyId;
      AmazonSecretAccessKey = amazonSecretAccessKey;
      LastSync = lastSync;
    }

    public string AmazonAccessKeyId;
    public string AmazonSecretAccessKey;

    [XmlAttribute("lastSync")]
    public DateTime LastSync;
  }
}
