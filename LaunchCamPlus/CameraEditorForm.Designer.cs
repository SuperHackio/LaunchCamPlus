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
            EditorMenuStrip = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            NewToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            SaveToolStripMenuItem = new ToolStripMenuItem();
            SaveAsToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            EditToolStripMenuItem = new ToolStripMenuItem();
            AddCameraToolStripMenuItem = new ToolStripMenuItem();
            AddDefaultCameraToolStripMenuItem = new ToolStripMenuItem();
            PresetsToolStripMenuItem = new ToolStripMenuItem();
            AddNewFromClipboardToolStripMenuItem = new ToolStripMenuItem();
            DeleteCameraToolStripMenuItem = new ToolStripMenuItem();
            CopyToolStripMenuItem = new ToolStripMenuItem();
            PasteToolStripMenuItem = new ToolStripMenuItem();
            MoveToTopToolStripMenuItem = new ToolStripMenuItem();
            MoveUpToolStripMenuItem = new ToolStripMenuItem();
            MoveDownToolStripMenuItem = new ToolStripMenuItem();
            MoveToBottomToolStripMenuItem = new ToolStripMenuItem();
            AddCANMKeyframeToolStripMenuItem = new ToolStripMenuItem();
            DeleteCANMKeyframeToolStripMenuItem = new ToolStripMenuItem();
            SetAllToLinearToolStripMenuItem = new ToolStripMenuItem();
            SetAllToZeroToolStripMenuItem = new ToolStripMenuItem();
            ToolsToolStripMenuItem = new ToolStripMenuItem();
            AutoSortToolStripMenuItem = new ToolStripMenuItem();
            IdentificationAssistantToolStripMenuItem = new ToolStripMenuItem();
            ExportPresetToolStripMenuItem = new ToolStripMenuItem();
            OptionsToolStripMenuItem = new ToolStripMenuItem();
            HelpToolStripMenuItem = new ToolStripMenuItem();
            WikiToolStripMenuItem = new ToolStripMenuItem();
            IssuesToolStripMenuItem = new ToolStripMenuItem();
            GithubReleasesToolStripMenuItem = new ToolStripMenuItem();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            MainSplitContainer = new SplitContainer();
            CameraListBox = new ListBox();
            Yaz0BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            EditorMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // EditorMenuStrip
            // 
            EditorMenuStrip.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, EditToolStripMenuItem, ToolsToolStripMenuItem, HelpToolStripMenuItem });
            EditorMenuStrip.Location = new Point(0, 0);
            EditorMenuStrip.Name = "EditorMenuStrip";
            EditorMenuStrip.Padding = new Padding(7, 2, 0, 2);
            EditorMenuStrip.Size = new Size(668, 24);
            EditorMenuStrip.TabIndex = 0;
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewToolStripMenuItem, OpenToolStripMenuItem, SaveToolStripMenuItem, SaveAsToolStripMenuItem, ExitToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(37, 20);
            FileToolStripMenuItem.Text = "File";
            // 
            // NewToolStripMenuItem
            // 
            NewToolStripMenuItem.Image = Properties.Resources.New;
            NewToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            NewToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            NewToolStripMenuItem.Size = new Size(186, 22);
            NewToolStripMenuItem.Text = "&New";
            NewToolStripMenuItem.Click += NewToolStripMenuItem_Click;
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Image = Properties.Resources.Icon_Open;
            OpenToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            OpenToolStripMenuItem.Size = new Size(186, 22);
            OpenToolStripMenuItem.Text = "&Open";
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // SaveToolStripMenuItem
            // 
            SaveToolStripMenuItem.Enabled = false;
            SaveToolStripMenuItem.Image = Properties.Resources.Save_File;
            SaveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            SaveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            SaveToolStripMenuItem.Size = new Size(186, 22);
            SaveToolStripMenuItem.Text = "&Save";
            SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // SaveAsToolStripMenuItem
            // 
            SaveAsToolStripMenuItem.Enabled = false;
            SaveAsToolStripMenuItem.Image = Properties.Resources.Save_As;
            SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            SaveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            SaveAsToolStripMenuItem.Size = new Size(186, 22);
            SaveAsToolStripMenuItem.Text = "Save &As";
            SaveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(186, 22);
            ExitToolStripMenuItem.Text = "E&xit";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddCameraToolStripMenuItem, DeleteCameraToolStripMenuItem, CopyToolStripMenuItem, PasteToolStripMenuItem, MoveToTopToolStripMenuItem, MoveUpToolStripMenuItem, MoveDownToolStripMenuItem, MoveToBottomToolStripMenuItem, AddCANMKeyframeToolStripMenuItem, DeleteCANMKeyframeToolStripMenuItem, SetAllToLinearToolStripMenuItem, SetAllToZeroToolStripMenuItem });
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new Size(39, 20);
            EditToolStripMenuItem.Text = "Edit";
            // 
            // AddCameraToolStripMenuItem
            // 
            AddCameraToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddDefaultCameraToolStripMenuItem, PresetsToolStripMenuItem, AddNewFromClipboardToolStripMenuItem });
            AddCameraToolStripMenuItem.Image = Properties.Resources.AddCamera;
            AddCameraToolStripMenuItem.Name = "AddCameraToolStripMenuItem";
            AddCameraToolStripMenuItem.Size = new Size(215, 22);
            AddCameraToolStripMenuItem.Text = "Add Camera";
            // 
            // AddDefaultCameraToolStripMenuItem
            // 
            AddDefaultCameraToolStripMenuItem.Name = "AddDefaultCameraToolStripMenuItem";
            AddDefaultCameraToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            AddDefaultCameraToolStripMenuItem.Size = new Size(230, 22);
            AddDefaultCameraToolStripMenuItem.Text = "Default Camera";
            AddDefaultCameraToolStripMenuItem.Click += AddDefaultCameraToolStripMenuItem_Click;
            // 
            // PresetsToolStripMenuItem
            // 
            PresetsToolStripMenuItem.Name = "PresetsToolStripMenuItem";
            PresetsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            PresetsToolStripMenuItem.Size = new Size(230, 22);
            PresetsToolStripMenuItem.Text = "Choose from Presets";
            PresetsToolStripMenuItem.Click += PresetsToolStripMenuItem_Click;
            // 
            // AddNewFromClipboardToolStripMenuItem
            // 
            AddNewFromClipboardToolStripMenuItem.Name = "AddNewFromClipboardToolStripMenuItem";
            AddNewFromClipboardToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.V;
            AddNewFromClipboardToolStripMenuItem.Size = new Size(230, 22);
            AddNewFromClipboardToolStripMenuItem.Text = "From Clipboard";
            AddNewFromClipboardToolStripMenuItem.Click += AddNewFromClipboardToolStripMenuItem_Click;
            // 
            // DeleteCameraToolStripMenuItem
            // 
            DeleteCameraToolStripMenuItem.Image = Properties.Resources.Delete;
            DeleteCameraToolStripMenuItem.Name = "DeleteCameraToolStripMenuItem";
            DeleteCameraToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Del";
            DeleteCameraToolStripMenuItem.Size = new Size(215, 22);
            DeleteCameraToolStripMenuItem.Text = "Delete Camera";
            DeleteCameraToolStripMenuItem.Click += DeleteCameraToolStripMenuItem_Click;
            // 
            // CopyToolStripMenuItem
            // 
            CopyToolStripMenuItem.Image = Properties.Resources.Copy;
            CopyToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            CopyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            CopyToolStripMenuItem.Size = new Size(215, 22);
            CopyToolStripMenuItem.Text = "&Copy";
            CopyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
            // 
            // PasteToolStripMenuItem
            // 
            PasteToolStripMenuItem.Image = Properties.Resources.Paste;
            PasteToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            PasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
            PasteToolStripMenuItem.Size = new Size(215, 22);
            PasteToolStripMenuItem.Text = "&Paste";
            PasteToolStripMenuItem.Click += MoveToTopToolStripMenuItem_Click;
            // 
            // MoveToTopToolStripMenuItem
            // 
            MoveToTopToolStripMenuItem.Image = Properties.Resources.MoveCameraTop;
            MoveToTopToolStripMenuItem.Name = "MoveToTopToolStripMenuItem";
            MoveToTopToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Home";
            MoveToTopToolStripMenuItem.Size = new Size(215, 22);
            MoveToTopToolStripMenuItem.Text = "Move to Top";
            MoveToTopToolStripMenuItem.Click += MoveToTopToolStripMenuItem_Click;
            // 
            // MoveUpToolStripMenuItem
            // 
            MoveUpToolStripMenuItem.Image = Properties.Resources.MoveCameraUp;
            MoveUpToolStripMenuItem.Name = "MoveUpToolStripMenuItem";
            MoveUpToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+PgUp";
            MoveUpToolStripMenuItem.Size = new Size(215, 22);
            MoveUpToolStripMenuItem.Text = "Move Up";
            MoveUpToolStripMenuItem.Click += MoveUpToolStripMenuItem_Click;
            // 
            // MoveDownToolStripMenuItem
            // 
            MoveDownToolStripMenuItem.Image = Properties.Resources.MoveCameraDown;
            MoveDownToolStripMenuItem.Name = "MoveDownToolStripMenuItem";
            MoveDownToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+PgDn";
            MoveDownToolStripMenuItem.Size = new Size(215, 22);
            MoveDownToolStripMenuItem.Text = "Move Down";
            MoveDownToolStripMenuItem.Click += MoveDownToolStripMenuItem_Click;
            // 
            // MoveToBottomToolStripMenuItem
            // 
            MoveToBottomToolStripMenuItem.Image = Properties.Resources.MoveCameraBottom;
            MoveToBottomToolStripMenuItem.Name = "MoveToBottomToolStripMenuItem";
            MoveToBottomToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+End";
            MoveToBottomToolStripMenuItem.Size = new Size(215, 22);
            MoveToBottomToolStripMenuItem.Text = "Move to Bottom";
            MoveToBottomToolStripMenuItem.Click += MoveToBottomToolStripMenuItem_Click;
            // 
            // AddCANMKeyframeToolStripMenuItem
            // 
            AddCANMKeyframeToolStripMenuItem.Image = Properties.Resources.AddCamera;
            AddCANMKeyframeToolStripMenuItem.Name = "AddCANMKeyframeToolStripMenuItem";
            AddCANMKeyframeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            AddCANMKeyframeToolStripMenuItem.Size = new Size(215, 22);
            AddCANMKeyframeToolStripMenuItem.Text = "Add Keyframe";
            AddCANMKeyframeToolStripMenuItem.Click += AddCANMKeyframeToolStripMenuItem_Click;
            // 
            // DeleteCANMKeyframeToolStripMenuItem
            // 
            DeleteCANMKeyframeToolStripMenuItem.Image = Properties.Resources.Delete;
            DeleteCANMKeyframeToolStripMenuItem.Name = "DeleteCANMKeyframeToolStripMenuItem";
            DeleteCANMKeyframeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Del";
            DeleteCANMKeyframeToolStripMenuItem.Size = new Size(215, 22);
            DeleteCANMKeyframeToolStripMenuItem.Text = "Delete Keyframe";
            DeleteCANMKeyframeToolStripMenuItem.Click += DeleteCANMKeyframeToolStripMenuItem_Click;
            // 
            // SetAllToLinearToolStripMenuItem
            // 
            SetAllToLinearToolStripMenuItem.Image = Properties.Resources.LinearAll;
            SetAllToLinearToolStripMenuItem.Name = "SetAllToLinearToolStripMenuItem";
            SetAllToLinearToolStripMenuItem.Size = new Size(215, 22);
            SetAllToLinearToolStripMenuItem.Text = "Set All to Linear";
            SetAllToLinearToolStripMenuItem.Click += SetAllToLinearToolStripMenuItem_Click;
            // 
            // SetAllToZeroToolStripMenuItem
            // 
            SetAllToZeroToolStripMenuItem.Image = Properties.Resources.FlatAll;
            SetAllToZeroToolStripMenuItem.Name = "SetAllToZeroToolStripMenuItem";
            SetAllToZeroToolStripMenuItem.Size = new Size(215, 22);
            SetAllToZeroToolStripMenuItem.Text = "Set All to Zero";
            SetAllToZeroToolStripMenuItem.Click += SetAllToZeroToolStripMenuItem_Click;
            // 
            // ToolsToolStripMenuItem
            // 
            ToolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AutoSortToolStripMenuItem, IdentificationAssistantToolStripMenuItem, ExportPresetToolStripMenuItem, OptionsToolStripMenuItem });
            ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            ToolsToolStripMenuItem.Size = new Size(46, 20);
            ToolsToolStripMenuItem.Text = "Tools";
            // 
            // AutoSortToolStripMenuItem
            // 
            AutoSortToolStripMenuItem.Image = Properties.Resources.Reorganize;
            AutoSortToolStripMenuItem.Name = "AutoSortToolStripMenuItem";
            AutoSortToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            AutoSortToolStripMenuItem.Size = new Size(194, 22);
            AutoSortToolStripMenuItem.Text = "&Auto Sort";
            AutoSortToolStripMenuItem.Click += AutoSortToolStripMenuItem_Click;
            // 
            // IdentificationAssistantToolStripMenuItem
            // 
            IdentificationAssistantToolStripMenuItem.Image = Properties.Resources.Assistant;
            IdentificationAssistantToolStripMenuItem.Name = "IdentificationAssistantToolStripMenuItem";
            IdentificationAssistantToolStripMenuItem.Size = new Size(194, 22);
            IdentificationAssistantToolStripMenuItem.Text = "&Identification Assistant";
            IdentificationAssistantToolStripMenuItem.Click += IdentificationAssistantToolStripMenuItem_Click;
            // 
            // ExportPresetToolStripMenuItem
            // 
            ExportPresetToolStripMenuItem.Enabled = false;
            ExportPresetToolStripMenuItem.Image = Properties.Resources.Export_Preset;
            ExportPresetToolStripMenuItem.Name = "ExportPresetToolStripMenuItem";
            ExportPresetToolStripMenuItem.Size = new Size(194, 22);
            ExportPresetToolStripMenuItem.Text = "Export Preset";
            ExportPresetToolStripMenuItem.Click += ExportPresetToolStripMenuItem_Click;
            // 
            // OptionsToolStripMenuItem
            // 
            OptionsToolStripMenuItem.Image = Properties.Resources.Icon_Settings;
            OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            OptionsToolStripMenuItem.Size = new Size(194, 22);
            OptionsToolStripMenuItem.Text = "&Options";
            OptionsToolStripMenuItem.Click += OptionsToolStripMenuItem_Click;
            // 
            // HelpToolStripMenuItem
            // 
            HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { WikiToolStripMenuItem, IssuesToolStripMenuItem, GithubReleasesToolStripMenuItem, AboutToolStripMenuItem });
            HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            HelpToolStripMenuItem.Size = new Size(44, 20);
            HelpToolStripMenuItem.Text = "Help";
            // 
            // WikiToolStripMenuItem
            // 
            WikiToolStripMenuItem.Image = Properties.Resources.WikiPage;
            WikiToolStripMenuItem.Name = "WikiToolStripMenuItem";
            WikiToolStripMenuItem.Size = new Size(157, 22);
            WikiToolStripMenuItem.Text = "&Github Wiki";
            WikiToolStripMenuItem.Click += WikiToolStripMenuItem_Click;
            // 
            // IssuesToolStripMenuItem
            // 
            IssuesToolStripMenuItem.Image = Properties.Resources.IssuePage;
            IssuesToolStripMenuItem.Name = "IssuesToolStripMenuItem";
            IssuesToolStripMenuItem.Size = new Size(157, 22);
            IssuesToolStripMenuItem.Text = "&Github Issues";
            IssuesToolStripMenuItem.Click += IssuesToolStripMenuItem_Click;
            // 
            // GithubReleasesToolStripMenuItem
            // 
            GithubReleasesToolStripMenuItem.Image = Properties.Resources.ReleasesPage;
            GithubReleasesToolStripMenuItem.Name = "GithubReleasesToolStripMenuItem";
            GithubReleasesToolStripMenuItem.Size = new Size(157, 22);
            GithubReleasesToolStripMenuItem.Text = "Github Releases";
            GithubReleasesToolStripMenuItem.Click += GithubReleasesToolStripMenuItem_Click;
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Size = new Size(157, 22);
            AboutToolStripMenuItem.Text = "&About";
            AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // MainSplitContainer
            // 
            MainSplitContainer.Dock = DockStyle.Fill;
            MainSplitContainer.FixedPanel = FixedPanel.Panel1;
            MainSplitContainer.IsSplitterFixed = true;
            MainSplitContainer.Location = new Point(0, 24);
            MainSplitContainer.Margin = new Padding(4, 3, 4, 3);
            MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            MainSplitContainer.Panel1.Controls.Add(CameraListBox);
            MainSplitContainer.Panel1MinSize = 224;
            MainSplitContainer.Size = new Size(668, 441);
            MainSplitContainer.SplitterDistance = 224;
            MainSplitContainer.TabIndex = 1;
            MainSplitContainer.TabStop = false;
            // 
            // CameraListBox
            // 
            CameraListBox.BorderStyle = BorderStyle.None;
            CameraListBox.Dock = DockStyle.Fill;
            CameraListBox.Enabled = false;
            CameraListBox.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            CameraListBox.FormattingEnabled = true;
            CameraListBox.HorizontalScrollbar = true;
            CameraListBox.IntegralHeight = false;
            CameraListBox.Location = new Point(0, 0);
            CameraListBox.Margin = new Padding(4, 3, 4, 3);
            CameraListBox.Name = "CameraListBox";
            CameraListBox.Size = new Size(224, 441);
            CameraListBox.TabIndex = 0;
            CameraListBox.SelectedIndexChanged += CameraListBox_SelectedIndexChanged;
            CameraListBox.KeyDown += CameraListBox_KeyDown;
            CameraListBox.MouseUp += CameraListBox_MouseUp;
            // 
            // Yaz0BackgroundWorker
            // 
            Yaz0BackgroundWorker.WorkerReportsProgress = true;
            Yaz0BackgroundWorker.DoWork += Yaz0BackgroundWorker_DoWork;
            Yaz0BackgroundWorker.ProgressChanged += Yaz0BackgroundWorker_ProgressChanged;
            // 
            // CameraEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 465);
            Controls.Add(MainSplitContainer);
            Controls.Add(EditorMenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = EditorMenuStrip;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimumSize = new Size(684, 504);
            Name = "CameraEditorForm";
            Text = "Launch Cam Plus";
            EditorMenuStrip.ResumeLayout(false);
            EditorMenuStrip.PerformLayout();
            MainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).EndInit();
            MainSplitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripMenuItem AddCANMKeyframeToolStripMenuItem;
        private ToolStripMenuItem DeleteCANMKeyframeToolStripMenuItem;
        private ToolStripMenuItem SetAllToLinearToolStripMenuItem;
        private ToolStripMenuItem SetAllToZeroToolStripMenuItem;
    }
}