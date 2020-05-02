namespace LaunchCamPlus
{
    partial class AboutPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutPanel));
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.OtherInfoLabel = new System.Windows.Forms.Label();
            this.InformationTextBox = new LaunchCamPlus.ColourTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogoPictureBox.Image = global::LaunchCamPlus.Properties.Resources.LCPLogo;
            this.LogoPictureBox.InitialImage = null;
            this.LogoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(441, 50);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 0;
            this.LogoPictureBox.TabStop = false;
            // 
            // AboutLabel
            // 
            this.AboutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AboutLabel.AutoSize = true;
            this.AboutLabel.Location = new System.Drawing.Point(237, 428);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(201, 13);
            this.AboutLabel.TabIndex = 1;
            this.AboutLabel.Text = "© Super Hackio Incorporated 2018-2020";
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(0, 50);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(436, 238);
            this.InfoLabel.TabIndex = 2;
            this.InfoLabel.Text = resources.GetString("InfoLabel.Text");
            // 
            // OtherInfoLabel
            // 
            this.OtherInfoLabel.AutoSize = true;
            this.OtherInfoLabel.Location = new System.Drawing.Point(3, 306);
            this.OtherInfoLabel.Name = "OtherInfoLabel";
            this.OtherInfoLabel.Size = new System.Drawing.Size(90, 13);
            this.OtherInfoLabel.TabIndex = 4;
            this.OtherInfoLabel.Text = "Other information:";
            // 
            // InformationTextBox
            // 
            this.InformationTextBox.HideSelection = false;
            this.InformationTextBox.Location = new System.Drawing.Point(3, 322);
            this.InformationTextBox.Multiline = true;
            this.InformationTextBox.Name = "InformationTextBox";
            this.InformationTextBox.ReadOnly = true;
            this.InformationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InformationTextBox.ShortcutsEnabled = false;
            this.InformationTextBox.Size = new System.Drawing.Size(433, 103);
            this.InformationTextBox.TabIndex = 0;
            this.InformationTextBox.TabStop = false;
            this.InformationTextBox.Text = resources.GetString("InformationTextBox.Text");
            // 
            // AboutPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OtherInfoLabel);
            this.Controls.Add(this.InformationTextBox);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.AboutLabel);
            this.Controls.Add(this.LogoPictureBox);
            this.DoubleBuffered = true;
            this.Name = "AboutPanel";
            this.Size = new System.Drawing.Size(441, 441);
            this.Resize += new System.EventHandler(this.AboutPanel_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.Label InfoLabel;
        private ColourTextBox InformationTextBox;
        private System.Windows.Forms.Label OtherInfoLabel;
    }
}
