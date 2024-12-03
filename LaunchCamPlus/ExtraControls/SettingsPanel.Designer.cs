namespace LaunchCamPlus.ExtraControls
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
            LogoPictureBox = new PictureBox();
            AboutLabel = new Label();
            VisualSettingsGroupBox = new GroupBox();
            ShowAboutCheckBox = new CheckBox();
            UniqueEditorsCheckbox = new CheckBox();
            SplashSizeComboBox = new ColourComboBox();
            SplashLabel = new Label();
            LongNumberCheckBox = new CheckBox();
            UseHexCheckBox = new CheckBox();
            DarkModeCheckBox = new CheckBox();
            InternalSettingsGroupBox = new GroupBox();
            IsUseSMG1DefaultsCheckBox = new CheckBox();
            EnforceCompressCheckbox = new CheckBox();
            YAZ0CheckBox = new CheckBox();
            FunSettingsGroupBox = new GroupBox();
            ShowSplashButton = new Button();
            NoticeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
            VisualSettingsGroupBox.SuspendLayout();
            InternalSettingsGroupBox.SuspendLayout();
            FunSettingsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // LogoPictureBox
            // 
            LogoPictureBox.Dock = DockStyle.Top;
            LogoPictureBox.Image = Properties.Resources.LCPLogo;
            LogoPictureBox.InitialImage = null;
            LogoPictureBox.Location = new Point(0, 0);
            LogoPictureBox.Name = "LogoPictureBox";
            LogoPictureBox.Size = new Size(441, 50);
            LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            LogoPictureBox.TabIndex = 0;
            LogoPictureBox.TabStop = false;
            // 
            // AboutLabel
            // 
            AboutLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AboutLabel.AutoSize = true;
            AboutLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            AboutLabel.Location = new Point(237, 428);
            AboutLabel.Name = "AboutLabel";
            AboutLabel.Size = new Size(201, 13);
            AboutLabel.TabIndex = 1;
            AboutLabel.Text = "© Super Hackio Incorporated 2018-2024";
            // 
            // VisualSettingsGroupBox
            // 
            VisualSettingsGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VisualSettingsGroupBox.Controls.Add(ShowAboutCheckBox);
            VisualSettingsGroupBox.Controls.Add(UniqueEditorsCheckbox);
            VisualSettingsGroupBox.Controls.Add(SplashSizeComboBox);
            VisualSettingsGroupBox.Controls.Add(SplashLabel);
            VisualSettingsGroupBox.Controls.Add(LongNumberCheckBox);
            VisualSettingsGroupBox.Controls.Add(UseHexCheckBox);
            VisualSettingsGroupBox.Controls.Add(DarkModeCheckBox);
            VisualSettingsGroupBox.Font = new Font("Microsoft Sans Serif", 12F);
            VisualSettingsGroupBox.Location = new Point(3, 56);
            VisualSettingsGroupBox.Name = "VisualSettingsGroupBox";
            VisualSettingsGroupBox.Size = new Size(435, 118);
            VisualSettingsGroupBox.TabIndex = 2;
            VisualSettingsGroupBox.TabStop = false;
            VisualSettingsGroupBox.Text = "Visuals and Audio";
            // 
            // ShowAboutCheckBox
            // 
            ShowAboutCheckBox.AutoSize = true;
            ShowAboutCheckBox.Font = new Font("Microsoft Sans Serif", 10F);
            ShowAboutCheckBox.Location = new Point(137, 52);
            ShowAboutCheckBox.Name = "ShowAboutCheckBox";
            ShowAboutCheckBox.Size = new Size(170, 21);
            ShowAboutCheckBox.TabIndex = 6;
            ShowAboutCheckBox.Text = "Load About on Startup";
            ShowAboutCheckBox.UseVisualStyleBackColor = true;
            ShowAboutCheckBox.CheckedChanged += ShowAboutCheckBox_CheckedChanged;
            // 
            // UniqueEditorsCheckbox
            // 
            UniqueEditorsCheckbox.AutoSize = true;
            UniqueEditorsCheckbox.Font = new Font("Microsoft Sans Serif", 10F);
            UniqueEditorsCheckbox.Location = new Point(6, 52);
            UniqueEditorsCheckbox.Name = "UniqueEditorsCheckbox";
            UniqueEditorsCheckbox.Size = new Size(120, 21);
            UniqueEditorsCheckbox.TabIndex = 5;
            UniqueEditorsCheckbox.Text = "Unique Editors";
            UniqueEditorsCheckbox.UseVisualStyleBackColor = true;
            UniqueEditorsCheckbox.CheckedChanged += UniqueEditorsCheckbox_CheckedChanged;
            // 
            // SplashSizeComboBox
            // 
            SplashSizeComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SplashSizeComboBox.BorderColor = Color.FromArgb(200, 200, 200);
            SplashSizeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SplashSizeComboBox.FlatStyle = FlatStyle.Flat;
            SplashSizeComboBox.Font = new Font("Microsoft Sans Serif", 10F);
            SplashSizeComboBox.FormattingEnabled = true;
            SplashSizeComboBox.Items.AddRange(new object[] { "846x462", "1920x1080" });
            SplashSizeComboBox.Location = new Point(143, 88);
            SplashSizeComboBox.Name = "SplashSizeComboBox";
            SplashSizeComboBox.Size = new Size(286, 24);
            SplashSizeComboBox.TabIndex = 4;
            SplashSizeComboBox.SelectedIndexChanged += SplashSizeComboBox_SelectedIndexChanged;
            // 
            // SplashLabel
            // 
            SplashLabel.AutoSize = true;
            SplashLabel.Font = new Font("Microsoft Sans Serif", 10F);
            SplashLabel.Location = new Point(6, 91);
            SplashLabel.Name = "SplashLabel";
            SplashLabel.Size = new Size(131, 17);
            SplashLabel.TabIndex = 3;
            SplashLabel.Text = "Splash Screen Size";
            // 
            // LongNumberCheckBox
            // 
            LongNumberCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LongNumberCheckBox.AutoSize = true;
            LongNumberCheckBox.Font = new Font("Microsoft Sans Serif", 10F);
            LongNumberCheckBox.Location = new Point(316, 25);
            LongNumberCheckBox.Name = "LongNumberCheckBox";
            LongNumberCheckBox.Size = new Size(113, 21);
            LongNumberCheckBox.TabIndex = 2;
            LongNumberCheckBox.Text = "Pad Numbers";
            LongNumberCheckBox.UseVisualStyleBackColor = true;
            LongNumberCheckBox.CheckedChanged += LongNumberCheckBox_CheckedChanged;
            // 
            // UseHexCheckBox
            // 
            UseHexCheckBox.Anchor = AnchorStyles.Top;
            UseHexCheckBox.AutoSize = true;
            UseHexCheckBox.Font = new Font("Microsoft Sans Serif", 10F);
            UseHexCheckBox.Location = new Point(137, 25);
            UseHexCheckBox.Name = "UseHexCheckBox";
            UseHexCheckBox.Size = new Size(141, 21);
            UseHexCheckBox.TabIndex = 1;
            UseHexCheckBox.Text = "Use Hex Numbers";
            UseHexCheckBox.UseVisualStyleBackColor = true;
            UseHexCheckBox.CheckedChanged += UseHexCheckBox_CheckedChanged;
            // 
            // DarkModeCheckBox
            // 
            DarkModeCheckBox.AutoSize = true;
            DarkModeCheckBox.Font = new Font("Microsoft Sans Serif", 10F);
            DarkModeCheckBox.Location = new Point(6, 25);
            DarkModeCheckBox.Name = "DarkModeCheckBox";
            DarkModeCheckBox.Size = new Size(96, 21);
            DarkModeCheckBox.TabIndex = 0;
            DarkModeCheckBox.Text = "Dark Mode";
            DarkModeCheckBox.UseVisualStyleBackColor = true;
            DarkModeCheckBox.CheckedChanged += DarkModeCheckBox_CheckedChanged;
            // 
            // InternalSettingsGroupBox
            // 
            InternalSettingsGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            InternalSettingsGroupBox.Controls.Add(IsUseSMG1DefaultsCheckBox);
            InternalSettingsGroupBox.Controls.Add(EnforceCompressCheckbox);
            InternalSettingsGroupBox.Controls.Add(YAZ0CheckBox);
            InternalSettingsGroupBox.Font = new Font("Microsoft Sans Serif", 12F);
            InternalSettingsGroupBox.Location = new Point(3, 180);
            InternalSettingsGroupBox.Name = "InternalSettingsGroupBox";
            InternalSettingsGroupBox.Size = new Size(435, 80);
            InternalSettingsGroupBox.TabIndex = 3;
            InternalSettingsGroupBox.TabStop = false;
            InternalSettingsGroupBox.Text = "Internals";
            // 
            // IsUseSMG1DefaultsCheckBox
            // 
            IsUseSMG1DefaultsCheckBox.AutoSize = true;
            IsUseSMG1DefaultsCheckBox.Font = new Font("Microsoft Sans Serif", 10F);
            IsUseSMG1DefaultsCheckBox.Location = new Point(6, 52);
            IsUseSMG1DefaultsCheckBox.Name = "IsUseSMG1DefaultsCheckBox";
            IsUseSMG1DefaultsCheckBox.Size = new Size(204, 21);
            IsUseSMG1DefaultsCheckBox.TabIndex = 2;
            IsUseSMG1DefaultsCheckBox.Text = "Use SMG1 Camera Defaults";
            IsUseSMG1DefaultsCheckBox.UseVisualStyleBackColor = true;
            IsUseSMG1DefaultsCheckBox.CheckedChanged += IsUseSMG1DefaultsCheckBox_CheckedChanged;
            // 
            // EnforceCompressCheckbox
            // 
            EnforceCompressCheckbox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EnforceCompressCheckbox.AutoSize = true;
            EnforceCompressCheckbox.Font = new Font("Microsoft Sans Serif", 10F);
            EnforceCompressCheckbox.Location = new Point(244, 25);
            EnforceCompressCheckbox.Name = "EnforceCompressCheckbox";
            EnforceCompressCheckbox.Size = new Size(185, 21);
            EnforceCompressCheckbox.TabIndex = 1;
            EnforceCompressCheckbox.Text = "Enable Advanced Saving";
            EnforceCompressCheckbox.UseVisualStyleBackColor = true;
            EnforceCompressCheckbox.CheckedChanged += EnforceCompressCheckbox_CheckedChanged;
            // 
            // YAZ0CheckBox
            // 
            YAZ0CheckBox.AutoSize = true;
            YAZ0CheckBox.Font = new Font("Microsoft Sans Serif", 10F);
            YAZ0CheckBox.Location = new Point(6, 25);
            YAZ0CheckBox.Name = "YAZ0CheckBox";
            YAZ0CheckBox.Size = new Size(173, 21);
            YAZ0CheckBox.TabIndex = 0;
            YAZ0CheckBox.Text = "Enable YAZ0 Encoding";
            YAZ0CheckBox.UseVisualStyleBackColor = true;
            YAZ0CheckBox.CheckedChanged += YAZ0CheckBox_CheckedChanged;
            // 
            // FunSettingsGroupBox
            // 
            FunSettingsGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FunSettingsGroupBox.Controls.Add(ShowSplashButton);
            FunSettingsGroupBox.Font = new Font("Microsoft Sans Serif", 12F);
            FunSettingsGroupBox.Location = new Point(3, 366);
            FunSettingsGroupBox.Name = "FunSettingsGroupBox";
            FunSettingsGroupBox.Size = new Size(435, 59);
            FunSettingsGroupBox.TabIndex = 4;
            FunSettingsGroupBox.TabStop = false;
            FunSettingsGroupBox.Text = "Fun";
            // 
            // ShowSplashButton
            // 
            ShowSplashButton.FlatStyle = FlatStyle.Flat;
            ShowSplashButton.Location = new Point(6, 25);
            ShowSplashButton.Name = "ShowSplashButton";
            ShowSplashButton.Size = new Size(105, 28);
            ShowSplashButton.TabIndex = 0;
            ShowSplashButton.Text = "Splash Test";
            ShowSplashButton.UseVisualStyleBackColor = true;
            ShowSplashButton.Click += ShowSplashButton_Click;
            // 
            // NoticeLabel
            // 
            NoticeLabel.Anchor = AnchorStyles.Top;
            NoticeLabel.AutoSize = true;
            NoticeLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            NoticeLabel.Location = new Point(9, 274);
            NoticeLabel.Name = "NoticeLabel";
            NoticeLabel.Size = new Size(428, 78);
            NoticeLabel.TabIndex = 5;
            NoticeLabel.Text = resources.GetString("NoticeLabel.Text");
            // 
            // SettingsPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(NoticeLabel);
            Controls.Add(FunSettingsGroupBox);
            Controls.Add(InternalSettingsGroupBox);
            Controls.Add(VisualSettingsGroupBox);
            Controls.Add(AboutLabel);
            Controls.Add(LogoPictureBox);
            DoubleBuffered = true;
            Name = "SettingsPanel";
            Size = new Size(441, 441);
            Resize += SettingsPanel_Resize;
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).EndInit();
            VisualSettingsGroupBox.ResumeLayout(false);
            VisualSettingsGroupBox.PerformLayout();
            InternalSettingsGroupBox.ResumeLayout(false);
            InternalSettingsGroupBox.PerformLayout();
            FunSettingsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Label NoticeLabel;
        private CheckBox IsUseSMG1DefaultsCheckBox;
    }
}
