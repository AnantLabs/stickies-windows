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
    /// If set, we take the user to this URL when he or she clicks the
    /// balloon tip above our tray icon. We reset this to null every time
    /// the balloon closes.
    /// </summary>
    private string balloonClickUrl_;

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

      // Load the preferences and notes from disk
      preferences_ = LoadPreferences();
      noteForms_ = new List<NoteForm>();
      List<Note> notes = LoadNotes();
      foreach (Note note in notes) {
        ShowNote(new NoteForm(this, note));
      }
      UpdateMenus();

      // Start an asynchronous request to check for a more recent version of
      // the product
      string updateCheckUrl = String.Format(Messages.UpdateCheckUrl, Application.ProductVersion);
      UpdateChecker checker = new UpdateChecker(updateCheckUrl, OnVersionCheck);
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
      notifyIcon_.ShowBalloonTip(5000, Application.ProductName, message,
                                 ToolTipIcon.Error);
    }

    /// <summary>
    /// Shows an informational balloon message above our tray icon.
    /// </summary>
    public void ShowMessage(string message) {
      notifyIcon_.ShowBalloonTip(7000, Application.ProductName, message,
                                 ToolTipIcon.Info);
    }

    /// <summary>
    /// Called when the version checker has downloaded the version information
    /// from the Stickies web server. We display an update message if the
    /// version reported by the web server is different than this application's
    /// version.
    /// </summary>
    private void OnVersionCheck(VersionInfo versionInfo) {
      Debug.WriteLine("This application's version: " + Application.ProductVersion);
      Debug.WriteLine("Current application version: " + versionInfo.CurrentVersion);
      if (versionInfo.CurrentVersion != Application.ProductVersion) {
        ShowMessage(versionInfo.UpdateMessage);
        balloonClickUrl_ = versionInfo.UpdateUrl;
      }
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
        noteForm.Delete();
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
      ShowNote(new NoteForm(this));
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
      this.Close();
      Application.Exit();
    }

    /// <summary>
    /// Creates a new note on a left double click.
    /// </summary>
    private void notifyIcon__MouseDoubleClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        ShowNote(new NoteForm(this));
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
    /// Takes the user to the balloonClickUrl_ if one is registered.
    /// </summary>
    private void notifyIcon__BalloonTipClicked(object sender, EventArgs e) {
      if (balloonClickUrl_ != null) {
        System.Diagnostics.Process.Start(balloonClickUrl_);
      }
    }

    /// <summary>
    /// Clears the current balloonClickUrl_, if any.
    /// </summary>
    private void notifyIcon__BalloonTipClosed(object sender, EventArgs e) {
      balloonClickUrl_ = null;
    }
  }
}