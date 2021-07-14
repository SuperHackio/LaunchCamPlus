namespace LaunchCamPlus
{
    partial class SettingsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPanel));
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.VisualSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.SfxCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowAboutCheckBox = new System.Windows.Forms.CheckBox();
            this.UniqueEditorsCheckbox = new System.Windows.Forms.CheckBox();
            this.SplashSizeComboBox = new LaunchCamPlus.ColourComboBox();
            this.SplashLabel = new System.Windows.Forms.Label();
            this.LongNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.UseHexCheckBox = new System.Windows.Forms.CheckBox();
            this.DarkModeCheckBox = new System.Windows.Forms.CheckBox();
            this.InternalSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.EnforceCompressCheckbox = new System.Windows.Forms.CheckBox();
            this.YAZ0CheckBox = new System.Windows.Forms.CheckBox();
            this.FunSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.ShowSplashButton = new System.Windows.Forms.Button();
            this.NoticeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.VisualSettingsGroupBox.SuspendLayout();
            this.InternalSettingsGroupBox.SuspendLayout();
            this.FunSettingsGroupBox.SuspendLayout();
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
            this.AboutLabel.Text = "© Super Hackio Incorporated 2018-2021";
            // 
            // VisualSettingsGroupBox
            // 
            this.VisualSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VisualSettingsGroupBox.Controls.Add(this.SfxCheckBox);
            this.VisualSettingsGroupBox.Controls.Add(this.ShowAboutCheckBox);
            this.VisualSettingsGroupBox.Controls.Add(this.UniqueEditorsCheckbox);
            this.VisualSettingsGroupBox.Controls.Add(this.SplashSizeComboBox);
            this.VisualSettingsGroupBox.Controls.Add(this.SplashLabel);
            this.VisualSettingsGroupBox.Controls.Add(this.LongNumberCheckBox);
            this.VisualSettingsGroupBox.Controls.Add(this.UseHexCheckBox);
            this.VisualSettingsGroupBox.Controls.Add(this.DarkModeCheckBox);
            this.VisualSettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisualSettingsGroupBox.Location = new System.Drawing.Point(3, 56);
            this.VisualSettingsGroupBox.Name = "VisualSettingsGroupBox";
            this.VisualSettingsGroupBox.Size = new System.Drawing.Size(435, 118);
            this.VisualSettingsGroupBox.TabIndex = 2;
            this.VisualSettingsGroupBox.TabStop = false;
            this.VisualSettingsGroupBox.Text = "Visuals and Audio";
            // 
            // SfxCheckBox
            // 
            this.SfxCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SfxCheckBox.AutoSize = true;
            this.SfxCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SfxCheckBox.Location = new System.Drawing.Point(316, 52);
            this.SfxCheckBox.Name = "SfxCheckBox";
            this.SfxCheckBox.Size = new System.Drawing.Size(84, 21);
            this.SfxCheckBox.TabIndex = 7;
            this.SfxCheckBox.Text = "Play SFX";
            this.SfxCheckBox.UseVisualStyleBackColor = true;
            this.SfxCheckBox.CheckedChanged += new System.EventHandler(this.SfxCheckBox_CheckedChanged);
            // 
            // ShowAboutCheckBox
            // 
            this.ShowAboutCheckBox.AutoSize = true;
            this.ShowAboutCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowAboutCheckBox.Location = new System.Drawing.Point(137, 52);
            this.ShowAboutCheckBox.Name = "ShowAboutCheckBox";
            this.ShowAboutCheckBox.Size = new System.Drawing.Size(170, 21);
            this.ShowAboutCheckBox.TabIndex = 6;
            this.ShowAboutCheckBox.Text = "Load About on Startup";
            this.ShowAboutCheckBox.UseVisualStyleBackColor = true;
            this.ShowAboutCheckBox.CheckedChanged += new System.EventHandler(this.ShowAboutCheckBox_CheckedChanged);
            // 
            // UniqueEditorsCheckbox
            // 
            this.UniqueEditorsCheckbox.AutoSize = true;
            this.UniqueEditorsCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UniqueEditorsCheckbox.Location = new System.Drawing.Point(6, 52);
            this.UniqueEditorsCheckbox.Name = "UniqueEditorsCheckbox";
            this.UniqueEditorsCheckbox.Size = new System.Drawing.Size(120, 21);
            this.UniqueEditorsCheckbox.TabIndex = 5;
            this.UniqueEditorsCheckbox.Text = "Unique Editors";
            this.UniqueEditorsCheckbox.UseVisualStyleBackColor = true;
            this.UniqueEditorsCheckbox.CheckedChanged += new System.EventHandler(this.UniqueEditorsCheckbox_CheckedChanged);
            // 
            // SplashSizeComboBox
            // 
            this.SplashSizeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplashSizeComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.SplashSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SplashSizeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SplashSizeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SplashSizeComboBox.FormattingEnabled = true;
            this.SplashSizeComboBox.Items.AddRange(new object[] {
            "846x462",
            "1920x1080"});
            this.SplashSizeComboBox.Location = new System.Drawing.Point(143, 88);
            this.SplashSizeComboBox.Name = "SplashSizeComboBox";
            this.SplashSizeComboBox.Size = new System.Drawing.Size(286, 24);
            this.SplashSizeComboBox.TabIndex = 4;
            this.SplashSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.SplashSizeComboBox_SelectedIndexChanged);
            // 
            // SplashLabel
            // 
            this.SplashLabel.AutoSize = true;
            this.SplashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SplashLabel.Location = new System.Drawing.Point(6, 91);
            this.SplashLabel.Name = "SplashLabel";
            this.SplashLabel.Size = new System.Drawing.Size(131, 17);
            this.SplashLabel.TabIndex = 3;
            this.SplashLabel.Text = "Splash Screen Size";
            // 
            // LongNumberCheckBox
            // 
            this.LongNumberCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LongNumberCheckBox.AutoSize = true;
            this.LongNumberCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LongNumberCheckBox.Location = new System.Drawing.Point(316, 25);
            this.LongNumberCheckBox.Name = "LongNumberCheckBox";
            this.LongNumberCheckBox.Size = new System.Drawing.Size(113, 21);
            this.LongNumberCheckBox.TabIndex = 2;
            this.LongNumberCheckBox.Text = "Pad Numbers";
            this.LongNumberCheckBox.UseVisualStyleBackColor = true;
            this.LongNumberCheckBox.CheckedChanged += new System.EventHandler(this.LongNumberCheckBox_CheckedChanged);
            // 
            // UseHexCheckBox
            // 
            this.UseHexCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UseHexCheckBox.AutoSize = true;
            this.UseHexCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseHexCheckBox.Location = new System.Drawing.Point(137, 25);
            this.UseHexCheckBox.Name = "UseHexCheckBox";
            this.UseHexCheckBox.Size = new System.Drawing.Size(141, 21);
            this.UseHexCheckBox.TabIndex = 1;
            this.UseHexCheckBox.Text = "Use Hex Numbers";
            this.UseHexCheckBox.UseVisualStyleBackColor = true;
            this.UseHexCheckBox.CheckedChanged += new System.EventHandler(this.UseHexCheckBox_CheckedChanged);
            // 
            // DarkModeCheckBox
            // 
            this.DarkModeCheckBox.AutoSize = true;
            this.DarkModeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkModeCheckBox.Location = new System.Drawing.Point(6, 25);
            this.DarkModeCheckBox.Name = "DarkModeCheckBox";
            this.DarkModeCheckBox.Size = new System.Drawing.Size(96, 21);
            this.DarkModeCheckBox.TabIndex = 0;
            this.DarkModeCheckBox.Text = "Dark Mode";
            this.DarkModeCheckBox.UseVisualStyleBackColor = true;
            this.DarkModeCheckBox.CheckedChanged += new System.EventHandler(this.DarkModeCheckBox_CheckedChanged);
            // 
            // InternalSettingsGroupBox
            // 
            this.InternalSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InternalSettingsGroupBox.Controls.Add(this.EnforceCompressCheckbox);
            this.InternalSettingsGroupBox.Controls.Add(this.YAZ0CheckBox);
            this.InternalSettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InternalSettingsGroupBox.Location = new System.Drawing.Point(3, 180);
            this.InternalSettingsGroupBox.Name = "InternalSettingsGroupBox";
            this.InternalSettingsGroupBox.Size = new System.Drawing.Size(435, 59);
            this.InternalSettingsGroupBox.TabIndex = 3;
            this.InternalSettingsGroupBox.TabStop = false;
            this.InternalSettingsGroupBox.Text = "Internals";
            // 
            // EnforceCompressCheckbox
            // 
            this.EnforceCompressCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnforceCompressCheckbox.AutoSize = true;
            this.EnforceCompressCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnforceCompressCheckbox.Location = new System.Drawing.Point(244, 25);
            this.EnforceCompressCheckbox.Name = "EnforceCompressCheckbox";
            this.EnforceCompressCheckbox.Size = new System.Drawing.Size(185, 21);
            this.EnforceCompressCheckbox.TabIndex = 1;
            this.EnforceCompressCheckbox.Text = "Enable Advanced Saving";
            this.EnforceCompressCheckbox.UseVisualStyleBackColor = true;
            this.EnforceCompressCheckbox.CheckedChanged += new System.EventHandler(this.EnforceCompressCheckbox_CheckedChanged);
            // 
            // YAZ0CheckBox
            // 
            this.YAZ0CheckBox.AutoSize = true;
            this.YAZ0CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YAZ0CheckBox.Location = new System.Drawing.Point(6, 25);
            this.YAZ0CheckBox.Name = "YAZ0CheckBox";
            this.YAZ0CheckBox.Size = new System.Drawing.Size(173, 21);
            this.YAZ0CheckBox.TabIndex = 0;
            this.YAZ0CheckBox.Text = "Enable YAZ0 Encoding";
            this.YAZ0CheckBox.UseVisualStyleBackColor = true;
            this.YAZ0CheckBox.CheckedChanged += new System.EventHandler(this.YAZ0CheckBox_CheckedChanged);
            // 
            // FunSettingsGroupBox
            // 
            this.FunSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunSettingsGroupBox.Controls.Add(this.ShowSplashButton);
            this.FunSettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FunSettingsGroupBox.Location = new System.Drawing.Point(3, 366);
            this.FunSettingsGroupBox.Name = "FunSettingsGroupBox";
            this.FunSettingsGroupBox.Size = new System.Drawing.Size(435, 59);
            this.FunSettingsGroupBox.TabIndex = 4;
            this.FunSettingsGroupBox.TabStop = false;
            this.FunSettingsGroupBox.Text = "Fun";
            // 
            // ShowSplashButton
            // 
            this.ShowSplashButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowSplashButton.Location = new System.Drawing.Point(6, 25);
            this.ShowSplashButton.Name = "ShowSplashButton";
            this.ShowSplashButton.Size = new System.Drawing.Size(105, 28);
            this.ShowSplashButton.TabIndex = 0;
            this.ShowSplashButton.Text = "Splash Test";
            this.ShowSplashButton.UseVisualStyleBackColor = true;
            this.ShowSplashButton.Click += new System.EventHandler(this.ShowSplashButton_Click);
            // 
            // NoticeLabel
            // 
            this.NoticeLabel.AutoSize = true;
            this.NoticeLabel.Location = new System.Drawing.Point(22, 257);
            this.NoticeLabel.Name = "NoticeLabel";
            this.NoticeLabel.Size = new System.Drawing.Size(368, 78);
            this.NoticeLabel.TabIndex = 5;
            this.NoticeLabel.Text = resources.GetString("NoticeLabel.Text");
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NoticeLabel);
            this.Controls.Add(this.FunSettingsGroupBox);
            this.Controls.Add(this.InternalSettingsGroupBox);
            this.Controls.Add(this.VisualSettingsGroupBox);
            this.Controls.Add(this.AboutLabel);
            this.Controls.Add(this.LogoPictureBox);
            this.DoubleBuffered = true;
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(441, 441);
            this.Resize += new System.EventHandler(this.SettingsPanel_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.VisualSettingsGroupBox.ResumeLayout(false);
            this.VisualSettingsGroupBox.PerformLayout();
            this.InternalSettingsGroupBox.ResumeLayout(false);
            this.InternalSettingsGroupBox.PerformLayout();
            this.FunSettingsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.GroupBox VisualSettingsGroupBox;
        private System.Windows.Forms.CheckBox DarkModeCheckBox;
        private System.Windows.Forms.CheckBox UseHexCheckBox;
        private System.Windows.Forms.CheckBox LongNumberCheckBox;
        private System.Windows.Forms.GroupBox InternalSettingsGroupBox;
        private System.Windows.Forms.CheckBox YAZ0CheckBox;
        private System.Windows.Forms.CheckBox EnforceCompressCheckbox;
        private System.Windows.Forms.Label SplashLabel;
        private ColourComboBox SplashSizeComboBox;
        private System.Windows.Forms.GroupBox FunSettingsGroupBox;
        private System.Windows.Forms.Button ShowSplashButton;
        private System.Windows.Forms.CheckBox UniqueEditorsCheckbox;
        private System.Windows.Forms.CheckBox ShowAboutCheckBox;
        private System.Windows.Forms.CheckBox SfxCheckBox;
        private System.Windows.Forms.Label NoticeLabel;
    }
}
