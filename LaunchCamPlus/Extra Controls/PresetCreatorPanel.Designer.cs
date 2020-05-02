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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresetCreatorPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PresetListBox = new System.Windows.Forms.ListBox();
            this.SavePresetButton = new System.Windows.Forms.Button();
            this.PresetsTreeView = new System.Windows.Forms.TreeView();
            this.QuitButton = new System.Windows.Forms.Button();
            this.AddCameraButton = new System.Windows.Forms.Button();
            this.RemoveCameraButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PresetDirImageList = new System.Windows.Forms.ImageList(this.components);
            this.FilenameTextBox = new LaunchCamPlus.ColourTextBox();
            this.PresetCreatorTextBox = new LaunchCamPlus.ColourTextBox();
            this.PresetNameTextBox = new LaunchCamPlus.ColourTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preset Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Creator Name:";
            // 
            // PresetListBox
            // 
            this.PresetListBox.FormattingEnabled = true;
            this.PresetListBox.HorizontalScrollbar = true;
            this.PresetListBox.Location = new System.Drawing.Point(3, 81);
            this.PresetListBox.Name = "PresetListBox";
            this.PresetListBox.Size = new System.Drawing.Size(435, 134);
            this.PresetListBox.TabIndex = 9;
            // 
            // SavePresetButton
            // 
            this.SavePresetButton.Enabled = false;
            this.SavePresetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SavePresetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavePresetButton.Location = new System.Drawing.Point(3, 406);
            this.SavePresetButton.Name = "SavePresetButton";
            this.SavePresetButton.Size = new System.Drawing.Size(379, 32);
            this.SavePresetButton.TabIndex = 13;
            this.SavePresetButton.Text = "Save";
            this.SavePresetButton.UseVisualStyleBackColor = true;
            this.SavePresetButton.Click += new System.EventHandler(this.SavePresetButton_Click);
            // 
            // PresetsTreeView
            // 
            this.PresetsTreeView.ImageIndex = 0;
            this.PresetsTreeView.ImageList = this.PresetDirImageList;
            this.PresetsTreeView.Location = new System.Drawing.Point(3, 250);
            this.PresetsTreeView.Name = "PresetsTreeView";
            this.PresetsTreeView.SelectedImageIndex = 0;
            this.PresetsTreeView.Size = new System.Drawing.Size(435, 150);
            this.PresetsTreeView.TabIndex = 14;
            this.PresetsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PresetsTreeView_AfterSelect);
            // 
            // QuitButton
            // 
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.Location = new System.Drawing.Point(388, 406);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(50, 32);
            this.QuitButton.TabIndex = 15;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // AddCameraButton
            // 
            this.AddCameraButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddCameraButton.Location = new System.Drawing.Point(3, 221);
            this.AddCameraButton.Name = "AddCameraButton";
            this.AddCameraButton.Size = new System.Drawing.Size(122, 23);
            this.AddCameraButton.TabIndex = 16;
            this.AddCameraButton.Text = "Add Selected Camera";
            this.AddCameraButton.UseVisualStyleBackColor = true;
            this.AddCameraButton.Click += new System.EventHandler(this.AddCameraButton_Click);
            // 
            // RemoveCameraButton
            // 
            this.RemoveCameraButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveCameraButton.Location = new System.Drawing.Point(297, 221);
            this.RemoveCameraButton.Name = "RemoveCameraButton";
            this.RemoveCameraButton.Size = new System.Drawing.Size(141, 23);
            this.RemoveCameraButton.TabIndex = 17;
            this.RemoveCameraButton.Text = "Remove Selected Camera";
            this.RemoveCameraButton.UseVisualStyleBackColor = true;
            this.RemoveCameraButton.Click += new System.EventHandler(this.RemoveCameraButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "File Name:";
            // 
            // PresetDirImageList
            // 
            this.PresetDirImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PresetDirImageList.ImageStream")));
            this.PresetDirImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.PresetDirImageList.Images.SetKeyName(0, "Preset.png");
            this.PresetDirImageList.Images.SetKeyName(1, "Icon_Open.png");
            this.PresetDirImageList.Images.SetKeyName(2, "PresetBankRoot.png");
            // 
            // FilenameTextBox
            // 
            this.FilenameTextBox.Location = new System.Drawing.Point(109, 55);
            this.FilenameTextBox.Name = "FilenameTextBox";
            this.FilenameTextBox.Size = new System.Drawing.Size(329, 20);
            this.FilenameTextBox.TabIndex = 18;
            // 
            // PresetCreatorTextBox
            // 
            this.PresetCreatorTextBox.Location = new System.Drawing.Point(109, 29);
            this.PresetCreatorTextBox.Name = "PresetCreatorTextBox";
            this.PresetCreatorTextBox.Size = new System.Drawing.Size(329, 20);
            this.PresetCreatorTextBox.TabIndex = 3;
            this.PresetCreatorTextBox.TextChanged += new System.EventHandler(this.PresetCreatorTextBox_TextChanged);
            // 
            // PresetNameTextBox
            // 
            this.PresetNameTextBox.Location = new System.Drawing.Point(109, 3);
            this.PresetNameTextBox.Name = "PresetNameTextBox";
            this.PresetNameTextBox.Size = new System.Drawing.Size(329, 20);
            this.PresetNameTextBox.TabIndex = 1;
            // 
            // PresetCreatorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FilenameTextBox);
            this.Controls.Add(this.RemoveCameraButton);
            this.Controls.Add(this.AddCameraButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.PresetsTreeView);
            this.Controls.Add(this.SavePresetButton);
            this.Controls.Add(this.PresetListBox);
            this.Controls.Add(this.PresetCreatorTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PresetNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "PresetCreatorPanel";
            this.Size = new System.Drawing.Size(441, 441);
            this.Load += new System.EventHandler(this.PresetCreatorPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ColourTextBox PresetNameTextBox;
        private ColourTextBox PresetCreatorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox PresetListBox;
        private System.Windows.Forms.Button SavePresetButton;
        private System.Windows.Forms.TreeView PresetsTreeView;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button AddCameraButton;
        private System.Windows.Forms.Button RemoveCameraButton;
        private ColourTextBox FilenameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList PresetDirImageList;
    }
}
