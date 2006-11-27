namespace Stickies {
  partial class PreferencesDialog {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesDialog));
      this.startOnWindowsCheckBox_ = new System.Windows.Forms.CheckBox();
      this.appearanceTabPage_ = new System.Windows.Forms.TabPage();
      this.settingsPanel_ = new System.Windows.Forms.Panel();
      this.notePreferencesControl_ = new Stickies.NotePreferencesControl();
      this.noteContainerPanel_ = new System.Windows.Forms.Panel();
      this.notePanel_ = new System.Windows.Forms.Panel();
      this.noteTextBox_ = new System.Windows.Forms.RichTextBox();
      this.iconCheckBox_ = new System.Windows.Forms.CheckBox();
      this.iconBrowseButton_ = new System.Windows.Forms.Button();
      this.buttonPanel_ = new System.Windows.Forms.Panel();
      this.cancelButton_ = new System.Windows.Forms.Button();
      this.saveButton_ = new System.Windows.Forms.Button();
      this.tabControl_ = new System.Windows.Forms.TabControl();
      this.settingsTabPage_ = new System.Windows.Forms.TabPage();
      this.iconTextBox_ = new System.Windows.Forms.TextBox();
      this.iconFileDialog_ = new System.Windows.Forms.OpenFileDialog();
      this.appearanceTabPage_.SuspendLayout();
      this.settingsPanel_.SuspendLayout();
      this.noteContainerPanel_.SuspendLayout();
      this.notePanel_.SuspendLayout();
      this.buttonPanel_.SuspendLayout();
      this.tabControl_.SuspendLayout();
      this.settingsTabPage_.SuspendLayout();
      this.SuspendLayout();
      // 
      // startOnWindowsCheckBox_
      // 
      this.startOnWindowsCheckBox_.AutoSize = true;
      this.startOnWindowsCheckBox_.Location = new System.Drawing.Point(21, 19);
      this.startOnWindowsCheckBox_.Name = "startOnWindowsCheckBox_";
      this.startOnWindowsCheckBox_.Size = new System.Drawing.Size(192, 17);
      this.startOnWindowsCheckBox_.TabIndex = 0;
      this.startOnWindowsCheckBox_.Text = "Start Stickies when Windows starts";
      this.startOnWindowsCheckBox_.UseVisualStyleBackColor = true;
      this.startOnWindowsCheckBox_.CheckedChanged += new System.EventHandler(this.startOnWindowsCheckBox__CheckedChanged);
      // 
      // appearanceTabPage_
      // 
      this.appearanceTabPage_.Controls.Add(this.settingsPanel_);
      this.appearanceTabPage_.Controls.Add(this.noteContainerPanel_);
      this.appearanceTabPage_.Location = new System.Drawing.Point(4, 22);
      this.appearanceTabPage_.Name = "appearanceTabPage_";
      this.appearanceTabPage_.Padding = new System.Windows.Forms.Padding(10);
      this.appearanceTabPage_.Size = new System.Drawing.Size(411, 210);
      this.appearanceTabPage_.TabIndex = 0;
      this.appearanceTabPage_.Text = "Note Appearance";
      this.appearanceTabPage_.UseVisualStyleBackColor = true;
      // 
      // settingsPanel_
      // 
      this.settingsPanel_.Controls.Add(this.notePreferencesControl_);
      this.settingsPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.settingsPanel_.Location = new System.Drawing.Point(199, 10);
      this.settingsPanel_.Name = "settingsPanel_";
      this.settingsPanel_.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
      this.settingsPanel_.Size = new System.Drawing.Size(202, 190);
      this.settingsPanel_.TabIndex = 1;
      // 
      // notePreferencesControl_
      // 
      this.notePreferencesControl_.BackColor = System.Drawing.Color.Transparent;
      this.notePreferencesControl_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.notePreferencesControl_.Location = new System.Drawing.Point(10, 10);
      this.notePreferencesControl_.Name = "notePreferencesControl_";
      this.notePreferencesControl_.NoteAlwaysOnTop = false;
      this.notePreferencesControl_.NoteBackgroundColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (192)))));
      this.notePreferencesControl_.NoteBorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
      this.notePreferencesControl_.NoteFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.notePreferencesControl_.NoteFontColor = System.Drawing.SystemColors.ControlText;
      this.notePreferencesControl_.NoteTransparency = 0;
      this.notePreferencesControl_.Size = new System.Drawing.Size(192, 170);
      this.notePreferencesControl_.SliderBarBackColor = System.Drawing.SystemColors.Control;
      this.notePreferencesControl_.TabIndex = 0;
      this.notePreferencesControl_.NoteFontColorChanged += new Stickies.NotePreferencesControl.NotePreferencesHandler(this.notePreferencesControl__NoteFontColorChanged);
      this.notePreferencesControl_.NoteBackgroundColorChanged += new Stickies.NotePreferencesControl.NotePreferencesHandler(this.notePreferencesControl__NoteBackgroundColorChanged);
      this.notePreferencesControl_.NoteBorderColorChanged += new Stickies.NotePreferencesControl.NotePreferencesHandler(this.notePreferencesControl__NoteBorderColorChanged);
      this.notePreferencesControl_.NoteFontChanged += new Stickies.NotePreferencesControl.NotePreferencesHandler(this.notePreferencesControl__NoteFontChanged);
      // 
      // noteContainerPanel_
      // 
      this.noteContainerPanel_.Controls.Add(this.notePanel_);
      this.noteContainerPanel_.Dock = System.Windows.Forms.DockStyle.Left;
      this.noteContainerPanel_.Location = new System.Drawing.Point(10, 10);
      this.noteContainerPanel_.Name = "noteContainerPanel_";
      this.noteContainerPanel_.Size = new System.Drawing.Size(189, 190);
      this.noteContainerPanel_.TabIndex = 0;
      // 
      // notePanel_
      // 
      this.notePanel_.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
      this.notePanel_.Controls.Add(this.noteTextBox_);
      this.notePanel_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.notePanel_.Location = new System.Drawing.Point(0, 0);
      this.notePanel_.Name = "notePanel_";
      this.notePanel_.Padding = new System.Windows.Forms.Padding(2, 11, 2, 2);
      this.notePanel_.Size = new System.Drawing.Size(189, 190);
      this.notePanel_.TabIndex = 1;
      // 
      // noteTextBox_
      // 
      this.noteTextBox_.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (192)))));
      this.noteTextBox_.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.noteTextBox_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.noteTextBox_.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.noteTextBox_.Location = new System.Drawing.Point(2, 11);
      this.noteTextBox_.Name = "noteTextBox_";
      this.noteTextBox_.Size = new System.Drawing.Size(185, 177);
      this.noteTextBox_.TabIndex = 2;
      // 
      // iconCheckBox_
      // 
      this.iconCheckBox_.AutoSize = true;
      this.iconCheckBox_.Location = new System.Drawing.Point(21, 42);
      this.iconCheckBox_.Name = "iconCheckBox_";
      this.iconCheckBox_.Size = new System.Drawing.Size(253, 17);
      this.iconCheckBox_.TabIndex = 1;
      this.iconCheckBox_.Text = "Use a custom icon for Stickies in the system tray";
      this.iconCheckBox_.UseVisualStyleBackColor = true;
      this.iconCheckBox_.CheckedChanged += new System.EventHandler(this.customIconCheckBox__CheckedChanged);
      // 
      // iconBrowseButton_
      // 
      this.iconBrowseButton_.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.iconBrowseButton_.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.iconBrowseButton_.Location = new System.Drawing.Point(309, 63);
      this.iconBrowseButton_.Name = "iconBrowseButton_";
      this.iconBrowseButton_.Size = new System.Drawing.Size(69, 23);
      this.iconBrowseButton_.TabIndex = 3;
      this.iconBrowseButton_.Text = "Browse";
      this.iconBrowseButton_.UseVisualStyleBackColor = true;
      this.iconBrowseButton_.Click += new System.EventHandler(this.iconBrowseButton__Click);
      // 
      // buttonPanel_
      // 
      this.buttonPanel_.Controls.Add(this.cancelButton_);
      this.buttonPanel_.Controls.Add(this.saveButton_);
      this.buttonPanel_.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.buttonPanel_.Location = new System.Drawing.Point(5, 241);
      this.buttonPanel_.Name = "buttonPanel_";
      this.buttonPanel_.Size = new System.Drawing.Size(419, 31);
      this.buttonPanel_.TabIndex = 1;
      // 
      // cancelButton_
      // 
      this.cancelButton_.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton_.Location = new System.Drawing.Point(227, 3);
      this.cancelButton_.Name = "cancelButton_";
      this.cancelButton_.Size = new System.Drawing.Size(91, 23);
      this.cancelButton_.TabIndex = 1;
      this.cancelButton_.Text = "Cancel";
      this.cancelButton_.UseVisualStyleBackColor = true;
      // 
      // saveButton_
      // 
      this.saveButton_.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.saveButton_.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.saveButton_.Location = new System.Drawing.Point(324, 3);
      this.saveButton_.Name = "saveButton_";
      this.saveButton_.Size = new System.Drawing.Size(91, 23);
      this.saveButton_.TabIndex = 0;
      this.saveButton_.Text = "Save Changes";
      this.saveButton_.UseVisualStyleBackColor = true;
      // 
      // tabControl_
      // 
      this.tabControl_.Controls.Add(this.appearanceTabPage_);
      this.tabControl_.Controls.Add(this.settingsTabPage_);
      this.tabControl_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl_.Location = new System.Drawing.Point(5, 5);
      this.tabControl_.Name = "tabControl_";
      this.tabControl_.SelectedIndex = 0;
      this.tabControl_.Size = new System.Drawing.Size(419, 236);
      this.tabControl_.TabIndex = 2;
      // 
      // settingsTabPage_
      // 
      this.settingsTabPage_.Controls.Add(this.iconBrowseButton_);
      this.settingsTabPage_.Controls.Add(this.iconTextBox_);
      this.settingsTabPage_.Controls.Add(this.iconCheckBox_);
      this.settingsTabPage_.Controls.Add(this.startOnWindowsCheckBox_);
      this.settingsTabPage_.Location = new System.Drawing.Point(4, 22);
      this.settingsTabPage_.Name = "settingsTabPage_";
      this.settingsTabPage_.Size = new System.Drawing.Size(411, 210);
      this.settingsTabPage_.TabIndex = 1;
      this.settingsTabPage_.Text = "Application Options";
      this.settingsTabPage_.UseVisualStyleBackColor = true;
      // 
      // iconTextBox_
      // 
      this.iconTextBox_.Location = new System.Drawing.Point(40, 65);
      this.iconTextBox_.Name = "iconTextBox_";
      this.iconTextBox_.Size = new System.Drawing.Size(263, 20);
      this.iconTextBox_.TabIndex = 2;
      // 
      // iconFileDialog_
      // 
      this.iconFileDialog_.DefaultExt = "ico";
      this.iconFileDialog_.Filter = "Icon Files (*.ico)|*.ico|All Files (*.*)|*.*";
      // 
      // PreferencesDialog
      // 
      this.AcceptButton = this.saveButton_;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton_;
      this.ClientSize = new System.Drawing.Size(429, 277);
      this.Controls.Add(this.tabControl_);
      this.Controls.Add(this.buttonPanel_);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PreferencesDialog";
      this.Padding = new System.Windows.Forms.Padding(5);
      this.appearanceTabPage_.ResumeLayout(false);
      this.settingsPanel_.ResumeLayout(false);
      this.noteContainerPanel_.ResumeLayout(false);
      this.notePanel_.ResumeLayout(false);
      this.buttonPanel_.ResumeLayout(false);
      this.tabControl_.ResumeLayout(false);
      this.settingsTabPage_.ResumeLayout(false);
      this.settingsTabPage_.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel buttonPanel_;
    private System.Windows.Forms.Button saveButton_;
    private System.Windows.Forms.TabControl tabControl_;
    private System.Windows.Forms.Button cancelButton_;
    private System.Windows.Forms.Panel noteContainerPanel_;
    private System.Windows.Forms.Panel notePanel_;
    private System.Windows.Forms.RichTextBox noteTextBox_;
    private System.Windows.Forms.Panel settingsPanel_;
    private NotePreferencesControl notePreferencesControl_;
    private System.Windows.Forms.TabPage settingsTabPage_;
    private System.Windows.Forms.TextBox iconTextBox_;
    private System.Windows.Forms.OpenFileDialog iconFileDialog_;
    private System.Windows.Forms.CheckBox iconCheckBox_;
    private System.Windows.Forms.Button iconBrowseButton_;
    private System.Windows.Forms.TabPage appearanceTabPage_;
    private System.Windows.Forms.CheckBox startOnWindowsCheckBox_;
  }
}