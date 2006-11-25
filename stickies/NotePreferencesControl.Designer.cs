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
      System.Windows.Forms.Label transparencyLabel_;
      System.Windows.Forms.Label fontLabel_;
      System.Windows.Forms.Label backgroundColorLabel_;
      System.Windows.Forms.Label borderColorLabel_;
      System.Windows.Forms.Label opaqueLabel_;
      System.Windows.Forms.Label invisibleLabel_;
      System.Windows.Forms.Button fontButton_;
      System.Windows.Forms.Button backgroundColorButton_;
      System.Windows.Forms.Button borderColorButton_;
      this.transparencyBar_ = new System.Windows.Forms.TrackBar();
      this.fontPreviewLabel_ = new System.Windows.Forms.Label();
      this.backgroundColorPreviewPanel_ = new System.Windows.Forms.Panel();
      this.borderColorPreviewPanel_ = new System.Windows.Forms.Panel();
      this.colorDialog_ = new System.Windows.Forms.ColorDialog();
      this.fontDialog_ = new System.Windows.Forms.FontDialog();
      transparencyLabel_ = new System.Windows.Forms.Label();
      fontLabel_ = new System.Windows.Forms.Label();
      backgroundColorLabel_ = new System.Windows.Forms.Label();
      borderColorLabel_ = new System.Windows.Forms.Label();
      opaqueLabel_ = new System.Windows.Forms.Label();
      invisibleLabel_ = new System.Windows.Forms.Label();
      fontButton_ = new System.Windows.Forms.Button();
      backgroundColorButton_ = new System.Windows.Forms.Button();
      borderColorButton_ = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize) (this.transparencyBar_)).BeginInit();
      this.SuspendLayout();
      // 
      // transparencyLabel_
      // 
      transparencyLabel_.AutoSize = true;
      transparencyLabel_.Location = new System.Drawing.Point(3, 93);
      transparencyLabel_.Name = "transparencyLabel_";
      transparencyLabel_.Size = new System.Drawing.Size(72, 13);
      transparencyLabel_.TabIndex = 23;
      transparencyLabel_.Text = "Transparency";
      // 
      // fontLabel_
      // 
      fontLabel_.AutoSize = true;
      fontLabel_.Location = new System.Drawing.Point(29, 60);
      fontLabel_.Name = "fontLabel_";
      fontLabel_.Size = new System.Drawing.Size(28, 13);
      fontLabel_.TabIndex = 19;
      fontLabel_.Text = "Font";
      // 
      // backgroundColorLabel_
      // 
      backgroundColorLabel_.AutoSize = true;
      backgroundColorLabel_.Location = new System.Drawing.Point(29, 34);
      backgroundColorLabel_.Name = "backgroundColorLabel_";
      backgroundColorLabel_.Size = new System.Drawing.Size(92, 13);
      backgroundColorLabel_.TabIndex = 16;
      backgroundColorLabel_.Text = "Background Color";
      // 
      // borderColorLabel_
      // 
      borderColorLabel_.AutoSize = true;
      borderColorLabel_.Location = new System.Drawing.Point(29, 8);
      borderColorLabel_.Name = "borderColorLabel_";
      borderColorLabel_.Size = new System.Drawing.Size(65, 13);
      borderColorLabel_.TabIndex = 14;
      borderColorLabel_.Text = "Border Color";
      // 
      // opaqueLabel_
      // 
      opaqueLabel_.AutoSize = true;
      opaqueLabel_.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
      opaqueLabel_.Location = new System.Drawing.Point(3, 132);
      opaqueLabel_.Name = "opaqueLabel_";
      opaqueLabel_.Size = new System.Drawing.Size(68, 13);
      opaqueLabel_.TabIndex = 25;
      opaqueLabel_.Text = "Opaque (0%)";
      // 
      // invisibleLabel_
      // 
      invisibleLabel_.AutoSize = true;
      invisibleLabel_.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
      invisibleLabel_.Location = new System.Drawing.Point(110, 132);
      invisibleLabel_.Name = "invisibleLabel_";
      invisibleLabel_.Size = new System.Drawing.Size(80, 13);
      invisibleLabel_.TabIndex = 24;
      invisibleLabel_.Text = "Invisible (100%)";
      // 
      // fontButton_
      // 
      fontButton_.Location = new System.Drawing.Point(127, 55);
      fontButton_.Name = "fontButton_";
      fontButton_.Size = new System.Drawing.Size(63, 23);
      fontButton_.TabIndex = 20;
      fontButton_.Text = "Change";
      fontButton_.UseVisualStyleBackColor = true;
      fontButton_.Click += new System.EventHandler(this.fontButton__Click);
      // 
      // backgroundColorButton_
      // 
      backgroundColorButton_.Location = new System.Drawing.Point(127, 29);
      backgroundColorButton_.Name = "backgroundColorButton_";
      backgroundColorButton_.Size = new System.Drawing.Size(63, 23);
      backgroundColorButton_.TabIndex = 18;
      backgroundColorButton_.Text = "Change";
      backgroundColorButton_.UseVisualStyleBackColor = true;
      backgroundColorButton_.Click += new System.EventHandler(this.backgroundColorButton__Click);
      // 
      // borderColorButton_
      // 
      borderColorButton_.Location = new System.Drawing.Point(127, 3);
      borderColorButton_.Name = "borderColorButton_";
      borderColorButton_.Size = new System.Drawing.Size(63, 23);
      borderColorButton_.TabIndex = 15;
      borderColorButton_.Text = "Change";
      borderColorButton_.UseVisualStyleBackColor = true;
      borderColorButton_.Click += new System.EventHandler(this.borderColorButton__Click);
      // 
      // transparencyBar_
      // 
      this.transparencyBar_.Location = new System.Drawing.Point(3, 109);
      this.transparencyBar_.Maximum = 100;
      this.transparencyBar_.Name = "transparencyBar_";
      this.transparencyBar_.Size = new System.Drawing.Size(187, 45);
      this.transparencyBar_.TabIndex = 22;
      this.transparencyBar_.TickFrequency = 10;
      this.transparencyBar_.TickStyle = System.Windows.Forms.TickStyle.None;
      this.transparencyBar_.Scroll += new System.EventHandler(this.transparencyBar__Scroll);
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
      // NotePreferencesControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.Controls.Add(opaqueLabel_);
      this.Controls.Add(invisibleLabel_);
      this.Controls.Add(transparencyLabel_);
      this.Controls.Add(this.transparencyBar_);
      this.Controls.Add(this.fontPreviewLabel_);
      this.Controls.Add(fontButton_);
      this.Controls.Add(this.backgroundColorPreviewPanel_);
      this.Controls.Add(fontLabel_);
      this.Controls.Add(backgroundColorButton_);
      this.Controls.Add(this.borderColorPreviewPanel_);
      this.Controls.Add(backgroundColorLabel_);
      this.Controls.Add(borderColorButton_);
      this.Controls.Add(borderColorLabel_);
      this.Name = "NotePreferencesControl";
      this.Size = new System.Drawing.Size(192, 156);
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

  }
}
