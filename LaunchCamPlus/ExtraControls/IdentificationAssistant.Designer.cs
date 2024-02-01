namespace LaunchCamPlus
{
    partial class IdentificationAssistant
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
            PartLabel = new Label();
            CameraNumberLabel = new Label();
            EventLabel = new Label();
            CategoryLabel = new Label();
            ApplyButton = new Button();
            IDLabel = new Label();
            SubCamIDNumericUpDown = new ExtraControls.ColourNumericUpDown();
            CamIDNumericUpDown = new ExtraControls.ColourNumericUpDown();
            EventComboBox = new ExtraControls.ColourComboBox();
            CategoryComboBox = new ExtraControls.ColourComboBox();
            IDTextBox = new ExtraControls.ColourTextBox();
            GetNextFreeIDButton = new Button();
            ((System.ComponentModel.ISupportInitialize)SubCamIDNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CamIDNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // PartLabel
            // 
            PartLabel.Anchor = AnchorStyles.Top;
            PartLabel.AutoSize = true;
            PartLabel.Location = new Point(234, 60);
            PartLabel.Name = "PartLabel";
            PartLabel.Size = new Size(69, 13);
            PartLabel.TabIndex = 20;
            PartLabel.Text = "Part Number:";
            // 
            // CameraNumberLabel
            // 
            CameraNumberLabel.AutoSize = true;
            CameraNumberLabel.Location = new Point(3, 60);
            CameraNumberLabel.Name = "CameraNumberLabel";
            CameraNumberLabel.Size = new Size(60, 13);
            CameraNumberLabel.TabIndex = 18;
            CameraNumberLabel.Text = "Camera ID:";
            // 
            // EventLabel
            // 
            EventLabel.Anchor = AnchorStyles.Top;
            EventLabel.AutoSize = true;
            EventLabel.Location = new Point(265, 34);
            EventLabel.Name = "EventLabel";
            EventLabel.Size = new Size(38, 13);
            EventLabel.TabIndex = 16;
            EventLabel.Text = "Event:";
            // 
            // CategoryLabel
            // 
            CategoryLabel.AutoSize = true;
            CategoryLabel.Location = new Point(3, 34);
            CategoryLabel.Name = "CategoryLabel";
            CategoryLabel.Size = new Size(52, 13);
            CategoryLabel.TabIndex = 14;
            CategoryLabel.Text = "Category:";
            // 
            // ApplyButton
            // 
            ApplyButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            ApplyButton.Enabled = false;
            ApplyButton.FlatStyle = FlatStyle.Flat;
            ApplyButton.Location = new Point(554, 3);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(103, 77);
            ApplyButton.TabIndex = 13;
            ApplyButton.Text = "Apply to Selected";
            ApplyButton.UseVisualStyleBackColor = true;
            // 
            // IDLabel
            // 
            IDLabel.AutoSize = true;
            IDLabel.Location = new Point(3, 8);
            IDLabel.Name = "IDLabel";
            IDLabel.Size = new Size(21, 13);
            IDLabel.TabIndex = 11;
            IDLabel.Text = "ID:";
            // 
            // SubCamIDNumericUpDown
            // 
            SubCamIDNumericUpDown.Anchor = AnchorStyles.Top;
            SubCamIDNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            SubCamIDNumericUpDown.Location = new Point(309, 58);
            SubCamIDNumericUpDown.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            SubCamIDNumericUpDown.Name = "SubCamIDNumericUpDown";
            SubCamIDNumericUpDown.Size = new Size(239, 20);
            SubCamIDNumericUpDown.TabIndex = 21;
            SubCamIDNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // CamIDNumericUpDown
            // 
            CamIDNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            CamIDNumericUpDown.Location = new Point(69, 58);
            CamIDNumericUpDown.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            CamIDNumericUpDown.Name = "CamIDNumericUpDown";
            CamIDNumericUpDown.Size = new Size(159, 20);
            CamIDNumericUpDown.TabIndex = 19;
            CamIDNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // EventComboBox
            // 
            EventComboBox.Anchor = AnchorStyles.Top;
            EventComboBox.BorderColor = Color.FromArgb(200, 200, 200);
            EventComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            EventComboBox.FlatStyle = FlatStyle.Flat;
            EventComboBox.FormattingEnabled = true;
            EventComboBox.Location = new Point(309, 31);
            EventComboBox.Name = "EventComboBox";
            EventComboBox.Size = new Size(239, 21);
            EventComboBox.TabIndex = 17;
            EventComboBox.SelectedIndexChanged += EventComboBox_SelectedIndexChanged;
            // 
            // CategoryComboBox
            // 
            CategoryComboBox.BorderColor = Color.FromArgb(200, 200, 200);
            CategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CategoryComboBox.FlatStyle = FlatStyle.Flat;
            CategoryComboBox.FormattingEnabled = true;
            CategoryComboBox.Items.AddRange(new object[] { "Camera Area", "Spawn Point", "Event", "Other" });
            CategoryComboBox.Location = new Point(69, 31);
            CategoryComboBox.Name = "CategoryComboBox";
            CategoryComboBox.Size = new Size(159, 21);
            CategoryComboBox.TabIndex = 15;
            CategoryComboBox.SelectedIndexChanged += CategoryComboBox_SelectedIndexChanged;
            // 
            // IDTextBox
            // 
            IDTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            IDTextBox.Location = new Point(30, 5);
            IDTextBox.Name = "IDTextBox";
            IDTextBox.ReadOnly = true;
            IDTextBox.Size = new Size(410, 20);
            IDTextBox.TabIndex = 12;
            // 
            // GetNextFreeIDButton
            // 
            GetNextFreeIDButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GetNextFreeIDButton.FlatStyle = FlatStyle.Flat;
            GetNextFreeIDButton.Location = new Point(446, 3);
            GetNextFreeIDButton.Name = "GetNextFreeIDButton";
            GetNextFreeIDButton.Size = new Size(102, 23);
            GetNextFreeIDButton.TabIndex = 22;
            GetNextFreeIDButton.Text = "Get New Number";
            GetNextFreeIDButton.UseVisualStyleBackColor = true;
            GetNextFreeIDButton.Click += GetNextFreeIDButton_Click;
            // 
            // IdentificationAssistant
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(GetNextFreeIDButton);
            Controls.Add(SubCamIDNumericUpDown);
            Controls.Add(PartLabel);
            Controls.Add(CamIDNumericUpDown);
            Controls.Add(CameraNumberLabel);
            Controls.Add(EventComboBox);
            Controls.Add(EventLabel);
            Controls.Add(CategoryComboBox);
            Controls.Add(CategoryLabel);
            Controls.Add(ApplyButton);
            Controls.Add(IDTextBox);
            Controls.Add(IDLabel);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(660, 83);
            Name = "IdentificationAssistant";
            Size = new Size(660, 83);
            Resize += IdentificationAssistant_Resize;
            ((System.ComponentModel.ISupportInitialize)SubCamIDNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CamIDNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private LaunchCamPlus.ExtraControls.ColourNumericUpDown SubCamIDNumericUpDown;
        private System.Windows.Forms.Label PartLabel;
        private LaunchCamPlus.ExtraControls.ColourNumericUpDown CamIDNumericUpDown;
        private System.Windows.Forms.Label CameraNumberLabel;
        private LaunchCamPlus.ExtraControls.ColourComboBox EventComboBox;
        private System.Windows.Forms.Label EventLabel;
        private LaunchCamPlus.ExtraControls.ColourComboBox CategoryComboBox;
        private System.Windows.Forms.Label CategoryLabel;
        private LaunchCamPlus.ExtraControls.ColourTextBox IDTextBox;
        private System.Windows.Forms.Label IDLabel;
        public System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button GetNextFreeIDButton;
    }
}
