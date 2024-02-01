namespace LaunchCamPlus.ExtraControls
{
    partial class Vector3NumericUpDown
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
            NameLabel = new Label();
            ZValueNumericUpDown = new ColourNumericUpDown();
            YValueNumericUpDown = new ColourNumericUpDown();
            XValueNumericUpDown = new ColourNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)ZValueNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YValueNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XValueNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            NameLabel.Location = new Point(4, 0);
            NameLabel.Margin = new Padding(4, 0, 4, 0);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(44, 13);
            NameLabel.TabIndex = 3;
            NameLabel.Text = "Vector3";
            // 
            // ZValueNumericUpDown
            // 
            ZValueNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ZValueNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            ZValueNumericUpDown.DecimalPlaces = 3;
            ZValueNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            ZValueNumericUpDown.Location = new Point(4, 63);
            ZValueNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            ZValueNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            ZValueNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            ZValueNumericUpDown.Name = "ZValueNumericUpDown";
            ZValueNumericUpDown.Size = new Size(93, 20);
            ZValueNumericUpDown.TabIndex = 2;
            ZValueNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // YValueNumericUpDown
            // 
            YValueNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            YValueNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            YValueNumericUpDown.DecimalPlaces = 3;
            YValueNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            YValueNumericUpDown.Location = new Point(3, 39);
            YValueNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            YValueNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            YValueNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            YValueNumericUpDown.Name = "YValueNumericUpDown";
            YValueNumericUpDown.Size = new Size(94, 20);
            YValueNumericUpDown.TabIndex = 1;
            YValueNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // XValueNumericUpDown
            // 
            XValueNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            XValueNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            XValueNumericUpDown.DecimalPlaces = 3;
            XValueNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            XValueNumericUpDown.Location = new Point(3, 15);
            XValueNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            XValueNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            XValueNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            XValueNumericUpDown.Name = "XValueNumericUpDown";
            XValueNumericUpDown.Size = new Size(94, 20);
            XValueNumericUpDown.TabIndex = 0;
            XValueNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // Vector3NumericUpDown
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(NameLabel);
            Controls.Add(ZValueNumericUpDown);
            Controls.Add(YValueNumericUpDown);
            Controls.Add(XValueNumericUpDown);
            MinimumSize = new Size(50, 85);
            Name = "Vector3NumericUpDown";
            Size = new Size(100, 85);
            ((System.ComponentModel.ISupportInitialize)ZValueNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)YValueNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)XValueNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ColourNumericUpDown XValueNumericUpDown;
        private ColourNumericUpDown YValueNumericUpDown;
        private ColourNumericUpDown ZValueNumericUpDown;
        private System.Windows.Forms.Label NameLabel;
    }
}
