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
  /// A form that displays a Note to the end user. NoteForms are bound to a
  /// single Note instance that represents the Note on disk.  As the user makes
  /// changes to this NoteForm, we perodically serialize the Note to disk.
  /// </summary>
  public partial class NoteForm : Form {
    /// <summary>
    /// The Note instance associated with this NoteForm
    /// </summary>
    private Note note_;

    /// <summary>
    /// The MainForm instance for the application.
    /// </summary>
    private MainForm mainForm_;

    /// <summary>
    ///  Our NoteSettingsDialog instance if one is open
    /// </summary>
    private NoteSettingsDialog settingsDialog_;

    /// <summary>
    /// Creates a new note. We create the Note instance in addition to loading
    /// a NoteForm with the default settings. We style the note based on the
    /// given preferences.
    /// </summary>
    public NoteForm(MainForm mainForm) {
      mainForm_ = mainForm;

      // Create a note with a new GUID
      note_ = new Note(Guid.NewGuid());

      // Load the settings from the default note settings in the preferences
      InitializeComponent();
      this.StartPosition = FormStartPosition.WindowsDefaultLocation;
      this.Size = new Size(mainForm.Preferences.Note.Width, mainForm.Preferences.Note.Height);
      this.BackColor = Color.FromArgb(mainForm.Preferences.Note.BorderColor);
      textBox_.BackColor = Color.FromArgb(mainForm.Preferences.Note.BackColor);
      this.Opacity = 1.0 - mainForm.Preferences.Note.Transparency;
      textBox_.Rtf = mainForm.Preferences.Note.Rtf;

      // Don't lock the note since it is a new note
      UpdateTitle();
      timer_.Start();
    }

    /// <summary>
    /// Creates a NoteForm for the given Note instance. We load our settings
    /// from the given Note instance, and we bind ourselves to the instance,
    /// so as the user changes this NoteForm, we serialize the changes in the
    /// given Note.
    /// </summary>
    public NoteForm(MainForm mainForm, Note note) {
      mainForm_ = mainForm;
      note_ = note;
      InitializeComponent();

      // Load the settings from the Note instance
      this.StartPosition = FormStartPosition.Manual;
      this.Location = new Point(note.Left, note.Top);
      this.Size = new Size(note.Width, note.Height);
      this.BackColor = Color.FromArgb(note.BorderColor);
      textBox_.BackColor = Color.FromArgb(note.BackColor);
      textBox_.Rtf = note.Rtf;
      this.Opacity = 1.0 - note.Transparency;

      // Lock this note initially since it is not a new note
      Lock();
      UpdateTitle();
      timer_.Start();
    }

    /// <summary>
    /// Makes a friendly window title for this Note using the first line of
    /// text in the note. This is mainly to support a friendly title when the
    /// user is Alt-Tabbing through all the desktop windows.
    /// </summary>
    private void UpdateTitle() {
      string text = textBox_.Text;
      int carriageReturn = text.IndexOf('\n');
      string firstLine = text;
      if (carriageReturn >= 0) {
        firstLine = text.Substring(0, carriageReturn);
      }
      firstLine = firstLine.Trim();
      if (firstLine.Length > 0) {
        this.Text = firstLine;
      } else {
        this.Text = Messages.NoteNewStickyNote;
      }
    }

    /// <summary>
    /// Serializes this Note to disk if the position or content has changed since
    /// we last saved the changes.
    /// </summary>
    public void Save() {
      if (note_ == null) return;
      System.Diagnostics.Debug.WriteLine("Saving note " + note_.Guid);
      note_.Left = this.Left;
      note_.Top = this.Top;
      note_.Width = this.Width;
      note_.Height = this.Height;
      note_.Transparency = 1.0 - this.Opacity;
      note_.Rtf = textBox_.Rtf;
      note_.BackColor = textBox_.BackColor.ToArgb();
      note_.BorderColor = this.BackColor.ToArgb();
      try {
        note_.Save();
      } catch (Exception e) {
        mainForm_.ShowError(String.Format(Messages.ErrorNoteSave, e.Message));
      }
    }

    /// <summary>
    /// Deletes this Note. We delete the serialized Note from disk and close
    /// this NoteForm window.
    /// </summary>
    public void Delete() {
      timer_.Stop();
      note_.Delete();
      note_ = null;
      this.Close();
    }

    /// <summary>
    /// "Locks" this NoteForm, which means the user can drag it around by
    /// clicking anywhere on the note, and they have to double-click to edit.
    /// </summary>
    public void Lock() {
      textBox_.Locked = true;
    }

    /// <summary>
    /// Unlocks the form, which make the text area editable again. See Lock()
    /// for details.
    /// </summary>
    public void Unlock() {
      textBox_.Locked = false;
    }

    #region Win32 WM_NCHITTEST

    // Returns the proper WM_NCHITTEST result so that the corners of of our
    // window can perform resizes and the title bar can act as a draggable
    // title bar.
    private int OnNcHitTest(Point p) {
      if (p.Y < this.Padding.Top) {
        if (p.X < this.Padding.Left) {
          if (p.Y < this.Padding.Left) {
            return WinUser.HTTOPLEFT;
          } else {
            return WinUser.HTLEFT;
          }
        } else if (p.X >= this.Width - this.Padding.Right) {
          if (p.Y < this.Padding.Right) {
            return WinUser.HTTOPRIGHT;
          } else {
            return WinUser.HTRIGHT;
          }
        } else if (p.Y < this.Padding.Left) {
          return WinUser.HTTOP;
        }
      } else {
        if (p.Y < this.Height - this.Padding.Bottom) {
          if (p.X < this.Padding.Left) {
            return WinUser.HTLEFT;
          } else if (p.X >= this.Width - this.Padding.Right) {
            return WinUser.HTRIGHT;
          }
        } else {
          if (p.X < this.Padding.Left) {
            return WinUser.HTBOTTOMLEFT;
          } else if (p.X >= this.Width - this.Padding.Right) {
            return WinUser.HTBOTTOMRIGHT;
          } else {
            return WinUser.HTBOTTOM;
          }
        }
      }

      return WinUser.HTCAPTION;
    }

    // Capture the WM_NCHITTEST message and associated messages so we can make
    // our borderless window draggable and resizable.
    protected override void WndProc(ref Message m) {
      switch (m.Msg) {
        case WinUser.WM_NCHITTEST:
          m.Result = new System.IntPtr(OnNcHitTest(PointToClient(WinUser.LParamToPoint(m.LParam))));
          return;
        case WinUser.WM_NCLBUTTONDOWN:
        case WinUser.WM_NCRBUTTONDOWN:
        case WinUser.WM_NCLBUTTONUP:
          // If the user creates a note and immediately moves it (before any
          // edits), we probably don't want to lock it yet (it is annoying)
          if (!textBox_.Locked && textBox_.Text.Length > 0) Lock();
          base.WndProc(ref m);
          break;
        case WinUser.WM_NCRBUTTONUP:
          Lock();
          contextMenu_.Show(this, PointToClient(WinUser.LParamToPoint(m.LParam)));
          break;
        case WinUser.WM_NCLBUTTONDBLCLK:
          Unlock();
          break;
        default:
          base.WndProc(ref m);
          break;
      }
    }

    #endregion

    /// <summary>
    /// The timer ticks periodically, and we update our title and save the Note.
    /// </summary>
    private void timer_Tick(object sender, EventArgs e) {
      if (note_.Rtf != textBox_.Rtf || this.Left != note_.Left ||
          this.Top != note_.Top || this.Width != note_.Width ||
          this.Height != note_.Height) {
        Save();
        UpdateTitle();
      }
    }

    /// <summary>
    /// Deletes this note.
    /// </summary>
    private void deleteMenuItem__Click(object sender, EventArgs e) {
      Delete();
    }

    /// <summary>
    /// When the form loses focus, save, update title, and lock the note so
    /// that we are in a solid state before the user, e.g., shuts down the
    /// computer.
    /// </summary>
    private void NoteForm_Deactivate(object sender, EventArgs e) {
      Lock();
      Save();
      UpdateTitle();
    }

    /// <summary>
    /// Unlock the note automatically when the user starts typing.  Escape
    /// locks the note.
    /// </summary>
    private void textBox__KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Escape) {
        Lock();
      } else if (e.KeyCode != Keys.ControlKey) {
        Unlock();
      }
    }

    /// <summary>
    /// Create a preferences form initialized with our settings and display it.
    /// We don't make it a dialog box so that the user can edit and resize their
    /// note as they change preferences, but we only show one preferences form
    /// at a time like a dialog box.
    /// </summary>
    private void preferencesMenuItem__Click(object sender, EventArgs e) {
      if (settingsDialog_ == null || !settingsDialog_.Visible) {
        settingsDialog_ = new NoteSettingsDialog(this);
        settingsDialog_.PreferencesControl.NoteBackgroundColor = textBox_.BackColor;
        settingsDialog_.PreferencesControl.NoteBorderColor = this.BackColor;
        settingsDialog_.PreferencesControl.NoteFont = textBox_.SelectionFont;
        settingsDialog_.PreferencesControl.NoteFontColor = textBox_.ForeColor;
        settingsDialog_.PreferencesControl.NoteTransparency = 1.0 - this.Opacity;
        settingsDialog_.PreferencesControl.NoteBackgroundColorChanged += new NotePreferencesControl.NotePreferencesHandler(settingsDialog__NoteBackgroundColorChanged);
        settingsDialog_.PreferencesControl.NoteBorderColorChanged += new NotePreferencesControl.NotePreferencesHandler(settingsDialog__NoteBorderColorChanged);
        settingsDialog_.PreferencesControl.NoteFontChanged += new NotePreferencesControl.NotePreferencesHandler(settingsDialog__NoteFontChanged);
        settingsDialog_.PreferencesControl.NoteFontColorChanged += new NotePreferencesControl.NotePreferencesHandler(settingsDialog__NoteFontColorChanged);
        settingsDialog_.PreferencesControl.NoteTransparencyChanged += new NotePreferencesControl.NotePreferencesHandler(settingsDialog__NoteTransparencyChanged);
        settingsDialog_.Show();
      } else {
        settingsDialog_.Activate();
      }
    }

    void settingsDialog__NoteTransparencyChanged() {
      this.Opacity = 1.0 - settingsDialog_.PreferencesControl.NoteTransparency;
    }

    void settingsDialog__NoteFontColorChanged() {
      textBox_.ForeColor = settingsDialog_.PreferencesControl.NoteFontColor;
    }

    void settingsDialog__NoteFontChanged() {
      textBox_.Font = settingsDialog_.PreferencesControl.NoteFont;
    }

    void settingsDialog__NoteBorderColorChanged() {
      this.BackColor = settingsDialog_.PreferencesControl.NoteBorderColor;
    }

    void settingsDialog__NoteBackgroundColorChanged() {
      textBox_.BackColor = settingsDialog_.PreferencesControl.NoteBackgroundColor;
    }
  }
}