namespace Stickies {
  partial class NetworkActivityDialog {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkActivityDialog));
      this.infoPanel_ = new System.Windows.Forms.Panel();
      this.infoLabel_ = new System.Windows.Forms.Label();
      this.buttonPanel_ = new System.Windows.Forms.Panel();
      this.cancelButton_ = new System.Windows.Forms.Button();
      this.progressBar_ = new System.Windows.Forms.ProgressBar();
      this.infoPanel_.SuspendLayout();
      this.buttonPanel_.SuspendLayout();
      this.SuspendLayout();
      // 
      // infoPanel_
      // 
      this.infoPanel_.Controls.Add(this.infoLabel_);
      this.infoPanel_.Dock = System.Windows.Forms.DockStyle.Top;
      this.infoPanel_.Location = new System.Drawing.Point(20, 20);
      this.infoPanel_.Name = "infoPanel_";
      this.infoPanel_.Size = new System.Drawing.Size(284, 25);
      this.infoPanel_.TabIndex = 0;
      // 
      // infoLabel_
      // 
      this.infoLabel_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.infoLabel_.Location = new System.Drawing.Point(0, 0);
      this.infoLabel_.Name = "infoLabel_";
      this.infoLabel_.Size = new System.Drawing.Size(284, 25);
      this.infoLabel_.TabIndex = 1;
      // 
      // buttonPanel_
      // 
      this.buttonPanel_.Controls.Add(this.cancelButton_);
      this.buttonPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.buttonPanel_.Location = new System.Drawing.Point(20, 68);
      this.buttonPanel_.Name = "buttonPanel_";
      this.buttonPanel_.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.buttonPanel_.Size = new System.Drawing.Size(284, 34);
      this.buttonPanel_.TabIndex = 5;
      // 
      // cancelButton_
      // 
      this.cancelButton_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton_.Dock = System.Windows.Forms.DockStyle.Right;
      this.cancelButton_.Location = new System.Drawing.Point(209, 10);
      this.cancelButton_.Name = "cancelButton_";
      this.cancelButton_.Size = new System.Drawing.Size(75, 24);
      this.cancelButton_.TabIndex = 0;
      this.cancelButton_.Text = "Cancel";
      this.cancelButton_.UseVisualStyleBackColor = true;
      this.cancelButton_.Click += new System.EventHandler(this.cancelButton__Click);
      // 
      // progressBar_
      // 
      this.progressBar_.Dock = System.Windows.Forms.DockStyle.Top;
      this.progressBar_.Location = new System.Drawing.Point(20, 45);
      this.progressBar_.Name = "progressBar_";
      this.progressBar_.Size = new System.Drawing.Size(284, 23);
      this.progressBar_.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
      this.progressBar_.TabIndex = 4;
      // 
      // NetworkActivityDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton_;
      this.ClientSize = new System.Drawing.Size(324, 122);
      this.Controls.Add(this.buttonPanel_);
      this.Controls.Add(this.progressBar_);
      this.Controls.Add(this.infoPanel_);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "NetworkActivityDialog";
      this.Padding = new System.Windows.Forms.Padding(20);
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Shown += new System.EventHandler(this.NetworkActivityDialog_Shown);
      this.infoPanel_.ResumeLayout(false);
      this.buttonPanel_.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel infoPanel_;
    private System.Windows.Forms.Panel buttonPanel_;
    private System.Windows.Forms.Button cancelButton_;
    private System.Windows.Forms.ProgressBar progressBar_;
    private System.Windows.Forms.Label infoLabel_;

  }
}