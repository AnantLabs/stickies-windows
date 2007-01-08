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
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stickies {
  /// <summary>
  /// A ContainedForm never leaves the visible screen. If the user drags the
  /// form to the edge of the screen, it will "stick" to the edge of the screen
  /// rather than leaving the screen. On load, if the form is off the screen,
  /// we position the form to the closest point on the screen.
  /// </summary>
  public class ContainedForm : Form {
    /// <summary>
    /// Returns the position closest to the given position such that this
    /// form will be completely on the screen.  E.g., if the form would be
    /// cropped off the right side of the screen, the returned point would
    /// have the same Y position and a lesser X position such that the right
    /// side of the form would be flush with the right side of the screen if
    /// it were placed at the given position.
    /// </summary>
    private Point CorrectPosition(Point position) {
      Point newPosition = new Point(position.X, position.Y);

      // Figure out the bounds of all screens (we just round if the monitors
      // happen to be different sizes).
      Rectangle screenBounds = Screen.FromControl(this).WorkingArea;
      int left = screenBounds.Left;
      int top = screenBounds.Top;
      int right = screenBounds.Right;
      int bottom = screenBounds.Bottom;
      foreach (Screen screen in Screen.AllScreens) {
        left = Math.Min(screen.WorkingArea.Left, left);
        top = Math.Min(screen.WorkingArea.Top, top);
        right = Math.Max(screen.WorkingArea.Right, right);
        bottom = Math.Max(screen.WorkingArea.Bottom, bottom);
      }
      Rectangle workingBounds = new Rectangle(left, top, right - left, bottom - top);

      Rectangle formBounds = this.Bounds;
      if (newPosition.X < workingBounds.Left) {
        newPosition.X = workingBounds.Left;
      } else if (newPosition.X + formBounds.Width > workingBounds.Right) {
        newPosition.X = workingBounds.Right - formBounds.Width;
      }
      if (newPosition.Y < workingBounds.Top) {
        newPosition.Y = workingBounds.Top;
      } else if (newPosition.Y + formBounds.Height > workingBounds.Bottom) {
        newPosition.Y = workingBounds.Bottom - formBounds.Height;
      }
      return newPosition;
    }

    /// <summary>
    /// Capture the WM_WINDOWPOSCHANGING message to stick this form to the edges
    /// of the screen.
    /// </summary>
    protected override void WndProc(ref Message m) {
      switch (m.Msg) {
        case WinUser.WM_WINDOWPOSCHANGING:
          WinUser.WINDOWPOS pos = (WinUser.WINDOWPOS) Marshal.PtrToStructure(m.LParam, typeof(WinUser.WINDOWPOS));
          Point newPosition = CorrectPosition(new Point(pos.x, pos.y));
          pos.x = newPosition.X;
          pos.y = newPosition.Y;
          Marshal.StructureToPtr(pos, m.LParam, false);
          break;
        default:
          base.WndProc(ref m);
          break;
      }
    }

    /// <summary>
    /// Snap the form to the edge of the screen if it is off the screen at load
    /// time.
    /// </summary>
    protected override void OnLoad(EventArgs e) {
      // Snap to the screen border
      Point newPosition = CorrectPosition(this.Location);
      if (!newPosition.Equals(this.Location)) {
        this.Location = newPosition;
      }
      base.OnLoad(e);
    }
  }
}