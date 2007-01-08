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
using System.ComponentModel;
using System.Collections;
using System.Configuration.Install;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace StickiesCustomActions {
  /// <summary>
  /// Runs the path specified in the command line arguments. Useful to start
  /// the application after the installer completes.
  /// </summary>
  [RunInstaller(true)]
  public partial class Launcher : Installer {
    private const string kStickiesWindowName = "StickiesMainForm";
    public const int WM_STICKIES_QUIT = 0x0400 + 2;

    public Launcher() {
      InitializeComponent();
    }

    /// <summary>
    /// Runs the path specified in the command line arguments.
    /// </summary>
    public override void Install(IDictionary stateSaver) {
      try {
        if (this.Context.Parameters.ContainsKey("path")) {
          Process.Start(this.Context.Parameters["path"]);
        }
      } catch (Exception) {
      }
    }

    /// <summary>
    /// Stops all running Stickies processes.
    /// </summary>
    public override void Uninstall(IDictionary savedState) {
      IntPtr mainWindow = FindWindow(null, kStickiesWindowName);
      if (!mainWindow.Equals(IntPtr.Zero)) {
        SendMessage(mainWindow, new IntPtr(WM_STICKIES_QUIT), IntPtr.Zero, IntPtr.Zero);
      }
    }

    // From winuser.h
    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, IntPtr msg, IntPtr wParam, IntPtr lParam);

    // From winuser.h
    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(String className, String title);
  }
}