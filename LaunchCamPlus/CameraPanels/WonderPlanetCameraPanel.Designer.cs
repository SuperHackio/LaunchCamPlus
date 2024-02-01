namespace LaunchCamPlus.CameraPanels
{
    partial class WonderPlanetCameraPanel
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
            CameraHeightArrange = new ExtraControls.CameraHeightControl();
            StringLabel = new Label();
            StringColourTextBox = new ExtraControls.ColourTextBox();
            NoFovYCheckBox = new CheckBox();
            VersionColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            VersionLabel = new Label();
            FovYColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            FovYLabel = new Label();
            RollColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            RollLabel = new Label();
            AngleAColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            AngleALabel = new Label();
            CameraLOfs = new ExtraControls.CameraLookOffsetControl();
            CameraVariant = new ExtraControls.CameraVariantControl();
            WOffsetVector3NumericUpDown = new ExtraControls.Vector3NumericUpDown();
            AxisXColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            label1 = new Label();
            AxisYColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            label2 = new Label();
            BehaviourGroupBox = new GroupBox();
            SubjectiveOffCheckBox = new CheckBox();
            NoResetCheckBox = new CheckBox();
            CollisionOffCheckBox = new CheckBox();
            AntiBlurOffCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FovYColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RollColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AngleAColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AxisXColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AxisYColourNumericUpDown).BeginInit();
            BehaviourGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // CameraHeightArrange
            // 
            CameraHeightArrange.Location = new Point(3, 312);
            CameraHeightArrange.Name = "CameraHeightArrange";
            CameraHeightArrange.Size = new Size(291, 97);
            CameraHeightArrange.TabIndex = 5;
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
            NoFovYCheckBox.Location = new Point(44, 122);
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
            FovYColourNumericUpDown.Location = new Point(77, 120);
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
            FovYLabel.Location = new Point(2, 122);
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
            RollColourNumericUpDown.Location = new Point(77, 98);
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
            RollLabel.Location = new Point(2, 100);
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
            AngleAColourNumericUpDown.Location = new Point(77, 76);
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
            AngleALabel.Location = new Point(2, 78);
            AngleALabel.Name = "AngleALabel";
            AngleALabel.Size = new Size(57, 13);
            AngleALabel.TabIndex = 72;
            AngleALabel.Text = "X Rotation";
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
            // AxisXColourNumericUpDown
            // 
            AxisXColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            AxisXColourNumericUpDown.DecimalPlaces = 6;
            AxisXColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            AxisXColourNumericUpDown.Location = new Point(77, 142);
            AxisXColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            AxisXColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            AxisXColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            AxisXColourNumericUpDown.Name = "AxisXColourNumericUpDown";
            AxisXColourNumericUpDown.Size = new Size(74, 20);
            AxisXColourNumericUpDown.TabIndex = 95;
            AxisXColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 393216 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F);
            label1.Location = new Point(2, 166);
            label1.Name = "label1";
            label1.Size = new Size(52, 13);
            label1.TabIndex = 94;
            label1.Text = "Far Zoom";
            // 
            // AxisYColourNumericUpDown
            // 
            AxisYColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            AxisYColourNumericUpDown.DecimalPlaces = 6;
            AxisYColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            AxisYColourNumericUpDown.Location = new Point(77, 164);
            AxisYColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            AxisYColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            AxisYColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            AxisYColourNumericUpDown.Name = "AxisYColourNumericUpDown";
            AxisYColourNumericUpDown.Size = new Size(74, 20);
            AxisYColourNumericUpDown.TabIndex = 93;
            AxisYColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 393216 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F);
            label2.Location = new Point(2, 144);
            label2.Name = "label2";
            label2.Size = new Size(60, 13);
            label2.TabIndex = 92;
            label2.Text = "Near Zoom";
            // 
            // BehaviourGroupBox
            // 
            BehaviourGroupBox.Controls.Add(SubjectiveOffCheckBox);
            BehaviourGroupBox.Controls.Add(NoResetCheckBox);
            BehaviourGroupBox.Controls.Add(CollisionOffCheckBox);
            BehaviourGroupBox.Controls.Add(AntiBlurOffCheckBox);
            BehaviourGroupBox.Location = new Point(157, 147);
            BehaviourGroupBox.Name = "BehaviourGroupBox";
            BehaviourGroupBox.Size = new Size(136, 90);
            BehaviourGroupBox.TabIndex = 96;
            BehaviourGroupBox.TabStop = false;
            BehaviourGroupBox.Text = "Behaviour Options";
            // 
            // SubjectiveOffCheckBox
            // 
            SubjectiveOffCheckBox.AutoSize = true;
            SubjectiveOffCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            SubjectiveOffCheckBox.Location = new Point(6, 17);
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
            NoResetCheckBox.Location = new Point(6, 68);
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
            CollisionOffCheckBox.Location = new Point(6, 34);
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
            AntiBlurOffCheckBox.Location = new Point(6, 51);
            AntiBlurOffCheckBox.Margin = new Padding(3, 0, 3, 0);
            AntiBlurOffCheckBox.Name = "AntiBlurOffCheckBox";
            AntiBlurOffCheckBox.Size = new Size(117, 17);
            AntiBlurOffCheckBox.TabIndex = 88;
            AntiBlurOffCheckBox.Text = "D-Pad Interpolation";
            AntiBlurOffCheckBox.UseVisualStyleBackColor = true;
            // 
            // WonderPlanetCameraPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BehaviourGroupBox);
            Controls.Add(AxisXColourNumericUpDown);
            Controls.Add(label1);
            Controls.Add(AxisYColourNumericUpDown);
            Controls.Add(label2);
            Controls.Add(WOffsetVector3NumericUpDown);
            Controls.Add(CameraVariant);
            Controls.Add(CameraLOfs);
            Controls.Add(NoFovYCheckBox);
            Controls.Add(VersionColourNumericUpDown);
            Controls.Add(VersionLabel);
            Controls.Add(FovYColourNumericUpDown);
            Controls.Add(FovYLabel);
            Controls.Add(RollColourNumericUpDown);
            Controls.Add(RollLabel);
            Controls.Add(AngleAColourNumericUpDown);
            Controls.Add(AngleALabel);
            Controls.Add(StringLabel);
            Controls.Add(StringColourTextBox);
            Controls.Add(CameraHeightArrange);
            Name = "WonderPlanetCameraPanel";
            Controls.SetChildIndex(CameraHeightArrange, 0);
            Controls.SetChildIndex(StringColourTextBox, 0);
            Controls.SetChildIndex(StringLabel, 0);
            Controls.SetChildIndex(AngleALabel, 0);
            Controls.SetChildIndex(AngleAColourNumericUpDown, 0);
            Controls.SetChildIndex(RollLabel, 0);
            Controls.SetChildIndex(RollColourNumericUpDown, 0);
            Controls.SetChildIndex(FovYLabel, 0);
            Controls.SetChildIndex(FovYColourNumericUpDown, 0);
            Controls.SetChildIndex(VersionLabel, 0);
            Controls.SetChildIndex(VersionColourNumericUpDown, 0);
            Controls.SetChildIndex(NoFovYCheckBox, 0);
            Controls.SetChildIndex(CameraLOfs, 0);
            Controls.SetChildIndex(CameraVariant, 0);
            Controls.SetChildIndex(WOffsetVector3NumericUpDown, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(AxisYColourNumericUpDown, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(AxisXColourNumericUpDown, 0);
            Controls.SetChildIndex(BehaviourGroupBox, 0);
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)FovYColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RollColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AngleAColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AxisXColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AxisYColourNumericUpDown).EndInit();
            BehaviourGroupBox.ResumeLayout(false);
            BehaviourGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ExtraControls.CameraHeightControl CameraHeightArrange;
        private Label StringLabel;
        private ExtraControls.ColourTextBox StringColourTextBox;
        private CheckBox NoFovYCheckBox;
        private ExtraControls.ColourNumericUpDown VersionColourNumericUpDown;
        private Label VersionLabel;
        private ExtraControls.ColourNumericUpDown FovYColourNumericUpDown;
        private Label FovYLabel;
        private ExtraControls.ColourNumericUpDown RollColourNumericUpDown;
        private Label RollLabel;
        private ExtraControls.ColourNumericUpDown AngleAColourNumericUpDown;
        private Label AngleALabel;
        private ExtraControls.CameraLookOffsetControl CameraLOfs;
        private ExtraControls.CameraVariantControl CameraVariant;
        private ExtraControls.Vector3NumericUpDown WOffsetVector3NumericUpDown;
        private ExtraControls.ColourNumericUpDown AxisXColourNumericUpDown;
        private Label label1;
        private ExtraControls.ColourNumericUpDown AxisYColourNumericUpDown;
        private Label label2;
        private GroupBox BehaviourGroupBox;
        private CheckBox SubjectiveOffCheckBox;
        private CheckBox NoResetCheckBox;
        private CheckBox CollisionOffCheckBox;
        private CheckBox AntiBlurOffCheckBox;
    }
}
