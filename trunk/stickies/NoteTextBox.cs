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
  /// An extension of the standard RichTextBox class that allows "locking" and
  /// "unlocking". When the text box is locked, all events pass through the
  /// text box as if it does not exist.
  /// </summary>
  public partial class NoteTextBox : RichTextBox {
    public NoteTextBox() {
      InitializeComponent();
    }

    /// <summary>
    /// When set, we lock this text box, so all events pass through it as if
    /// it does not exist.
    /// </summary>
    public bool Locked {
      get {
        return this.ReadOnly;
      }
      set {
        if (value == this.ReadOnly) return;
        this.ReadOnly = value;
        if (this.Locked) {
          Message m = Message.Create(this.Handle, WinUser.WM_KILLFOCUS, IntPtr.Zero, IntPtr.Zero);
          this.WndProc(ref m);
        } else {
          Message m = Message.Create(this.Handle, WinUser.WM_SETFOCUS, IntPtr.Zero, IntPtr.Zero);
          this.WndProc(ref m);
        }
      }
    }

    #region Win32 WM_NCHITTEST

    // Capture the WM_NCHITTEST event to return HTTRANSPARENT when we are
    // locked.
    protected override void WndProc(ref Message m) {
      switch (m.Msg) {
        case WinUser.WM_NCHITTEST:
          if (this.Locked) {
            m.Result = new IntPtr(WinUser.HTTRANSPARENT);
            break;
          }
          base.WndProc(ref m);
          break;
        case WinUser.WM_SETFOCUS:
          if (!this.Locked) {
            base.WndProc(ref m);
          }
          break;
        default:
          base.WndProc(ref m);
          break;
      }
    }

    #endregion
  }
}
