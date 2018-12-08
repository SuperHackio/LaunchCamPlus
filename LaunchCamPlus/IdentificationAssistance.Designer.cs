namespace LaunchCamPlus
{
    partial class IdentificationAssistance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdentificationAssistance));
            this.label1 = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.EventComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CamIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RecalcTimer = new System.Windows.Forms.Timer(this.components);
            this.SubCamIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.AddSubCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.CamIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubCamIDNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(39, 14);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(184, 20);
            this.IDTextBox.TabIndex = 1;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(229, 12);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(103, 23);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "Apply to Selected";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Camera Category:";
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Items.AddRange(new object[] {
            "Camera Area",
            "Spawn Point",
            "Event",
            "Other"});
            this.CategoryComboBox.Location = new System.Drawing.Point(109, 40);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(223, 21);
            this.CategoryComboBox.TabIndex = 4;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // EventComboBox
            // 
            this.EventComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EventComboBox.Enabled = false;
            this.EventComboBox.FormattingEnabled = true;
            this.EventComboBox.Location = new System.Drawing.Point(109, 67);
            this.EventComboBox.Name = "EventComboBox";
            this.EventComboBox.Size = new System.Drawing.Size(136, 21);
            this.EventComboBox.TabIndex = 6;
            this.EventComboBox.SelectedIndexChanged += new System.EventHandler(this.EventComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Event ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Camera ID:";
            // 
            // CamIDNumericUpDown
            // 
            this.CamIDNumericUpDown.Location = new System.Drawing.Point(109, 94);
            this.CamIDNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.CamIDNumericUpDown.Name = "CamIDNumericUpDown";
            this.CamIDNumericUpDown.Size = new System.Drawing.Size(223, 20);
            this.CamIDNumericUpDown.TabIndex = 8;
            // 
            // RecalcTimer
            // 
            this.RecalcTimer.Interval = 1000;
            this.RecalcTimer.Tick += new System.EventHandler(this.RecalcTimer_Tick);
            // 
            // SubCamIDNumericUpDown
            // 
            this.SubCamIDNumericUpDown.Location = new System.Drawing.Point(109, 120);
            this.SubCamIDNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.SubCamIDNumericUpDown.Name = "SubCamIDNumericUpDown";
            this.SubCamIDNumericUpDown.Size = new System.Drawing.Size(223, 20);
            this.SubCamIDNumericUpDown.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Minor Camera ID:";
            // 
            // AddSubCheckBox
            // 
            this.AddSubCheckBox.AutoSize = true;
            this.AddSubCheckBox.Location = new System.Drawing.Point(251, 70);
            this.AddSubCheckBox.Name = "AddSubCheckBox";
            this.AddSubCheckBox.Size = new System.Drawing.Size(81, 17);
            this.AddSubCheckBox.TabIndex = 11;
            this.AddSubCheckBox.Text = "Add Sub ID";
            this.AddSubCheckBox.UseVisualStyleBackColor = true;
            // 
            // IdentificationAssistance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 151);
            this.Controls.Add(this.AddSubCheckBox);
            this.Controls.Add(this.SubCamIDNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CamIDNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EventComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IdentificationAssistance";
            this.Text = "Launch Cam Plus - Camera ID Assistance";
            ((System.ComponentModel.ISupportInitialize)(this.CamIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubCamIDNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.ComboBox EventComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown CamIDNumericUpDown;
        private System.Windows.Forms.Timer RecalcTimer;
        private System.Windows.Forms.NumericUpDown SubCamIDNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox AddSubCheckBox;
    }
}