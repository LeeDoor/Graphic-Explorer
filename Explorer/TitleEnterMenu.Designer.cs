namespace Explorer
{
    partial class TitleEnterMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleEnterMenu));
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.IconsImageList = new System.Windows.Forms.ImageList(this.components);
            this.IconPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(12, 234);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(194, 23);
            this.TitleTextBox.TabIndex = 1;
            this.TitleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnTitleTextBoxKeyPress);
            // 
            // IconsImageList
            // 
            this.IconsImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.IconsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconsImageList.ImageStream")));
            this.IconsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconsImageList.Images.SetKeyName(0, "text file icon");
            this.IconsImageList.Images.SetKeyName(1, "folder icon");
            // 
            // IconPictureBox
            // 
            this.IconPictureBox.Image = global::Explorer.Properties.Resources._104647;
            this.IconPictureBox.Location = new System.Drawing.Point(12, 12);
            this.IconPictureBox.Name = "IconPictureBox";
            this.IconPictureBox.Size = new System.Drawing.Size(194, 216);
            this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconPictureBox.TabIndex = 2;
            this.IconPictureBox.TabStop = false;
            // 
            // TitleEnterMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 269);
            this.Controls.Add(this.IconPictureBox);
            this.Controls.Add(this.TitleTextBox);
            this.Name = "TitleEnterMenu";
            this.Text = "TitleEnterMenu";
            this.Load += new System.EventHandler(this.TitleEnterMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox TitleTextBox;
        private ImageList IconsImageList;
        private PictureBox IconPictureBox;
    }
}