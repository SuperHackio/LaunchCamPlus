namespace LaunchCamPlus.CameraPanels
{
    partial class CubePlanetCameraPanel
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
            DistColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            DistLabel = new Label();
            RollColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            RollLabel = new Label();
            AngleAColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            AngleALabel = new Label();
            AngleBColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            AngleBLabel = new Label();
            CameraLOfs = new ExtraControls.CameraLookOffsetControl();
            CameraVariant = new ExtraControls.CameraVariantControl();
            WOffsetVector3NumericUpDown = new ExtraControls.Vector3NumericUpDown();
            BehaviourGroupBox = new GroupBox();
            Num1CheckBox = new CheckBox();
            SubjectiveOffCheckBox = new CheckBox();
            NoResetCheckBox = new CheckBox();
            CollisionOffCheckBox = new CheckBox();
            AntiBlurOffCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FovYColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DistColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RollColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AngleAColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AngleBColourNumericUpDown).BeginInit();
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
            NoFovYCheckBox.Checked = true;
            NoFovYCheckBox.CheckState = CheckState.Checked;
            NoFovYCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            NoFovYCheckBox.Location = new Point(44, 166);
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
            VersionColourNumericUpDown.Location = new Point(77, 54);
            VersionColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            VersionColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            VersionColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            VersionColourNumericUpDown.Name = "VersionColourNumericUpDown";
            VersionColourNumericUpDown.Size = new Size(74, 20);
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
            FovYColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            FovYColourNumericUpDown.Location = new Point(77, 164);
            FovYColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            FovYColourNumericUpDown.Maximum = new decimal(new int[] { 1799, 0, 0, 65536 });
            FovYColourNumericUpDown.Name = "FovYColourNumericUpDown";
            FovYColourNumericUpDown.Size = new Size(74, 20);
            FovYColourNumericUpDown.TabIndex = 79;
            FovYColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // FovYLabel
            // 
            FovYLabel.AutoSize = true;
            FovYLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            FovYLabel.Location = new Point(2, 166);
            FovYLabel.Name = "FovYLabel";
            FovYLabel.Size = new Size(32, 13);
            FovYLabel.TabIndex = 78;
            FovYLabel.Text = "FovY";
            // 
            // DistColourNumericUpDown
            // 
            DistColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            DistColourNumericUpDown.DecimalPlaces = 3;
            DistColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            DistColourNumericUpDown.Location = new Point(77, 142);
            DistColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            DistColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            DistColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            DistColourNumericUpDown.Name = "DistColourNumericUpDown";
            DistColourNumericUpDown.Size = new Size(74, 20);
            DistColourNumericUpDown.TabIndex = 77;
            DistColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // DistLabel
            // 
            DistLabel.AutoSize = true;
            DistLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            DistLabel.Location = new Point(2, 144);
            DistLabel.Name = "DistLabel";
            DistLabel.Size = new Size(34, 13);
            DistLabel.TabIndex = 76;
            DistLabel.Text = "Zoom";
            // 
            // RollColourNumericUpDown
            // 
            RollColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            RollColourNumericUpDown.DecimalPlaces = 3;
            RollColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            RollColourNumericUpDown.Location = new Point(77, 120);
            RollColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            RollColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            RollColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            RollColourNumericUpDown.Name = "RollColourNumericUpDown";
            RollColourNumericUpDown.Size = new Size(74, 20);
            RollColourNumericUpDown.TabIndex = 75;
            RollColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // RollLabel
            // 
            RollLabel.AutoSize = true;
            RollLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            RollLabel.Location = new Point(2, 122);
            RollLabel.Name = "RollLabel";
            RollLabel.Size = new Size(25, 13);
            RollLabel.TabIndex = 74;
            RollLabel.Text = "Roll";
            // 
            // AngleAColourNumericUpDown
            // 
            AngleAColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            AngleAColourNumericUpDown.DecimalPlaces = 6;
            AngleAColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            AngleAColourNumericUpDown.Location = new Point(77, 98);
            AngleAColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            AngleAColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            AngleAColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            AngleAColourNumericUpDown.Name = "AngleAColourNumericUpDown";
            AngleAColourNumericUpDown.Size = new Size(74, 20);
            AngleAColourNumericUpDown.TabIndex = 73;
            AngleAColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 393216 });
            // 
            // AngleALabel
            // 
            AngleALabel.AutoSize = true;
            AngleALabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            AngleALabel.Location = new Point(2, 100);
            AngleALabel.Name = "AngleALabel";
            AngleALabel.Size = new Size(57, 13);
            AngleALabel.TabIndex = 72;
            AngleALabel.Text = "X Rotation";
            // 
            // AngleBColourNumericUpDown
            // 
            AngleBColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            AngleBColourNumericUpDown.DecimalPlaces = 6;
            AngleBColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            AngleBColourNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            AngleBColourNumericUpDown.Location = new Point(77, 76);
            AngleBColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            AngleBColourNumericUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            AngleBColourNumericUpDown.Name = "AngleBColourNumericUpDown";
            AngleBColourNumericUpDown.Size = new Size(74, 20);
            AngleBColourNumericUpDown.TabIndex = 71;
            AngleBColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 393216 });
            // 
            // AngleBLabel
            // 
            AngleBLabel.AutoSize = true;
            AngleBLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            AngleBLabel.Location = new Point(2, 78);
            AngleBLabel.Name = "AngleBLabel";
            AngleBLabel.Size = new Size(73, 13);
            AngleBLabel.TabIndex = 70;
            AngleBLabel.Text = "Rotate Speed";
            // 
            // CameraLOfs
            // 
            CameraLOfs.Location = new Point(300, 312);
            CameraLOfs.Name = "CameraLOfs";
            CameraLOfs.Size = new Size(138, 97);
            CameraLOfs.TabIndex = 84;
            // 
            // CameraVariant
            // 
            CameraVariant.Location = new Point(299, 56);
            CameraVariant.Name = "CameraVariant";
            CameraVariant.Size = new Size(138, 245);
            CameraVariant.TabIndex = 85;
            // 
            // WOffsetVector3NumericUpDown
            // 
            WOffsetVector3NumericUpDown.Location = new Point(157, 56);
            WOffsetVector3NumericUpDown.MinimumSize = new Size(70, 85);
            WOffsetVector3NumericUpDown.Name = "WOffsetVector3NumericUpDown";
            WOffsetVector3NumericUpDown.Size = new Size(136, 85);
            WOffsetVector3NumericUpDown.TabIndex = 86;
            WOffsetVector3NumericUpDown.Text = "Offset from Target";
            // 
            // BehaviourGroupBox
            // 
            BehaviourGroupBox.Controls.Add(Num1CheckBox);
            BehaviourGroupBox.Controls.Add(SubjectiveOffCheckBox);
            BehaviourGroupBox.Controls.Add(NoResetCheckBox);
            BehaviourGroupBox.Controls.Add(CollisionOffCheckBox);
            BehaviourGroupBox.Controls.Add(AntiBlurOffCheckBox);
            BehaviourGroupBox.Location = new Point(157, 147);
            BehaviourGroupBox.Name = "BehaviourGroupBox";
            BehaviourGroupBox.Size = new Size(136, 105);
            BehaviourGroupBox.TabIndex = 96;
            BehaviourGroupBox.TabStop = false;
            BehaviourGroupBox.Text = "Behaviour Options";
            // 
            // Num1CheckBox
            // 
            Num1CheckBox.AutoSize = true;
            Num1CheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            Num1CheckBox.Location = new Point(6, 16);
            Num1CheckBox.Margin = new Padding(3, 0, 3, 0);
            Num1CheckBox.Name = "Num1CheckBox";
            Num1CheckBox.Size = new Size(99, 17);
            Num1CheckBox.TabIndex = 91;
            Num1CheckBox.Text = "D-Pad Rotation";
            Num1CheckBox.UseVisualStyleBackColor = true;
            // 
            // SubjectiveOffCheckBox
            // 
            SubjectiveOffCheckBox.AutoSize = true;
            SubjectiveOffCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            SubjectiveOffCheckBox.Location = new Point(6, 33);
            SubjectiveOffCheckBox.Margin = new Padding(3, 0, 3, 0);
            SubjectiveOffCheckBox.Name = "SubjectiveOffCheckBox";
            SubjectiveOffCheckBox.Size = new Size(81, 17);
            SubjectiveOffCheckBox.TabIndex = 90;
            SubjectiveOffCheckBox.Text = "First Person";
            SubjectiveOffCheckBox.UseVisualStyleBackColor = true;
            // 
            // NoResetCheckBox
            // 
            NoResetCheckBox.AutoSize = true;
            NoResetCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            NoResetCheckBox.Location = new Point(6, 84);
            NoResetCheckBox.Margin = new Padding(3, 0, 3, 0);
            NoResetCheckBox.Name = "NoResetCheckBox";
            NoResetCheckBox.Size = new Size(68, 17);
            NoResetCheckBox.TabIndex = 87;
            NoResetCheckBox.Text = "NoReset";
            NoResetCheckBox.UseVisualStyleBackColor = true;
            // 
            // CollisionOffCheckBox
            // 
            CollisionOffCheckBox.AutoSize = true;
            CollisionOffCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            CollisionOffCheckBox.Location = new Point(6, 50);
            CollisionOffCheckBox.Margin = new Padding(3, 0, 3, 0);
            CollisionOffCheckBox.Name = "CollisionOffCheckBox";
            CollisionOffCheckBox.Size = new Size(102, 17);
            CollisionOffCheckBox.TabIndex = 89;
            CollisionOffCheckBox.Text = "Disable Collision";
            CollisionOffCheckBox.UseVisualStyleBackColor = true;
            // 
            // AntiBlurOffCheckBox
            // 
            AntiBlurOffCheckBox.AutoSize = true;
            AntiBlurOffCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            AntiBlurOffCheckBox.Location = new Point(6, 67);
            AntiBlurOffCheckBox.Margin = new Padding(3, 0, 3, 0);
            AntiBlurOffCheckBox.Name = "AntiBlurOffCheckBox";
            AntiBlurOffCheckBox.Size = new Size(117, 17);
            AntiBlurOffCheckBox.TabIndex = 88;
            AntiBlurOffCheckBox.Text = "D-Pad Interpolation";
            AntiBlurOffCheckBox.UseVisualStyleBackColor = true;
            // 
            // CubePlanetCameraPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BehaviourGroupBox);
            Controls.Add(WOffsetVector3NumericUpDown);
            Controls.Add(CameraVariant);
            Controls.Add(CameraLOfs);
            Controls.Add(NoFovYCheckBox);
            Controls.Add(VersionColourNumericUpDown);
            Controls.Add(VersionLabel);
            Controls.Add(FovYColourNumericUpDown);
            Controls.Add(FovYLabel);
            Controls.Add(DistColourNumericUpDown);
            Controls.Add(DistLabel);
            Controls.Add(RollColourNumericUpDown);
            Controls.Add(RollLabel);
            Controls.Add(AngleAColourNumericUpDown);
            Controls.Add(AngleALabel);
            Controls.Add(AngleBColourNumericUpDown);
            Controls.Add(AngleBLabel);
            Controls.Add(StringLabel);
            Controls.Add(StringColourTextBox);
            Name = "CubePlanetCameraPanel";
            Controls.SetChildIndex(StringColourTextBox, 0);
            Controls.SetChildIndex(StringLabel, 0);
            Controls.SetChildIndex(AngleBLabel, 0);
            Controls.SetChildIndex(AngleBColourNumericUpDown, 0);
            Controls.SetChildIndex(AngleALabel, 0);
            Controls.SetChildIndex(AngleAColourNumericUpDown, 0);
            Controls.SetChildIndex(RollLabel, 0);
            Controls.SetChildIndex(RollColourNumericUpDown, 0);
            Controls.SetChildIndex(DistLabel, 0);
            Controls.SetChildIndex(DistColourNumericUpDown, 0);
            Controls.SetChildIndex(FovYLabel, 0);
            Controls.SetChildIndex(FovYColourNumericUpDown, 0);
            Controls.SetChildIndex(VersionLabel, 0);
            Controls.SetChildIndex(VersionColourNumericUpDown, 0);
            Controls.SetChildIndex(NoFovYCheckBox, 0);
            Controls.SetChildIndex(CameraLOfs, 0);
            Controls.SetChildIndex(CameraVariant, 0);
            Controls.SetChildIndex(WOffsetVector3NumericUpDown, 0);
            Controls.SetChildIndex(BehaviourGroupBox, 0);
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)FovYColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)DistColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RollColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AngleAColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AngleBColourNumericUpDown).EndInit();
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
        private ExtraControls.ColourNumericUpDown DistColourNumericUpDown;
        private Label DistLabel;
        private ExtraControls.ColourNumericUpDown RollColourNumericUpDown;
        private Label RollLabel;
        private ExtraControls.ColourNumericUpDown AngleAColourNumericUpDown;
        private Label AngleALabel;
        private ExtraControls.ColourNumericUpDown AngleBColourNumericUpDown;
        private Label AngleBLabel;
        private ExtraControls.CameraLookOffsetControl CameraLOfs;
        private ExtraControls.CameraVariantControl CameraVariant;
        private ExtraControls.Vector3NumericUpDown WOffsetVector3NumericUpDown;
        private GroupBox BehaviourGroupBox;
        private CheckBox Num1CheckBox;
        private CheckBox SubjectiveOffCheckBox;
        private CheckBox NoResetCheckBox;
        private CheckBox CollisionOffCheckBox;
        private CheckBox AntiBlurOffCheckBox;
    }
}
