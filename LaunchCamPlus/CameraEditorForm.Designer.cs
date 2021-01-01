namespace LaunchCamPlus
{
    partial class CameraEditorForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraEditorForm));
            this.EditorMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDefaultCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IdentificationAssistantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportPresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IssuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GithubReleasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CameraListBox = new System.Windows.Forms.ListBox();
            this.Yaz0BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.EditorMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditorMenuStrip
            // 
            this.EditorMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.EditorMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.EditorMenuStrip.Name = "EditorMenuStrip";
            this.EditorMenuStrip.Size = new System.Drawing.Size(668, 24);
            this.EditorMenuStrip.TabIndex = 0;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewToolStripMenuItem.Image")));
            this.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.NewToolStripMenuItem.Text = "&New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Icon_Open;
            this.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.OpenToolStripMenuItem.Text = "&Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripMenuItem.Image")));
            this.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.SaveToolStripMenuItem.Text = "&Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Enabled = false;
            this.SaveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveAsToolStripMenuItem.Image")));
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.SaveAsToolStripMenuItem.Text = "Save &As";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ExitToolStripMenuItem.Text = "E&xit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddCameraToolStripMenuItem,
            this.DeleteCameraToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.MoveToTopToolStripMenuItem,
            this.MoveUpToolStripMenuItem,
            this.MoveDownToolStripMenuItem,
            this.MoveToBottomToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditToolStripMenuItem.Text = "Edit";
            // 
            // AddCameraToolStripMenuItem
            // 
            this.AddCameraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDefaultCameraToolStripMenuItem,
            this.PresetsToolStripMenuItem,
            this.AddNewFromClipboardToolStripMenuItem});
            this.AddCameraToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.AddCamera;
            this.AddCameraToolStripMenuItem.Name = "AddCameraToolStripMenuItem";
            this.AddCameraToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.AddCameraToolStripMenuItem.Text = "Add Camera";
            // 
            // AddDefaultCameraToolStripMenuItem
            // 
            this.AddDefaultCameraToolStripMenuItem.Name = "AddDefaultCameraToolStripMenuItem";
            this.AddDefaultCameraToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.AddDefaultCameraToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.AddDefaultCameraToolStripMenuItem.Text = "Default Camera";
            this.AddDefaultCameraToolStripMenuItem.Click += new System.EventHandler(this.AddDefaultCameraToolStripMenuItem_Click);
            // 
            // PresetsToolStripMenuItem
            // 
            this.PresetsToolStripMenuItem.Name = "PresetsToolStripMenuItem";
            this.PresetsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PresetsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.PresetsToolStripMenuItem.Text = "Choose from Presets";
            this.PresetsToolStripMenuItem.Click += new System.EventHandler(this.PresetsToolStripMenuItem_Click);
            // 
            // AddNewFromClipboardToolStripMenuItem
            // 
            this.AddNewFromClipboardToolStripMenuItem.Name = "AddNewFromClipboardToolStripMenuItem";
            this.AddNewFromClipboardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.AddNewFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.AddNewFromClipboardToolStripMenuItem.Text = "From Clipboard";
            this.AddNewFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.AddNewFromClipboardToolStripMenuItem_Click);
            // 
            // DeleteCameraToolStripMenuItem
            // 
            this.DeleteCameraToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Delete;
            this.DeleteCameraToolStripMenuItem.Name = "DeleteCameraToolStripMenuItem";
            this.DeleteCameraToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Del";
            this.DeleteCameraToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.DeleteCameraToolStripMenuItem.Text = "Delete Camera";
            this.DeleteCameraToolStripMenuItem.Click += new System.EventHandler(this.DeleteCameraToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopyToolStripMenuItem.Image")));
            this.CopyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.CopyToolStripMenuItem.Text = "&Copy";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PasteToolStripMenuItem.Image")));
            this.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.PasteToolStripMenuItem.Text = "&Paste";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // MoveToTopToolStripMenuItem
            // 
            this.MoveToTopToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.MoveCameraTop;
            this.MoveToTopToolStripMenuItem.Name = "MoveToTopToolStripMenuItem";
            this.MoveToTopToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Home";
            this.MoveToTopToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.MoveToTopToolStripMenuItem.Text = "Move to Top";
            this.MoveToTopToolStripMenuItem.Click += new System.EventHandler(this.MoveToTopToolStripMenuItem_Click);
            // 
            // MoveUpToolStripMenuItem
            // 
            this.MoveUpToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.MoveCameraUp;
            this.MoveUpToolStripMenuItem.Name = "MoveUpToolStripMenuItem";
            this.MoveUpToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+PgUp";
            this.MoveUpToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.MoveUpToolStripMenuItem.Text = "Move Up";
            this.MoveUpToolStripMenuItem.Click += new System.EventHandler(this.MoveUpToolStripMenuItem_Click);
            // 
            // MoveDownToolStripMenuItem
            // 
            this.MoveDownToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.MoveCameraDown;
            this.MoveDownToolStripMenuItem.Name = "MoveDownToolStripMenuItem";
            this.MoveDownToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+PgDn";
            this.MoveDownToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.MoveDownToolStripMenuItem.Text = "Move Down";
            this.MoveDownToolStripMenuItem.Click += new System.EventHandler(this.MoveDownToolStripMenuItem_Click);
            // 
            // MoveToBottomToolStripMenuItem
            // 
            this.MoveToBottomToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.MoveCameraBottom;
            this.MoveToBottomToolStripMenuItem.Name = "MoveToBottomToolStripMenuItem";
            this.MoveToBottomToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+End";
            this.MoveToBottomToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.MoveToBottomToolStripMenuItem.Text = "Move to Bottom";
            this.MoveToBottomToolStripMenuItem.Click += new System.EventHandler(this.MoveToBottomToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoSortToolStripMenuItem,
            this.IdentificationAssistantToolStripMenuItem,
            this.ExportPresetToolStripMenuItem,
            this.OptionsToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.ToolsToolStripMenuItem.Text = "Tools";
            // 
            // AutoSortToolStripMenuItem
            // 
            this.AutoSortToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Reorganize;
            this.AutoSortToolStripMenuItem.Name = "AutoSortToolStripMenuItem";
            this.AutoSortToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.AutoSortToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.AutoSortToolStripMenuItem.Text = "&Auto Sort";
            this.AutoSortToolStripMenuItem.Click += new System.EventHandler(this.AutoSortToolStripMenuItem_Click);
            // 
            // IdentificationAssistantToolStripMenuItem
            // 
            this.IdentificationAssistantToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Assistant;
            this.IdentificationAssistantToolStripMenuItem.Name = "IdentificationAssistantToolStripMenuItem";
            this.IdentificationAssistantToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.IdentificationAssistantToolStripMenuItem.Text = "&Identification Assistant";
            this.IdentificationAssistantToolStripMenuItem.Click += new System.EventHandler(this.IdentificationAssistantToolStripMenuItem_Click);
            // 
            // ExportPresetToolStripMenuItem
            // 
            this.ExportPresetToolStripMenuItem.Enabled = false;
            this.ExportPresetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExportPresetToolStripMenuItem.Image")));
            this.ExportPresetToolStripMenuItem.Name = "ExportPresetToolStripMenuItem";
            this.ExportPresetToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.ExportPresetToolStripMenuItem.Text = "Export Preset";
            this.ExportPresetToolStripMenuItem.Click += new System.EventHandler(this.ExportPresetToolStripMenuItem_Click);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Icon_Settings;
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.OptionsToolStripMenuItem.Text = "&Options";
            this.OptionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WikiToolStripMenuItem,
            this.IssuesToolStripMenuItem,
            this.GithubReleasesToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // WikiToolStripMenuItem
            // 
            this.WikiToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.WikiPage;
            this.WikiToolStripMenuItem.Name = "WikiToolStripMenuItem";
            this.WikiToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.WikiToolStripMenuItem.Text = "&Github Wiki";
            this.WikiToolStripMenuItem.Click += new System.EventHandler(this.WikiToolStripMenuItem_Click);
            // 
            // IssuesToolStripMenuItem
            // 
            this.IssuesToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.IssuePage;
            this.IssuesToolStripMenuItem.Name = "IssuesToolStripMenuItem";
            this.IssuesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.IssuesToolStripMenuItem.Text = "&Github Issues";
            this.IssuesToolStripMenuItem.Click += new System.EventHandler(this.IssuesToolStripMenuItem_Click);
            // 
            // GithubReleasesToolStripMenuItem
            // 
            this.GithubReleasesToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.ReleasesPage;
            this.GithubReleasesToolStripMenuItem.Name = "GithubReleasesToolStripMenuItem";
            this.GithubReleasesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.GithubReleasesToolStripMenuItem.Text = "Github Releases";
            this.GithubReleasesToolStripMenuItem.Click += new System.EventHandler(this.GithubReleasesToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.AboutToolStripMenuItem.Text = "&About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.CameraListBox);
            this.MainSplitContainer.Size = new System.Drawing.Size(668, 441);
            this.MainSplitContainer.SplitterDistance = 224;
            this.MainSplitContainer.TabIndex = 1;
            this.MainSplitContainer.TabStop = false;
            // 
            // CameraListBox
            // 
            this.CameraListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CameraListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraListBox.Enabled = false;
            this.CameraListBox.FormattingEnabled = true;
            this.CameraListBox.HorizontalScrollbar = true;
            this.CameraListBox.IntegralHeight = false;
            this.CameraListBox.Location = new System.Drawing.Point(0, 0);
            this.CameraListBox.Name = "CameraListBox";
            this.CameraListBox.Size = new System.Drawing.Size(224, 441);
            this.CameraListBox.TabIndex = 0;
            this.CameraListBox.SelectedIndexChanged += new System.EventHandler(this.CameraListBox_SelectedIndexChanged);
            this.CameraListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CameraListBox_KeyDown);
            // 
            // Yaz0BackgroundWorker
            // 
            this.Yaz0BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Yaz0BackgroundWorker_DoWork);
            // 
            // CameraEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 465);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.EditorMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.EditorMenuStrip;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(684, 504);
            this.Name = "CameraEditorForm";
            this.Text = "Launch Cam Plus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraEditorForm_FormClosing);
            this.EditorMenuStrip.ResumeLayout(false);
            this.EditorMenuStrip.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip EditorMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WikiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IssuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ToolStripMenuItem MoveToTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveToBottomToolStripMenuItem;
        private System.Windows.Forms.ListBox CameraListBox;
        private System.Windows.Forms.ToolStripMenuItem AutoSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IdentificationAssistantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddDefaultCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PresetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GithubReleasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportPresetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddNewFromClipboardToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker Yaz0BackgroundWorker;
    }
}