namespace Stickies {
  partial class AboutDialog {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
      this.topPanel_ = new System.Windows.Forms.Panel();
      this.logoPictureBox_ = new System.Windows.Forms.PictureBox();
      this.versionLabel_ = new System.Windows.Forms.Label();
      this.linkLabel_ = new System.Windows.Forms.LinkLabel();
      this.licenseLabel_ = new System.Windows.Forms.Label();
      this.authorLabel_ = new System.Windows.Forms.Label();
      this.closeButton_ = new System.Windows.Forms.Button();
      this.topPanel_.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize) (this.logoPictureBox_)).BeginInit();
      this.SuspendLayout();
      // 
      // topPanel_
      // 
      this.topPanel_.Controls.Add(this.logoPictureBox_);
      this.topPanel_.Dock = System.Windows.Forms.DockStyle.Top;
      this.topPanel_.Location = new System.Drawing.Point(0, 0);
      this.topPanel_.Name = "topPanel_";
      this.topPanel_.Size = new System.Drawing.Size(303, 129);
      this.topPanel_.TabIndex = 0;
      // 
      // logoPictureBox_
      // 
      this.logoPictureBox_.Image = ((System.Drawing.Image) (resources.GetObject("logoPictureBox_.Image")));
      this.logoPictureBox_.ImageLocation = "";
      this.logoPictureBox_.Location = new System.Drawing.Point(12, 12);
      this.logoPictureBox_.Name = "logoPictureBox_";
      this.logoPictureBox_.Size = new System.Drawing.Size(277, 99);
      this.logoPictureBox_.TabIndex = 3;
      this.logoPictureBox_.TabStop = false;
      // 
      // versionLabel_
      // 
      this.versionLabel_.Dock = System.Windows.Forms.DockStyle.Top;
      this.versionLabel_.Location = new System.Drawing.Point(0, 129);
      this.versionLabel_.Name = "versionLabel_";
      this.versionLabel_.Size = new System.Drawing.Size(303, 30);
      this.versionLabel_.TabIndex = 10;
      this.versionLabel_.Text = "Version";
      this.versionLabel_.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // linkLabel_
      // 
      this.linkLabel_.Dock = System.Windows.Forms.DockStyle.Top;
      this.linkLabel_.LinkColor = System.Drawing.Color.MediumBlue;
      this.linkLabel_.Location = new System.Drawing.Point(0, 189);
      this.linkLabel_.Name = "linkLabel_";
      this.linkLabel_.Size = new System.Drawing.Size(303, 13);
      this.linkLabel_.TabIndex = 1;
      this.linkLabel_.TabStop = true;
      this.linkLabel_.Text = "http://finiteloop.org/~btaylor/software/stickies/";
      this.linkLabel_.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.linkLabel_.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel__LinkClicked);
      // 
      // licenseLabel_
      // 
      this.licenseLabel_.Dock = System.Windows.Forms.DockStyle.Top;
      this.licenseLabel_.Location = new System.Drawing.Point(0, 174);
      this.licenseLabel_.Name = "licenseLabel_";
      this.licenseLabel_.Size = new System.Drawing.Size(303, 15);
      this.licenseLabel_.TabIndex = 12;
      this.licenseLabel_.Text = "Available under the Apache 2.0 open source license.";
      this.licenseLabel_.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // authorLabel_
      // 
      this.authorLabel_.Dock = System.Windows.Forms.DockStyle.Top;
      this.authorLabel_.Location = new System.Drawing.Point(0, 159);
      this.authorLabel_.Name = "authorLabel_";
      this.authorLabel_.Size = new System.Drawing.Size(303, 15);
      this.authorLabel_.TabIndex = 11;
      this.authorLabel_.Text = "Written by Bret Taylor (btaylor@gmail.com).";
      this.authorLabel_.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // closeButton_
      // 
      this.closeButton_.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.closeButton_.Location = new System.Drawing.Point(114, 217);
      this.closeButton_.Name = "closeButton_";
      this.closeButton_.Size = new System.Drawing.Size(75, 23);
      this.closeButton_.TabIndex = 0;
      this.closeButton_.Text = "Close";
      this.closeButton_.UseVisualStyleBackColor = true;
      // 
      // AboutForm
      // 
      this.AcceptButton = this.linkLabel_;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(303, 252);
      this.Controls.Add(this.closeButton_);
      this.Controls.Add(this.linkLabel_);
      this.Controls.Add(this.licenseLabel_);
      this.Controls.Add(this.authorLabel_);
      this.Controls.Add(this.versionLabel_);
      this.Controls.Add(this.topPanel_);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutForm";
      this.topPanel_.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize) (this.logoPictureBox_)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel topPanel_;
    private System.Windows.Forms.PictureBox logoPictureBox_;
    private System.Windows.Forms.Label versionLabel_;
    private System.Windows.Forms.LinkLabel linkLabel_;
    private System.Windows.Forms.Label licenseLabel_;
    private System.Windows.Forms.Label authorLabel_;
    private System.Windows.Forms.Button closeButton_;

  }
}