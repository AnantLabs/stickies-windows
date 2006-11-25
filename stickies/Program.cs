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
using System.Windows.Forms;

namespace Stickies {
  /// <summary>
  /// The entrance point to the Stickies application. We create a MainForm
  /// and start the application message loop with Application.Run().
  /// </summary>
  static class Program {
    /// <summary>
    /// Create the main form and start the application message loop. We don't
    /// send the form to the Application.Run() method because we don't want
    /// to call MainForm.Show(); our main form is just an invisible window that
    /// receives messages for our tray icon.
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      MainForm mainForm = new MainForm();
      Application.Run();
    }
  }
}