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
  /// A Panel that returns HTTTRANSPARENT for all WM_NCHITTEST events.
  /// </summary>
  public partial class TransparentPanel : Panel {
    public TransparentPanel() {
      InitializeComponent();
    }
    
    /// <summary>
    /// Capture the WM_NCHITTEST event to return HTTRANSPARENT.
    /// </summary>
    protected override void WndProc(ref Message m) {
      switch (m.Msg) {
        case WinUser.WM_NCHITTEST:
          m.Result = new IntPtr(WinUser.HTTRANSPARENT);
          break;
        default:
          base.WndProc(ref m);
          break;
      }
    }

  }
}
