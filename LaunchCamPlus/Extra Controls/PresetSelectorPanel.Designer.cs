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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresetSelectorPanel));
            this.PresetsTreeView = new System.Windows.Forms.TreeView();
            this.PresetDirImageList = new System.Windows.Forms.ImageList(this.components);
            this.SelectButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PresetsTreeView
            // 
            this.PresetsTreeView.ImageIndex = 0;
            this.PresetsTreeView.ImageList = this.PresetDirImageList;
            this.PresetsTreeView.Location = new System.Drawing.Point(3, 32);
            this.PresetsTreeView.Name = "PresetsTreeView";
            this.PresetsTreeView.SelectedImageIndex = 0;
            this.PresetsTreeView.Size = new System.Drawing.Size(435, 352);
            this.PresetsTreeView.TabIndex = 0;
            this.PresetsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PresetsTreeView_AfterSelect);
            // 
            // PresetDirImageList
            // 
            this.PresetDirImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PresetDirImageList.ImageStream")));
            this.PresetDirImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.PresetDirImageList.Images.SetKeyName(0, "Preset.png");
            this.PresetDirImageList.Images.SetKeyName(1, "Icon_Open.png");
            this.PresetDirImageList.Images.SetKeyName(2, "PresetBankRoot.png");
            // 
            // SelectButton
            // 
            this.SelectButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SelectButton.Enabled = false;
            this.SelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectButton.Location = new System.Drawing.Point(0, 390);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(441, 51);
            this.SelectButton.TabIndex = 1;
            this.SelectButton.Text = "Select a Preset to add";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Location = new System.Drawing.Point(363, 3);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // PresetSelectorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.PresetsTreeView);
            this.Name = "PresetSelectorPanel";
            this.Size = new System.Drawing.Size(441, 441);
            this.Load += new System.EventHandler(this.PresetPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView PresetsTreeView;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.ImageList PresetDirImageList;
        private System.Windows.Forms.Button RefreshButton;
    }
}
