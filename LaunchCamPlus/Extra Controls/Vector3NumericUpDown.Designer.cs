namespace LaunchCamPlus
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.ZValueNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.YValueNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.XValueNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ZValueNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YValueNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XValueNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(3, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(44, 13);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "Vector3";
            // 
            // ZValueNumericUpDown
            // 
            this.ZValueNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ZValueNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ZValueNumericUpDown.DecimalPlaces = 3;
            this.ZValueNumericUpDown.Location = new System.Drawing.Point(3, 68);
            this.ZValueNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ZValueNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.ZValueNumericUpDown.Name = "ZValueNumericUpDown";
            this.ZValueNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.ZValueNumericUpDown.TabIndex = 2;
            // 
            // YValueNumericUpDown
            // 
            this.YValueNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YValueNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.YValueNumericUpDown.DecimalPlaces = 3;
            this.YValueNumericUpDown.Location = new System.Drawing.Point(3, 42);
            this.YValueNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.YValueNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.YValueNumericUpDown.Name = "YValueNumericUpDown";
            this.YValueNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.YValueNumericUpDown.TabIndex = 1;
            // 
            // XValueNumericUpDown
            // 
            this.XValueNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XValueNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.XValueNumericUpDown.DecimalPlaces = 3;
            this.XValueNumericUpDown.Location = new System.Drawing.Point(3, 16);
            this.XValueNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.XValueNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.XValueNumericUpDown.Name = "XValueNumericUpDown";
            this.XValueNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.XValueNumericUpDown.TabIndex = 0;
            // 
            // Vector3NumericUpDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.ZValueNumericUpDown);
            this.Controls.Add(this.YValueNumericUpDown);
            this.Controls.Add(this.XValueNumericUpDown);
            this.MinimumSize = new System.Drawing.Size(50, 90);
            this.Name = "Vector3NumericUpDown";
            this.Size = new System.Drawing.Size(100, 90);
            ((System.ComponentModel.ISupportInitialize)(this.ZValueNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YValueNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XValueNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColourNumericUpDown XValueNumericUpDown;
        private ColourNumericUpDown YValueNumericUpDown;
        private ColourNumericUpDown ZValueNumericUpDown;
        private System.Windows.Forms.Label NameLabel;
    }
}
