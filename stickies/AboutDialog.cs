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
  /// Our About dialog page that displays the Stickies logo, the version number
  /// of the application, and random stuff like copyright information.
  /// </summary>
  public partial class AboutDialog : ContainedForm {
    public AboutDialog() {
      InitializeComponent();
      this.Text = String.Format(Messages.AboutTitle, Application.ProductName);
      closeButton_.Text = Messages.AboutClose;
      versionLabel_.Text = String.Format(Messages.AboutVersion, Application.ProductVersion);
      authorLabel_.Text = Messages.AboutAuthor;
      licenseLabel_.Text = Messages.AboutLicense;
      linkLabel_.Text = Messages.AboutLink;

      // Start the preferences dialog under the mouse cursor. Since we are
      // a ContainedControl, this will work correctly even if the mouse is
      // near the edge of the screen.
      this.StartPosition = FormStartPosition.Manual;
      this.Location = Control.MousePosition;
    }

    /// <summary>
    /// Launches the default web browser to view the URL in the label.
    /// </summary>
    private void linkLabel__LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      System.Diagnostics.Process.Start(linkLabel_.Text);
    }
  }
}