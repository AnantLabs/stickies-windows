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
using System.Threading;
using System.Windows.Forms;

namespace Stickies {
  /// <summary>
  /// Abstraction for a blocking network operation.
  /// </summary>
  public abstract class NetworkOperation {
    private System.Exception exception_;
    private Control callbackControl_;
    private Delegate callback_;

    /// <summary>
    /// Blocks as this network operation runs. This will lock up the application
    /// if it is run on the UI thread.
    /// </summary>
    public abstract void Run();

    /// <summary>
    /// Runs this operation, catching all exceptions except for
    /// ThreadInterruptedException. When we catch exception, it is available
    /// in the Exception property of this instance after we return.
    /// </summary>
    public void Execute() {
      try {
        Run();
      } catch (ThreadInterruptedException) {
        throw;
      } catch (Exception e) {
        exception_ = e;
      }
    }

    /// <summary>
    /// Runs this operation asynchronously, calling the given delegate when
    /// the operation is complete in the thread that owns the given Control's
    /// handle. If an exception is thrown during execution, the exception
    /// is available in the Exception property of this instance after the
    /// delegate is called.
    /// </summary>
    public void RunAsynchronously(Control control, Delegate callback) {
      callbackControl_ = control;
      callback_ = callback;
      Thread thread = new Thread(this.RunAsynchronously);
      thread.Start();
    }

    /// <summary>
    /// ThreadStart method for the RunAsynchronously method.
    /// </summary>
    private void RunAsynchronously() {
      try {
        Execute();
      } catch (ThreadInterruptedException) {
      }
      callbackControl_.Invoke(callback_);
    }

    /// <summary>
    /// The exception that was thrown during the call to Execute(), if any.
    /// </summary>
    public System.Exception Exception {
      get {
        return exception_;
      }
    }
  }
}
