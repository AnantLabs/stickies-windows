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
      this.buttonPanel_ = new System.Windows.Forms.Panel();
      this.cancelButton_ = new System.Windows.Forms.Button();
      this.saveButton_ = new System.Windows.Forms.Button();
      this.tabControl_ = new System.Windows.Forms.TabControl();
      this.appearanceTabPage_ = new System.Windows.Forms.TabPage();
      this.settingsPanel_ = new System.Windows.Forms.Panel();
      this.notePreferencesControl_ = new Stickies.NotePreferencesControl();
      this.noteContainerPanel_ = new System.Windows.Forms.Panel();
      this.notePanel_ = new System.Windows.Forms.Panel();
      this.noteTextBox_ = new System.Windows.Forms.RichTextBox();
      this.buttonPanel_.SuspendLayout();
      this.tabControl_.SuspendLayout();
      this.appearanceTabPage_.SuspendLayout();
      this.settingsPanel_.SuspendLayout();
      this.noteContainerPanel_.SuspendLayout();
      this.notePanel_.SuspendLayout();
      this.SuspendLayout();
      // 
      // buttonPanel_
      // 
      this.buttonPanel_.Controls.Add(this.cancelButton_);
      this.buttonPanel_.Controls.Add(this.saveButton_);
      this.buttonPanel_.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.buttonPanel_.Location = new System.Drawing.Point(5, 226);
      this.buttonPanel_.Name = "buttonPanel_";
      this.buttonPanel_.Size = new System.Drawing.Size(408, 31);
      this.buttonPanel_.TabIndex = 1;
      // 
      // cancelButton_
      // 
      this.cancelButton_.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton_.Location = new System.Drawing.Point(216, 3);
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
      this.saveButton_.Location = new System.Drawing.Point(313, 3);
      this.saveButton_.Name = "saveButton_";
      this.saveButton_.Size = new System.Drawing.Size(91, 23);
      this.saveButton_.TabIndex = 0;
      this.saveButton_.Text = "Save Changes";
      this.saveButton_.UseVisualStyleBackColor = true;
      // 
      // tabControl_
      // 
      this.tabControl_.Controls.Add(this.appearanceTabPage_);
      this.tabControl_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl_.Location = new System.Drawing.Point(5, 5);
      this.tabControl_.Name = "tabControl_";
      this.tabControl_.SelectedIndex = 0;
      this.tabControl_.Size = new System.Drawing.Size(408, 221);
      this.tabControl_.TabIndex = 2;
      // 
      // appearanceTabPage_
      // 
      this.appearanceTabPage_.Controls.Add(this.settingsPanel_);
      this.appearanceTabPage_.Controls.Add(this.noteContainerPanel_);
      this.appearanceTabPage_.Location = new System.Drawing.Point(4, 22);
      this.appearanceTabPage_.Name = "appearanceTabPage_";
      this.appearanceTabPage_.Padding = new System.Windows.Forms.Padding(10);
      this.appearanceTabPage_.Size = new System.Drawing.Size(400, 195);
      this.appearanceTabPage_.TabIndex = 0;
      this.appearanceTabPage_.Text = "Note Appearance";
      this.appearanceTabPage_.UseVisualStyleBackColor = true;
      // 
      // settingsPanel_
      // 
      this.settingsPanel_.Controls.Add(this.notePreferencesControl_);
      this.settingsPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.settingsPanel_.Location = new System.Drawing.Point(184, 10);
      this.settingsPanel_.Name = "settingsPanel_";
      this.settingsPanel_.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
      this.settingsPanel_.Size = new System.Drawing.Size(206, 175);
      this.settingsPanel_.TabIndex = 1;
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
      this.notePreferencesControl_.Size = new System.Drawing.Size(196, 155);
      this.notePreferencesControl_.TabIndex = 0;
      this.notePreferencesControl_.NoteFontChanged += new Stickies.NotePreferencesControl.NotePreferencesHandler(this.notePreferencesControl__NoteFontChanged);
      this.notePreferencesControl_.NoteBackgroundColorChanged += new Stickies.NotePreferencesControl.NotePreferencesHandler(this.notePreferencesControl__NoteBackgroundColorChanged);
      this.notePreferencesControl_.NoteFontColorChanged += new Stickies.NotePreferencesControl.NotePreferencesHandler(this.notePreferencesControl__NoteFontColorChanged);
      this.notePreferencesControl_.NoteBorderColorChanged += new Stickies.NotePreferencesControl.NotePreferencesHandler(this.notePreferencesControl__NoteBorderColorChanged);
      // 
      // noteContainerPanel_
      // 
      this.noteContainerPanel_.Controls.Add(this.notePanel_);
      this.noteContainerPanel_.Dock = System.Windows.Forms.DockStyle.Left;
      this.noteContainerPanel_.Location = new System.Drawing.Point(10, 10);
      this.noteContainerPanel_.Name = "noteContainerPanel_";
      this.noteContainerPanel_.Size = new System.Drawing.Size(174, 175);
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
      this.notePanel_.Size = new System.Drawing.Size(174, 175);
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
      this.noteTextBox_.Size = new System.Drawing.Size(170, 162);
      this.noteTextBox_.TabIndex = 2;
      this.noteTextBox_.Text = "";
      // 
      // PreferencesDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(418, 262);
      this.Controls.Add(this.tabControl_);
      this.Controls.Add(this.buttonPanel_);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PreferencesDialog";
      this.Padding = new System.Windows.Forms.Padding(5);
      this.buttonPanel_.ResumeLayout(false);
      this.tabControl_.ResumeLayout(false);
      this.appearanceTabPage_.ResumeLayout(false);
      this.settingsPanel_.ResumeLayout(false);
      this.noteContainerPanel_.ResumeLayout(false);
      this.notePanel_.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel buttonPanel_;
    private System.Windows.Forms.Button saveButton_;
    private System.Windows.Forms.TabControl tabControl_;
    private System.Windows.Forms.TabPage appearanceTabPage_;
    private System.Windows.Forms.Button cancelButton_;
    private System.Windows.Forms.Panel noteContainerPanel_;
    private System.Windows.Forms.Panel notePanel_;
    private System.Windows.Forms.RichTextBox noteTextBox_;
    private System.Windows.Forms.Panel settingsPanel_;
    private NotePreferencesControl notePreferencesControl_;
  }
}