namespace LaunchCamPlus.CameraPanels
{
    partial class EyeposFixThereCameraPanel
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
            this.RotationZLabel = new System.Windows.Forms.Label();
            this.RotationZNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.Num1CheckBox = new System.Windows.Forms.CheckBox();
            this.DisableFirstPersonCheckBox = new System.Windows.Forms.CheckBox();
            this.CamEndIntLabel = new System.Windows.Forms.Label();
            this.CamEndIntNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.CamIntLabel = new System.Windows.Forms.Label();
            this.CamIntNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.EventUseTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.EventUseEndTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.EventFrameLabel = new System.Windows.Forms.Label();
            this.EventFrameNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.HeightOffsetNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.HeightOffsetLabel = new System.Windows.Forms.Label();
            this.FrontOffsetNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.FrontOffsetLabel = new System.Windows.Forms.Label();
            this.FixpointVector3NumericUpDown = new LaunchCamPlus.Vector3NumericUpDown();
            this.UpAxisVector3NumericUpDown = new LaunchCamPlus.Vector3NumericUpDown();
            this.SharpZoomCheckBox = new System.Windows.Forms.CheckBox();
            this.GFlagEndTimeLabel = new System.Windows.Forms.Label();
            this.GFlagEndTimeNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.GFlagEndErpFrameCheckBox = new System.Windows.Forms.CheckBox();
            this.GFlagThroughCheckBox = new System.Windows.Forms.CheckBox();
            this.StringTextBox = new LaunchCamPlus.ColourTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RotationZNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamEndIntNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamIntNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventFrameNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightOffsetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontOffsetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GFlagEndTimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // RotationZLabel
            // 
            this.RotationZLabel.AutoSize = true;
            this.RotationZLabel.Location = new System.Drawing.Point(3, 58);
            this.RotationZLabel.Name = "RotationZLabel";
            this.RotationZLabel.Size = new System.Drawing.Size(25, 13);
            this.RotationZLabel.TabIndex = 10;
            this.RotationZLabel.Text = "Roll";
            // 
            // RotationZNumericUpDown
            // 
            this.RotationZNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.RotationZNumericUpDown.DecimalPlaces = 3;
            this.RotationZNumericUpDown.Location = new System.Drawing.Point(83, 56);
            this.RotationZNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.RotationZNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.RotationZNumericUpDown.Name = "RotationZNumericUpDown";
            this.RotationZNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.RotationZNumericUpDown.TabIndex = 11;
            this.RotationZNumericUpDown.TextValue = new decimal(new int[] {
            0,
            0,
            0,
            196608});
            // 
            // Num1CheckBox
            // 
            this.Num1CheckBox.AutoSize = true;
            this.Num1CheckBox.Location = new System.Drawing.Point(270, 54);
            this.Num1CheckBox.Name = "Num1CheckBox";
            this.Num1CheckBox.Size = new System.Drawing.Size(120, 17);
            this.Num1CheckBox.TabIndex = 76;
            this.Num1CheckBox.Text = "Advanced Tracking";
            this.Num1CheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableFirstPersonCheckBox
            // 
            this.DisableFirstPersonCheckBox.AutoSize = true;
            this.DisableFirstPersonCheckBox.Location = new System.Drawing.Point(270, 75);
            this.DisableFirstPersonCheckBox.Name = "DisableFirstPersonCheckBox";
            this.DisableFirstPersonCheckBox.Size = new System.Drawing.Size(81, 17);
            this.DisableFirstPersonCheckBox.TabIndex = 77;
            this.DisableFirstPersonCheckBox.Text = "First Person";
            this.DisableFirstPersonCheckBox.UseVisualStyleBackColor = true;
            // 
            // CamEndIntLabel
            // 
            this.CamEndIntLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CamEndIntLabel.AutoSize = true;
            this.CamEndIntLabel.Location = new System.Drawing.Point(3, 162);
            this.CamEndIntLabel.Name = "CamEndIntLabel";
            this.CamEndIntLabel.Size = new System.Drawing.Size(50, 13);
            this.CamEndIntLabel.TabIndex = 80;
            this.CamEndIntLabel.Text = "Exit Time";
            // 
            // CamEndIntNumericUpDown
            // 
            this.CamEndIntNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CamEndIntNumericUpDown.Location = new System.Drawing.Point(83, 160);
            this.CamEndIntNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.CamEndIntNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.CamEndIntNumericUpDown.Name = "CamEndIntNumericUpDown";
            this.CamEndIntNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.CamEndIntNumericUpDown.TabIndex = 81;
            this.CamEndIntNumericUpDown.TextValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // CamIntLabel
            // 
            this.CamIntLabel.AutoSize = true;
            this.CamIntLabel.Location = new System.Drawing.Point(3, 136);
            this.CamIntLabel.Name = "CamIntLabel";
            this.CamIntLabel.Size = new System.Drawing.Size(58, 13);
            this.CamIntLabel.TabIndex = 78;
            this.CamIntLabel.Text = "Enter Time";
            // 
            // CamIntNumericUpDown
            // 
            this.CamIntNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CamIntNumericUpDown.Location = new System.Drawing.Point(83, 134);
            this.CamIntNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.CamIntNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.CamIntNumericUpDown.Name = "CamIntNumericUpDown";
            this.CamIntNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.CamIntNumericUpDown.TabIndex = 79;
            this.CamIntNumericUpDown.TextValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // EventUseTimeCheckBox
            // 
            this.EventUseTimeCheckBox.AutoSize = true;
            this.EventUseTimeCheckBox.Location = new System.Drawing.Point(270, 120);
            this.EventUseTimeCheckBox.Name = "EventUseTimeCheckBox";
            this.EventUseTimeCheckBox.Size = new System.Drawing.Size(108, 17);
            this.EventUseTimeCheckBox.TabIndex = 82;
            this.EventUseTimeCheckBox.Text = "Event Enter Time";
            this.EventUseTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // EventUseEndTimeCheckBox
            // 
            this.EventUseEndTimeCheckBox.AutoSize = true;
            this.EventUseEndTimeCheckBox.Location = new System.Drawing.Point(270, 143);
            this.EventUseEndTimeCheckBox.Name = "EventUseEndTimeCheckBox";
            this.EventUseEndTimeCheckBox.Size = new System.Drawing.Size(100, 17);
            this.EventUseEndTimeCheckBox.TabIndex = 83;
            this.EventUseEndTimeCheckBox.Text = "Event Exit Time";
            this.EventUseEndTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // EventFrameLabel
            // 
            this.EventFrameLabel.AutoSize = true;
            this.EventFrameLabel.Location = new System.Drawing.Point(3, 188);
            this.EventFrameLabel.Name = "EventFrameLabel";
            this.EventFrameLabel.Size = new System.Drawing.Size(71, 13);
            this.EventFrameLabel.TabIndex = 84;
            this.EventFrameLabel.Text = "Event Length";
            // 
            // EventFrameNumericUpDown
            // 
            this.EventFrameNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.EventFrameNumericUpDown.Location = new System.Drawing.Point(83, 186);
            this.EventFrameNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.EventFrameNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.EventFrameNumericUpDown.Name = "EventFrameNumericUpDown";
            this.EventFrameNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.EventFrameNumericUpDown.TabIndex = 85;
            this.EventFrameNumericUpDown.TextValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // HeightOffsetNumericUpDown
            // 
            this.HeightOffsetNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.HeightOffsetNumericUpDown.DecimalPlaces = 3;
            this.HeightOffsetNumericUpDown.Location = new System.Drawing.Point(83, 108);
            this.HeightOffsetNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.HeightOffsetNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.HeightOffsetNumericUpDown.Name = "HeightOffsetNumericUpDown";
            this.HeightOffsetNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.HeightOffsetNumericUpDown.TabIndex = 89;
            this.HeightOffsetNumericUpDown.TextValue = new decimal(new int[] {
            0,
            0,
            0,
            196608});
            // 
            // HeightOffsetLabel
            // 
            this.HeightOffsetLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HeightOffsetLabel.AutoSize = true;
            this.HeightOffsetLabel.Location = new System.Drawing.Point(3, 110);
            this.HeightOffsetLabel.Name = "HeightOffsetLabel";
            this.HeightOffsetLabel.Size = new System.Drawing.Size(54, 13);
            this.HeightOffsetLabel.TabIndex = 88;
            this.HeightOffsetLabel.Text = "↪ Vertical";
            // 
            // FrontOffsetNumericUpDown
            // 
            this.FrontOffsetNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.FrontOffsetNumericUpDown.DecimalPlaces = 3;
            this.FrontOffsetNumericUpDown.Location = new System.Drawing.Point(83, 82);
            this.FrontOffsetNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.FrontOffsetNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.FrontOffsetNumericUpDown.Name = "FrontOffsetNumericUpDown";
            this.FrontOffsetNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.FrontOffsetNumericUpDown.TabIndex = 87;
            this.FrontOffsetNumericUpDown.TextValue = new decimal(new int[] {
            0,
            0,
            0,
            196608});
            // 
            // FrontOffsetLabel
            // 
            this.FrontOffsetLabel.AutoSize = true;
            this.FrontOffsetLabel.Location = new System.Drawing.Point(3, 84);
            this.FrontOffsetLabel.Name = "FrontOffsetLabel";
            this.FrontOffsetLabel.Size = new System.Drawing.Size(62, 13);
            this.FrontOffsetLabel.TabIndex = 86;
            this.FrontOffsetLabel.Text = "Look Offset";
            // 
            // FixpointVector3NumericUpDown
            // 
            this.FixpointVector3NumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FixpointVector3NumericUpDown.Location = new System.Drawing.Point(164, 54);
            this.FixpointVector3NumericUpDown.MinimumSize = new System.Drawing.Size(100, 90);
            this.FixpointVector3NumericUpDown.Name = "FixpointVector3NumericUpDown";
            this.FixpointVector3NumericUpDown.Size = new System.Drawing.Size(100, 92);
            this.FixpointVector3NumericUpDown.TabIndex = 90;
            this.FixpointVector3NumericUpDown.Text = "Fixpoint Offset";
            // 
            // UpAxisVector3NumericUpDown
            // 
            this.UpAxisVector3NumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UpAxisVector3NumericUpDown.Location = new System.Drawing.Point(164, 144);
            this.UpAxisVector3NumericUpDown.MinimumSize = new System.Drawing.Size(100, 90);
            this.UpAxisVector3NumericUpDown.Name = "UpAxisVector3NumericUpDown";
            this.UpAxisVector3NumericUpDown.Size = new System.Drawing.Size(100, 92);
            this.UpAxisVector3NumericUpDown.TabIndex = 91;
            this.UpAxisVector3NumericUpDown.Text = "Up Axis";
            // 
            // SharpZoomCheckBox
            // 
            this.SharpZoomCheckBox.AutoSize = true;
            this.SharpZoomCheckBox.Location = new System.Drawing.Point(270, 97);
            this.SharpZoomCheckBox.Name = "SharpZoomCheckBox";
            this.SharpZoomCheckBox.Size = new System.Drawing.Size(111, 17);
            this.SharpZoomCheckBox.TabIndex = 92;
            this.SharpZoomCheckBox.Text = "Static Look Offset";
            this.SharpZoomCheckBox.UseVisualStyleBackColor = true;
            // 
            // GFlagEndTimeLabel
            // 
            this.GFlagEndTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GFlagEndTimeLabel.AutoSize = true;
            this.GFlagEndTimeLabel.Location = new System.Drawing.Point(3, 214);
            this.GFlagEndTimeLabel.Name = "GFlagEndTimeLabel";
            this.GFlagEndTimeLabel.Size = new System.Drawing.Size(57, 13);
            this.GFlagEndTimeLabel.TabIndex = 94;
            this.GFlagEndTimeLabel.Text = "GEndTime";
            // 
            // GFlagEndTimeNumericUpDown
            // 
            this.GFlagEndTimeNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.GFlagEndTimeNumericUpDown.Location = new System.Drawing.Point(83, 212);
            this.GFlagEndTimeNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.GFlagEndTimeNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.GFlagEndTimeNumericUpDown.Name = "GFlagEndTimeNumericUpDown";
            this.GFlagEndTimeNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.GFlagEndTimeNumericUpDown.TabIndex = 96;
            this.GFlagEndTimeNumericUpDown.TextValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // GFlagEndErpFrameCheckBox
            // 
            this.GFlagEndErpFrameCheckBox.AutoSize = true;
            this.GFlagEndErpFrameCheckBox.Location = new System.Drawing.Point(270, 189);
            this.GFlagEndErpFrameCheckBox.Name = "GFlagEndErpFrameCheckBox";
            this.GFlagEndErpFrameCheckBox.Size = new System.Drawing.Size(118, 17);
            this.GFlagEndErpFrameCheckBox.TabIndex = 93;
            this.GFlagEndErpFrameCheckBox.Text = "GFlagEndErpFrame";
            this.GFlagEndErpFrameCheckBox.UseVisualStyleBackColor = true;
            // 
            // GFlagThroughCheckBox
            // 
            this.GFlagThroughCheckBox.AutoSize = true;
            this.GFlagThroughCheckBox.Location = new System.Drawing.Point(270, 166);
            this.GFlagThroughCheckBox.Name = "GFlagThroughCheckBox";
            this.GFlagThroughCheckBox.Size = new System.Drawing.Size(94, 17);
            this.GFlagThroughCheckBox.TabIndex = 95;
            this.GFlagThroughCheckBox.Text = "GFlagThrough";
            this.GFlagThroughCheckBox.UseVisualStyleBackColor = true;
            // 
            // StringTextBox
            // 
            this.StringTextBox.Location = new System.Drawing.Point(310, 212);
            this.StringTextBox.Name = "StringTextBox";
            this.StringTextBox.Size = new System.Drawing.Size(128, 20);
            this.StringTextBox.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "String";
            // 
            // EyeposFixThereCameraPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CameraType = "CAM_TYPE_EYEPOS_FIX_THERE";
            this.Controls.Add(this.StringTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GFlagEndTimeLabel);
            this.Controls.Add(this.GFlagEndTimeNumericUpDown);
            this.Controls.Add(this.GFlagEndErpFrameCheckBox);
            this.Controls.Add(this.GFlagThroughCheckBox);
            this.Controls.Add(this.SharpZoomCheckBox);
            this.Controls.Add(this.UpAxisVector3NumericUpDown);
            this.Controls.Add(this.FixpointVector3NumericUpDown);
            this.Controls.Add(this.HeightOffsetNumericUpDown);
            this.Controls.Add(this.HeightOffsetLabel);
            this.Controls.Add(this.FrontOffsetNumericUpDown);
            this.Controls.Add(this.FrontOffsetLabel);
            this.Controls.Add(this.EventFrameLabel);
            this.Controls.Add(this.EventFrameNumericUpDown);
            this.Controls.Add(this.CamEndIntLabel);
            this.Controls.Add(this.CamEndIntNumericUpDown);
            this.Controls.Add(this.CamIntLabel);
            this.Controls.Add(this.CamIntNumericUpDown);
            this.Controls.Add(this.EventUseTimeCheckBox);
            this.Controls.Add(this.EventUseEndTimeCheckBox);
            this.Controls.Add(this.DisableFirstPersonCheckBox);
            this.Controls.Add(this.Num1CheckBox);
            this.Controls.Add(this.RotationZLabel);
            this.Controls.Add(this.RotationZNumericUpDown);
            this.Name = "EyeposFixThereCameraPanel";
            this.Controls.SetChildIndex(this.RotationZNumericUpDown, 0);
            this.Controls.SetChildIndex(this.RotationZLabel, 0);
            this.Controls.SetChildIndex(this.Num1CheckBox, 0);
            this.Controls.SetChildIndex(this.DisableFirstPersonCheckBox, 0);
            this.Controls.SetChildIndex(this.EventUseEndTimeCheckBox, 0);
            this.Controls.SetChildIndex(this.EventUseTimeCheckBox, 0);
            this.Controls.SetChildIndex(this.CamIntNumericUpDown, 0);
            this.Controls.SetChildIndex(this.CamIntLabel, 0);
            this.Controls.SetChildIndex(this.CamEndIntNumericUpDown, 0);
            this.Controls.SetChildIndex(this.CamEndIntLabel, 0);
            this.Controls.SetChildIndex(this.EventFrameNumericUpDown, 0);
            this.Controls.SetChildIndex(this.EventFrameLabel, 0);
            this.Controls.SetChildIndex(this.FrontOffsetLabel, 0);
            this.Controls.SetChildIndex(this.FrontOffsetNumericUpDown, 0);
            this.Controls.SetChildIndex(this.HeightOffsetLabel, 0);
            this.Controls.SetChildIndex(this.HeightOffsetNumericUpDown, 0);
            this.Controls.SetChildIndex(this.FixpointVector3NumericUpDown, 0);
            this.Controls.SetChildIndex(this.UpAxisVector3NumericUpDown, 0);
            this.Controls.SetChildIndex(this.SharpZoomCheckBox, 0);
            this.Controls.SetChildIndex(this.GFlagThroughCheckBox, 0);
            this.Controls.SetChildIndex(this.GFlagEndErpFrameCheckBox, 0);
            this.Controls.SetChildIndex(this.GFlagEndTimeNumericUpDown, 0);
            this.Controls.SetChildIndex(this.GFlagEndTimeLabel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.StringTextBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RotationZNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamEndIntNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamIntNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventFrameNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightOffsetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontOffsetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GFlagEndTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RotationZLabel;
        private ColourNumericUpDown RotationZNumericUpDown;
        private System.Windows.Forms.CheckBox Num1CheckBox;
        private System.Windows.Forms.CheckBox DisableFirstPersonCheckBox;
        private System.Windows.Forms.Label CamEndIntLabel;
        private ColourNumericUpDown CamEndIntNumericUpDown;
        private System.Windows.Forms.Label CamIntLabel;
        private ColourNumericUpDown CamIntNumericUpDown;
        private System.Windows.Forms.CheckBox EventUseTimeCheckBox;
        private System.Windows.Forms.CheckBox EventUseEndTimeCheckBox;
        private System.Windows.Forms.Label EventFrameLabel;
        private ColourNumericUpDown EventFrameNumericUpDown;
        private ColourNumericUpDown HeightOffsetNumericUpDown;
        private System.Windows.Forms.Label HeightOffsetLabel;
        private ColourNumericUpDown FrontOffsetNumericUpDown;
        private System.Windows.Forms.Label FrontOffsetLabel;
        private Vector3NumericUpDown FixpointVector3NumericUpDown;
        private Vector3NumericUpDown UpAxisVector3NumericUpDown;
        private System.Windows.Forms.CheckBox SharpZoomCheckBox;
        private System.Windows.Forms.Label GFlagEndTimeLabel;
        private ColourNumericUpDown GFlagEndTimeNumericUpDown;
        private System.Windows.Forms.CheckBox GFlagEndErpFrameCheckBox;
        private System.Windows.Forms.CheckBox GFlagThroughCheckBox;
        private ColourTextBox StringTextBox;
        private System.Windows.Forms.Label label1;
    }
}
