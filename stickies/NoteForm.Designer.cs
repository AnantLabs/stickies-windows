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
      System.Windows.Forms.ToolStripSeparator toolStripMenuItem_;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
      this.deleteMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
      this.preferencesMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenu_ = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.archiveMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
      this.boldMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
      this.italicMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
      this.underlineMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
      this.strikethroughMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
      this.saveFileDialog_ = new System.Windows.Forms.SaveFileDialog();
      this.textBox_ = new Stickies.NoteTextBox();
      this.rollUpLabel_ = new Stickies.TransparentLabel();
      toolStripMenuItem_ = new System.Windows.Forms.ToolStripSeparator();
      this.contextMenu_.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripMenuItem_
      // 
      toolStripMenuItem_.Name = "toolStripMenuItem_";
      toolStripMenuItem_.Size = new System.Drawing.Size(185, 6);
      // 
      // deleteMenuItem_
      // 
      this.deleteMenuItem_.Name = "deleteMenuItem_";
      this.deleteMenuItem_.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
      this.deleteMenuItem_.Size = new System.Drawing.Size(188, 22);
      this.deleteMenuItem_.Text = "&Delete";
      this.deleteMenuItem_.Click += new System.EventHandler(this.deleteMenuItem__Click);
      // 
      // preferencesMenuItem_
      // 
      this.preferencesMenuItem_.Name = "preferencesMenuItem_";
      this.preferencesMenuItem_.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.preferencesMenuItem_.Size = new System.Drawing.Size(188, 22);
      this.preferencesMenuItem_.Text = "&Preferences";
      this.preferencesMenuItem_.Click += new System.EventHandler(this.preferencesMenuItem__Click);
      // 
      // contextMenu_
      // 
      this.contextMenu_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesMenuItem_,
            this.deleteMenuItem_,
            this.archiveMenuItem_,
            toolStripMenuItem_,
            this.boldMenuItem_,
            this.italicMenuItem_,
            this.underlineMenuItem_,
            this.strikethroughMenuItem_});
      this.contextMenu_.Name = "contextMenu_";
      this.contextMenu_.Size = new System.Drawing.Size(189, 164);
      // 
      // archiveMenuItem_
      // 
      this.archiveMenuItem_.Name = "archiveMenuItem_";
      this.archiveMenuItem_.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.archiveMenuItem_.Size = new System.Drawing.Size(188, 22);
      this.archiveMenuItem_.Text = "&Archive";
      this.archiveMenuItem_.Click += new System.EventHandler(this.archiveMenuItem__Click);
      // 
      // boldMenuItem_
      // 
      this.boldMenuItem_.Name = "boldMenuItem_";
      this.boldMenuItem_.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
      this.boldMenuItem_.Size = new System.Drawing.Size(188, 22);
      this.boldMenuItem_.Text = "&Bold";
      this.boldMenuItem_.Click += new System.EventHandler(this.boldMenuItem__Click);
      // 
      // italicMenuItem_
      // 
      this.italicMenuItem_.Name = "italicMenuItem_";
      this.italicMenuItem_.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
      this.italicMenuItem_.Size = new System.Drawing.Size(188, 22);
      this.italicMenuItem_.Text = "&Italic";
      this.italicMenuItem_.Click += new System.EventHandler(this.italicMenuItem__Click);
      // 
      // underlineMenuItem_
      // 
      this.underlineMenuItem_.Name = "underlineMenuItem_";
      this.underlineMenuItem_.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
      this.underlineMenuItem_.Size = new System.Drawing.Size(188, 22);
      this.underlineMenuItem_.Text = "&Underline";
      this.underlineMenuItem_.Click += new System.EventHandler(this.underlineMenuItem__Click);
      // 
      // strikethroughMenuItem_
      // 
      this.strikethroughMenuItem_.Name = "strikethroughMenuItem_";
      this.strikethroughMenuItem_.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
      this.strikethroughMenuItem_.Size = new System.Drawing.Size(188, 22);
      this.strikethroughMenuItem_.Text = "&Strikethrough";
      this.strikethroughMenuItem_.Click += new System.EventHandler(this.strikethroughMenuItem__Click);
      // 
      // textBox_
      // 
      this.textBox_.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (192)))));
      this.textBox_.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox_.ContextMenuStrip = this.contextMenu_;
      this.textBox_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBox_.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.textBox_.Location = new System.Drawing.Point(2, 13);
      this.textBox_.Name = "textBox_";
      this.textBox_.Size = new System.Drawing.Size(171, 160);
      this.textBox_.TabIndex = 7;
      this.textBox_.Text = "";
      this.textBox_.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textBox__LinkClicked);
      this.textBox_.SelectionChanged += new System.EventHandler(this.textBox__SelectionChanged);
      this.textBox_.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox__KeyDown);
      // 
      // rollUpLabel_
      // 
      this.rollUpLabel_.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.rollUpLabel_.Location = new System.Drawing.Point(0, 0);
      this.rollUpLabel_.Name = "rollUpLabel_";
      this.rollUpLabel_.Size = new System.Drawing.Size(153, 12);
      this.rollUpLabel_.TabIndex = 8;
      this.rollUpLabel_.Visible = false;
      // 
      // NoteForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
      this.ClientSize = new System.Drawing.Size(175, 175);
      this.ContextMenuStrip = this.contextMenu_;
      this.Controls.Add(this.rollUpLabel_);
      this.Controls.Add(this.textBox_);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
      this.Name = "NoteForm";
      this.Padding = new System.Windows.Forms.Padding(2, 13, 2, 2);
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
    private System.Windows.Forms.ToolStripMenuItem boldMenuItem_;
    private System.Windows.Forms.ToolStripMenuItem italicMenuItem_;
    private System.Windows.Forms.ToolStripMenuItem underlineMenuItem_;
    private System.Windows.Forms.ToolStripMenuItem archiveMenuItem_;
    private System.Windows.Forms.ToolStripMenuItem strikethroughMenuItem_;
    private System.Windows.Forms.SaveFileDialog saveFileDialog_;
    private NoteTextBox textBox_;
    private TransparentLabel rollUpLabel_;
  }
}