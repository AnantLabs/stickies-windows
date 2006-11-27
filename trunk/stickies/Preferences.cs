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

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Stickies {
  /// <summary>
  /// Serializable struct representing Stickies preferences.
  /// </summary>
  public class Preferences : Settings {
    /// <summary>
    /// The default note settings.
    /// </summary>
    [XmlElement("DefaultNoteSettings")]
    public Note Note;

    /// <summary>
    /// The custom tray icon path, if any.
    /// </summary>
    public string TrayIconPath;

    /// <summary>
    /// The Windows registry location that lists the applications that start
    /// automatically when Windows starts.
    /// </summary>
    private const string kWindowsStartAppsRegistry = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

    /// <summary>
    /// Creates a new set of preferences with the default settings.
    /// </summary>
    public Preferences()
      : base() {
      this.Note = new Note();
    }

    /// <summary>
    /// Returns the path to the Stickies preferences file.
    /// </summary>
    public override string GetPath() {
      return SettingsPath(Path);
    }

    /// <summary>
    /// Loads a Preferences instance from the Stickies preferences file.
    /// </summary>
    /// <returns></returns>
    public static Preferences Load() {
      return (Preferences) Settings.Load(SettingsPath(Path), typeof(Preferences));
    }

    /// <summary>
    /// Returns true if there is a registry entry that makes Stickies start
    /// when Windows starts.
    /// </summary>
    static public bool StartWithWindows() {
      try {
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(kWindowsStartAppsRegistry)) {
          if (key != null) {
            string value = (string) key.GetValue(Application.ProductName);
            return (value != null && value.Length > 0);
          }
        }
      } catch (Exception e) {
        System.Diagnostics.Debug.WriteLine("Registry get error: " + e.Message);
      }
      return false;
    }

    /// <summary>
    /// Sets or deletes the registry value that makes Stickies start when
    /// Windows starts.
    /// </summary>
    static public void SetStartWithWindows(bool startWithWindows) {
      using (RegistryKey key = Registry.CurrentUser.OpenSubKey(kWindowsStartAppsRegistry, true)) {
        if (key != null) {
          try {
            if (startWithWindows) {
              key.SetValue(Application.ProductName, Application.ExecutablePath);
            } else {
              key.SetValue(Application.ProductName, "");
            }
          } catch (Exception e) {
            System.Diagnostics.Debug.WriteLine("Registry set error: " + e.Message);
          }
        }
      }
    }

    /// <summary>
    /// The path to the Stickies preferences file, relative to the application
    /// settings directory.
    /// </summary>
    public const string Path = "preferences.xml";
  }
}