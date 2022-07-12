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
            this.DirectoryTextBox = new System.Windows.Forms.TextBox();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // DirectoryTextBox
            // 
            this.DirectoryTextBox.Location = new System.Drawing.Point(12, 12);
            this.DirectoryTextBox.Name = "DirectoryTextBox";
            this.DirectoryTextBox.Size = new System.Drawing.Size(460, 23);
            this.DirectoryTextBox.TabIndex = 0;
            // 
            // FileListBox
            // 
            this.FileListBox.ColumnWidth = 20;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 961);
            this.Controls.Add(this.FileListBox);
            this.Controls.Add(this.DirectoryTextBox);
            this.MaximumSize = new System.Drawing.Size(500, 1000);
            this.MinimumSize = new System.Drawing.Size(500, 1000);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox DirectoryTextBox;
        private ListBox FileListBox;
    }
}