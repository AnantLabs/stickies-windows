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
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Stickies {
  /// <summary>
  /// Our main form, which is invisible. We attach the NotifyIcon tray icon
  /// to this form, and we close the form when the user exits the applictaion
  /// using the system tray icon.
  /// </summary>
  public partial class MainForm : Form {
    /// <summary>
    /// Our About dialog instance.
    /// </summary>
    private AboutDialog aboutDialog_;

    /// <summary>
    /// Our Preferences dialog instance.
    /// </summary>
    private PreferencesDialog preferencesDialog_;

    /// <summary>
    /// The collection of all open notes. We remove notes from the list when
    /// they are closed and add to the list when they are constructed.
    /// </summary>
    private List<NoteForm> noteForms_;
    
    /// <summary>
    /// Our application preferences. We reset this every time the user saves
    /// new preferences in the Preferences dialog.
    /// </summary>
    private Preferences preferences_;

    /// <summary>
    /// The URL that we open when the user clicks the notify icon balloon.
    /// </summary>
    private string notifyIconBalloonUrl_;

    /// <summary>
    /// The global hotkey ID we use to register our Windows hotkey.
    /// </summary>
    private const int kHotkeyId = 0x1;

    /// <summary>
    /// The title we use for our (invisible) Window, which is useful to know
    /// for sending messages to this window from other processes.
    /// </summary>
    public static string kWindowTitle = Application.ProductName + " " + Application.ProductVersion;

    /// <summary>
    /// The Windows message that we should send to this window when the user
    /// tries to open stickies after it is already open.
    /// </summary>
    public const int WM_STICKIES_REOPEN = WinUser.WM_USER + 1;

    /// <summary>
    /// Load our preferences from disk, set up our tray icon, and load all of
    /// our notes from disk. Send an asynchronous request to check for newer
    /// versions of the product in parallel.
    /// </summary>
    public MainForm() {
      // Set up our tray icon and context menu
      InitializeComponent();
      this.Text = Application.ProductName;
      showAllNotesMenuItem_.Text = Messages.MainShowAllNotes;
      deleteAllNotesMenuItem_.Text = Messages.MainDeleteAllNotes;
      aboutMenuItem_.Text = String.Format(Messages.MainAbout, Application.ProductName);
      newNoteMenuItem_.Text = Messages.MainNewNote;
      preferencesMenuItem_.Text = Messages.MainPreferences;
      exitMenuItem_.Text = Messages.MainExit;
      notifyIcon_.Text = Application.ProductName;

      // Name our window so we can find it via inter-process communication
      this.Text = kWindowTitle;

      // Load the preferences from disk
      preferences_ = LoadPreferences();
      ReloadPreferences();

      // Load the notes from disk
      noteForms_ = new List<NoteForm>();
      List<Note> notes = LoadNotes();
      foreach (Note note in notes) {
        ShowNote(new NoteForm(this, note, false));
      }
      UpdateMenus();

      // Register a global hot-key to create new sticky notes
      RegisterGlobalHotKey();

      // Check for new versions of Stickies
      UpdateChecker checker = new UpdateChecker(GetVersionCheckURL(), new UpdateChecker.Callback(OnUpdateCheck));
      checker.Run();
    }

    /// <summary>
    /// Our application preferences instance.
    /// </summary>
    public Preferences Preferences {
      get {
        return preferences_;
      }
    }

    /// <summary>
    /// Shows an error balloon message above our tray icon.
    /// </summary>
    public void ShowError(string message) {
      ShowMessage(message, null, ToolTipIcon.Error, 5000);
    }

    /// <summary>
    /// Shows an informational balloon message above our tray icon.
    /// </summary>
    public void ShowMessage(string message) {
      ShowMessage(message, null);
    }

    /// <summary>
    /// Shows an informational balloon message above our tray icon. If the user
    /// clicks the balloon, we open the given URL in the default browser.
    /// </summary>
    public void ShowMessage(string message, string clickUrl) {
      ShowMessage(message, clickUrl, ToolTipIcon.Info, 7000);
    }

    /// <summary>
    /// Shows the give balloon message with the given icon above our tray icon.
    /// If clickUrl is not null, we open the given URL in the default browser if
    /// the user clicks the URL.
    /// </summary>
    public void ShowMessage(string message, string clickUrl, ToolTipIcon icon, int timeout) {
      notifyIconBalloonUrl_ = clickUrl;
      notifyIcon_.ShowBalloonTip(timeout, Application.ProductName, message,
                                 ToolTipIcon.Info);
    }

    /// <summary>
    /// Loads the application preferences from disk. If it doesn't exist, we
    /// create a new set of preferences, save them to disk, and show a welcome
    /// message to the user since this is (presumably) the first time they
    /// have used the application.
    /// </summary>
    private Preferences LoadPreferences() {
      try {
        return Preferences.Load();
      } catch (Exception) {
        Preferences newPreferences = new Preferences();
        ShowMessage(String.Format(Messages.MessageIntroduction, Application.ProductName));
        try {
          newPreferences.Save();
        } catch (Exception e) {
          ShowError(String.Format(Messages.ErrorPreferencesSave, e.Message));
        }
        return newPreferences;
      }
    }

    /// <summary>
    /// Loads all the notes from disk, returning an array of note structs.
    /// </summary>
    private List<Note> LoadNotes() {
      List<Note> notes = new List<Note>();
      try {
        foreach (string path in Directory.GetFiles(Settings.SettingsDirectory(),
                                                   "*" + Note.PathSuffix)) {
          try {
            notes.Add(Note.Load(path));
          } catch (Exception e) {
            ShowError(String.Format(Messages.ErrorNoteLoad, e.Message));
          }
        }
      } catch (Exception e) {
        ShowError(String.Format(Messages.ErrorSettingsDirectory, e.Message));
      }
      return notes;
    }

    /// <summary>
    /// Registers and displays the given NoteForm.
    /// </summary>
    private void ShowNote(NoteForm noteForm) {
      noteForms_.Add(noteForm);
      noteForm.HandleDestroyed += new EventHandler(NoteForm__HandleDestroyed);
      noteForm.Show();
      UpdateMenus();
    }

    /// <summary>
    /// Brings all registered note forms to the top of the screen.
    /// </summary>
    private void BringNotesToTop() {
      foreach (NoteForm noteForm in noteForms_) {
        noteForm.BringToFront();
      }
    }

    /// <summary>
    /// Deletes all the visible sticky notes.
    /// </summary>
    private void DeleteAllNotes() {
      NoteForm[] notes = new NoteForm[noteForms_.Count];
      noteForms_.CopyTo(notes);
      foreach (NoteForm noteForm in notes) {
        noteForm.Delete(false);
      }
    }

    /// <summary>
    /// Enables or disables menus based on whether the user has any visible
    /// sticky notes.
    /// </summary>
    private void UpdateMenus() {
      deleteAllNotesMenuItem_.Enabled = noteForms_.Count > 0;
      showAllNotesMenuItem_.Enabled = noteForms_.Count > 0;
    }

    /// <summary>
    /// Creates a new note under the current mouse position.
    /// </summary>
    private void NewNote() {
      Note note = (Note) preferences_.Note.Copy();
      note.Guid = Guid.NewGuid().ToString();
      note.Left = Control.MousePosition.X - note.Width / 2;
      note.Top = Control.MousePosition.Y - note.Height / 2;
      NoteForm noteForm = new NoteForm(this, note, true);
      ShowNote(noteForm);
      noteForm.Activate();
    }

    /// <summary>
    /// Loads the changes from the current set of preferences.
    /// </summary>
    private void ReloadPreferences() {
      if (preferences_.TrayIconPath != null) {
        try {
          notifyIcon_.Icon = new System.Drawing.Icon(preferences_.TrayIconPath);
        } catch (Exception e) {
          ShowError(String.Format(Messages.ErrorIconLoad, e.Message));
        }
      } else {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
        notifyIcon_.Icon = (System.Drawing.Icon) resources.GetObject("notifyIcon_.Icon");
      }
    }

    /// <summary>
    /// Registers a global Windows hot key to create new sticky notes.
    /// </summary>
    private void RegisterGlobalHotKey() {
      if (WinUser.RegisterHotKey(this.Handle, kHotkeyId, WinUser.MOD_CONTROL | WinUser.MOD_SHIFT, (int) Keys.N) == 0) {
        System.Diagnostics.Debug.WriteLine("RegisterHotKey failed");
      }
    }

    /// <summary>
    /// Unregisters our global Windows hot key.
    /// </summary>
    private void UnregisterGlobalHotKey() {
      WinUser.UnregisterHotKey(this.Handle, kHotkeyId);
    }

    /// <summary>
    /// If the version on the server is different than our version, show the
    /// update message.
    /// </summary>
    /// <param name="versionInfo"></param>
    private void OnUpdateCheck(VersionInfo versionInfo) {
      if (versionInfo.CurrentVersion != Application.ProductVersion) {
        ShowMessage(versionInfo.UpdateMessage, versionInfo.UpdateUrl);
      }
    }

    /// <summary>
    /// Returns the URL we should use to check for more recent versions of
    /// Stickies.
    /// </summary>
    private String GetVersionCheckURL() {
      return "http://www.stickiesforwindows.com/checkupgrade?v=" + Application.ProductVersion;
    }

    /// <summary>
    /// Handle our global Windows hot key.
    /// </summary>
    /// <param name="m"></param>
    protected override void WndProc(ref Message m) {
      switch (m.Msg) {
        case WinUser.WM_HOTKEY:
          NewNote();
          break;
        case WM_STICKIES_REOPEN:
          ShowMessage(Messages.MessageStickiesAlreadyOpen);
          break;
        default:
          base.WndProc(ref m);
          break;
      }
    }

    /// <summary>
    /// Called when a NoteForm closes. We removed the NoteForm from our
    /// collection when it is closed.
    /// </summary>
    private void NoteForm__HandleDestroyed(object sender, EventArgs e) {
      noteForms_.Remove((NoteForm) sender);
      UpdateMenus();
    }

    /// <summary>
    /// Creates and registers a new note.
    /// </summary>
    private void newNoteMenuItem__Click(object sender, EventArgs e) {
      NewNote();
    }

    /// <summary>
    /// Brings all the notes to the top of the screen.
    /// </summary>
    private void showAllNotesMenuItem__Click(object sender, EventArgs e) {
      BringNotesToTop();
    }

    /// <summary>
    /// Shows the Preferences dialog. If the user exits the dialog
    /// successfully, we save the preferences to disk and set the new
    /// preferences to our instance variable.
    /// </summary>
    private void preferencesMenuItem__Click(object sender, EventArgs e) {
      if (preferencesDialog_ != null && preferencesDialog_.Visible) {
        preferencesDialog_.Activate();
      } else {
        preferencesDialog_ = new PreferencesDialog(preferences_);
        if (preferencesDialog_.ShowDialog(this) == DialogResult.OK) {
          preferences_ = preferencesDialog_.GetPreferences();
          try {
            preferences_.Save();
          } catch (Exception ex) {
            ShowError(String.Format(Messages.ErrorPreferencesSave, ex.Message));
          }
          ReloadPreferences();
        }
      }
    }

    /// <summary>
    /// Shows our About dialog.
    /// </summary>
    private void aboutMenuItem__Click(object sender, EventArgs e) {
      if (aboutDialog_ != null && aboutDialog_.Visible) {
        aboutDialog_.Activate();
      } else {
        aboutDialog_ = new AboutDialog();
        aboutDialog_.ShowDialog(this);
      }
    }

    /// <summary>
    /// Closes this form and exits the application. We need the second step
    /// since this form is not registered with the application message loop.
    /// </summary>
    private void exitMenuItem__Click(object sender, EventArgs e) {
      UnregisterGlobalHotKey();
      this.Close();
      Application.Exit();
    }

    /// <summary>
    /// Creates a new note on a left double click.
    /// </summary>
    private void notifyIcon__MouseDoubleClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        NewNote();
      }
    }

    /// <summary>
    /// Deletes all the visible notes if the user clicks Yes to a prompt.
    /// </summary>
    private void deleteAllNotesMenuItem__Click(object sender, EventArgs e) {
      if (MessageBox.Show(this, Messages.MainDeleteAllConfirm, Application.ProductName,
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                          MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
        DeleteAllNotes();
      }
    }

    /// <summary>
    /// Open the current notifyIconBalloonUrl_, if any, in the default browser.
    /// </summary>
    private void notifyIcon__BalloonTipClicked(object sender, EventArgs e) {
      if (notifyIconBalloonUrl_ != null) {
        System.Diagnostics.Process.Start(notifyIconBalloonUrl_);
      }
    }
  }
}