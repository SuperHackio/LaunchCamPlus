namespace LaunchCamPlus.CameraPanels
{
    partial class AnimCameraPanel
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
            Num2ColourNumericUpDown = new LaunchCamPlus.ExtraControls.ColourNumericUpDown();
            Num2Label = new Label();
            Num1ColourNumericUpDown = new LaunchCamPlus.ExtraControls.ColourNumericUpDown();
            Num1Label = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Num2ColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Num1ColourNumericUpDown).BeginInit();
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
            // Num2ColourNumericUpDown
            // 
            Num2ColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            Num2ColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            Num2ColourNumericUpDown.Location = new Point(215, 221);
            Num2ColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            Num2ColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            Num2ColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            Num2ColourNumericUpDown.Name = "Num2ColourNumericUpDown";
            Num2ColourNumericUpDown.Size = new Size(134, 20);
            Num2ColourNumericUpDown.TabIndex = 85;
            Num2ColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // Num2Label
            // 
            Num2Label.AutoSize = true;
            Num2Label.Font = new Font("Microsoft Sans Serif", 8.25F);
            Num2Label.Location = new Point(128, 223);
            Num2Label.Name = "Num2Label";
            Num2Label.Size = new Size(81, 13);
            Num2Label.TabIndex = 84;
            Num2Label.Text = "CANM Duration";
            // 
            // Num1ColourNumericUpDown
            // 
            Num1ColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            Num1ColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            Num1ColourNumericUpDown.Hexadecimal = true;
            Num1ColourNumericUpDown.Location = new Point(215, 199);
            Num1ColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            Num1ColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            Num1ColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            Num1ColourNumericUpDown.Name = "Num1ColourNumericUpDown";
            Num1ColourNumericUpDown.Size = new Size(134, 20);
            Num1ColourNumericUpDown.TabIndex = 83;
            Num1ColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // Num1Label
            // 
            Num1Label.AutoSize = true;
            Num1Label.Font = new Font("Microsoft Sans Serif", 8.25F);
            Num1Label.Location = new Point(71, 201);
            Num1Label.Name = "Num1Label";
            Num1Label.Size = new Size(138, 13);
            Num1Label.TabIndex = 82;
            Num1Label.Text = "CANM File Memory Address";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F);
            label1.Location = new Point(25, 142);
            label1.Name = "label1";
            label1.Size = new Size(324, 39);
            label1.TabIndex = 86;
            label1.Text = "This camera type cannot be used.\r\nThe game uses this to represent CANM animations.\r\nThis is here for viewing purposes, if you were to paste camera data.";
            // 
            // AnimCameraPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(Num2ColourNumericUpDown);
            Controls.Add(Num2Label);
            Controls.Add(Num1ColourNumericUpDown);
            Controls.Add(Num1Label);
            Controls.Add(VersionColourNumericUpDown);
            Controls.Add(VersionLabel);
            Name = "AnimCameraPanel";
            Controls.SetChildIndex(VersionLabel, 0);
            Controls.SetChildIndex(VersionColourNumericUpDown, 0);
            Controls.SetChildIndex(Num1Label, 0);
            Controls.SetChildIndex(Num1ColourNumericUpDown, 0);
            Controls.SetChildIndex(Num2Label, 0);
            Controls.SetChildIndex(Num2ColourNumericUpDown, 0);
            Controls.SetChildIndex(label1, 0);
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)Num2ColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)Num1ColourNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ExtraControls.ColourNumericUpDown VersionColourNumericUpDown;
        private Label VersionLabel;
        private ExtraControls.ColourNumericUpDown Num2ColourNumericUpDown;
        private Label Num2Label;
        private ExtraControls.ColourNumericUpDown Num1ColourNumericUpDown;
        private Label Num1Label;
        private Label label1;
    }
}
