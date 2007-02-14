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

namespace Stickies {
  /// <summary>
  /// Tests Amazon S3 synchronization by creating our sticky notes bucket.
  /// </summary>
  public class TestSynchronizationOperation : AmazonS3Operation {
    public TestSynchronizationOperation(SynchronizationSettings settings)
      : base(settings) {
    }

    public override void Run() {
      CreateBucket();
    }
  }
}
