namespace LaunchCamPlus
{
    partial class PresetSelectorPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresetSelectorPanel));
            PresetsTreeView = new TreeView();
            PresetDirImageList = new ImageList(components);
            SelectButton = new Button();
            RefreshButton = new Button();
            SuspendLayout();
            // 
            // PresetsTreeView
            // 
            PresetsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PresetsTreeView.ImageIndex = 0;
            PresetsTreeView.ImageList = PresetDirImageList;
            PresetsTreeView.Location = new Point(4, 37);
            PresetsTreeView.Margin = new Padding(4, 3, 4, 3);
            PresetsTreeView.Name = "PresetsTreeView";
            PresetsTreeView.SelectedImageIndex = 0;
            PresetsTreeView.Size = new Size(434, 338);
            PresetsTreeView.TabIndex = 0;
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
            // SelectButton
            // 
            SelectButton.Dock = DockStyle.Bottom;
            SelectButton.Enabled = false;
            SelectButton.FlatStyle = FlatStyle.Flat;
            SelectButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SelectButton.Location = new Point(0, 382);
            SelectButton.Margin = new Padding(4, 3, 4, 3);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(441, 59);
            SelectButton.TabIndex = 1;
            SelectButton.Text = "Select a Preset to add";
            SelectButton.UseVisualStyleBackColor = true;
            SelectButton.Click += SelectButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RefreshButton.FlatStyle = FlatStyle.Flat;
            RefreshButton.Location = new Point(351, 3);
            RefreshButton.Margin = new Padding(4, 3, 4, 3);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(88, 27);
            RefreshButton.TabIndex = 2;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // PresetSelectorPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(RefreshButton);
            Controls.Add(SelectButton);
            Controls.Add(PresetsTreeView);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PresetSelectorPanel";
            Size = new Size(441, 441);
            Load += PresetPanel_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView PresetsTreeView;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.ImageList PresetDirImageList;
        private System.Windows.Forms.Button RefreshButton;
    }
}
