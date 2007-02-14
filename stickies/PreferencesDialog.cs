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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Stickies {
  /// <summary>
  /// The dialog box that lets users specify their application preferences for
  /// Stickies.
  /// </summary>
  public partial class PreferencesDialog : ContainedForm {
    /// <summary>
    /// We set this variable when the user sets or changes their synchronization
    /// preferences.
    /// </summary>
    private SynchronizationSettings synchronizationSettings_;

    /// <summary>
    /// Creates a new preferences dialog, initializing our form based on the
    /// settings in the given Preferences instance.
    /// </summary>
    public PreferencesDialog(Preferences preferences) {
      InitializeComponent();
      this.Text = String.Format(Messages.PreferencesTitle, Application.ProductName);
      saveButton_.Text = Messages.PreferencesSave;
      cancelButton_.Text = Messages.PreferencesCancel;
      appearanceTabPage_.Text = Messages.PreferencesAppearanceTab;
      settingsTabPage_.Text = Messages.PreferencesSettingsTab;
      startOnWindowsCheckBox_.Text = Messages.PreferencesStartWithWindows;
      iconCheckBox_.Text = Messages.PreferencesCustomIcon;

      // Start the preferences dialog under the mouse cursor. Since we are
      // a ContainedControl, this will work correctly even if the mouse is
      // near the edge of the screen.
      this.StartPosition = FormStartPosition.Manual;
      this.Location = Control.MousePosition;

      // Reflect the initial set of preferences in our form
      notePreferencesControl_.NoteBackgroundColor = Color.FromArgb(preferences.Note.BackColor);
      notePreferencesControl_.NoteBorderColor = Color.FromArgb(preferences.Note.BorderColor);
      noteTextBox_.ForeColor = Color.FromArgb(preferences.Note.FontColor);
      notePreferencesControl_.NoteTransparency = preferences.Note.Transparency;
      if (preferences.Note.Rtf != null) {
        noteTextBox_.Rtf = preferences.Note.Rtf;
        notePreferencesControl_.NoteFont = noteTextBox_.SelectionFont;
        notePreferencesControl_.NoteFontColor = noteTextBox_.SelectionColor;
      }
      notePreferencesControl_.NoteAlwaysOnTop = preferences.Note.AlwaysOnTop;
      noteTextBox_.Text = Messages.PreferencesNoteText;
      if (preferences.TrayIconPath != null) {
        iconTextBox_.Text = preferences.TrayIconPath;
      }
      iconCheckBox_.Checked = preferences.TrayIconPath != null;
      iconTextBox_.Enabled = iconCheckBox_.Checked;
      iconBrowseButton_.Enabled = iconCheckBox_.Checked;
      startOnWindowsCheckBox_.Checked = Preferences.StartWithWindows();

      synchronizationSettings_ = preferences.SynchronizeSettings;
      if (synchronizationSettings_ != null) {
        synchronizeCheckBox_.Checked = true;
        amazonAccessKeyIdTextBox_.Text = synchronizationSettings_.AmazonAccessKeyId;
        amazonSecretAccessKeyTextBox_.Text = synchronizationSettings_.AmazonSecretAccessKey;
      }

      // Hack to make slider bar look right on top of the light colored
      // TabControl. The slider bar control does not support transparent
      // background colors.
      notePreferencesControl_.SliderBarBackColor = Color.FromArgb(244, 243, 239);

      UpdateSynchronizationEnabled();
    }

    /// <summary>
    /// Generates a Preferences instance from the settings the user has
    /// input into this dialog. Use this to get Preferences after the dialog
    /// closes.
    /// </summary>
    public Preferences GetPreferences() {
      Preferences preferences = new Preferences();
      preferences.Note.BackColor = notePreferencesControl_.NoteBackgroundColor.ToArgb();
      preferences.Note.BorderColor = notePreferencesControl_.NoteBorderColor.ToArgb();
      preferences.Note.FontColor = notePreferencesControl_.NoteFontColor.ToArgb();
      preferences.Note.Transparency = notePreferencesControl_.NoteTransparency;
      preferences.Note.AlwaysOnTop = notePreferencesControl_.NoteAlwaysOnTop;

      if (iconCheckBox_.Checked && iconTextBox_.Text.Length > 0) {
        preferences.TrayIconPath = iconTextBox_.Text;
      }

      if (synchronizeCheckBox_.Checked && amazonAccessKeyIdTextBox_.Text.Length > 0 && amazonSecretAccessKeyTextBox_.Text.Length > 0) {
        // Preserve the old synchronization (and LastSync timestamp) unless the
        // Amazon key has changed.
        if (synchronizationSettings_ != null && synchronizationSettings_.AmazonAccessKeyId == amazonAccessKeyIdTextBox_.Text && synchronizationSettings_.AmazonSecretAccessKey == amazonSecretAccessKeyTextBox_.Text) {
          preferences.SynchronizeSettings = synchronizationSettings_;
        } else {
          preferences.SynchronizeSettings = new SynchronizationSettings(amazonAccessKeyIdTextBox_.Text, amazonSecretAccessKeyTextBox_.Text);
        }
      }

      // Save the font by deleting the text and saving the emtpy RTF
      noteTextBox_.Text = "";
      preferences.Note.Rtf = noteTextBox_.Rtf;
      return preferences;
    }

    /// <summary>
    /// Updates the synchronization form, disabling all elements if the
    /// checkbox option is not checked.
    /// </summary>
    private void UpdateSynchronizationEnabled() {
      amazonAccessKeyIdTextBox_.Enabled = synchronizeCheckBox_.Checked;
      amazonAccessKeyIdLabel_.Enabled = synchronizeCheckBox_.Checked;
      amazonSecretAccessKeyTextBox_.Enabled = synchronizeCheckBox_.Checked;
      amazonSecretAccessKeyLabel_.Enabled = synchronizeCheckBox_.Checked;
      synchronizationButton_.Enabled = amazonAccessKeyIdTextBox_.Text.Length > 0 && amazonSecretAccessKeyTextBox_.Text.Length > 0;
    }

    private void notePreferencesControl__NoteBackgroundColorChanged() {
      noteTextBox_.BackColor = notePreferencesControl_.NoteBackgroundColor;
    }

    private void notePreferencesControl__NoteBorderColorChanged() {
      notePanel_.BackColor = notePreferencesControl_.NoteBorderColor;
    }

    private void notePreferencesControl__NoteFontChanged() {
      noteTextBox_.Font = notePreferencesControl_.NoteFont;
    }

    private void notePreferencesControl__NoteFontColorChanged() {
      noteTextBox_.ForeColor = notePreferencesControl_.NoteFontColor;
    }

    private void iconBrowseButton__Click(object sender, EventArgs e) {
      iconFileDialog_.InitialDirectory = iconTextBox_.Text;
      iconFileDialog_.Title = String.Format(Messages.PreferencesIconFileDialog, Application.ProductName);
      if (iconFileDialog_.ShowDialog(this) == DialogResult.OK) {
        iconTextBox_.Text = iconFileDialog_.FileName;
      }
    }

    private void customIconCheckBox__CheckedChanged(object sender, EventArgs e) {
      iconTextBox_.Enabled = iconCheckBox_.Checked;
      iconBrowseButton_.Enabled = iconCheckBox_.Checked;
    }

    private void startOnWindowsCheckBox__CheckedChanged(object sender, EventArgs e) {
      Preferences.SetStartWithWindows(startOnWindowsCheckBox_.Checked);
    }

    private void EnableSynchronizationTest(object sender, EventArgs e) {
      UpdateSynchronizationEnabled();
    }

    private void spreadsheetsCheckBox__CheckedChanged(object sender, EventArgs e) {
      UpdateSynchronizationEnabled();
    }

    private void synchronizationButton__Click(object sender, EventArgs e) {
      synchronizationErrorLabel_.Text = "";
      TestSynchronizationOperation operation = new TestSynchronizationOperation(new SynchronizationSettings(amazonAccessKeyIdTextBox_.Text, amazonSecretAccessKeyTextBox_.Text));
      NetworkActivityDialog dialog = new NetworkActivityDialog(Messages.SynchronizationTesting, operation);
      if (dialog.ShowDialog(this) == DialogResult.OK) {
        if (operation.Exception != null) {
          synchronizationErrorLabel_.Text = operation.Exception.Message;
          synchronizationErrorLabel_.ForeColor = Color.DarkRed;
        } else {
          synchronizationErrorLabel_.Text = Messages.SynchronizationTestSuccess;
          synchronizationErrorLabel_.ForeColor = SystemColors.ControlText;
        }
      }
    }

    private void signUpLinkLabel__LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      System.Diagnostics.Process.Start(String.Format(Messages.SynchronizationInformationUrl, Application.ProductVersion));
    }
  }
}