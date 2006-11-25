using System;
using System.Collections.Generic;
using System.Text;

namespace Stickies {
  /// <summary>
  /// Structure returned by the Stickies web server with information on the
  /// most recent version of the Stickies application available for download.
  /// </summary>
  public class VersionInfo {
    /// <summary>
    /// The most recent version of the Stickies application available for
    /// download.
    /// </summary>
    public string CurrentVersion;

    /// <summary>
    /// The message we should display to the end user if their version of
    /// the product is older than the current version.
    /// </summary>
    public string UpdateMessage;

    /// <summary>
    /// The URL the user should visit to download the new version of the
    /// product.
    /// </summary>
    public string UpdateUrl;
  }
}
