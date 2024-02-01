namespace LaunchCamPlus.ExtraControls
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
            LogoPictureBox = new PictureBox();
            AboutLabel = new Label();
            InfoLabel = new Label();
            VersionLabel = new Label();
            UpdateTextLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // LogoPictureBox
            // 
            LogoPictureBox.Dock = DockStyle.Top;
            LogoPictureBox.Image = Properties.Resources.LCPLogo;
            LogoPictureBox.InitialImage = null;
            LogoPictureBox.Location = new Point(0, 0);
            LogoPictureBox.Margin = new Padding(4, 3, 4, 3);
            LogoPictureBox.Name = "LogoPictureBox";
            LogoPictureBox.Size = new Size(441, 58);
            LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            LogoPictureBox.TabIndex = 0;
            LogoPictureBox.TabStop = false;
            // 
            // AboutLabel
            // 
            AboutLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AboutLabel.AutoSize = true;
            AboutLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            AboutLabel.Location = new Point(252, 428);
            AboutLabel.Name = "AboutLabel";
            AboutLabel.Size = new Size(189, 13);
            AboutLabel.TabIndex = 1;
            AboutLabel.Text = "Super Hackio Incorporated 2018-2024";
            // 
            // InfoLabel
            // 
            InfoLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            InfoLabel.AutoSize = true;
            InfoLabel.Font = new Font("Microsoft Sans Serif", 10F);
            InfoLabel.Location = new Point(4, 341);
            InfoLabel.Margin = new Padding(4, 0, 4, 0);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(389, 85);
            InfoLabel.TabIndex = 2;
            InfoLabel.Text = "Icons by Yusuke Kamiyamane.\r\nLicensed under a Creative Commons Attribution 3.0 License.\r\n\r\nIcons related to GitHub were made by GitHub.\r\nLicensed under a MIT License";
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Dock = DockStyle.Top;
            VersionLabel.Font = new Font("Microsoft Sans Serif", 10F);
            VersionLabel.Location = new Point(0, 58);
            VersionLabel.Margin = new Padding(4, 0, 4, 0);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Padding = new Padding(0, 0, 0, 16);
            VersionLabel.Size = new Size(95, 33);
            VersionLabel.TabIndex = 4;
            VersionLabel.Text = "LCP VX.X.X.X";
            // 
            // UpdateTextLabel
            // 
            UpdateTextLabel.AutoSize = true;
            UpdateTextLabel.Dock = DockStyle.Top;
            UpdateTextLabel.Font = new Font("Microsoft Sans Serif", 10F);
            UpdateTextLabel.Location = new Point(0, 91);
            UpdateTextLabel.Margin = new Padding(4, 0, 4, 0);
            UpdateTextLabel.Name = "UpdateTextLabel";
            UpdateTextLabel.Size = new Size(261, 85);
            UpdateTextLabel.TabIndex = 5;
            UpdateTextLabel.Text = "- This is update information\r\n- This string is useless\r\n- It will get replaced with the update data\r\n- which is a new feature, yes\r\n- may the old credits rest in peace";
            // 
            // AboutPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(UpdateTextLabel);
            Controls.Add(VersionLabel);
            Controls.Add(InfoLabel);
            Controls.Add(AboutLabel);
            Controls.Add(LogoPictureBox);
            DoubleBuffered = true;
            Name = "AboutPanel";
            Size = new Size(441, 441);
            Resize += AboutPanel_Resize;
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.Label InfoLabel;
        private Label VersionLabel;
        private Label UpdateTextLabel;
    }
}
