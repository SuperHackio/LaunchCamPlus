namespace LaunchCamPlus.CameraPanels
{
    partial class XZParaCameraPanel : CameraPanelBase
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
            this.RotationXNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.RotationXLabel = new System.Windows.Forms.Label();
            this.RotationYLabel = new System.Windows.Forms.Label();
            this.RotationZLabel = new System.Windows.Forms.Label();
            this.RotationZNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.RotationYNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.LowerBorderNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.LowerBorderLabel = new System.Windows.Forms.Label();
            this.UpperBorderNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.UpperBorderLabel = new System.Windows.Forms.Label();
            this.HeightOffsetNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.HeightOffsetLabel = new System.Windows.Forms.Label();
            this.FrontOffsetNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.FrontOffsetLabel = new System.Windows.Forms.Label();
            this.JumpingYNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.MaxYLabel = new System.Windows.Forms.Label();
            this.MinYLabel = new System.Windows.Forms.Label();
            this.FallingYNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.FieldOfViewNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.FieldOfViewLabel = new System.Windows.Forms.Label();
            this.ZoomNumericUpDown = new LaunchCamPlus.ColourNumericUpDown();
            this.ZoomLabel = new System.Windows.Forms.Label();
            this.FlagGroupBox = new System.Windows.Forms.GroupBox();
            this.Num2CheckBox = new System.Windows.Forms.CheckBox();
            this.Num1CheckBox = new System.Windows.Forms.CheckBox();
            this.FieldOfViewCheckBox = new System.Windows.Forms.CheckBox();
            this.EventUseTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.EventUseEndTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableAntiBlurCheckBox = new System.Windows.Forms.CheckBox();
            this.SharpZoomCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableFirstPersonCheckBox = new System.Windows.Forms.CheckBox();
            this.GFlagTransitionEndTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.GFlagThroughCheckBox = new System.Windows.Forms.CheckBox();
            this.GFlagEndErpFrameCheckBox = new System.Windows.Forms.CheckBox();
            this.UseVerticalPanAxisCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableCollisionCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.RotationXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationZNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerBorderNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpperBorderNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightOffsetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontOffsetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JumpingYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FallingYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieldOfViewNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomNumericUpDown)).BeginInit();
            this.FlagGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RotationXNumericUpDown
            // 
            this.RotationXNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.RotationXNumericUpDown.DecimalPlaces = 3;
            this.RotationXNumericUpDown.Location = new System.Drawing.Point(83, 56);
            this.RotationXNumericUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.RotationXNumericUpDown.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.RotationXNumericUpDown.Name = "RotationXNumericUpDown";
            this.RotationXNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.RotationXNumericUpDown.TabIndex = 11;
            // 
            // RotationXLabel
            // 
            this.RotationXLabel.AutoSize = true;
            this.RotationXLabel.Location = new System.Drawing.Point(3, 58);
            this.RotationXLabel.Name = "RotationXLabel";
            this.RotationXLabel.Size = new System.Drawing.Size(57, 13);
            this.RotationXLabel.TabIndex = 10;
            this.RotationXLabel.Text = "X Rotation";
            // 
            // RotationYLabel
            // 
            this.RotationYLabel.AutoSize = true;
            this.RotationYLabel.Location = new System.Drawing.Point(2, 84);
            this.RotationYLabel.Name = "RotationYLabel";
            this.RotationYLabel.Size = new System.Drawing.Size(57, 13);
            this.RotationYLabel.TabIndex = 12;
            this.RotationYLabel.Text = "Y Rotation";
            // 
            // RotationZLabel
            // 
            this.RotationZLabel.AutoSize = true;
            this.RotationZLabel.Location = new System.Drawing.Point(3, 110);
            this.RotationZLabel.Name = "RotationZLabel";
            this.RotationZLabel.Size = new System.Drawing.Size(25, 13);
            this.RotationZLabel.TabIndex = 14;
            this.RotationZLabel.Text = "Roll";
            // 
            // RotationZNumericUpDown
            // 
            this.RotationZNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.RotationZNumericUpDown.DecimalPlaces = 3;
            this.RotationZNumericUpDown.Location = new System.Drawing.Point(83, 108);
            this.RotationZNumericUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.RotationZNumericUpDown.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.RotationZNumericUpDown.Name = "RotationZNumericUpDown";
            this.RotationZNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.RotationZNumericUpDown.TabIndex = 15;
            // 
            // RotationYNumericUpDown
            // 
            this.RotationYNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.RotationYNumericUpDown.DecimalPlaces = 3;
            this.RotationYNumericUpDown.Location = new System.Drawing.Point(83, 82);
            this.RotationYNumericUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.RotationYNumericUpDown.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.RotationYNumericUpDown.Name = "RotationYNumericUpDown";
            this.RotationYNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.RotationYNumericUpDown.TabIndex = 13;
            // 
            // LowerBorderNumericUpDown
            // 
            this.LowerBorderNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LowerBorderNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.LowerBorderNumericUpDown.DecimalPlaces = 3;
            this.LowerBorderNumericUpDown.Location = new System.Drawing.Point(83, 316);
            this.LowerBorderNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.LowerBorderNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.LowerBorderNumericUpDown.Name = "LowerBorderNumericUpDown";
            this.LowerBorderNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.LowerBorderNumericUpDown.TabIndex = 62;
            // 
            // LowerBorderLabel
            // 
            this.LowerBorderLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LowerBorderLabel.AutoSize = true;
            this.LowerBorderLabel.Location = new System.Drawing.Point(3, 318);
            this.LowerBorderLabel.Name = "LowerBorderLabel";
            this.LowerBorderLabel.Size = new System.Drawing.Size(70, 13);
            this.LowerBorderLabel.TabIndex = 61;
            this.LowerBorderLabel.Text = "Lower Border";
            // 
            // UpperBorderNumericUpDown
            // 
            this.UpperBorderNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UpperBorderNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.UpperBorderNumericUpDown.DecimalPlaces = 3;
            this.UpperBorderNumericUpDown.Location = new System.Drawing.Point(83, 290);
            this.UpperBorderNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.UpperBorderNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.UpperBorderNumericUpDown.Name = "UpperBorderNumericUpDown";
            this.UpperBorderNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.UpperBorderNumericUpDown.TabIndex = 60;
            // 
            // UpperBorderLabel
            // 
            this.UpperBorderLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UpperBorderLabel.AutoSize = true;
            this.UpperBorderLabel.Location = new System.Drawing.Point(3, 292);
            this.UpperBorderLabel.Name = "UpperBorderLabel";
            this.UpperBorderLabel.Size = new System.Drawing.Size(70, 13);
            this.UpperBorderLabel.TabIndex = 59;
            this.UpperBorderLabel.Text = "Upper Border";
            // 
            // HeightOffsetNumericUpDown
            // 
            this.HeightOffsetNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HeightOffsetNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.HeightOffsetNumericUpDown.DecimalPlaces = 3;
            this.HeightOffsetNumericUpDown.Location = new System.Drawing.Point(83, 212);
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
            this.HeightOffsetNumericUpDown.TabIndex = 58;
            // 
            // HeightOffsetLabel
            // 
            this.HeightOffsetLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HeightOffsetLabel.AutoSize = true;
            this.HeightOffsetLabel.Location = new System.Drawing.Point(3, 214);
            this.HeightOffsetLabel.Name = "HeightOffsetLabel";
            this.HeightOffsetLabel.Size = new System.Drawing.Size(62, 13);
            this.HeightOffsetLabel.TabIndex = 57;
            this.HeightOffsetLabel.Text = "Air distance";
            // 
            // FrontOffsetNumericUpDown
            // 
            this.FrontOffsetNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.FrontOffsetNumericUpDown.DecimalPlaces = 3;
            this.FrontOffsetNumericUpDown.Location = new System.Drawing.Point(83, 186);
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
            this.FrontOffsetNumericUpDown.TabIndex = 56;
            // 
            // FrontOffsetLabel
            // 
            this.FrontOffsetLabel.AutoSize = true;
            this.FrontOffsetLabel.Location = new System.Drawing.Point(3, 188);
            this.FrontOffsetLabel.Name = "FrontOffsetLabel";
            this.FrontOffsetLabel.Size = new System.Drawing.Size(74, 13);
            this.FrontOffsetLabel.TabIndex = 55;
            this.FrontOffsetLabel.Text = "Front distance";
            // 
            // JumpingYNumericUpDown
            // 
            this.JumpingYNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JumpingYNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.JumpingYNumericUpDown.DecimalPlaces = 3;
            this.JumpingYNumericUpDown.Location = new System.Drawing.Point(83, 238);
            this.JumpingYNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.JumpingYNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.JumpingYNumericUpDown.Name = "JumpingYNumericUpDown";
            this.JumpingYNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.JumpingYNumericUpDown.TabIndex = 52;
            // 
            // MaxYLabel
            // 
            this.MaxYLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxYLabel.AutoSize = true;
            this.MaxYLabel.Location = new System.Drawing.Point(3, 245);
            this.MaxYLabel.Name = "MaxYLabel";
            this.MaxYLabel.Size = new System.Drawing.Size(37, 13);
            this.MaxYLabel.TabIndex = 51;
            this.MaxYLabel.Text = "Max Y";
            // 
            // MinYLabel
            // 
            this.MinYLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinYLabel.AutoSize = true;
            this.MinYLabel.Location = new System.Drawing.Point(3, 271);
            this.MinYLabel.Name = "MinYLabel";
            this.MinYLabel.Size = new System.Drawing.Size(34, 13);
            this.MinYLabel.TabIndex = 53;
            this.MinYLabel.Text = "Min Y";
            // 
            // FallingYNumericUpDown
            // 
            this.FallingYNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FallingYNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.FallingYNumericUpDown.DecimalPlaces = 3;
            this.FallingYNumericUpDown.Location = new System.Drawing.Point(83, 264);
            this.FallingYNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.FallingYNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.FallingYNumericUpDown.Name = "FallingYNumericUpDown";
            this.FallingYNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.FallingYNumericUpDown.TabIndex = 54;
            // 
            // FieldOfViewNumericUpDown
            // 
            this.FieldOfViewNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FieldOfViewNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.FieldOfViewNumericUpDown.DecimalPlaces = 3;
            this.FieldOfViewNumericUpDown.Location = new System.Drawing.Point(83, 160);
            this.FieldOfViewNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.FieldOfViewNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.FieldOfViewNumericUpDown.Name = "FieldOfViewNumericUpDown";
            this.FieldOfViewNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.FieldOfViewNumericUpDown.TabIndex = 50;
            // 
            // FieldOfViewLabel
            // 
            this.FieldOfViewLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FieldOfViewLabel.AutoSize = true;
            this.FieldOfViewLabel.Location = new System.Drawing.Point(3, 162);
            this.FieldOfViewLabel.Name = "FieldOfViewLabel";
            this.FieldOfViewLabel.Size = new System.Drawing.Size(67, 13);
            this.FieldOfViewLabel.TabIndex = 49;
            this.FieldOfViewLabel.Text = "Field of View";
            // 
            // ZoomNumericUpDown
            // 
            this.ZoomNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ZoomNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ZoomNumericUpDown.DecimalPlaces = 3;
            this.ZoomNumericUpDown.Location = new System.Drawing.Point(83, 134);
            this.ZoomNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ZoomNumericUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.ZoomNumericUpDown.Name = "ZoomNumericUpDown";
            this.ZoomNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.ZoomNumericUpDown.TabIndex = 48;
            // 
            // ZoomLabel
            // 
            this.ZoomLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ZoomLabel.AutoSize = true;
            this.ZoomLabel.Location = new System.Drawing.Point(3, 136);
            this.ZoomLabel.Name = "ZoomLabel";
            this.ZoomLabel.Size = new System.Drawing.Size(34, 13);
            this.ZoomLabel.TabIndex = 47;
            this.ZoomLabel.Text = "Zoom";
            // 
            // FlagGroupBox
            // 
            this.FlagGroupBox.Controls.Add(this.Num2CheckBox);
            this.FlagGroupBox.Controls.Add(this.Num1CheckBox);
            this.FlagGroupBox.Controls.Add(this.GFlagThroughCheckBox);
            this.FlagGroupBox.Controls.Add(this.FieldOfViewCheckBox);
            this.FlagGroupBox.Controls.Add(this.EventUseTimeCheckBox);
            this.FlagGroupBox.Controls.Add(this.EventUseEndTimeCheckBox);
            this.FlagGroupBox.Controls.Add(this.DisableCollisionCheckBox);
            this.FlagGroupBox.Controls.Add(this.DisableAntiBlurCheckBox);
            this.FlagGroupBox.Controls.Add(this.SharpZoomCheckBox);
            this.FlagGroupBox.Controls.Add(this.DisableFirstPersonCheckBox);
            this.FlagGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlagGroupBox.Location = new System.Drawing.Point(0, 343);
            this.FlagGroupBox.Name = "FlagGroupBox";
            this.FlagGroupBox.Size = new System.Drawing.Size(441, 98);
            this.FlagGroupBox.TabIndex = 63;
            this.FlagGroupBox.TabStop = false;
            this.FlagGroupBox.Text = "Flags";
            // 
            // Num2CheckBox
            // 
            this.Num2CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Num2CheckBox.AutoSize = true;
            this.Num2CheckBox.Location = new System.Drawing.Point(302, 42);
            this.Num2CheckBox.Name = "Num2CheckBox";
            this.Num2CheckBox.Size = new System.Drawing.Size(125, 17);
            this.Num2CheckBox.TabIndex = 76;
            this.Num2CheckBox.Text = "Disable D-Pad Reset";
            this.Num2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Num1CheckBox
            // 
            this.Num1CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Num1CheckBox.AutoSize = true;
            this.Num1CheckBox.Location = new System.Drawing.Point(137, 42);
            this.Num1CheckBox.Name = "Num1CheckBox";
            this.Num1CheckBox.Size = new System.Drawing.Size(137, 17);
            this.Num1CheckBox.TabIndex = 75;
            this.Num1CheckBox.Text = "Disable D-Pad Rotation";
            this.Num1CheckBox.UseVisualStyleBackColor = true;
            // 
            // FieldOfViewCheckBox
            // 
            this.FieldOfViewCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FieldOfViewCheckBox.AutoSize = true;
            this.FieldOfViewCheckBox.Location = new System.Drawing.Point(6, 19);
            this.FieldOfViewCheckBox.Name = "FieldOfViewCheckBox";
            this.FieldOfViewCheckBox.Size = new System.Drawing.Size(122, 17);
            this.FieldOfViewCheckBox.TabIndex = 64;
            this.FieldOfViewCheckBox.Text = "Enable Field of View";
            this.FieldOfViewCheckBox.UseVisualStyleBackColor = true;
            // 
            // EventUseTimeCheckBox
            // 
            this.EventUseTimeCheckBox.AutoSize = true;
            this.EventUseTimeCheckBox.Location = new System.Drawing.Point(114, 78);
            this.EventUseTimeCheckBox.Name = "EventUseTimeCheckBox";
            this.EventUseTimeCheckBox.Size = new System.Drawing.Size(159, 17);
            this.EventUseTimeCheckBox.TabIndex = 73;
            this.EventUseTimeCheckBox.Text = "Events: Use Transition Time";
            this.EventUseTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // EventUseEndTimeCheckBox
            // 
            this.EventUseEndTimeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EventUseEndTimeCheckBox.AutoSize = true;
            this.EventUseEndTimeCheckBox.Location = new System.Drawing.Point(305, 78);
            this.EventUseEndTimeCheckBox.Name = "EventUseEndTimeCheckBox";
            this.EventUseEndTimeCheckBox.Size = new System.Drawing.Size(130, 17);
            this.EventUseEndTimeCheckBox.TabIndex = 74;
            this.EventUseEndTimeCheckBox.Text = "Events: Use Exit Time";
            this.EventUseEndTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableAntiBlurCheckBox
            // 
            this.DisableAntiBlurCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DisableAntiBlurCheckBox.AutoSize = true;
            this.DisableAntiBlurCheckBox.Location = new System.Drawing.Point(265, 19);
            this.DisableAntiBlurCheckBox.Name = "DisableAntiBlurCheckBox";
            this.DisableAntiBlurCheckBox.Size = new System.Drawing.Size(80, 17);
            this.DisableAntiBlurCheckBox.TabIndex = 68;
            this.DisableAntiBlurCheckBox.Text = "Enable Blur";
            this.DisableAntiBlurCheckBox.UseVisualStyleBackColor = true;
            // 
            // SharpZoomCheckBox
            // 
            this.SharpZoomCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SharpZoomCheckBox.AutoSize = true;
            this.SharpZoomCheckBox.Location = new System.Drawing.Point(140, 19);
            this.SharpZoomCheckBox.Name = "SharpZoomCheckBox";
            this.SharpZoomCheckBox.Size = new System.Drawing.Size(122, 17);
            this.SharpZoomCheckBox.TabIndex = 65;
            this.SharpZoomCheckBox.Text = "Disable Interpolation";
            this.SharpZoomCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableFirstPersonCheckBox
            // 
            this.DisableFirstPersonCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DisableFirstPersonCheckBox.AutoSize = true;
            this.DisableFirstPersonCheckBox.Location = new System.Drawing.Point(6, 42);
            this.DisableFirstPersonCheckBox.Name = "DisableFirstPersonCheckBox";
            this.DisableFirstPersonCheckBox.Size = new System.Drawing.Size(119, 17);
            this.DisableFirstPersonCheckBox.TabIndex = 69;
            this.DisableFirstPersonCheckBox.Text = "Disable First Person";
            this.DisableFirstPersonCheckBox.UseVisualStyleBackColor = true;
            // 
            // GFlagTransitionEndTimeCheckBox
            // 
            this.GFlagTransitionEndTimeCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GFlagTransitionEndTimeCheckBox.AutoSize = true;
            this.GFlagTransitionEndTimeCheckBox.Location = new System.Drawing.Point(171, 239);
            this.GFlagTransitionEndTimeCheckBox.Name = "GFlagTransitionEndTimeCheckBox";
            this.GFlagTransitionEndTimeCheckBox.Size = new System.Drawing.Size(96, 17);
            this.GFlagTransitionEndTimeCheckBox.TabIndex = 72;
            this.GFlagTransitionEndTimeCheckBox.Text = "GFlagEndTime";
            this.GFlagTransitionEndTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // GFlagThroughCheckBox
            // 
            this.GFlagThroughCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GFlagThroughCheckBox.AutoSize = true;
            this.GFlagThroughCheckBox.Location = new System.Drawing.Point(6, 55);
            this.GFlagThroughCheckBox.Name = "GFlagThroughCheckBox";
            this.GFlagThroughCheckBox.Size = new System.Drawing.Size(94, 17);
            this.GFlagThroughCheckBox.TabIndex = 71;
            this.GFlagThroughCheckBox.Text = "GFlagThrough";
            this.GFlagThroughCheckBox.UseVisualStyleBackColor = true;
            // 
            // GFlagEndErpFrameCheckBox
            // 
            this.GFlagEndErpFrameCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GFlagEndErpFrameCheckBox.AutoSize = true;
            this.GFlagEndErpFrameCheckBox.Location = new System.Drawing.Point(312, 261);
            this.GFlagEndErpFrameCheckBox.Name = "GFlagEndErpFrameCheckBox";
            this.GFlagEndErpFrameCheckBox.Size = new System.Drawing.Size(118, 17);
            this.GFlagEndErpFrameCheckBox.TabIndex = 70;
            this.GFlagEndErpFrameCheckBox.Text = "GFlagEndErpFrame";
            this.GFlagEndErpFrameCheckBox.UseVisualStyleBackColor = true;
            // 
            // UseVerticalPanAxisCheckBox
            // 
            this.UseVerticalPanAxisCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseVerticalPanAxisCheckBox.AutoSize = true;
            this.UseVerticalPanAxisCheckBox.Location = new System.Drawing.Point(312, 295);
            this.UseVerticalPanAxisCheckBox.Name = "UseVerticalPanAxisCheckBox";
            this.UseVerticalPanAxisCheckBox.Size = new System.Drawing.Size(119, 17);
            this.UseVerticalPanAxisCheckBox.TabIndex = 67;
            this.UseVerticalPanAxisCheckBox.Text = "Enable Vertical Axis";
            this.UseVerticalPanAxisCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableCollisionCheckBox
            // 
            this.DisableCollisionCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DisableCollisionCheckBox.AutoSize = true;
            this.DisableCollisionCheckBox.Location = new System.Drawing.Point(6, 78);
            this.DisableCollisionCheckBox.Name = "DisableCollisionCheckBox";
            this.DisableCollisionCheckBox.Size = new System.Drawing.Size(102, 17);
            this.DisableCollisionCheckBox.TabIndex = 66;
            this.DisableCollisionCheckBox.Text = "Disable Collision";
            this.DisableCollisionCheckBox.UseVisualStyleBackColor = true;
            // 
            // XZParaCameraPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CameraType = "CAM_TYPE_XZ_PARA";
            this.Controls.Add(this.GFlagTransitionEndTimeCheckBox);
            this.Controls.Add(this.GFlagEndErpFrameCheckBox);
            this.Controls.Add(this.UseVerticalPanAxisCheckBox);
            this.Controls.Add(this.FlagGroupBox);
            this.Controls.Add(this.LowerBorderNumericUpDown);
            this.Controls.Add(this.LowerBorderLabel);
            this.Controls.Add(this.UpperBorderNumericUpDown);
            this.Controls.Add(this.UpperBorderLabel);
            this.Controls.Add(this.HeightOffsetNumericUpDown);
            this.Controls.Add(this.HeightOffsetLabel);
            this.Controls.Add(this.FrontOffsetNumericUpDown);
            this.Controls.Add(this.FrontOffsetLabel);
            this.Controls.Add(this.JumpingYNumericUpDown);
            this.Controls.Add(this.MaxYLabel);
            this.Controls.Add(this.MinYLabel);
            this.Controls.Add(this.FallingYNumericUpDown);
            this.Controls.Add(this.FieldOfViewNumericUpDown);
            this.Controls.Add(this.FieldOfViewLabel);
            this.Controls.Add(this.ZoomNumericUpDown);
            this.Controls.Add(this.ZoomLabel);
            this.Controls.Add(this.RotationXNumericUpDown);
            this.Controls.Add(this.RotationXLabel);
            this.Controls.Add(this.RotationYLabel);
            this.Controls.Add(this.RotationZLabel);
            this.Controls.Add(this.RotationZNumericUpDown);
            this.Controls.Add(this.RotationYNumericUpDown);
            this.Name = "XZParaCameraPanel";
            this.Controls.SetChildIndex(this.RotationYNumericUpDown, 0);
            this.Controls.SetChildIndex(this.RotationZNumericUpDown, 0);
            this.Controls.SetChildIndex(this.RotationZLabel, 0);
            this.Controls.SetChildIndex(this.RotationYLabel, 0);
            this.Controls.SetChildIndex(this.RotationXLabel, 0);
            this.Controls.SetChildIndex(this.RotationXNumericUpDown, 0);
            this.Controls.SetChildIndex(this.ZoomLabel, 0);
            this.Controls.SetChildIndex(this.ZoomNumericUpDown, 0);
            this.Controls.SetChildIndex(this.FieldOfViewLabel, 0);
            this.Controls.SetChildIndex(this.FieldOfViewNumericUpDown, 0);
            this.Controls.SetChildIndex(this.FallingYNumericUpDown, 0);
            this.Controls.SetChildIndex(this.MinYLabel, 0);
            this.Controls.SetChildIndex(this.MaxYLabel, 0);
            this.Controls.SetChildIndex(this.JumpingYNumericUpDown, 0);
            this.Controls.SetChildIndex(this.FrontOffsetLabel, 0);
            this.Controls.SetChildIndex(this.FrontOffsetNumericUpDown, 0);
            this.Controls.SetChildIndex(this.HeightOffsetLabel, 0);
            this.Controls.SetChildIndex(this.HeightOffsetNumericUpDown, 0);
            this.Controls.SetChildIndex(this.UpperBorderLabel, 0);
            this.Controls.SetChildIndex(this.UpperBorderNumericUpDown, 0);
            this.Controls.SetChildIndex(this.LowerBorderLabel, 0);
            this.Controls.SetChildIndex(this.LowerBorderNumericUpDown, 0);
            this.Controls.SetChildIndex(this.FlagGroupBox, 0);
            this.Controls.SetChildIndex(this.UseVerticalPanAxisCheckBox, 0);
            this.Controls.SetChildIndex(this.GFlagEndErpFrameCheckBox, 0);
            this.Controls.SetChildIndex(this.GFlagTransitionEndTimeCheckBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RotationXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationZNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerBorderNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpperBorderNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightOffsetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontOffsetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JumpingYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FallingYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieldOfViewNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomNumericUpDown)).EndInit();
            this.FlagGroupBox.ResumeLayout(false);
            this.FlagGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColourNumericUpDown RotationXNumericUpDown;
        private System.Windows.Forms.Label RotationXLabel;
        private System.Windows.Forms.Label RotationYLabel;
        private System.Windows.Forms.Label RotationZLabel;
        private ColourNumericUpDown RotationZNumericUpDown;
        private ColourNumericUpDown RotationYNumericUpDown;
        private ColourNumericUpDown LowerBorderNumericUpDown;
        private System.Windows.Forms.Label LowerBorderLabel;
        private ColourNumericUpDown UpperBorderNumericUpDown;
        private System.Windows.Forms.Label UpperBorderLabel;
        private ColourNumericUpDown HeightOffsetNumericUpDown;
        private System.Windows.Forms.Label HeightOffsetLabel;
        private ColourNumericUpDown FrontOffsetNumericUpDown;
        private System.Windows.Forms.Label FrontOffsetLabel;
        private ColourNumericUpDown JumpingYNumericUpDown;
        private System.Windows.Forms.Label MaxYLabel;
        private System.Windows.Forms.Label MinYLabel;
        private ColourNumericUpDown FallingYNumericUpDown;
        private ColourNumericUpDown FieldOfViewNumericUpDown;
        private System.Windows.Forms.Label FieldOfViewLabel;
        private ColourNumericUpDown ZoomNumericUpDown;
        private System.Windows.Forms.Label ZoomLabel;
        private System.Windows.Forms.GroupBox FlagGroupBox;
        private System.Windows.Forms.CheckBox Num2CheckBox;
        private System.Windows.Forms.CheckBox Num1CheckBox;
        private System.Windows.Forms.CheckBox FieldOfViewCheckBox;
        private System.Windows.Forms.CheckBox EventUseTimeCheckBox;
        private System.Windows.Forms.CheckBox EventUseEndTimeCheckBox;
        private System.Windows.Forms.CheckBox DisableAntiBlurCheckBox;
        private System.Windows.Forms.CheckBox SharpZoomCheckBox;
        private System.Windows.Forms.CheckBox DisableFirstPersonCheckBox;
        private System.Windows.Forms.CheckBox GFlagTransitionEndTimeCheckBox;
        private System.Windows.Forms.CheckBox GFlagThroughCheckBox;
        private System.Windows.Forms.CheckBox GFlagEndErpFrameCheckBox;
        private System.Windows.Forms.CheckBox UseVerticalPanAxisCheckBox;
        private System.Windows.Forms.CheckBox DisableCollisionCheckBox;
    }
}
