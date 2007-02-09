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
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.Windows.Forms;

namespace Stickies {
  /// <summary>
  /// Abstract base class for all serializable structures that we use to store
  /// the state of Stickies between sessions. All of the settings and
  /// configuration files we save on disk are subclasses of this class. We
  /// serialize the classes using XmlSerializer so they can be easily read and
  /// edited by end users.
  /// </summary>
  public abstract class Settings {
    /// <summary>
    /// The version of Stickies from which this set of Settings was saved.
    /// </summary>
    [XmlAttribute("version")]
    public string Version;

    /// <summary>
    /// The time at which this set of Settings was created.
    /// </summary>
    [XmlAttribute("created")]
    public DateTime Created;

    /// <summary>
    /// The time at which this set of Settings was last saved.
    /// </summary>
    [XmlAttribute("modified")]
    public DateTime Modified;

    /// <summary>
    /// Initializes this Settings instance by copying over the default values
    /// of all fields.
    /// </summary>
    public Settings() {
      // Store the product version as the XML version
      this.Version = Application.ProductVersion;
      this.Created = DateTime.Now;
      this.Modified = this.Created;

      // Load the default values for all the fields so that this structure
      // will have the default values even if it is not loaded from disk
      foreach (FieldInfo field in this.GetType().GetFields()) {
        DefaultValueAttribute defaultValue = (DefaultValueAttribute)
          Attribute.GetCustomAttribute(field, typeof(DefaultValueAttribute));
        if (defaultValue != null) {
          field.SetValue(this, defaultValue.Value);
        }
      }
    }

    /// <summary>
    /// Returns a copy of this Settings instance.
    /// </summary>
    public Settings Copy() {
      ConstructorInfo constructor = this.GetType().GetConstructor(new Type[0]);
      Settings copy = (Settings) constructor.Invoke(new object[0]);
      foreach (FieldInfo field in this.GetType().GetFields()) {
        if (!field.IsLiteral) {
          field.SetValue(copy, field.GetValue(this));
        }
      }
      return copy;
    }

    /// <summary>
    /// Loads the Settings struct from the file at the given path for the
    /// given Settings type.
    /// </summary>
    public static Settings Load(string path, Type type) {
      using (Stream stream = File.OpenRead(path)) {
        XmlSerializer serializer = new XmlSerializer(type, XmlNamespace);
        return (Settings) serializer.Deserialize(stream);
      }
    }

    /// <summary>
    /// Returns the hard disk path for this Settings struct. This is the path
    /// we save to when the Save() method is called.
    /// </summary>
    public abstract string GetPath();

    /// <summary>
    /// Saves this Settings struct to the path returned by GetPath().
    /// </summary>
    public void Save() {
      System.Diagnostics.Debug.WriteLine("Saving " + GetPath());
      RecursiveCreateDirectory(new DirectoryInfo(SettingsDirectory()));
      using (Stream stream = File.Open(GetPath(), FileMode.Create, FileAccess.Write)) {
        XmlSerializer serializer = new XmlSerializer(this.GetType(), XmlNamespace);
        DateTime oldLastSaved = this.Modified;
        this.Modified = DateTime.Now;
        try {
          serializer.Serialize(stream, this);
        } catch (Exception) {
          this.Modified = oldLastSaved;
          throw;
        }
      }
    }

    /// <summary>
    /// Recursively creates the given directory.
    /// </summary>
    private void RecursiveCreateDirectory(DirectoryInfo directory) {
      if (!directory.Exists) {
        RecursiveCreateDirectory(directory.Parent);
        directory.Create();
      }
    }

    /// <summary>
    /// Deletes the file on disk associated with this Settings struct, i.e.,
    /// the file returned by GetPath().
    /// </summary>
    public void Delete() {
      File.Delete(this.GetPath());
    }

    /// <summary>
    /// Returns the path to the application settings directory. All settings
    /// files should be stored within this directory or children of this
    /// directory.
    /// </summary>
    public static string SettingsDirectory() {
      string directory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
      return Path.Combine(Path.Combine(directory, Application.CompanyName), Application.ProductName);
    }

    /// <summary>
    /// Returns the full path for the settings file with the given name.
    /// </summary>
    public static string SettingsPath(string fileName) {
      return Path.Combine(SettingsDirectory(), fileName);
    }

    /// <summary>
    /// The XML namespace that we use in our serialized settings files.
    /// </summary>
    public const string XmlNamespace = "http://schemas.stickiesforwindows.com/V3";
  }
}