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
            this.PartLabel = new System.Windows.Forms.Label();
            this.CameraNumberLabel = new System.Windows.Forms.Label();
            this.EventLabel = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.IDLabel = new System.Windows.Forms.Label();
            this.SubCamIDNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.CamIDNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.EventComboBox = new LaunchCamPlus.ColourComboBox();
            this.CategoryComboBox = new LaunchCamPlus.ColourComboBox();
            this.IDTextBox = new LaunchCamPlus.ColourTextBox();
            this.GetNextFreeIDButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SubCamIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamIDNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // PartLabel
            // 
            this.PartLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PartLabel.AutoSize = true;
            this.PartLabel.Location = new System.Drawing.Point(234, 60);
            this.PartLabel.Name = "PartLabel";
            this.PartLabel.Size = new System.Drawing.Size(69, 13);
            this.PartLabel.TabIndex = 20;
            this.PartLabel.Text = "Part Number:";
            // 
            // CameraNumberLabel
            // 
            this.CameraNumberLabel.AutoSize = true;
            this.CameraNumberLabel.Location = new System.Drawing.Point(3, 60);
            this.CameraNumberLabel.Name = "CameraNumberLabel";
            this.CameraNumberLabel.Size = new System.Drawing.Size(60, 13);
            this.CameraNumberLabel.TabIndex = 18;
            this.CameraNumberLabel.Text = "Camera ID:";
            // 
            // EventLabel
            // 
            this.EventLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EventLabel.AutoSize = true;
            this.EventLabel.Location = new System.Drawing.Point(265, 34);
            this.EventLabel.Name = "EventLabel";
            this.EventLabel.Size = new System.Drawing.Size(38, 13);
            this.EventLabel.TabIndex = 16;
            this.EventLabel.Text = "Event:";
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(3, 34);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(52, 13);
            this.CategoryLabel.TabIndex = 14;
            this.CategoryLabel.Text = "Category:";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Enabled = false;
            this.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyButton.Location = new System.Drawing.Point(554, 3);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(103, 77);
            this.ApplyButton.TabIndex = 13;
            this.ApplyButton.Text = "Apply to Selected";
            this.ApplyButton.UseVisualStyleBackColor = true;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(3, 8);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(21, 13);
            this.IDLabel.TabIndex = 11;
            this.IDLabel.Text = "ID:";
            // 
            // SubCamIDNumericUpDown
            // 
            this.SubCamIDNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SubCamIDNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.SubCamIDNumericUpDown.Location = new System.Drawing.Point(309, 58);
            this.SubCamIDNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.SubCamIDNumericUpDown.Name = "SubCamIDNumericUpDown";
            this.SubCamIDNumericUpDown.Size = new System.Drawing.Size(239, 20);
            this.SubCamIDNumericUpDown.TabIndex = 21;
            this.SubCamIDNumericUpDown.ValueChanged += new System.EventHandler(this.SubCamIDNumericUpDown_ValueChanged);
            // 
            // CamIDNumericUpDown
            // 
            this.CamIDNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CamIDNumericUpDown.Location = new System.Drawing.Point(69, 58);
            this.CamIDNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.CamIDNumericUpDown.Name = "CamIDNumericUpDown";
            this.CamIDNumericUpDown.Size = new System.Drawing.Size(159, 20);
            this.CamIDNumericUpDown.TabIndex = 19;
            this.CamIDNumericUpDown.ValueChanged += new System.EventHandler(this.CamIDNumericUpDown_ValueChanged);
            // 
            // EventComboBox
            // 
            this.EventComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EventComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.EventComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EventComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EventComboBox.FormattingEnabled = true;
            this.EventComboBox.Location = new System.Drawing.Point(309, 31);
            this.EventComboBox.Name = "EventComboBox";
            this.EventComboBox.Size = new System.Drawing.Size(239, 21);
            this.EventComboBox.TabIndex = 17;
            this.EventComboBox.SelectedIndexChanged += new System.EventHandler(this.EventComboBox_SelectedIndexChanged);
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Items.AddRange(new object[] {
            "Camera Area",
            "Spawn Point",
            "Event",
            "Other"});
            this.CategoryComboBox.Location = new System.Drawing.Point(69, 31);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(159, 21);
            this.CategoryComboBox.TabIndex = 15;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // IDTextBox
            // 
            this.IDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IDTextBox.Location = new System.Drawing.Point(30, 5);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.ReadOnly = true;
            this.IDTextBox.Size = new System.Drawing.Size(410, 20);
            this.IDTextBox.TabIndex = 12;
            // 
            // GetNextFreeIDButton
            // 
            this.GetNextFreeIDButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetNextFreeIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetNextFreeIDButton.Location = new System.Drawing.Point(446, 3);
            this.GetNextFreeIDButton.Name = "GetNextFreeIDButton";
            this.GetNextFreeIDButton.Size = new System.Drawing.Size(102, 23);
            this.GetNextFreeIDButton.TabIndex = 22;
            this.GetNextFreeIDButton.Text = "Get New Number";
            this.GetNextFreeIDButton.UseVisualStyleBackColor = true;
            this.GetNextFreeIDButton.Click += new System.EventHandler(this.GetNextFreeIDButton_Click);
            // 
            // IdentificationAssistant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GetNextFreeIDButton);
            this.Controls.Add(this.SubCamIDNumericUpDown);
            this.Controls.Add(this.PartLabel);
            this.Controls.Add(this.CamIDNumericUpDown);
            this.Controls.Add(this.CameraNumberLabel);
            this.Controls.Add(this.EventComboBox);
            this.Controls.Add(this.EventLabel);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.IDLabel);
            this.MinimumSize = new System.Drawing.Size(660, 83);
            this.Name = "IdentificationAssistant";
            this.Size = new System.Drawing.Size(660, 83);
            this.Resize += new System.EventHandler(this.IdentificationAssistant_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.SubCamIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamIDNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ColourNumericUpDown SubCamIDNumericUpDown;
        private System.Windows.Forms.Label PartLabel;
        private ColourNumericUpDown CamIDNumericUpDown;
        private System.Windows.Forms.Label CameraNumberLabel;
        private ColourComboBox EventComboBox;
        private System.Windows.Forms.Label EventLabel;
        private ColourComboBox CategoryComboBox;
        private System.Windows.Forms.Label CategoryLabel;
        private ColourTextBox IDTextBox;
        private System.Windows.Forms.Label IDLabel;
        public System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button GetNextFreeIDButton;
    }
}
