namespace LaunchCamPlus.CameraPanels
{
    partial class CharmedFixCameraPanel
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
            StringLabel = new Label();
            StringColourTextBox = new ExtraControls.ColourTextBox();
            NoFovYCheckBox = new CheckBox();
            VersionColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            VersionLabel = new Label();
            FovYColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            FovYLabel = new Label();
            RollColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            RollLabel = new Label();
            CameraVariant = new ExtraControls.CameraVariantControl();
            WPointVector3NumericUpDown = new ExtraControls.Vector3NumericUpDown();
            SubjectiveOffCheckBox = new CheckBox();
            CollisionOffCheckBox = new CheckBox();
            NoResetCheckBox = new CheckBox();
            BehaviourGroupBox = new GroupBox();
            AxisVector3NumericUpDown = new ExtraControls.Vector3NumericUpDown();
            UpVector3NumericUpDown = new ExtraControls.Vector3NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FovYColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RollColourNumericUpDown).BeginInit();
            BehaviourGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // StringLabel
            // 
            StringLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StringLabel.AutoSize = true;
            StringLabel.Location = new Point(4, 418);
            StringLabel.Margin = new Padding(4, 0, 4, 0);
            StringLabel.Name = "StringLabel";
            StringLabel.Size = new Size(41, 15);
            StringLabel.TabIndex = 10;
            StringLabel.Text = "String:";
            // 
            // StringColourTextBox
            // 
            StringColourTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StringColourTextBox.Location = new Point(50, 415);
            StringColourTextBox.Margin = new Padding(4, 3, 4, 3);
            StringColourTextBox.Name = "StringColourTextBox";
            StringColourTextBox.Size = new Size(387, 23);
            StringColourTextBox.TabIndex = 9;
            // 
            // NoFovYCheckBox
            // 
            NoFovYCheckBox.AutoSize = true;
            NoFovYCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            NoFovYCheckBox.Location = new Point(44, 100);
            NoFovYCheckBox.Margin = new Padding(3, 0, 3, 0);
            NoFovYCheckBox.Name = "NoFovYCheckBox";
            NoFovYCheckBox.Size = new Size(15, 14);
            NoFovYCheckBox.TabIndex = 82;
            NoFovYCheckBox.UseVisualStyleBackColor = true;
            NoFovYCheckBox.CheckedChanged += NoFovYCheckBox_CheckedChanged;
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
            // FovYColourNumericUpDown
            // 
            FovYColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            FovYColourNumericUpDown.DecimalPlaces = 3;
            FovYColourNumericUpDown.Enabled = false;
            FovYColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            FovYColourNumericUpDown.Location = new Point(65, 98);
            FovYColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            FovYColourNumericUpDown.Maximum = new decimal(new int[] { 1799, 0, 0, 65536 });
            FovYColourNumericUpDown.Name = "FovYColourNumericUpDown";
            FovYColourNumericUpDown.Size = new Size(86, 20);
            FovYColourNumericUpDown.TabIndex = 79;
            FovYColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // FovYLabel
            // 
            FovYLabel.AutoSize = true;
            FovYLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            FovYLabel.Location = new Point(2, 100);
            FovYLabel.Name = "FovYLabel";
            FovYLabel.Size = new Size(32, 13);
            FovYLabel.TabIndex = 78;
            FovYLabel.Text = "FovY";
            // 
            // RollColourNumericUpDown
            // 
            RollColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            RollColourNumericUpDown.DecimalPlaces = 3;
            RollColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            RollColourNumericUpDown.Location = new Point(65, 76);
            RollColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            RollColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            RollColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            RollColourNumericUpDown.Name = "RollColourNumericUpDown";
            RollColourNumericUpDown.Size = new Size(86, 20);
            RollColourNumericUpDown.TabIndex = 75;
            RollColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // RollLabel
            // 
            RollLabel.AutoSize = true;
            RollLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            RollLabel.Location = new Point(2, 78);
            RollLabel.Name = "RollLabel";
            RollLabel.Size = new Size(25, 13);
            RollLabel.TabIndex = 74;
            RollLabel.Text = "Roll";
            // 
            // CameraVariant
            // 
            CameraVariant.Location = new Point(299, 56);
            CameraVariant.Name = "CameraVariant";
            CameraVariant.Size = new Size(138, 245);
            CameraVariant.TabIndex = 85;
            // 
            // WPointVector3NumericUpDown
            // 
            WPointVector3NumericUpDown.Location = new Point(157, 56);
            WPointVector3NumericUpDown.MinimumSize = new Size(70, 85);
            WPointVector3NumericUpDown.Name = "WPointVector3NumericUpDown";
            WPointVector3NumericUpDown.Size = new Size(136, 85);
            WPointVector3NumericUpDown.TabIndex = 86;
            WPointVector3NumericUpDown.Text = "Target Anchor";
            // 
            // SubjectiveOffCheckBox
            // 
            SubjectiveOffCheckBox.AutoSize = true;
            SubjectiveOffCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            SubjectiveOffCheckBox.Location = new Point(6, 19);
            SubjectiveOffCheckBox.Margin = new Padding(3, 0, 3, 0);
            SubjectiveOffCheckBox.Name = "SubjectiveOffCheckBox";
            SubjectiveOffCheckBox.Size = new Size(81, 17);
            SubjectiveOffCheckBox.TabIndex = 90;
            SubjectiveOffCheckBox.Text = "First Person";
            SubjectiveOffCheckBox.UseVisualStyleBackColor = true;
            // 
            // CollisionOffCheckBox
            // 
            CollisionOffCheckBox.AutoSize = true;
            CollisionOffCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            CollisionOffCheckBox.Location = new Point(6, 36);
            CollisionOffCheckBox.Margin = new Padding(3, 0, 3, 0);
            CollisionOffCheckBox.Name = "CollisionOffCheckBox";
            CollisionOffCheckBox.Size = new Size(102, 17);
            CollisionOffCheckBox.TabIndex = 89;
            CollisionOffCheckBox.Text = "Disable Collision";
            CollisionOffCheckBox.UseVisualStyleBackColor = true;
            // 
            // NoResetCheckBox
            // 
            NoResetCheckBox.AutoSize = true;
            NoResetCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            NoResetCheckBox.Location = new Point(6, 53);
            NoResetCheckBox.Margin = new Padding(3, 0, 3, 0);
            NoResetCheckBox.Name = "NoResetCheckBox";
            NoResetCheckBox.Size = new Size(68, 17);
            NoResetCheckBox.TabIndex = 87;
            NoResetCheckBox.Text = "NoReset";
            NoResetCheckBox.UseVisualStyleBackColor = true;
            // 
            // BehaviourGroupBox
            // 
            BehaviourGroupBox.Controls.Add(SubjectiveOffCheckBox);
            BehaviourGroupBox.Controls.Add(NoResetCheckBox);
            BehaviourGroupBox.Controls.Add(CollisionOffCheckBox);
            BehaviourGroupBox.Location = new Point(3, 122);
            BehaviourGroupBox.Name = "BehaviourGroupBox";
            BehaviourGroupBox.Size = new Size(148, 184);
            BehaviourGroupBox.TabIndex = 91;
            BehaviourGroupBox.TabStop = false;
            BehaviourGroupBox.Text = "Behaviour Options";
            // 
            // AxisVector3NumericUpDown
            // 
            AxisVector3NumericUpDown.Location = new Point(157, 144);
            AxisVector3NumericUpDown.Margin = new Padding(3, 0, 3, 0);
            AxisVector3NumericUpDown.MinimumSize = new Size(70, 85);
            AxisVector3NumericUpDown.Name = "AxisVector3NumericUpDown";
            AxisVector3NumericUpDown.Size = new Size(136, 85);
            AxisVector3NumericUpDown.TabIndex = 93;
            AxisVector3NumericUpDown.Text = "Camera Origin";
            // 
            // UpVector3NumericUpDown
            // 
            UpVector3NumericUpDown.Location = new Point(157, 229);
            UpVector3NumericUpDown.Margin = new Padding(3, 0, 3, 0);
            UpVector3NumericUpDown.MinimumSize = new Size(70, 85);
            UpVector3NumericUpDown.Name = "UpVector3NumericUpDown";
            UpVector3NumericUpDown.Size = new Size(136, 85);
            UpVector3NumericUpDown.TabIndex = 94;
            UpVector3NumericUpDown.Text = "Up Axis Normal";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 314);
            label1.Name = "label1";
            label1.Size = new Size(394, 15);
            label1.TabIndex = 95;
            label1.Text = "You can change the Zoom by using the Z Value (3rd) of the Target Anchor";
            // 
            // CharmedFixCameraPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(UpVector3NumericUpDown);
            Controls.Add(AxisVector3NumericUpDown);
            Controls.Add(BehaviourGroupBox);
            Controls.Add(WPointVector3NumericUpDown);
            Controls.Add(CameraVariant);
            Controls.Add(NoFovYCheckBox);
            Controls.Add(VersionColourNumericUpDown);
            Controls.Add(VersionLabel);
            Controls.Add(FovYColourNumericUpDown);
            Controls.Add(FovYLabel);
            Controls.Add(RollColourNumericUpDown);
            Controls.Add(RollLabel);
            Controls.Add(StringLabel);
            Controls.Add(StringColourTextBox);
            Name = "CharmedFixCameraPanel";
            Controls.SetChildIndex(StringColourTextBox, 0);
            Controls.SetChildIndex(StringLabel, 0);
            Controls.SetChildIndex(RollLabel, 0);
            Controls.SetChildIndex(RollColourNumericUpDown, 0);
            Controls.SetChildIndex(FovYLabel, 0);
            Controls.SetChildIndex(FovYColourNumericUpDown, 0);
            Controls.SetChildIndex(VersionLabel, 0);
            Controls.SetChildIndex(VersionColourNumericUpDown, 0);
            Controls.SetChildIndex(NoFovYCheckBox, 0);
            Controls.SetChildIndex(CameraVariant, 0);
            Controls.SetChildIndex(WPointVector3NumericUpDown, 0);
            Controls.SetChildIndex(BehaviourGroupBox, 0);
            Controls.SetChildIndex(AxisVector3NumericUpDown, 0);
            Controls.SetChildIndex(UpVector3NumericUpDown, 0);
            Controls.SetChildIndex(label1, 0);
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)FovYColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RollColourNumericUpDown).EndInit();
            BehaviourGroupBox.ResumeLayout(false);
            BehaviourGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label StringLabel;
        private ExtraControls.ColourTextBox StringColourTextBox;
        private CheckBox NoFovYCheckBox;
        private ExtraControls.ColourNumericUpDown VersionColourNumericUpDown;
        private Label VersionLabel;
        private ExtraControls.ColourNumericUpDown FovYColourNumericUpDown;
        private Label FovYLabel;
        private ExtraControls.ColourNumericUpDown RollColourNumericUpDown;
        private Label RollLabel;
        private ExtraControls.CameraVariantControl CameraVariant;
        private ExtraControls.Vector3NumericUpDown WPointVector3NumericUpDown;
        private CheckBox SubjectiveOffCheckBox;
        private CheckBox CollisionOffCheckBox;
        private CheckBox NoResetCheckBox;
        private GroupBox BehaviourGroupBox;
        private ExtraControls.Vector3NumericUpDown AxisVector3NumericUpDown;
        private ExtraControls.Vector3NumericUpDown UpVector3NumericUpDown;
        private Label label1;
    }
}
