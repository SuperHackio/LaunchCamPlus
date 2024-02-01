namespace LaunchCamPlus.ExtraControls
{
    partial class CameraLookOffsetControl
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
            LookOffsetGroupBox = new GroupBox();
            LOfsErpOffCheckBox = new CheckBox();
            LOffsetVColourNumericUpDown = new ColourNumericUpDown();
            label2 = new Label();
            label1 = new Label();
            LOffsetColourNumericUpDown = new ColourNumericUpDown();
            LookOffsetGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LOffsetVColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LOffsetColourNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // LookOffsetGroupBox
            // 
            LookOffsetGroupBox.Controls.Add(LOfsErpOffCheckBox);
            LookOffsetGroupBox.Controls.Add(LOffsetVColourNumericUpDown);
            LookOffsetGroupBox.Controls.Add(label2);
            LookOffsetGroupBox.Controls.Add(label1);
            LookOffsetGroupBox.Controls.Add(LOffsetColourNumericUpDown);
            LookOffsetGroupBox.Dock = DockStyle.Fill;
            LookOffsetGroupBox.Location = new Point(0, 0);
            LookOffsetGroupBox.Name = "LookOffsetGroupBox";
            LookOffsetGroupBox.Size = new Size(138, 97);
            LookOffsetGroupBox.TabIndex = 0;
            LookOffsetGroupBox.TabStop = false;
            LookOffsetGroupBox.Text = "Look Offset";
            // 
            // LOfsErpOffCheckBox
            // 
            LOfsErpOffCheckBox.AutoSize = true;
            LOfsErpOffCheckBox.Location = new Point(6, 18);
            LOfsErpOffCheckBox.Name = "LOfsErpOffCheckBox";
            LOfsErpOffCheckBox.Size = new Size(116, 19);
            LOfsErpOffCheckBox.TabIndex = 8;
            LOfsErpOffCheckBox.Text = "Use Interpolation";
            LOfsErpOffCheckBox.UseVisualStyleBackColor = true;
            // 
            // LOffsetVColourNumericUpDown
            // 
            LOffsetVColourNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LOffsetVColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            LOffsetVColourNumericUpDown.DecimalPlaces = 3;
            LOffsetVColourNumericUpDown.Location = new Point(62, 70);
            LOffsetVColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            LOffsetVColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            LOffsetVColourNumericUpDown.Name = "LOffsetVColourNumericUpDown";
            LOffsetVColourNumericUpDown.Size = new Size(70, 23);
            LOffsetVColourNumericUpDown.TabIndex = 6;
            LOffsetVColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 72);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 7;
            label2.Text = "Height";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 43);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 5;
            label1.Text = "Forward";
            // 
            // LOffsetColourNumericUpDown
            // 
            LOffsetColourNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LOffsetColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            LOffsetColourNumericUpDown.DecimalPlaces = 3;
            LOffsetColourNumericUpDown.Location = new Point(62, 41);
            LOffsetColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            LOffsetColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            LOffsetColourNumericUpDown.Name = "LOffsetColourNumericUpDown";
            LOffsetColourNumericUpDown.Size = new Size(70, 23);
            LOffsetColourNumericUpDown.TabIndex = 4;
            LOffsetColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // CameraLookOffsetControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(LookOffsetGroupBox);
            Name = "CameraLookOffsetControl";
            Size = new Size(138, 97);
            LookOffsetGroupBox.ResumeLayout(false);
            LookOffsetGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LOffsetVColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)LOffsetColourNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox LookOffsetGroupBox;
        private ColourNumericUpDown LOffsetVColourNumericUpDown;
        private Label label2;
        private Label label1;
        private ColourNumericUpDown LOffsetColourNumericUpDown;
        private CheckBox LOfsErpOffCheckBox;
    }
}
