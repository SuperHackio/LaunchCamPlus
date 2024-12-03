namespace LaunchCamPlus.CameraPanels
{
    partial class SpiralDemoCameraPanel
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
            WOffsetVector3NumericUpDown = new ExtraControls.Vector3NumericUpDown();
            WPointXColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            label1 = new Label();
            WPointYColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            label2 = new Label();
            WPointZColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            label3 = new Label();
            AxisZColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            label4 = new Label();
            AxisYColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            label5 = new Label();
            AxisXColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            label6 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            SubjectiveOffCheckBox = new CheckBox();
            NoResetCheckBox = new CheckBox();
            CollisionOffCheckBox = new CheckBox();
            label8 = new Label();
            label7 = new Label();
            Num1BColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            Num1AColourNumericUpDown = new ExtraControls.ColourNumericUpDown();
            groupBox4 = new GroupBox();
            Num2NoneRadioButton = new RadioButton();
            Num2SmoothRadioButton = new RadioButton();
            Num2LinearRadioButton = new RadioButton();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FovYColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RollColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WPointXColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WPointYColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WPointZColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AxisZColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AxisYColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AxisXColourNumericUpDown).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Num1BColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Num1AColourNumericUpDown).BeginInit();
            groupBox4.SuspendLayout();
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
            // WOffsetVector3NumericUpDown
            // 
            WOffsetVector3NumericUpDown.Location = new Point(157, 56);
            WOffsetVector3NumericUpDown.MinimumSize = new Size(70, 85);
            WOffsetVector3NumericUpDown.Name = "WOffsetVector3NumericUpDown";
            WOffsetVector3NumericUpDown.Size = new Size(136, 85);
            WOffsetVector3NumericUpDown.TabIndex = 87;
            WOffsetVector3NumericUpDown.Text = "Static Offset from Target";
            // 
            // WPointXColourNumericUpDown
            // 
            WPointXColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            WPointXColourNumericUpDown.DecimalPlaces = 3;
            WPointXColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            WPointXColourNumericUpDown.Location = new Point(69, 20);
            WPointXColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            WPointXColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            WPointXColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            WPointXColourNumericUpDown.Name = "WPointXColourNumericUpDown";
            WPointXColourNumericUpDown.Size = new Size(86, 20);
            WPointXColourNumericUpDown.TabIndex = 77;
            WPointXColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F);
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(57, 13);
            label1.TabIndex = 76;
            label1.Text = "Y Rotation";
            // 
            // WPointYColourNumericUpDown
            // 
            WPointYColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            WPointYColourNumericUpDown.DecimalPlaces = 3;
            WPointYColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            WPointYColourNumericUpDown.Location = new Point(69, 42);
            WPointYColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            WPointYColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            WPointYColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            WPointYColourNumericUpDown.Name = "WPointYColourNumericUpDown";
            WPointYColourNumericUpDown.Size = new Size(86, 20);
            WPointYColourNumericUpDown.TabIndex = 89;
            WPointYColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F);
            label2.Location = new Point(6, 44);
            label2.Name = "label2";
            label2.Size = new Size(45, 13);
            label2.TabIndex = 88;
            label2.Text = "Y Offset";
            // 
            // WPointZColourNumericUpDown
            // 
            WPointZColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            WPointZColourNumericUpDown.DecimalPlaces = 3;
            WPointZColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            WPointZColourNumericUpDown.Location = new Point(69, 64);
            WPointZColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            WPointZColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            WPointZColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            WPointZColourNumericUpDown.Name = "WPointZColourNumericUpDown";
            WPointZColourNumericUpDown.Size = new Size(86, 20);
            WPointZColourNumericUpDown.TabIndex = 91;
            WPointZColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F);
            label3.Location = new Point(6, 66);
            label3.Name = "label3";
            label3.Size = new Size(34, 13);
            label3.TabIndex = 90;
            label3.Text = "Zoom";
            // 
            // AxisZColourNumericUpDown
            // 
            AxisZColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            AxisZColourNumericUpDown.DecimalPlaces = 3;
            AxisZColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            AxisZColourNumericUpDown.Location = new Point(69, 64);
            AxisZColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            AxisZColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            AxisZColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            AxisZColourNumericUpDown.Name = "AxisZColourNumericUpDown";
            AxisZColourNumericUpDown.Size = new Size(86, 20);
            AxisZColourNumericUpDown.TabIndex = 97;
            AxisZColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 8.25F);
            label4.Location = new Point(6, 66);
            label4.Name = "label4";
            label4.Size = new Size(34, 13);
            label4.TabIndex = 96;
            label4.Text = "Zoom";
            // 
            // AxisYColourNumericUpDown
            // 
            AxisYColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            AxisYColourNumericUpDown.DecimalPlaces = 3;
            AxisYColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            AxisYColourNumericUpDown.Location = new Point(69, 42);
            AxisYColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            AxisYColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            AxisYColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            AxisYColourNumericUpDown.Name = "AxisYColourNumericUpDown";
            AxisYColourNumericUpDown.Size = new Size(86, 20);
            AxisYColourNumericUpDown.TabIndex = 95;
            AxisYColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 8.25F);
            label5.Location = new Point(6, 44);
            label5.Name = "label5";
            label5.Size = new Size(45, 13);
            label5.TabIndex = 94;
            label5.Text = "Y Offset";
            // 
            // AxisXColourNumericUpDown
            // 
            AxisXColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            AxisXColourNumericUpDown.DecimalPlaces = 3;
            AxisXColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            AxisXColourNumericUpDown.Location = new Point(69, 20);
            AxisXColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            AxisXColourNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            AxisXColourNumericUpDown.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            AxisXColourNumericUpDown.Name = "AxisXColourNumericUpDown";
            AxisXColourNumericUpDown.Size = new Size(86, 20);
            AxisXColourNumericUpDown.TabIndex = 93;
            AxisXColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 196608 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 8.25F);
            label6.Location = new Point(6, 22);
            label6.Name = "label6";
            label6.Size = new Size(57, 13);
            label6.TabIndex = 92;
            label6.Text = "Y Rotation";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(WPointXColourNumericUpDown);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(WPointYColourNumericUpDown);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(WPointZColourNumericUpDown);
            groupBox1.Location = new Point(-4, 119);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(161, 89);
            groupBox1.TabIndex = 98;
            groupBox1.TabStop = false;
            groupBox1.Text = "Starting Values";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(AxisXColourNumericUpDown);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(AxisZColourNumericUpDown);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(AxisYColourNumericUpDown);
            groupBox2.Location = new Point(-4, 214);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(161, 89);
            groupBox2.TabIndex = 99;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ending Values";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(SubjectiveOffCheckBox);
            groupBox3.Controls.Add(NoResetCheckBox);
            groupBox3.Controls.Add(CollisionOffCheckBox);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(Num1BColourNumericUpDown);
            groupBox3.Controls.Add(Num1AColourNumericUpDown);
            groupBox3.Location = new Point(161, 147);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(130, 172);
            groupBox3.TabIndex = 100;
            groupBox3.TabStop = false;
            groupBox3.Text = "Behaviour Options";
            // 
            // SubjectiveOffCheckBox
            // 
            SubjectiveOffCheckBox.AutoSize = true;
            SubjectiveOffCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            SubjectiveOffCheckBox.Location = new Point(6, 116);
            SubjectiveOffCheckBox.Margin = new Padding(3, 0, 3, 0);
            SubjectiveOffCheckBox.Name = "SubjectiveOffCheckBox";
            SubjectiveOffCheckBox.Size = new Size(81, 17);
            SubjectiveOffCheckBox.TabIndex = 106;
            SubjectiveOffCheckBox.Text = "First Person";
            SubjectiveOffCheckBox.UseVisualStyleBackColor = true;
            // 
            // NoResetCheckBox
            // 
            NoResetCheckBox.AutoSize = true;
            NoResetCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            NoResetCheckBox.Location = new Point(6, 150);
            NoResetCheckBox.Margin = new Padding(3, 0, 3, 0);
            NoResetCheckBox.Name = "NoResetCheckBox";
            NoResetCheckBox.Size = new Size(68, 17);
            NoResetCheckBox.TabIndex = 104;
            NoResetCheckBox.Text = "NoReset";
            NoResetCheckBox.UseVisualStyleBackColor = true;
            // 
            // CollisionOffCheckBox
            // 
            CollisionOffCheckBox.AutoSize = true;
            CollisionOffCheckBox.Font = new Font("Microsoft Sans Serif", 8.25F);
            CollisionOffCheckBox.Location = new Point(6, 133);
            CollisionOffCheckBox.Margin = new Padding(3, 0, 3, 0);
            CollisionOffCheckBox.Name = "CollisionOffCheckBox";
            CollisionOffCheckBox.Size = new Size(102, 17);
            CollisionOffCheckBox.TabIndex = 105;
            CollisionOffCheckBox.Text = "Disable Collision";
            CollisionOffCheckBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 67);
            label8.Name = "label8";
            label8.Size = new Size(111, 15);
            label8.TabIndex = 103;
            label8.Text = "Rotation Start Delay";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 22);
            label7.Name = "label7";
            label7.Size = new Size(81, 15);
            label7.TabIndex = 101;
            label7.Text = "Rotation Time";
            // 
            // Num1BColourNumericUpDown
            // 
            Num1BColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            Num1BColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            Num1BColourNumericUpDown.Location = new Point(6, 83);
            Num1BColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            Num1BColourNumericUpDown.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            Num1BColourNumericUpDown.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
            Num1BColourNumericUpDown.Name = "Num1BColourNumericUpDown";
            Num1BColourNumericUpDown.Size = new Size(118, 20);
            Num1BColourNumericUpDown.TabIndex = 102;
            Num1BColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // Num1AColourNumericUpDown
            // 
            Num1AColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            Num1AColourNumericUpDown.Font = new Font("Microsoft Sans Serif", 8.25F);
            Num1AColourNumericUpDown.Location = new Point(6, 38);
            Num1AColourNumericUpDown.Margin = new Padding(3, 1, 3, 1);
            Num1AColourNumericUpDown.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            Num1AColourNumericUpDown.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
            Num1AColourNumericUpDown.Name = "Num1AColourNumericUpDown";
            Num1AColourNumericUpDown.Size = new Size(118, 20);
            Num1AColourNumericUpDown.TabIndex = 101;
            Num1AColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(Num2NoneRadioButton);
            groupBox4.Controls.Add(Num2SmoothRadioButton);
            groupBox4.Controls.Add(Num2LinearRadioButton);
            groupBox4.Location = new Point(0, 309);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(157, 87);
            groupBox4.TabIndex = 101;
            groupBox4.TabStop = false;
            groupBox4.Text = "Interpolation";
            // 
            // Num2NoneRadioButton
            // 
            Num2NoneRadioButton.AutoSize = true;
            Num2NoneRadioButton.Location = new Point(6, 62);
            Num2NoneRadioButton.Margin = new Padding(1);
            Num2NoneRadioButton.Name = "Num2NoneRadioButton";
            Num2NoneRadioButton.Size = new Size(102, 19);
            Num2NoneRadioButton.TabIndex = 2;
            Num2NoneRadioButton.TabStop = true;
            Num2NoneRadioButton.Text = "No Movement";
            Num2NoneRadioButton.UseVisualStyleBackColor = true;
            // 
            // Num2SmoothRadioButton
            // 
            Num2SmoothRadioButton.AutoSize = true;
            Num2SmoothRadioButton.Location = new Point(6, 41);
            Num2SmoothRadioButton.Margin = new Padding(1);
            Num2SmoothRadioButton.Name = "Num2SmoothRadioButton";
            Num2SmoothRadioButton.Size = new Size(67, 19);
            Num2SmoothRadioButton.TabIndex = 1;
            Num2SmoothRadioButton.TabStop = true;
            Num2SmoothRadioButton.Text = "Smooth";
            Num2SmoothRadioButton.UseVisualStyleBackColor = true;
            // 
            // Num2LinearRadioButton
            // 
            Num2LinearRadioButton.AutoSize = true;
            Num2LinearRadioButton.Location = new Point(6, 20);
            Num2LinearRadioButton.Margin = new Padding(1);
            Num2LinearRadioButton.Name = "Num2LinearRadioButton";
            Num2LinearRadioButton.Size = new Size(57, 19);
            Num2LinearRadioButton.TabIndex = 0;
            Num2LinearRadioButton.TabStop = true;
            Num2LinearRadioButton.Text = "Linear";
            Num2LinearRadioButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(238, 352);
            label9.Name = "label9";
            label9.Size = new Size(187, 45);
            label9.TabIndex = 102;
            label9.Text = "Note: The Y Rotations for this\r\ncamera type are absolute.\r\n0 -> 360 is different than 0 -> -360";
            // 
            // SpiralDemoCameraPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label9);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(WOffsetVector3NumericUpDown);
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
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "SpiralDemoCameraPanel";
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(groupBox2, 0);
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
            Controls.SetChildIndex(WOffsetVector3NumericUpDown, 0);
            Controls.SetChildIndex(groupBox3, 0);
            Controls.SetChildIndex(groupBox4, 0);
            Controls.SetChildIndex(label9, 0);
            ((System.ComponentModel.ISupportInitialize)VersionColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)FovYColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RollColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)WPointXColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)WPointYColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)WPointZColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AxisZColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AxisYColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AxisXColourNumericUpDown).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Num1BColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)Num1AColourNumericUpDown).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private ExtraControls.Vector3NumericUpDown WOffsetVector3NumericUpDown;
        private ExtraControls.ColourNumericUpDown WPointXColourNumericUpDown;
        private Label label1;
        private ExtraControls.ColourNumericUpDown WPointYColourNumericUpDown;
        private Label label2;
        private ExtraControls.ColourNumericUpDown WPointZColourNumericUpDown;
        private Label label3;
        private ExtraControls.ColourNumericUpDown AxisZColourNumericUpDown;
        private Label label4;
        private ExtraControls.ColourNumericUpDown AxisYColourNumericUpDown;
        private Label label5;
        private ExtraControls.ColourNumericUpDown AxisXColourNumericUpDown;
        private Label label6;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private ExtraControls.ColourNumericUpDown Num1AColourNumericUpDown;
        private Label label8;
        private Label label7;
        private ExtraControls.ColourNumericUpDown Num1BColourNumericUpDown;
        private GroupBox groupBox4;
        private RadioButton Num2NoneRadioButton;
        private RadioButton Num2SmoothRadioButton;
        private RadioButton Num2LinearRadioButton;
        private CheckBox SubjectiveOffCheckBox;
        private CheckBox NoResetCheckBox;
        private CheckBox CollisionOffCheckBox;
        private Label label9;
    }
}
