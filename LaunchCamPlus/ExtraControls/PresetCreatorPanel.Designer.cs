namespace LaunchCamPlus
{
    partial class PresetCreatorPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresetCreatorPanel));
            label1 = new Label();
            label2 = new Label();
            PresetListBox = new ListBox();
            SavePresetButton = new Button();
            PresetsTreeView = new TreeView();
            PresetDirImageList = new ImageList(components);
            QuitButton = new Button();
            AddCameraButton = new Button();
            RemoveCameraButton = new Button();
            label3 = new Label();
            FilenameTextBox = new ExtraControls.ColourTextBox();
            PresetCreatorTextBox = new ExtraControls.ColourTextBox();
            PresetNameTextBox = new ExtraControls.ColourTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(4, 5);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 17);
            label1.TabIndex = 0;
            label1.Text = "Preset Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(4, 35);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 17);
            label2.TabIndex = 2;
            label2.Text = "Creator Name:";
            // 
            // PresetListBox
            // 
            PresetListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PresetListBox.FormattingEnabled = true;
            PresetListBox.HorizontalScrollbar = true;
            PresetListBox.ItemHeight = 15;
            PresetListBox.Location = new Point(4, 93);
            PresetListBox.Margin = new Padding(4, 3, 4, 3);
            PresetListBox.Name = "PresetListBox";
            PresetListBox.Size = new Size(434, 154);
            PresetListBox.TabIndex = 9;
            // 
            // SavePresetButton
            // 
            SavePresetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SavePresetButton.Enabled = false;
            SavePresetButton.FlatStyle = FlatStyle.Flat;
            SavePresetButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            SavePresetButton.Location = new Point(4, 400);
            SavePresetButton.Margin = new Padding(4, 3, 4, 3);
            SavePresetButton.Name = "SavePresetButton";
            SavePresetButton.Size = new Size(369, 37);
            SavePresetButton.TabIndex = 13;
            SavePresetButton.Text = "Save";
            SavePresetButton.UseVisualStyleBackColor = true;
            SavePresetButton.Click += SavePresetButton_Click;
            // 
            // PresetsTreeView
            // 
            PresetsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PresetsTreeView.ImageIndex = 0;
            PresetsTreeView.ImageList = PresetDirImageList;
            PresetsTreeView.Location = new Point(4, 288);
            PresetsTreeView.Margin = new Padding(4, 3, 4, 3);
            PresetsTreeView.Name = "PresetsTreeView";
            PresetsTreeView.SelectedImageIndex = 0;
            PresetsTreeView.Size = new Size(434, 104);
            PresetsTreeView.TabIndex = 14;
            PresetsTreeView.AfterSelect += PresetsTreeView_AfterSelect;
            // 
            // PresetDirImageList
            // 
            PresetDirImageList.ColorDepth = ColorDepth.Depth32Bit;
            PresetDirImageList.ImageStream = (ImageListStreamer)resources.GetObject("PresetDirImageList.ImageStream");
            PresetDirImageList.TransparentColor = Color.Transparent;
            PresetDirImageList.Images.SetKeyName(0, "Preset.png");
            PresetDirImageList.Images.SetKeyName(1, "Icon_Open.png");
            PresetDirImageList.Images.SetKeyName(2, "PresetBankRoot.png");
            // 
            // QuitButton
            // 
            QuitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            QuitButton.FlatStyle = FlatStyle.Flat;
            QuitButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            QuitButton.Location = new Point(380, 400);
            QuitButton.Margin = new Padding(4, 3, 4, 3);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(58, 37);
            QuitButton.TabIndex = 15;
            QuitButton.Text = "Quit";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += QuitButton_Click;
            // 
            // AddCameraButton
            // 
            AddCameraButton.FlatStyle = FlatStyle.Flat;
            AddCameraButton.Location = new Point(4, 255);
            AddCameraButton.Margin = new Padding(4, 3, 4, 3);
            AddCameraButton.Name = "AddCameraButton";
            AddCameraButton.Size = new Size(142, 27);
            AddCameraButton.TabIndex = 16;
            AddCameraButton.Text = "Add Selected Camera";
            AddCameraButton.UseVisualStyleBackColor = true;
            AddCameraButton.Click += AddCameraButton_Click;
            // 
            // RemoveCameraButton
            // 
            RemoveCameraButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RemoveCameraButton.FlatStyle = FlatStyle.Flat;
            RemoveCameraButton.Location = new Point(273, 255);
            RemoveCameraButton.Margin = new Padding(4, 3, 4, 3);
            RemoveCameraButton.Name = "RemoveCameraButton";
            RemoveCameraButton.Size = new Size(164, 27);
            RemoveCameraButton.TabIndex = 17;
            RemoveCameraButton.Text = "Remove Selected Camera";
            RemoveCameraButton.UseVisualStyleBackColor = true;
            RemoveCameraButton.Click += RemoveCameraButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(4, 63);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(75, 17);
            label3.TabIndex = 19;
            label3.Text = "File Name:";
            // 
            // FilenameTextBox
            // 
            FilenameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FilenameTextBox.Location = new Point(127, 63);
            FilenameTextBox.Margin = new Padding(4, 3, 4, 3);
            FilenameTextBox.Name = "FilenameTextBox";
            FilenameTextBox.Size = new Size(310, 23);
            FilenameTextBox.TabIndex = 18;
            // 
            // PresetCreatorTextBox
            // 
            PresetCreatorTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PresetCreatorTextBox.Location = new Point(127, 33);
            PresetCreatorTextBox.Margin = new Padding(4, 3, 4, 3);
            PresetCreatorTextBox.Name = "PresetCreatorTextBox";
            PresetCreatorTextBox.Size = new Size(310, 23);
            PresetCreatorTextBox.TabIndex = 3;
            PresetCreatorTextBox.TextChanged += PresetCreatorTextBox_TextChanged;
            // 
            // PresetNameTextBox
            // 
            PresetNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PresetNameTextBox.Location = new Point(127, 3);
            PresetNameTextBox.Margin = new Padding(4, 3, 4, 3);
            PresetNameTextBox.Name = "PresetNameTextBox";
            PresetNameTextBox.Size = new Size(310, 23);
            PresetNameTextBox.TabIndex = 1;
            // 
            // PresetCreatorPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(FilenameTextBox);
            Controls.Add(RemoveCameraButton);
            Controls.Add(AddCameraButton);
            Controls.Add(QuitButton);
            Controls.Add(PresetsTreeView);
            Controls.Add(SavePresetButton);
            Controls.Add(PresetListBox);
            Controls.Add(PresetCreatorTextBox);
            Controls.Add(label2);
            Controls.Add(PresetNameTextBox);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PresetCreatorPanel";
            Size = new Size(441, 441);
            Load += PresetCreatorPanel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private LaunchCamPlus.ExtraControls.ColourTextBox PresetNameTextBox;
        private LaunchCamPlus.ExtraControls.ColourTextBox PresetCreatorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox PresetListBox;
        private System.Windows.Forms.Button SavePresetButton;
        private System.Windows.Forms.TreeView PresetsTreeView;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button AddCameraButton;
        private System.Windows.Forms.Button RemoveCameraButton;
        private LaunchCamPlus.ExtraControls.ColourTextBox FilenameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList PresetDirImageList;
    }
}
