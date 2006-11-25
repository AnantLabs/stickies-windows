namespace Stickies {
  partial class NoteForm {
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.ToolStripMenuItem deleteMenuItem_;
      System.Windows.Forms.ToolStripMenuItem preferencesMenuItem_;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
      this.timer_ = new System.Windows.Forms.Timer(this.components);
      this.contextMenu_ = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.textBox_ = new Stickies.NoteTextBox();
      deleteMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
      preferencesMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenu_.SuspendLayout();
      this.SuspendLayout();
      // 
      // deleteMenuItem_
      // 
      deleteMenuItem_.Name = "deleteMenuItem_";
      deleteMenuItem_.Size = new System.Drawing.Size(143, 22);
      deleteMenuItem_.Text = "&Delete";
      deleteMenuItem_.Click += new System.EventHandler(this.deleteMenuItem__Click);
      // 
      // preferencesMenuItem_
      // 
      preferencesMenuItem_.Name = "preferencesMenuItem_";
      preferencesMenuItem_.Size = new System.Drawing.Size(143, 22);
      preferencesMenuItem_.Text = "&Preferences";
      preferencesMenuItem_.Click += new System.EventHandler(this.preferencesMenuItem__Click);
      // 
      // timer_
      // 
      this.timer_.Interval = 5000;
      this.timer_.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // contextMenu_
      // 
      this.contextMenu_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            preferencesMenuItem_,
            deleteMenuItem_});
      this.contextMenu_.Name = "contextMenu_";
      this.contextMenu_.Size = new System.Drawing.Size(144, 48);
      // 
      // textBox_
      // 
      this.textBox_.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (192)))));
      this.textBox_.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox_.ContextMenuStrip = this.contextMenu_;
      this.textBox_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBox_.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.textBox_.Location = new System.Drawing.Point(2, 11);
      this.textBox_.Name = "textBox_";
      this.textBox_.Size = new System.Drawing.Size(171, 162);
      this.textBox_.TabIndex = 1;
      this.textBox_.Text = "";
      this.textBox_.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox__KeyDown);
      // 
      // NoteForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
      this.ClientSize = new System.Drawing.Size(175, 175);
      this.ContextMenuStrip = this.contextMenu_;
      this.Controls.Add(this.textBox_);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
      this.Name = "NoteForm";
      this.Padding = new System.Windows.Forms.Padding(2, 11, 2, 2);
      this.ShowInTaskbar = false;
      this.Deactivate += new System.EventHandler(this.NoteForm_Deactivate);
      this.Load += new System.EventHandler(this.NoteForm_Load);
      this.contextMenu_.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer timer_;
    private System.Windows.Forms.ContextMenuStrip contextMenu_;
    private NoteTextBox textBox_;
  }
}