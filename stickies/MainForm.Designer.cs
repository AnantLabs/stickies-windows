namespace Stickies
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.components = new System.ComponentModel.Container();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
          this.notifyIcon_ = new System.Windows.Forms.NotifyIcon(this.components);
          this.contextMenu_ = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.newNoteMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
          this.showAllNotesMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
          this.deleteAllNotesMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
          this.synchronizeMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
          this.preferencesMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
          this.reportBugMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
          this.aboutMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
          this.exitMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
          this.synchronizationTimer_ = new System.Windows.Forms.Timer(this.components);
          this.contextMenu_.SuspendLayout();
          this.SuspendLayout();
          // 
          // notifyIcon_
          // 
          this.notifyIcon_.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
          this.notifyIcon_.ContextMenuStrip = this.contextMenu_;
          this.notifyIcon_.Icon = ((System.Drawing.Icon) (resources.GetObject("notifyIcon_.Icon")));
          this.notifyIcon_.Visible = true;
          this.notifyIcon_.BalloonTipClicked += new System.EventHandler(this.notifyIcon__BalloonTipClicked);
          this.notifyIcon_.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon__MouseDoubleClick);
          // 
          // contextMenu_
          // 
          this.contextMenu_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newNoteMenuItem_,
            this.showAllNotesMenuItem_,
            this.deleteAllNotesMenuItem_,
            this.synchronizeMenuItem_,
            this.toolStripMenuItem2,
            this.preferencesMenuItem_,
            this.toolStripMenuItem1,
            this.reportBugMenuItem_,
            this.aboutMenuItem_,
            this.exitMenuItem_});
          this.contextMenu_.Name = "contextMenu_";
          this.contextMenu_.Size = new System.Drawing.Size(208, 192);
          // 
          // newNoteMenuItem_
          // 
          this.newNoteMenuItem_.Name = "newNoteMenuItem_";
          this.newNoteMenuItem_.Size = new System.Drawing.Size(207, 22);
          this.newNoteMenuItem_.Text = "&New Note";
          this.newNoteMenuItem_.Click += new System.EventHandler(this.newNoteMenuItem__Click);
          // 
          // showAllNotesMenuItem_
          // 
          this.showAllNotesMenuItem_.Name = "showAllNotesMenuItem_";
          this.showAllNotesMenuItem_.Size = new System.Drawing.Size(207, 22);
          this.showAllNotesMenuItem_.Text = "&Show All Notes";
          this.showAllNotesMenuItem_.Click += new System.EventHandler(this.showAllNotesMenuItem__Click);
          // 
          // deleteAllNotesMenuItem_
          // 
          this.deleteAllNotesMenuItem_.Name = "deleteAllNotesMenuItem_";
          this.deleteAllNotesMenuItem_.Size = new System.Drawing.Size(207, 22);
          this.deleteAllNotesMenuItem_.Text = "&Delete All Notes";
          this.deleteAllNotesMenuItem_.Click += new System.EventHandler(this.deleteAllNotesMenuItem__Click);
          // 
          // synchronizeMenuItem_
          // 
          this.synchronizeMenuItem_.Name = "synchronizeMenuItem_";
          this.synchronizeMenuItem_.Size = new System.Drawing.Size(207, 22);
          this.synchronizeMenuItem_.Text = "Synchronize &Online Notes";
          this.synchronizeMenuItem_.Click += new System.EventHandler(this.synchronizeMenuItem__Click);
          // 
          // toolStripMenuItem2
          // 
          this.toolStripMenuItem2.Name = "toolStripMenuItem2";
          this.toolStripMenuItem2.Size = new System.Drawing.Size(204, 6);
          // 
          // preferencesMenuItem_
          // 
          this.preferencesMenuItem_.Name = "preferencesMenuItem_";
          this.preferencesMenuItem_.Size = new System.Drawing.Size(207, 22);
          this.preferencesMenuItem_.Text = "&Preferences";
          this.preferencesMenuItem_.Click += new System.EventHandler(this.preferencesMenuItem__Click);
          // 
          // toolStripMenuItem1
          // 
          this.toolStripMenuItem1.Name = "toolStripMenuItem1";
          this.toolStripMenuItem1.Size = new System.Drawing.Size(204, 6);
          // 
          // reportBugMenuItem_
          // 
          this.reportBugMenuItem_.Name = "reportBugMenuItem_";
          this.reportBugMenuItem_.Size = new System.Drawing.Size(207, 22);
          this.reportBugMenuItem_.Text = "Report a &Bug";
          this.reportBugMenuItem_.Click += new System.EventHandler(this.reportBugMenuItem__Click);
          // 
          // aboutMenuItem_
          // 
          this.aboutMenuItem_.Name = "aboutMenuItem_";
          this.aboutMenuItem_.Size = new System.Drawing.Size(207, 22);
          this.aboutMenuItem_.Text = "&About Stickies";
          this.aboutMenuItem_.Click += new System.EventHandler(this.aboutMenuItem__Click);
          // 
          // exitMenuItem_
          // 
          this.exitMenuItem_.Name = "exitMenuItem_";
          this.exitMenuItem_.Size = new System.Drawing.Size(207, 22);
          this.exitMenuItem_.Text = "E&xit";
          this.exitMenuItem_.Click += new System.EventHandler(this.exitMenuItem__Click);
          // 
          // synchronizationTimer_
          // 
          this.synchronizationTimer_.Interval = 300000;
          this.synchronizationTimer_.Tick += new System.EventHandler(this.synchronizationTimer__Tick);
          // 
          // MainForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(292, 266);
          this.Name = "MainForm";
          this.contextMenu_.ResumeLayout(false);
          this.ResumeLayout(false);

        }

        #endregion

      private System.Windows.Forms.NotifyIcon notifyIcon_;
      private System.Windows.Forms.ContextMenuStrip contextMenu_;
      private System.Windows.Forms.ToolStripMenuItem newNoteMenuItem_;
      private System.Windows.Forms.ToolStripMenuItem showAllNotesMenuItem_;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem preferencesMenuItem_;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem aboutMenuItem_;
      private System.Windows.Forms.ToolStripMenuItem exitMenuItem_;
      private System.Windows.Forms.ToolStripMenuItem deleteAllNotesMenuItem_;
      private System.Windows.Forms.ToolStripMenuItem reportBugMenuItem_;
      private System.Windows.Forms.ToolStripMenuItem synchronizeMenuItem_;
      private System.Windows.Forms.Timer synchronizationTimer_;
    }
}

