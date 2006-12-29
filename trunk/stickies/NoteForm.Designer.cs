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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
      this.deleteMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
      this.preferencesMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenu_ = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.textBox_ = new Stickies.NoteTextBox();
      this.contextMenu_.SuspendLayout();
      this.SuspendLayout();
      // 
      // deleteMenuItem_
      // 
      this.deleteMenuItem_.Name = "deleteMenuItem_";
      this.deleteMenuItem_.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
      this.deleteMenuItem_.Size = new System.Drawing.Size(181, 22);
      this.deleteMenuItem_.Text = "&Delete";
      this.deleteMenuItem_.Click += new System.EventHandler(this.deleteMenuItem__Click);
      // 
      // preferencesMenuItem_
      // 
      this.preferencesMenuItem_.Name = "preferencesMenuItem_";
      this.preferencesMenuItem_.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.preferencesMenuItem_.Size = new System.Drawing.Size(181, 22);
      this.preferencesMenuItem_.Text = "&Preferences";
      this.preferencesMenuItem_.Click += new System.EventHandler(this.preferencesMenuItem__Click);
      // 
      // contextMenu_
      // 
      this.contextMenu_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesMenuItem_,
            this.deleteMenuItem_});
      this.contextMenu_.Name = "contextMenu_";
      this.contextMenu_.Size = new System.Drawing.Size(182, 48);
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
      this.textBox_.TabIndex = 5;
      this.textBox_.Text = "";
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
      this.Resize += new System.EventHandler(this.MakeDirty);
      this.Move += new System.EventHandler(this.MakeDirty);
      this.BackColorChanged += new System.EventHandler(this.MakeDirty);
      this.Load += new System.EventHandler(this.NoteForm_Load);
      this.contextMenu_.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenu_;
    private System.Windows.Forms.ToolStripMenuItem preferencesMenuItem_;
    private System.Windows.Forms.ToolStripMenuItem deleteMenuItem_;
    private NoteTextBox textBox_;
  }
}