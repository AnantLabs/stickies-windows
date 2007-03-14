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
using System.Windows.Forms;

namespace Stickies {
  /// <summary>
  /// A small dialog box that changes the settings for a single note. We
  /// "stick" to the side of a NoteForm so that users can easily change their
  /// note settings and see the effect of their changes immediately.
  /// </summary>
  public partial class NoteSettingsDialog : Form {
    /// <summary>
    /// The NoteForm we are associated with. We track movement of the note form
    /// so that our settings form "sticks" to the side of the note.
    /// </summary>
    private NoteForm noteForm_;

    /// <summary>
    /// Creates a new NoteSettingsDialog form associated with the given
    /// NoteForm. We position ourselves so we are "stuck" to the side of the
    /// given NoteForm at all times.
    /// </summary>
    public NoteSettingsDialog(NoteForm noteForm) {
      noteForm_ = noteForm;
      InitializeComponent();
      this.Icon = Media.StickiesIcon;
      this.Text = Messages.NoteSettingsTitle;
      this.StartPosition = FormStartPosition.Manual;
      this.Location = DeterminePosition();
      noteForm_.FormClosed += new FormClosedEventHandler(noteForm__FormClosed);
      noteForm_.Move += new EventHandler(noteForm__Changed);
      noteForm_.Resize += new EventHandler(noteForm__Changed);
    }

    /// <summary>
    /// Returns the top left point of our form based on the position and size
    /// of the NoteForm we are associated with.
    /// </summary>
    private Point DeterminePosition() {
      // Always position the form to the right of the note if it fits.
      // Otherwise, position us on the right hand side.
      Rectangle screenBounds = Screen.FromControl(this).WorkingArea;
      int x = noteForm_.Bounds.Right;
      if (noteForm_.Bounds.Right + this.Bounds.Width > screenBounds.Width) {
        x = noteForm_.Bounds.Left - this.Bounds.Width;
      }

      // Align the top of the settings form with the top of the note if it is
      // on the screen. Otherwise, position the top or bottom of this form with
      // the top or bottom of the screen
      int y = noteForm_.Bounds.Top;
      if (y + this.Bounds.Height > screenBounds.Bottom) {
        y = screenBounds.Bottom - this.Bounds.Height;
      } else if (y < screenBounds.Top) {
        y = screenBounds.Top;
      }
      return new Point(x, y);
    }

    /// <summary>
    /// Getter for our NotePreferencesControl. Use this property to read the
    /// settings set by the user.
    /// </summary>
    public NotePreferencesControl PreferencesControl {
      get {
        return notePreferencesControl_;
      }
    }

    /// <summary>
    /// Close ourselves when our note closes.
    /// </summary>
    void noteForm__FormClosed(object sender, FormClosedEventArgs e) {
      this.Close();
    }

    /// <summary>
    /// Move ourselves when our note moves.
    /// </summary>
    void noteForm__Changed(object sender, EventArgs e) {
      if (this.Visible) {
        this.Location = DeterminePosition();
      }
    }
  }
}