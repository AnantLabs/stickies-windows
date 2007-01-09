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
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stickies {
  /// <summary>
  /// A form that displays a Note to the end user. NoteForms are bound to a
  /// single Note instance that represents the Note on disk.  As the user makes
  /// changes to this NoteForm, we perodically serialize the Note to disk.
  /// </summary>
  public partial class NoteForm : ContainedForm {
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
    /// The length of our fade-in/out in milliseconds.
    /// </summary>
    private const int FadeTime = 300;

    /// <summary>
    /// True if we have changed since our last save to disk.
    /// </summary>
    private bool dirty_;

    /// <summary>
    /// True if the user gave the fadeIn option in the constructor.
    /// </summary>
    private bool fadeIn_;

    /// <summary>
    /// Creates a NoteForm for the given Note instance. We load our settings
    /// from the given Note instance, and we bind ourselves to the instance,
    /// so as the user changes this NoteForm, we serialize the changes in the
    /// given Note. If fadeIn is true, we fade the note in rather than just
    /// showing it.
    /// </summary>
    public NoteForm(MainForm mainForm, Note note, bool fadeIn) {
      mainForm_ = mainForm;
      note_ = note;
      fadeIn_ = fadeIn;
      InitializeComponent();
      preferencesMenuItem_.Text = Messages.NotePreferences;
      deleteMenuItem_.Text = Messages.NoteDelete;
      archiveMenuItem_.Text = Messages.NoteArchive;
      boldMenuItem_.Text = Messages.NoteBold;
      italicMenuItem_.Text = Messages.NoteItalic;
      strikethroughMenuItem_.Text = Messages.NoteStrikethrough;

      // Load the settings from the Note instance
      this.StartPosition = FormStartPosition.Manual;
      this.Location = new Point(note.Left, note.Top);
      this.Size = new Size(note.Width, note.Height);
      this.BackColor = Color.FromArgb(note.BorderColor);
      textBox_.BackColor = Color.FromArgb(note.BackColor);
      textBox_.ForeColor = Color.FromArgb(note.FontColor);
      textBox_.Rtf = note.Rtf;
      this.TopMost = note.AlwaysOnTop;
      this.Opacity = 1.0 - note_.Transparency;

      // Lock this note initially since it is not a new note
      Lock();
      UpdateTitle();

      // We are not dirty since the note just loaded
      dirty_ = false;
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
      note_.Left = this.Left;
      note_.Top = this.Top;
      note_.Width = this.Width;
      note_.Height = this.Height;
      note_.Transparency = 1.0 - this.Opacity;
      note_.FontColor = textBox_.ForeColor.ToArgb();
      note_.BackColor = textBox_.BackColor.ToArgb();
      note_.BorderColor = this.BackColor.ToArgb();
      note_.AlwaysOnTop = this.TopMost;
      note_.Rtf = textBox_.Rtf;
      try {
        note_.Save();
      } catch (Exception e) {
        mainForm_.ShowError(String.Format(Messages.ErrorNoteSave, e.Message));
      }
      dirty_ = false;
    }

    /// <summary>
    /// Deletes this Note. We delete the serialized Note from disk and close
    /// this NoteForm window.
    /// </summary>
    public void Delete() {
      Delete(true);
    }

    /// <summary>
    /// Deletes this note, fading the note out if fade is true.
    /// </summary>
    public void Delete(bool fade) {
      if (fade && this.Opacity == 1.0) {
        // When we fade out, Windows only shows the background of the form, not
        // the controls, so we make our background color the color of our text
        // box so the fade looks correct
        this.BackColor = textBox_.BackColor;
        WinUser.AnimateWindow(this.Handle, FadeTime, WinUser.AW_BLEND | WinUser.AW_HIDE);
      }
      try {
        note_.Delete();
      } catch (Exception e) {
        mainForm_.ShowError(String.Format(Messages.ErrorNoteSave, e.Message));
      }
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

    /// <summary>
    /// Returns the proper WM_NCHITTEST result so that the corners of of our
    /// window can perform resizes and the title bar can act as a draggable
    /// title bar.
    /// </summary>
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

    /// <summary>
    /// Capture the WM_NCHITTEST message and associated messages so we can make
    /// our borderless window draggable and resizable.
    /// </summary>
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

    /// <summary>
    /// Checks or unchecks the bold/italic/underline menus.
    /// </summary>
    private void UpdateMenus() {
      Font font = this.SelectionFont;
      boldMenuItem_.Checked = font.Bold;
      italicMenuItem_.Checked = font.Italic;
      underlineMenuItem_.Checked = font.Underline;
      strikethroughMenuItem_.Checked = font.Strikeout;
    }

    /// <summary>
    /// Shows the user a file dialog so they can save the note to a standalone
    /// file. Returns true if the operation was not cancelled and completed
    /// successfully.
    /// </summary>
    private bool ExportNote() {
      UpdateTitle();
      // Set the default file name and strip illegal characters (but truncate
      // since long file names are useless). We cut off the string by maxing it
      // at 50 characters, and then we cut of the (likely truncated) word at
      // the end.
      string fileName = this.Text;
      if (fileName.Length > 50) {
        string[] parts = this.Text.Substring(0, 50).Split();
        if (parts.Length > 0) {
          fileName = String.Join(" ", parts, 0, Math.Max(parts.Length - 1, 1));
        } else {
          fileName = Messages.NoteNewStickyNote;
        }
      }
      ArrayList illegalChars = new ArrayList();
      illegalChars.AddRange(Path.GetInvalidFileNameChars());
      illegalChars.Add(Path.PathSeparator);
      illegalChars.Add(Path.VolumeSeparatorChar);
      illegalChars.Add(Path.AltDirectorySeparatorChar);
      illegalChars.Add(Path.DirectorySeparatorChar);
      illegalChars.Add('*');
      illegalChars.Add('?');
      foreach (char illegal in illegalChars) {
        fileName = fileName.Replace(new String(illegal, 1), "");
      }

      // Add today's date to the file name
      saveFileDialog_.FileName = fileName + " - " + String.Format("{0:yyyy-MM-dd}", System.DateTime.Now) + ".rtf";
      if (saveFileDialog_.ShowDialog(this) == DialogResult.OK) {
        try {
          using (StreamWriter writer = new StreamWriter(saveFileDialog_.FileName)) {
            if (Path.GetExtension(saveFileDialog_.FileName) == ".rtf") {
              writer.Write(textBox_.Rtf);
            } else {
              writer.Write(textBox_.Text);
            }
            return true;
          }
        } catch (Exception e) {
          this.mainForm_.ShowError(e.Message);
        }
      }
      return false;
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
      if (dirty_) {
        Save();
      }
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
    /// Called by a number of event handlers that change the state of our note.
    /// We use this in the Save() method to determine whether we should execute
    /// the save or note.
    /// </summary>
    private void MakeDirty(object sender, EventArgs e) {
      // Checking for Visible ensures we will only make our note "dirty" after
      // the initial form has been loaded, which ensures the dirty bit will
      // only be changed when the user makes changes
      if (this.Visible) {
        dirty_ = true;
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
        settingsDialog_.PreferencesControl.NoteFontColor = textBox_.SelectionColor;
        settingsDialog_.PreferencesControl.NoteTransparency = 1.0 - this.Opacity;
        settingsDialog_.PreferencesControl.NoteAlwaysOnTop = this.TopMost;
        settingsDialog_.PreferencesControl.NoteBackgroundColorChanged += new NotePreferencesControl.NotePreferencesHandler(settingsDialog__NoteBackgroundColorChanged);
        settingsDialog_.PreferencesControl.NoteBorderColorChanged += new NotePreferencesControl.NotePreferencesHandler(settingsDialog__NoteBorderColorChanged);
        settingsDialog_.PreferencesControl.NoteFontChanged += new NotePreferencesControl.NotePreferencesHandler(settingsDialog__NoteFontChanged);
        settingsDialog_.PreferencesControl.NoteFontColorChanged += new NotePreferencesControl.NotePreferencesHandler(settingsDialog__NoteFontColorChanged);
        settingsDialog_.PreferencesControl.NoteTransparencyChanged += new NotePreferencesControl.NotePreferencesHandler(settingsDialog__NoteTransparencyChanged);
        settingsDialog_.PreferencesControl.NoteAlwaysOnTopChanged += new NotePreferencesControl.NotePreferencesHandler(settingsDialog__NoteAlwaysOnTopChanged);
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

    void settingsDialog__NoteAlwaysOnTopChanged() {
      this.TopMost = settingsDialog_.PreferencesControl.NoteAlwaysOnTop;
    }

    /// <summary>
    /// Fade in and focus the text box if it is empty for easy editing.
    /// </summary>
    private void NoteForm_Load(object sender, EventArgs e) {
      // Fade the note in. We cannot fade in if the form is transparent because
      // Windows is retarded.
      if (fadeIn_ && this.Opacity == 1.0) {
        // When we fade in, Windows only shows the background of the form, not
        // the controls, so we make our background color the color of our text
        // box so the fade looks correct
        Color oldBackColor = this.BackColor;
        this.BackColor = textBox_.BackColor;
        WinUser.AnimateWindow(this.Handle, FadeTime, WinUser.AW_BLEND);
        this.BackColor = oldBackColor;
      }

      // Focus on the text box if this is a new/un-edited note
      if (textBox_.Text.Length == 0) {
        this.Unlock();
        textBox_.Focus();
      }
    }

    private void archiveMenuItem__Click(object sender, EventArgs e) {
      if (ExportNote()) {
        this.Delete();
      }
    }

    private void boldMenuItem__Click(object sender, System.EventArgs e) {
      textBox_.SelectionFont = new Font(this.SelectionFont, this.SelectionFont.Style ^ FontStyle.Bold);
      UpdateMenus();
    }

    private void italicMenuItem__Click(object sender, System.EventArgs e) {
      textBox_.SelectionFont = new Font(this.SelectionFont, this.SelectionFont.Style ^ FontStyle.Italic);
      UpdateMenus();
    }

    private void underlineMenuItem__Click(object sender, System.EventArgs e) {
      textBox_.SelectionFont = new Font(this.SelectionFont, this.SelectionFont.Style ^ FontStyle.Underline);
      UpdateMenus();
    }

    private void strikethroughMenuItem__Click(object sender, EventArgs e) {
      textBox_.SelectionFont = new Font(this.SelectionFont, this.SelectionFont.Style ^ FontStyle.Strikeout);
      UpdateMenus();
    }

    private void textBox__SelectionChanged(object sender, EventArgs e) {
      UpdateMenus();
    }

    private void textBox__LinkClicked(object sender, LinkClickedEventArgs e) {
      try {
        System.Diagnostics.Process.Start(e.LinkText);
      } catch (Exception exception) {
        this.mainForm_.ShowError(exception.Message);
      }
    }

    // Returns the selection font of the text box, or the global font of the
    // textbox if there is no text selected.
    private Font SelectionFont {
      get {
        if (textBox_.SelectionFont != null) {
          return textBox_.SelectionFont;
        } else {
          return textBox_.Font;
        }
      }
    }
  }
}