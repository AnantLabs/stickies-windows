namespace Stickies {
  partial class NoteSettingsDialog {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteSettingsDialog));
      this.notePreferencesControl_ = new Stickies.NotePreferencesControl();
      this.SuspendLayout();
      // 
      // notePreferencesControl_
      // 
      this.notePreferencesControl_.BackColor = System.Drawing.Color.Transparent;
      this.notePreferencesControl_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.notePreferencesControl_.Location = new System.Drawing.Point(10, 10);
      this.notePreferencesControl_.Name = "notePreferencesControl_";
      this.notePreferencesControl_.NoteBackgroundColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (192)))));
      this.notePreferencesControl_.NoteBorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
      this.notePreferencesControl_.NoteFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.notePreferencesControl_.NoteFontColor = System.Drawing.SystemColors.ControlText;
      this.notePreferencesControl_.NoteTransparency = 0;
      this.notePreferencesControl_.Size = new System.Drawing.Size(190, 154);
      this.notePreferencesControl_.TabIndex = 0;
      // 
      // NoteSettingsDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(210, 174);
      this.Controls.Add(this.notePreferencesControl_);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "NoteSettingsDialog";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);

    }

    #endregion

    private NotePreferencesControl notePreferencesControl_;
  }
}