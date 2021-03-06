namespace Explorer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DirectoryTextBox = new System.Windows.Forms.TextBox();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.ElementContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackButton = new System.Windows.Forms.Button();
            this.ElementContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DirectoryTextBox
            // 
            this.DirectoryTextBox.Location = new System.Drawing.Point(46, 12);
            this.DirectoryTextBox.Name = "DirectoryTextBox";
            this.DirectoryTextBox.Size = new System.Drawing.Size(426, 23);
            this.DirectoryTextBox.TabIndex = 0;
            this.DirectoryTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnDirectoryTextBoxKeyPress);
            // 
            // FileListBox
            // 
            this.FileListBox.ColumnWidth = 20;
            this.FileListBox.ContextMenuStrip = this.ElementContextMenu;
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.ItemHeight = 15;
            this.FileListBox.Items.AddRange(new object[] {
            "y",
            "y",
            "y",
            "y"});
            this.FileListBox.Location = new System.Drawing.Point(12, 45);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(460, 904);
            this.FileListBox.TabIndex = 1;
            this.FileListBox.DoubleClick += new System.EventHandler(this.OnFileListBoxDoubleClick);
            // 
            // ElementContextMenu
            // 
            this.ElementContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateFolderMenuItem,
            this.CreateFileMenuItem});
            this.ElementContextMenu.Name = "ElementContextMenu";
            this.ElementContextMenu.Size = new System.Drawing.Size(190, 70);
            this.ElementContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnElementContextMenuOpening);
            // 
            // CreateFolderMenuItem
            // 
            this.CreateFolderMenuItem.Name = "CreateFolderMenuItem";
            this.CreateFolderMenuItem.Size = new System.Drawing.Size(189, 22);
            this.CreateFolderMenuItem.Text = "Create folder";
            this.CreateFolderMenuItem.Click += new System.EventHandler(this.OnCreateFolderItemClick);
            // 
            // CreateFileMenuItem
            // 
            this.CreateFileMenuItem.Name = "CreateFileMenuItem";
            this.CreateFileMenuItem.Size = new System.Drawing.Size(189, 22);
            this.CreateFileMenuItem.Text = "Create text document";
            this.CreateFileMenuItem.Click += new System.EventHandler(this.OnCreateFileItemClick);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.ForeColor = System.Drawing.Color.Black;
            this.BackButton.Location = new System.Drawing.Point(12, 11);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(28, 24);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "<";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.OnBackButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 961);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.FileListBox);
            this.Controls.Add(this.DirectoryTextBox);
            this.MaximumSize = new System.Drawing.Size(500, 1000);
            this.MinimumSize = new System.Drawing.Size(500, 1000);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnForm1Load);
            this.ElementContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox DirectoryTextBox;
        private ListBox FileListBox;
        private Button BackButton;
        private ContextMenuStrip ElementContextMenu;
        private ToolStripMenuItem CreateFolderMenuItem;
        private ToolStripMenuItem CreateFileMenuItem;
    }
}