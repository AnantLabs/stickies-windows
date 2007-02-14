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
    public static string kWindowTitle = Application.ProductName + "MainForm";

    /// <summary>
    /// The Windows message that we should send to this window when the user
    /// tries to open stickies after it is already open.
    /// </summary>
    public const int WM_STICKIES_REOPEN = WinUser.WM_USER + 1;

    /// <summary>
    /// The Windows message that we should send to this window when Stickies
    /// should close/exit.
    /// </summary>
    public const int WM_STICKIES_QUIT = WinUser.WM_USER + 2;

    /// <summary>
    /// Our online synchronization operation. We store it globally because
    /// we only run one synchronization at a time.
    /// </summary>
    private SynchronizeNotesOperation synchronizer_ = null;

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
      reportBugMenuItem_.Text = Messages.MainReportBug;
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

      // Start the synchronization timer and do one initial synchronization
      synchronizationTimer_.Start();
      SynchronizeOnlineNotes(false);
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
    /// have used the application. Likewise, if Stickies has been upgraded,
    /// show an upgrade message.
    /// </summary>
    private Preferences LoadPreferences() {
      try {
        Preferences preferences = Preferences.Load();
        if (preferences.Version != Application.ProductVersion) {
          ShowMessage(String.Format(Messages.MessageUpgraded, Application.ProductName, Application.ProductVersion));
          try {
            preferences.Version = Application.ProductVersion;
            preferences.Save();
          } catch (Exception e) {
            ShowError(String.Format(Messages.ErrorPreferencesSave, e.Message));
          }
        }
        return preferences;
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
      synchronizeMenuItem_.Enabled = preferences_.SynchronizeSettings != null;
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
        Debug.WriteLine("RegisterHotKey failed");
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
    private void OnUpdateCheck(VersionInfo versionInfo) {
      if (versionInfo.CurrentVersion != Application.ProductVersion) {
        ShowMessage(versionInfo.UpdateMessage, versionInfo.UpdateUrl);
      }
    }

    /// <summary>
    /// Synchronizes the notes with the online data store.
    /// </summary>
    private void SynchronizeOnlineNotes(bool showUserInterface) {
      if (synchronizer_ != null) return;
      if (preferences_.SynchronizeSettings == null) return;

      // Load the note objects from the note forms
      List<Note> notes = new List<Note>();
      foreach (NoteForm form in noteForms_) {
        // TODO: Copy note to avoid synchronization problems
        notes.Add(form.Note);
      }

      // Synchronize the notes with or without a user interface
      synchronizer_ = new SynchronizeNotesOperation(preferences_.SynchronizeSettings, notes);
      if (showUserInterface) {
        NetworkActivityDialog dialog = new NetworkActivityDialog(Messages.SynchronizationProgress, synchronizer_);
        dialog.StartPosition = FormStartPosition.Manual;
        dialog.Location = Control.MousePosition;
        if (dialog.ShowDialog() == DialogResult.OK) {
          OnSynchronizeNotesComplete(true);
        } else {
          synchronizer_ = null;
        }
      } else {
        synchronizer_.RunAsynchronously(this, new System.Threading.ThreadStart(this.OnSynchronizeNotesComplete));
      }
    }

    /// <summary>
    /// Called when the note synchronization thread completes.
    /// </summary>
    private void OnSynchronizeNotesComplete() {
      OnSynchronizeNotesComplete(false);
    }

    /// <summary>
    /// Called when the note synchronization thread completes.
    /// </summary>
    private void OnSynchronizeNotesComplete(bool showUserInterface) {
      try {
        if (synchronizer_.Exception != null) {
          // Only show a network exception if we are doing a non-passive
          // operation (as opposed to our timer-based passive synchronization).
          // Otherwise, we would end up showing a bunch of exceptions when the
          // computer is not connected to the net.
          if (synchronizer_.Exception is System.Net.WebException && !showUserInterface) {
            return;
          }
          Debug.WriteLine(synchronizer_.Exception.Message);
          ShowError(String.Format(Messages.SynchronizationError, synchronizer_.Exception.Message));
          return;
        }

        // Load new notes and reload modified notes
        bool newNotesFound = false;
        foreach (Note note in synchronizer_.Notes) {
          bool skip = false;
          foreach (NoteForm form in noteForms_) {
            if (form.Note.Guid == note.Guid) {
              if (form.Note.Modified >= note.Modified) {
                skip = true;
              } else {
                // Replace this note with a new note. Since the note has the
                // same GUID, it will have the same path.
                form.Delete();
              }
              break;
            }
          }
          if (skip) continue;
          newNotesFound = true;
          ShowNote(new NoteForm(this, note, false));
          note.Save(false);
        }

        // Update our last sync time
        if (preferences_.SynchronizeSettings != null) {
          preferences_.SynchronizeSettings.LastSync = DateTime.UtcNow;
          preferences_.Save();
        }

        if (newNotesFound) {
          ShowMessage(Messages.SynchronizationNotesUpdated);
        }
      } catch (Exception e) {
        ShowError(String.Format(Messages.SynchronizationError, e.Message));
      } finally {
        synchronizer_ = null;
      }
    }

    /// <summary>
    /// Returns the URL we should use to check for more recent versions of
    /// Stickies.
    /// </summary>
    private String GetVersionCheckURL() {
      return String.Format(Messages.UpdateCheckUrl, Application.ProductVersion);
    }

    /// <summary>
    /// Frees all resources and exits the application.
    /// </summary>
    private void Quit() {
      UnregisterGlobalHotKey();
      this.Close();
      Application.Exit();
    }

    /// <summary>
    /// Handle our global Windows hot key.
    /// </summary>
    protected override void WndProc(ref Message m) {
      switch (m.Msg) {
        case WinUser.WM_HOTKEY:
          NewNote();
          break;
        case WM_STICKIES_REOPEN:
          ShowMessage(Messages.MessageStickiesAlreadyOpen);
          break;
        case WM_STICKIES_QUIT:
          Quit();
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
          bool wasSynchronized = (preferences_.SynchronizeSettings != null);
          preferences_ = preferencesDialog_.GetPreferences();
          try {
            preferences_.Save();
          } catch (Exception ex) {
            ShowError(String.Format(Messages.ErrorPreferencesSave, ex.Message));
          }
          ReloadPreferences();
          UpdateMenus();
          if (!wasSynchronized && preferences_.SynchronizeSettings != null) {
            SynchronizeOnlineNotes(false);
          }
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
      Quit();
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
        try {
          Process.Start(notifyIconBalloonUrl_);
        } catch (Exception exception) {
          ShowError(exception.Message);
        }
      }
    }

    /// <summary>
    /// Go to the Google Code issue tracking web site.
    /// </summary>
    private void reportBugMenuItem__Click(object sender, EventArgs e) {
      try {
        Process.Start(Messages.ReportBugUrl);
      } catch (Exception exception) {
        ShowError(exception.Message);
      }
    }

    private void synchronizeMenuItem__Click(object sender, EventArgs e) {
      SynchronizeOnlineNotes(true);
    }

    private void synchronizationTimer__Tick(object sender, EventArgs e) {
      SynchronizeOnlineNotes(false);
    }
  }
}