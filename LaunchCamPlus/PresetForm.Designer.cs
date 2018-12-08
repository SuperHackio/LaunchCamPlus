namespace LaunchCamPlus
{
    partial class PresetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresetForm));
            this.SaveButton = new System.Windows.Forms.Button();
            this.PresetNameTextBox = new System.Windows.Forms.TextBox();
            this.PresetCreatorTextBox = new System.Windows.Forms.TextBox();
            this.InfoLabel1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PresetListBox = new System.Windows.Forms.ListBox();
            this.CameraListBox = new System.Windows.Forms.ListBox();
            this.RemoveCamButton = new System.Windows.Forms.Button();
            this.AddCamButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(12, 286);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(440, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save Preset";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PresetNameTextBox
            // 
            this.PresetNameTextBox.Location = new System.Drawing.Point(93, 12);
            this.PresetNameTextBox.MaxLength = 64;
            this.PresetNameTextBox.Name = "PresetNameTextBox";
            this.PresetNameTextBox.Size = new System.Drawing.Size(359, 20);
            this.PresetNameTextBox.TabIndex = 1;
            this.PresetNameTextBox.TextChanged += new System.EventHandler(this.PresetNameTextBox_TextChanged);
            // 
            // PresetCreatorTextBox
            // 
            this.PresetCreatorTextBox.Location = new System.Drawing.Point(93, 38);
            this.PresetCreatorTextBox.MaxLength = 64;
            this.PresetCreatorTextBox.Name = "PresetCreatorTextBox";
            this.PresetCreatorTextBox.Size = new System.Drawing.Size(359, 20);
            this.PresetCreatorTextBox.TabIndex = 2;
            this.PresetCreatorTextBox.TextChanged += new System.EventHandler(this.PresetCreatorTextBox_TextChanged);
            // 
            // InfoLabel1
            // 
            this.InfoLabel1.AutoSize = true;
            this.InfoLabel1.Location = new System.Drawing.Point(12, 15);
            this.InfoLabel1.Name = "InfoLabel1";
            this.InfoLabel1.Size = new System.Drawing.Size(71, 13);
            this.InfoLabel1.TabIndex = 3;
            this.InfoLabel1.Text = "Preset Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Creator Name:";
            // 
            // PresetListBox
            // 
            this.PresetListBox.FormattingEnabled = true;
            this.PresetListBox.HorizontalScrollbar = true;
            this.PresetListBox.Location = new System.Drawing.Point(252, 65);
            this.PresetListBox.Name = "PresetListBox";
            this.PresetListBox.Size = new System.Drawing.Size(200, 212);
            this.PresetListBox.TabIndex = 5;
            // 
            // CameraListBox
            // 
            this.CameraListBox.FormattingEnabled = true;
            this.CameraListBox.HorizontalScrollbar = true;
            this.CameraListBox.Location = new System.Drawing.Point(12, 65);
            this.CameraListBox.Name = "CameraListBox";
            this.CameraListBox.Size = new System.Drawing.Size(200, 212);
            this.CameraListBox.TabIndex = 6;
            // 
            // RemoveCamButton
            // 
            this.RemoveCamButton.BackgroundImage = global::LaunchCamPlus.Properties.Resources.CheveronArrowL;
            this.RemoveCamButton.Location = new System.Drawing.Point(218, 230);
            this.RemoveCamButton.Name = "RemoveCamButton";
            this.RemoveCamButton.Size = new System.Drawing.Size(28, 47);
            this.RemoveCamButton.TabIndex = 8;
            this.RemoveCamButton.UseVisualStyleBackColor = true;
            this.RemoveCamButton.Click += new System.EventHandler(this.RemoveCamButton_Click);
            // 
            // AddCamButton
            // 
            this.AddCamButton.BackgroundImage = global::LaunchCamPlus.Properties.Resources.CheveronArrowR;
            this.AddCamButton.Location = new System.Drawing.Point(218, 64);
            this.AddCamButton.Name = "AddCamButton";
            this.AddCamButton.Size = new System.Drawing.Size(28, 47);
            this.AddCamButton.TabIndex = 7;
            this.AddCamButton.UseVisualStyleBackColor = true;
            this.AddCamButton.Click += new System.EventHandler(this.AddCamButton_Click);
            // 
            // PresetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 321);
            this.Controls.Add(this.RemoveCamButton);
            this.Controls.Add(this.AddCamButton);
            this.Controls.Add(this.CameraListBox);
            this.Controls.Add(this.PresetListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InfoLabel1);
            this.Controls.Add(this.PresetCreatorTextBox);
            this.Controls.Add(this.PresetNameTextBox);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PresetForm";
            this.Text = "Launch Cam Plus - Preset Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox PresetNameTextBox;
        private System.Windows.Forms.TextBox PresetCreatorTextBox;
        private System.Windows.Forms.Label InfoLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox PresetListBox;
        private System.Windows.Forms.ListBox CameraListBox;
        private System.Windows.Forms.Button AddCamButton;
        private System.Windows.Forms.Button RemoveCamButton;
    }
}