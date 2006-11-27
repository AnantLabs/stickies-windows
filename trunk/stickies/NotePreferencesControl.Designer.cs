namespace Stickies {
  partial class NotePreferencesControl {
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.transparencyLabel_ = new System.Windows.Forms.Label();
      this.fontLabel_ = new System.Windows.Forms.Label();
      this.backgroundColorLabel_ = new System.Windows.Forms.Label();
      this.borderColorLabel_ = new System.Windows.Forms.Label();
      this.opaqueLabel_ = new System.Windows.Forms.Label();
      this.invisibleLabel_ = new System.Windows.Forms.Label();
      this.fontButton_ = new System.Windows.Forms.Button();
      this.backgroundColorButton_ = new System.Windows.Forms.Button();
      this.borderColorButton_ = new System.Windows.Forms.Button();
      this.transparencyBar_ = new System.Windows.Forms.TrackBar();
      this.fontPreviewLabel_ = new System.Windows.Forms.Label();
      this.backgroundColorPreviewPanel_ = new System.Windows.Forms.Panel();
      this.borderColorPreviewPanel_ = new System.Windows.Forms.Panel();
      this.colorDialog_ = new System.Windows.Forms.ColorDialog();
      this.fontDialog_ = new System.Windows.Forms.FontDialog();
      this.alwaysOnTopCheckBox_ = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize) (this.transparencyBar_)).BeginInit();
      this.SuspendLayout();
      // 
      // transparencyLabel_
      // 
      this.transparencyLabel_.AutoSize = true;
      this.transparencyLabel_.Location = new System.Drawing.Point(0, 116);
      this.transparencyLabel_.Name = "transparencyLabel_";
      this.transparencyLabel_.Size = new System.Drawing.Size(72, 13);
      this.transparencyLabel_.TabIndex = 23;
      this.transparencyLabel_.Text = "Transparency";
      // 
      // fontLabel_
      // 
      this.fontLabel_.AutoSize = true;
      this.fontLabel_.Location = new System.Drawing.Point(29, 60);
      this.fontLabel_.Name = "fontLabel_";
      this.fontLabel_.Size = new System.Drawing.Size(28, 13);
      this.fontLabel_.TabIndex = 19;
      this.fontLabel_.Text = "Font";
      // 
      // backgroundColorLabel_
      // 
      this.backgroundColorLabel_.AutoSize = true;
      this.backgroundColorLabel_.Location = new System.Drawing.Point(29, 34);
      this.backgroundColorLabel_.Name = "backgroundColorLabel_";
      this.backgroundColorLabel_.Size = new System.Drawing.Size(92, 13);
      this.backgroundColorLabel_.TabIndex = 16;
      this.backgroundColorLabel_.Text = "Background Color";
      // 
      // borderColorLabel_
      // 
      this.borderColorLabel_.AutoSize = true;
      this.borderColorLabel_.Location = new System.Drawing.Point(29, 8);
      this.borderColorLabel_.Name = "borderColorLabel_";
      this.borderColorLabel_.Size = new System.Drawing.Size(65, 13);
      this.borderColorLabel_.TabIndex = 14;
      this.borderColorLabel_.Text = "Border Color";
      // 
      // opaqueLabel_
      // 
      this.opaqueLabel_.AutoSize = true;
      this.opaqueLabel_.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
      this.opaqueLabel_.Location = new System.Drawing.Point(0, 155);
      this.opaqueLabel_.Name = "opaqueLabel_";
      this.opaqueLabel_.Size = new System.Drawing.Size(68, 13);
      this.opaqueLabel_.TabIndex = 25;
      this.opaqueLabel_.Text = "Opaque (0%)";
      // 
      // invisibleLabel_
      // 
      this.invisibleLabel_.AutoSize = true;
      this.invisibleLabel_.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
      this.invisibleLabel_.Location = new System.Drawing.Point(107, 155);
      this.invisibleLabel_.Name = "invisibleLabel_";
      this.invisibleLabel_.Size = new System.Drawing.Size(80, 13);
      this.invisibleLabel_.TabIndex = 24;
      this.invisibleLabel_.Text = "Invisible (100%)";
      // 
      // fontButton_
      // 
      this.fontButton_.Location = new System.Drawing.Point(127, 55);
      this.fontButton_.Name = "fontButton_";
      this.fontButton_.Size = new System.Drawing.Size(63, 23);
      this.fontButton_.TabIndex = 20;
      this.fontButton_.Text = "Change";
      this.fontButton_.UseVisualStyleBackColor = true;
      this.fontButton_.Click += new System.EventHandler(this.fontButton__Click);
      // 
      // backgroundColorButton_
      // 
      this.backgroundColorButton_.Location = new System.Drawing.Point(127, 29);
      this.backgroundColorButton_.Name = "backgroundColorButton_";
      this.backgroundColorButton_.Size = new System.Drawing.Size(63, 23);
      this.backgroundColorButton_.TabIndex = 18;
      this.backgroundColorButton_.Text = "Change";
      this.backgroundColorButton_.UseVisualStyleBackColor = true;
      this.backgroundColorButton_.Click += new System.EventHandler(this.backgroundColorButton__Click);
      // 
      // borderColorButton_
      // 
      this.borderColorButton_.Location = new System.Drawing.Point(127, 3);
      this.borderColorButton_.Name = "borderColorButton_";
      this.borderColorButton_.Size = new System.Drawing.Size(63, 23);
      this.borderColorButton_.TabIndex = 15;
      this.borderColorButton_.Text = "Change";
      this.borderColorButton_.UseVisualStyleBackColor = true;
      this.borderColorButton_.Click += new System.EventHandler(this.borderColorButton__Click);
      // 
      // transparencyBar_
      // 
      this.transparencyBar_.Location = new System.Drawing.Point(0, 132);
      this.transparencyBar_.Maximum = 100;
      this.transparencyBar_.Name = "transparencyBar_";
      this.transparencyBar_.Size = new System.Drawing.Size(187, 45);
      this.transparencyBar_.TabIndex = 22;
      this.transparencyBar_.TickFrequency = 10;
      this.transparencyBar_.TickStyle = System.Windows.Forms.TickStyle.None;
      this.transparencyBar_.ValueChanged += new System.EventHandler(this.transparencyBar__ValueChanged);
      // 
      // fontPreviewLabel_
      // 
      this.fontPreviewLabel_.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (192)))));
      this.fontPreviewLabel_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.fontPreviewLabel_.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.fontPreviewLabel_.Location = new System.Drawing.Point(3, 55);
      this.fontPreviewLabel_.Name = "fontPreviewLabel_";
      this.fontPreviewLabel_.Size = new System.Drawing.Size(20, 20);
      this.fontPreviewLabel_.TabIndex = 21;
      this.fontPreviewLabel_.Text = "A";
      this.fontPreviewLabel_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // backgroundColorPreviewPanel_
      // 
      this.backgroundColorPreviewPanel_.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (192)))));
      this.backgroundColorPreviewPanel_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.backgroundColorPreviewPanel_.Location = new System.Drawing.Point(3, 29);
      this.backgroundColorPreviewPanel_.Name = "backgroundColorPreviewPanel_";
      this.backgroundColorPreviewPanel_.Size = new System.Drawing.Size(20, 20);
      this.backgroundColorPreviewPanel_.TabIndex = 17;
      // 
      // borderColorPreviewPanel_
      // 
      this.borderColorPreviewPanel_.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
      this.borderColorPreviewPanel_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.borderColorPreviewPanel_.Location = new System.Drawing.Point(3, 3);
      this.borderColorPreviewPanel_.Name = "borderColorPreviewPanel_";
      this.borderColorPreviewPanel_.Size = new System.Drawing.Size(20, 20);
      this.borderColorPreviewPanel_.TabIndex = 13;
      // 
      // colorDialog_
      // 
      this.colorDialog_.AnyColor = true;
      this.colorDialog_.FullOpen = true;
      // 
      // fontDialog_
      // 
      this.fontDialog_.FontMustExist = true;
      this.fontDialog_.ShowColor = true;
      // 
      // alwaysOnTopCheckBox_
      // 
      this.alwaysOnTopCheckBox_.AutoSize = true;
      this.alwaysOnTopCheckBox_.Location = new System.Drawing.Point(3, 90);
      this.alwaysOnTopCheckBox_.Name = "alwaysOnTopCheckBox_";
      this.alwaysOnTopCheckBox_.Size = new System.Drawing.Size(178, 17);
      this.alwaysOnTopCheckBox_.TabIndex = 26;
      this.alwaysOnTopCheckBox_.Text = "Remain on top of other windows";
      this.alwaysOnTopCheckBox_.UseVisualStyleBackColor = true;
      this.alwaysOnTopCheckBox_.CheckedChanged += new System.EventHandler(this.alwaysOnTopCheckBox__CheckedChanged);
      // 
      // NotePreferencesControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.Controls.Add(this.alwaysOnTopCheckBox_);
      this.Controls.Add(this.opaqueLabel_);
      this.Controls.Add(this.invisibleLabel_);
      this.Controls.Add(this.transparencyLabel_);
      this.Controls.Add(this.transparencyBar_);
      this.Controls.Add(this.fontPreviewLabel_);
      this.Controls.Add(this.fontButton_);
      this.Controls.Add(this.backgroundColorPreviewPanel_);
      this.Controls.Add(this.fontLabel_);
      this.Controls.Add(this.backgroundColorButton_);
      this.Controls.Add(this.borderColorPreviewPanel_);
      this.Controls.Add(this.backgroundColorLabel_);
      this.Controls.Add(this.borderColorButton_);
      this.Controls.Add(this.borderColorLabel_);
      this.Name = "NotePreferencesControl";
      this.Size = new System.Drawing.Size(192, 176);
      ((System.ComponentModel.ISupportInitialize) (this.transparencyBar_)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label fontPreviewLabel_;
    private System.Windows.Forms.Panel backgroundColorPreviewPanel_;
    private System.Windows.Forms.Panel borderColorPreviewPanel_;
    private System.Windows.Forms.ColorDialog colorDialog_;
    private System.Windows.Forms.FontDialog fontDialog_;
    private System.Windows.Forms.TrackBar transparencyBar_;
    private System.Windows.Forms.CheckBox alwaysOnTopCheckBox_;
    private System.Windows.Forms.Label transparencyLabel_;
    private System.Windows.Forms.Label fontLabel_;
    private System.Windows.Forms.Label backgroundColorLabel_;
    private System.Windows.Forms.Label borderColorLabel_;
    private System.Windows.Forms.Label opaqueLabel_;
    private System.Windows.Forms.Label invisibleLabel_;
    private System.Windows.Forms.Button fontButton_;
    private System.Windows.Forms.Button backgroundColorButton_;
    private System.Windows.Forms.Button borderColorButton_;

  }
}
