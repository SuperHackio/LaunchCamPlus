namespace LaunchCamPlus.ExtraControls
{
    partial class CANMEditPanel
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
            components = new System.ComponentModel.Container();
            CANMJ3dTrackControl = new J3DTrackControl();
            DataListBox = new ListBox();
            CANMSettingsGroupBox = new GroupBox();
            label5 = new Label();
            CANMLengthColourNumericUpDown = new ColourNumericUpDown();
            CANMKeyFrameGroupBox = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            KeyframeOutColourNumericUpDown = new ColourNumericUpDown();
            KeyframeInColourNumericUpDown = new ColourNumericUpDown();
            KeyframeValueColourNumericUpDown = new ColourNumericUpDown();
            KeyframeTimeColourNumericUpDown = new ColourNumericUpDown();
            KeyframeSetOutZeroButton = new Button();
            KeyframeSetOutLinearButton = new Button();
            KeyframeSetInZeroButton = new Button();
            KeyframeSetInLinearButton = new Button();
            KeyframeSetBothZeroButton = new Button();
            KeyframeSetBothLinearButton = new Button();
            MainToolTip = new ToolTip(components);
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            CANMSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CANMLengthColourNumericUpDown).BeginInit();
            CANMKeyFrameGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)KeyframeOutColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KeyframeInColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KeyframeValueColourNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KeyframeTimeColourNumericUpDown).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // CANMJ3dTrackControl
            // 
            CANMJ3dTrackControl.Dock = DockStyle.Top;
            CANMJ3dTrackControl.Location = new Point(0, 0);
            CANMJ3dTrackControl.MouseWheelMultiplier = 10;
            CANMJ3dTrackControl.Name = "CANMJ3dTrackControl";
            CANMJ3dTrackControl.SingleTangent = false;
            CANMJ3dTrackControl.Size = new Size(441, 210);
            CANMJ3dTrackControl.Spline = J3DTrackControl.SplineType.HERMITE;
            CANMJ3dTrackControl.TabIndex = 0;
            CANMJ3dTrackControl.ZoomX = 24;
            CANMJ3dTrackControl.ZoomY = 24;
            // 
            // DataListBox
            // 
            DataListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataListBox.FormattingEnabled = true;
            DataListBox.IntegralHeight = false;
            DataListBox.ItemHeight = 13;
            DataListBox.Location = new Point(3, 216);
            DataListBox.Name = "DataListBox";
            DataListBox.Size = new Size(229, 222);
            DataListBox.TabIndex = 1;
            DataListBox.SelectedIndexChanged += DataListBox_SelectedIndexChanged;
            DataListBox.KeyDown += DataListBox_KeyDown;
            // 
            // CANMSettingsGroupBox
            // 
            CANMSettingsGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CANMSettingsGroupBox.Controls.Add(label5);
            CANMSettingsGroupBox.Controls.Add(CANMLengthColourNumericUpDown);
            CANMSettingsGroupBox.Location = new Point(238, 391);
            CANMSettingsGroupBox.Name = "CANMSettingsGroupBox";
            CANMSettingsGroupBox.Size = new Size(200, 47);
            CANMSettingsGroupBox.TabIndex = 2;
            CANMSettingsGroupBox.TabStop = false;
            CANMSettingsGroupBox.Text = "CANM Settings";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 20);
            label5.Name = "label5";
            label5.Size = new Size(92, 13);
            label5.TabIndex = 9;
            label5.Text = "Animation Length:";
            // 
            // CANMLengthColourNumericUpDown
            // 
            CANMLengthColourNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CANMLengthColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            CANMLengthColourNumericUpDown.Location = new Point(99, 18);
            CANMLengthColourNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            CANMLengthColourNumericUpDown.Maximum = new decimal(new int[] { 216000, 0, 0, 0 });
            CANMLengthColourNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            CANMLengthColourNumericUpDown.Name = "CANMLengthColourNumericUpDown";
            CANMLengthColourNumericUpDown.Size = new Size(95, 20);
            CANMLengthColourNumericUpDown.TabIndex = 8;
            CANMLengthColourNumericUpDown.TextValue = new decimal(new int[] { 1, 0, 0, 0 });
            CANMLengthColourNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // CANMKeyFrameGroupBox
            // 
            CANMKeyFrameGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CANMKeyFrameGroupBox.Controls.Add(label4);
            CANMKeyFrameGroupBox.Controls.Add(label3);
            CANMKeyFrameGroupBox.Controls.Add(label2);
            CANMKeyFrameGroupBox.Controls.Add(label1);
            CANMKeyFrameGroupBox.Controls.Add(KeyframeOutColourNumericUpDown);
            CANMKeyFrameGroupBox.Controls.Add(KeyframeInColourNumericUpDown);
            CANMKeyFrameGroupBox.Controls.Add(KeyframeValueColourNumericUpDown);
            CANMKeyFrameGroupBox.Controls.Add(KeyframeTimeColourNumericUpDown);
            CANMKeyFrameGroupBox.Location = new Point(238, 216);
            CANMKeyFrameGroupBox.Name = "CANMKeyFrameGroupBox";
            CANMKeyFrameGroupBox.Size = new Size(200, 116);
            CANMKeyFrameGroupBox.TabIndex = 3;
            CANMKeyFrameGroupBox.TabStop = false;
            CANMKeyFrameGroupBox.Text = "Keyframe Data";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 93);
            label4.Name = "label4";
            label4.Size = new Size(70, 13);
            label4.TabIndex = 7;
            label4.Text = "Tangent Out:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 69);
            label3.Name = "label3";
            label3.Size = new Size(62, 13);
            label3.TabIndex = 6;
            label3.Text = "Tangent In:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 45);
            label2.Name = "label2";
            label2.Size = new Size(37, 13);
            label2.TabIndex = 5;
            label2.Text = "Value:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 21);
            label1.Name = "label1";
            label1.Size = new Size(33, 13);
            label1.TabIndex = 4;
            label1.Text = "Time:";
            // 
            // KeyframeOutColourNumericUpDown
            // 
            KeyframeOutColourNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            KeyframeOutColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            KeyframeOutColourNumericUpDown.DecimalPlaces = 4;
            KeyframeOutColourNumericUpDown.Location = new Point(99, 91);
            KeyframeOutColourNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            KeyframeOutColourNumericUpDown.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
            KeyframeOutColourNumericUpDown.Minimum = new decimal(new int[] { 2000000, 0, 0, int.MinValue });
            KeyframeOutColourNumericUpDown.Name = "KeyframeOutColourNumericUpDown";
            KeyframeOutColourNumericUpDown.Size = new Size(95, 20);
            KeyframeOutColourNumericUpDown.TabIndex = 3;
            KeyframeOutColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 262144 });
            // 
            // KeyframeInColourNumericUpDown
            // 
            KeyframeInColourNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            KeyframeInColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            KeyframeInColourNumericUpDown.DecimalPlaces = 4;
            KeyframeInColourNumericUpDown.Location = new Point(99, 67);
            KeyframeInColourNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            KeyframeInColourNumericUpDown.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
            KeyframeInColourNumericUpDown.Minimum = new decimal(new int[] { 2000000, 0, 0, int.MinValue });
            KeyframeInColourNumericUpDown.Name = "KeyframeInColourNumericUpDown";
            KeyframeInColourNumericUpDown.Size = new Size(95, 20);
            KeyframeInColourNumericUpDown.TabIndex = 2;
            KeyframeInColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 262144 });
            // 
            // KeyframeValueColourNumericUpDown
            // 
            KeyframeValueColourNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            KeyframeValueColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            KeyframeValueColourNumericUpDown.DecimalPlaces = 4;
            KeyframeValueColourNumericUpDown.Location = new Point(99, 43);
            KeyframeValueColourNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            KeyframeValueColourNumericUpDown.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
            KeyframeValueColourNumericUpDown.Minimum = new decimal(new int[] { 2000000, 0, 0, int.MinValue });
            KeyframeValueColourNumericUpDown.Name = "KeyframeValueColourNumericUpDown";
            KeyframeValueColourNumericUpDown.Size = new Size(95, 20);
            KeyframeValueColourNumericUpDown.TabIndex = 1;
            KeyframeValueColourNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 262144 });
            // 
            // KeyframeTimeColourNumericUpDown
            // 
            KeyframeTimeColourNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            KeyframeTimeColourNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            KeyframeTimeColourNumericUpDown.Location = new Point(99, 19);
            KeyframeTimeColourNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            KeyframeTimeColourNumericUpDown.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
            KeyframeTimeColourNumericUpDown.Name = "KeyframeTimeColourNumericUpDown";
            KeyframeTimeColourNumericUpDown.Size = new Size(95, 20);
            KeyframeTimeColourNumericUpDown.TabIndex = 0;
            KeyframeTimeColourNumericUpDown.TextValue = new decimal(new int[] { 1, 0, 0, 0 });
            KeyframeTimeColourNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // KeyframeSetOutZeroButton
            // 
            KeyframeSetOutZeroButton.BackgroundImage = Properties.Resources.FlatOut;
            KeyframeSetOutZeroButton.BackgroundImageLayout = ImageLayout.Center;
            KeyframeSetOutZeroButton.FlatStyle = FlatStyle.Flat;
            KeyframeSetOutZeroButton.Location = new Point(32, 19);
            KeyframeSetOutZeroButton.Name = "KeyframeSetOutZeroButton";
            KeyframeSetOutZeroButton.Size = new Size(20, 20);
            KeyframeSetOutZeroButton.TabIndex = 13;
            KeyframeSetOutZeroButton.UseVisualStyleBackColor = true;
            KeyframeSetOutZeroButton.Click += KeyframeSetOutZeroButton_Click;
            // 
            // KeyframeSetOutLinearButton
            // 
            KeyframeSetOutLinearButton.BackgroundImage = Properties.Resources.LinearOut;
            KeyframeSetOutLinearButton.BackgroundImageLayout = ImageLayout.Center;
            KeyframeSetOutLinearButton.FlatStyle = FlatStyle.Flat;
            KeyframeSetOutLinearButton.Location = new Point(6, 19);
            KeyframeSetOutLinearButton.Name = "KeyframeSetOutLinearButton";
            KeyframeSetOutLinearButton.Size = new Size(20, 20);
            KeyframeSetOutLinearButton.TabIndex = 12;
            KeyframeSetOutLinearButton.UseVisualStyleBackColor = true;
            KeyframeSetOutLinearButton.Click += KeyframeSetOutLinearButton_Click;
            // 
            // KeyframeSetInZeroButton
            // 
            KeyframeSetInZeroButton.BackgroundImage = Properties.Resources.FlatIn;
            KeyframeSetInZeroButton.BackgroundImageLayout = ImageLayout.Center;
            KeyframeSetInZeroButton.FlatStyle = FlatStyle.Flat;
            KeyframeSetInZeroButton.Location = new Point(32, 19);
            KeyframeSetInZeroButton.Name = "KeyframeSetInZeroButton";
            KeyframeSetInZeroButton.Size = new Size(20, 20);
            KeyframeSetInZeroButton.TabIndex = 11;
            KeyframeSetInZeroButton.UseVisualStyleBackColor = true;
            KeyframeSetInZeroButton.Click += KeyframeSetInZeroButton_Click;
            // 
            // KeyframeSetInLinearButton
            // 
            KeyframeSetInLinearButton.BackgroundImage = Properties.Resources.LinearIn;
            KeyframeSetInLinearButton.BackgroundImageLayout = ImageLayout.Center;
            KeyframeSetInLinearButton.FlatStyle = FlatStyle.Flat;
            KeyframeSetInLinearButton.Location = new Point(6, 19);
            KeyframeSetInLinearButton.Name = "KeyframeSetInLinearButton";
            KeyframeSetInLinearButton.Size = new Size(20, 20);
            KeyframeSetInLinearButton.TabIndex = 10;
            KeyframeSetInLinearButton.UseVisualStyleBackColor = true;
            KeyframeSetInLinearButton.Click += KeyframeSetInLinearButton_Click;
            // 
            // KeyframeSetBothZeroButton
            // 
            KeyframeSetBothZeroButton.BackgroundImage = Properties.Resources.FlatBoth;
            KeyframeSetBothZeroButton.BackgroundImageLayout = ImageLayout.Center;
            KeyframeSetBothZeroButton.FlatStyle = FlatStyle.Flat;
            KeyframeSetBothZeroButton.Location = new Point(32, 19);
            KeyframeSetBothZeroButton.Name = "KeyframeSetBothZeroButton";
            KeyframeSetBothZeroButton.Size = new Size(20, 20);
            KeyframeSetBothZeroButton.TabIndex = 9;
            MainToolTip.SetToolTip(KeyframeSetBothZeroButton, "Sets both the In and Out Tangents to Zero (Flat)");
            KeyframeSetBothZeroButton.UseVisualStyleBackColor = true;
            KeyframeSetBothZeroButton.Click += KeyframeSetBothZeroButton_Click;
            // 
            // KeyframeSetBothLinearButton
            // 
            KeyframeSetBothLinearButton.BackgroundImage = Properties.Resources.LinearBoth;
            KeyframeSetBothLinearButton.BackgroundImageLayout = ImageLayout.Center;
            KeyframeSetBothLinearButton.FlatStyle = FlatStyle.Flat;
            KeyframeSetBothLinearButton.Location = new Point(6, 19);
            KeyframeSetBothLinearButton.Name = "KeyframeSetBothLinearButton";
            KeyframeSetBothLinearButton.Size = new Size(20, 20);
            KeyframeSetBothLinearButton.TabIndex = 8;
            MainToolTip.SetToolTip(KeyframeSetBothLinearButton, "Sets both the In and Out Tangents to Linear\r\n\r\nRequires the track to be in Piece-wise mode");
            KeyframeSetBothLinearButton.UseVisualStyleBackColor = true;
            KeyframeSetBothLinearButton.Click += KeyframeSetBothLinearButton_Click;
            // 
            // MainToolTip
            // 
            MainToolTip.AutoPopDelay = 5000;
            MainToolTip.InitialDelay = 300;
            MainToolTip.IsBalloon = true;
            MainToolTip.ReshowDelay = 100;
            MainToolTip.ShowAlways = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(KeyframeSetBothLinearButton);
            groupBox1.Controls.Add(KeyframeSetBothZeroButton);
            groupBox1.Location = new Point(238, 338);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(60, 47);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Both";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(KeyframeSetInLinearButton);
            groupBox2.Controls.Add(KeyframeSetInZeroButton);
            groupBox2.Location = new Point(304, 338);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(60, 47);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "In Only";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.Controls.Add(KeyframeSetOutZeroButton);
            groupBox3.Controls.Add(KeyframeSetOutLinearButton);
            groupBox3.Location = new Point(370, 338);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(62, 47);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Out Only";
            // 
            // CANMEditPanel
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(CANMKeyFrameGroupBox);
            Controls.Add(CANMSettingsGroupBox);
            Controls.Add(DataListBox);
            Controls.Add(CANMJ3dTrackControl);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Name = "CANMEditPanel";
            Size = new Size(441, 441);
            CANMSettingsGroupBox.ResumeLayout(false);
            CANMSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CANMLengthColourNumericUpDown).EndInit();
            CANMKeyFrameGroupBox.ResumeLayout(false);
            CANMKeyFrameGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)KeyframeOutColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)KeyframeInColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)KeyframeValueColourNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)KeyframeTimeColourNumericUpDown).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private J3DTrackControl CANMJ3dTrackControl;
        private GroupBox CANMSettingsGroupBox;
        private Label label5;
        private GroupBox CANMKeyFrameGroupBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ColourNumericUpDown KeyframeOutColourNumericUpDown;
        private ColourNumericUpDown KeyframeInColourNumericUpDown;
        private ColourNumericUpDown KeyframeValueColourNumericUpDown;
        private ColourNumericUpDown KeyframeTimeColourNumericUpDown;
        private Button KeyframeSetBothZeroButton;
        private Button KeyframeSetBothLinearButton;
        private Button KeyframeSetOutZeroButton;
        private Button KeyframeSetOutLinearButton;
        private Button KeyframeSetInZeroButton;
        private Button KeyframeSetInLinearButton;
        private ToolTip MainToolTip;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        public ListBox DataListBox;
        private ColourNumericUpDown CANMLengthColourNumericUpDown;
    }
}
