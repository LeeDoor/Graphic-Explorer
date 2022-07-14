namespace Explorer
{
    partial class Features
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
            this.propertyLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.valueLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // propertyLayoutPanel
            // 
            this.propertyLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.propertyLayoutPanel.Location = new System.Drawing.Point(19, 20);
            this.propertyLayoutPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.propertyLayoutPanel.Name = "propertyLayoutPanel";
            this.propertyLayoutPanel.Size = new System.Drawing.Size(240, 728);
            this.propertyLayoutPanel.TabIndex = 0;
            // 
            // valueLayoutPanel
            // 
            this.valueLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.valueLayoutPanel.Location = new System.Drawing.Point(291, 20);
            this.valueLayoutPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.valueLayoutPanel.Name = "valueLayoutPanel";
            this.valueLayoutPanel.Size = new System.Drawing.Size(451, 728);
            this.valueLayoutPanel.TabIndex = 0;
            // 
            // Features
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 768);
            this.Controls.Add(this.valueLayoutPanel);
            this.Controls.Add(this.propertyLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(777, 1641);
            this.MinimumSize = new System.Drawing.Size(777, 141);
            this.Name = "Features";
            this.Text = "Features";
            this.Load += new System.EventHandler(this.Features_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel propertyLayoutPanel;
        private FlowLayoutPanel valueLayoutPanel;
    }
}