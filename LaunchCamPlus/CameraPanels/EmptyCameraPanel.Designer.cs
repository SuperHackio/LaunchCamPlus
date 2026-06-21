namespace LaunchCamPlus.CameraPanels
{
    partial class EmptyCameraPanel
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
            VersionColourNumericUpDown = new LaunchCamPlus.ExtraControls.ColourNumericUpDown();
            VersionLabel = new Label();
            InfoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // VersionColourNumericUpDown
            // 
            VersionColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            VersionColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            VersionColourNumericUpDown.Location = new Point(65, 54);
            VersionColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            VersionColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            VersionColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            VersionColourNumericUpDown.Name = "VersionColourNumericUpDown";
            VersionColourNumericUpDown.Size = new Size(86, 20);
            VersionColourNumericUpDown.TabIndex = 81;
            VersionColourNumericUpDown.TextValue = new decimal(new int[] { 196631, 0, 0, 0 });
            VersionColourNumericUpDown.Value = new decimal(new int[] { 196631, 0, 0, 0 });
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            VersionLabel.Location = new Point(2, 56);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(42, 13);
            VersionLabel.TabIndex = 80;
            VersionLabel.Text = "Version";
            // 
            // InfoLabel
            // 
            InfoLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            InfoLabel.Location = new Point(0, 75);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(441, 366);
            InfoLabel.TabIndex = 86;
            InfoLabel.Text = "This camera type has no properties";
            InfoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EmptyCameraPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(VersionColourNumericUpDown);
            Controls.Add(VersionLabel);
            Controls.Add(InfoLabel);
            Name = "EmptyCameraPanel";
            Controls.SetChildIndex(InfoLabel, 0);
            Controls.SetChildIndex(VersionLabel, 0);
            Controls.SetChildIndex(VersionColourNumericUpDown, 0);
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ExtraControls.ColourNumericUpDown VersionColourNumericUpDown;
        private Label VersionLabel;
        private Label InfoLabel;
    }
}
