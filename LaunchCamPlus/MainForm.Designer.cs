﻿namespace LaunchCamPlus
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StandardCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BasicPlanetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpawnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScenarioStartersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScenarioStarterSmoothMovingAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaunchStarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaunchStarSmoothMovingAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaunchStarSmoothShakingAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleDemoExecutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OtherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckForErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ErrorCheckSelectedCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ErrorCheckAllCamerasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportPresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IDAssistantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GitHubIssuesPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GitHubReleasesPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GitHubWikipediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraListBox = new System.Windows.Forms.ListBox();
            this.NewFileTimer = new System.Windows.Forms.Timer(this.components);
            this.CamIDTextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.CamTypeComboBox = new System.Windows.Forms.ComboBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.CopyTimer = new System.Windows.Forms.Timer(this.components);
            this.RotationTrackBar = new System.Windows.Forms.TrackBar();
            this.RotationAxisComboBox = new System.Windows.Forms.ComboBox();
            this.RotationValueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RotationDegRadioButton = new System.Windows.Forms.RadioButton();
            this.RotationRadRadioButton = new System.Windows.Forms.RadioButton();
            this.CamZoomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ZoomLabel = new System.Windows.Forms.Label();
            this.FOVLabel = new System.Windows.Forms.Label();
            this.CamFOVNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CamIntLabel = new System.Windows.Forms.Label();
            this.CamIntNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CamEndIntLabel = new System.Windows.Forms.Label();
            this.CamEndIntNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GndIntLabel = new System.Windows.Forms.Label();
            this.GndIntNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AllowDPadRotationCheckBox = new System.Windows.Forms.CheckBox();
            this.MaxYLabel = new System.Windows.Forms.Label();
            this.MaxYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MinYLabel = new System.Windows.Forms.Label();
            this.MinYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Num2CheckBox = new System.Windows.Forms.CheckBox();
            this.GroundMoveDelayLabel = new System.Windows.Forms.Label();
            this.GroundMoveDelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AirDelayLabel = new System.Windows.Forms.Label();
            this.AirMoveDelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.HeightZoomLabel = new System.Windows.Forms.Label();
            this.HeightZoomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FrontZoomLabel = new System.Windows.Forms.Label();
            this.FrontZoomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LowerLabel = new System.Windows.Forms.Label();
            this.UpperLabel = new System.Windows.Forms.Label();
            this.UpperNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LowerNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.UDownNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.UDownLabel = new System.Windows.Forms.Label();
            this.CoordinateGroupBox = new System.Windows.Forms.GroupBox();
            this.ZNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.YNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.XNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CoordinateComboBox = new System.Windows.Forms.ComboBox();
            this.DisableResetCheckBox = new System.Windows.Forms.CheckBox();
            this.EventFrameLabel = new System.Windows.Forms.Label();
            this.EventLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.EventPriorityLabel = new System.Windows.Forms.Label();
            this.EventPriorityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SharpZoomCheckBox = new System.Windows.Forms.CheckBox();
            this.EnableBlurCheckbox = new System.Windows.Forms.CheckBox();
            this.NoCollisionCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableFirstPersonCheckBox = new System.Windows.Forms.CheckBox();
            this.GEndTransCheckBox = new System.Windows.Forms.CheckBox();
            this.GThruCheckBox = new System.Windows.Forms.CheckBox();
            this.GEndErpFrameCheckBox = new System.Windows.Forms.CheckBox();
            this.EventTransCheckBox = new System.Windows.Forms.CheckBox();
            this.EventEndTransCheckBox = new System.Windows.Forms.CheckBox();
            this.VPanCheckBox = new System.Windows.Forms.CheckBox();
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.RailCamIDLabel = new System.Windows.Forms.Label();
            this.RailCamIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DiscordTimer = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationValueNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamZoomNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamFOVNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamIntNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamEndIntNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GndIntNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroundMoveDelayNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AirMoveDelayNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightZoomNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontZoomNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpperNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDownNumericUpDown)).BeginInit();
            this.CoordinateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventPriorityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RailCamIDNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(624, 24);
            this.MenuStrip.TabIndex = 0;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.New_File;
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.NewToolStripMenuItem.Text = "New";
            this.NewToolStripMenuItem.ToolTipText = "Starts a new Camera file";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Open_File;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.ToolTipText = "Opens a .bcam Camera File";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Save_File;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S ";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.ToolTipText = "Saves the .bcam";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Enabled = false;
            this.SaveAsToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Save_As;
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.ShortcutKeyDisplayString = "Shft+Ctrl+S ";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.SaveAsToolStripMenuItem.Text = "Save As...";
            this.SaveAsToolStripMenuItem.ToolTipText = "Saves a new .bcam";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.PresetsToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.EditToolStripMenuItem.Enabled = false;
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditToolStripMenuItem.Text = "Edit";
            // 
            // AddNewToolStripMenuItem
            // 
            this.AddNewToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.AddCamera;
            this.AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem";
            this.AddNewToolStripMenuItem.ShortcutKeyDisplayString = "Shft+Ctrl+A";
            this.AddNewToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.AddNewToolStripMenuItem.Text = "Add";
            this.AddNewToolStripMenuItem.ToolTipText = "Adds a new Camera";
            this.AddNewToolStripMenuItem.Click += new System.EventHandler(this.AddNewToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Copy;
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeyDisplayString = "Shft+Ctrl+C";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.CopyToolStripMenuItem.Text = "Copy";
            this.CopyToolStripMenuItem.ToolTipText = "Copies the selected Camera";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Enabled = false;
            this.PasteToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Paste;
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeyDisplayString = "Shft+Ctrl+V";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.PasteToolStripMenuItem.Text = "Paste";
            this.PasteToolStripMenuItem.ToolTipText = "Paste the copied Camera onto this one (OVERWRITES SELECTED CAMERA)";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // PresetsToolStripMenuItem
            // 
            this.PresetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CameraAreaToolStripMenuItem,
            this.SpawnToolStripMenuItem,
            this.EventsToolStripMenuItem,
            this.OtherToolStripMenuItem,
            this.LoadPresetToolStripMenuItem});
            this.PresetsToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Presets;
            this.PresetsToolStripMenuItem.Name = "PresetsToolStripMenuItem";
            this.PresetsToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.PresetsToolStripMenuItem.Text = "Presets";
            this.PresetsToolStripMenuItem.ToolTipText = "Official Preset Library";
            // 
            // CameraAreaToolStripMenuItem
            // 
            this.CameraAreaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StandardCameraToolStripMenuItem,
            this.TopDownToolStripMenuItem,
            this.BasicPlanetToolStripMenuItem,
            this.OpenWorldToolStripMenuItem});
            this.CameraAreaToolStripMenuItem.Name = "CameraAreaToolStripMenuItem";
            this.CameraAreaToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.CameraAreaToolStripMenuItem.Text = "General";
            this.CameraAreaToolStripMenuItem.ToolTipText = "Camera Areas";
            // 
            // StandardCameraToolStripMenuItem
            // 
            this.StandardCameraToolStripMenuItem.Name = "StandardCameraToolStripMenuItem";
            this.StandardCameraToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 1]";
            this.StandardCameraToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.StandardCameraToolStripMenuItem.Text = "Standard Camera";
            this.StandardCameraToolStripMenuItem.ToolTipText = "Standard Camera";
            this.StandardCameraToolStripMenuItem.Click += new System.EventHandler(this.StandardCameraToolStripMenuItem_Click);
            // 
            // TopDownToolStripMenuItem
            // 
            this.TopDownToolStripMenuItem.Name = "TopDownToolStripMenuItem";
            this.TopDownToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 1]";
            this.TopDownToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.TopDownToolStripMenuItem.Text = "Top Down";
            this.TopDownToolStripMenuItem.ToolTipText = "Top Down Camera";
            this.TopDownToolStripMenuItem.Click += new System.EventHandler(this.TopDownToolStripMenuItem_Click);
            // 
            // BasicPlanetToolStripMenuItem
            // 
            this.BasicPlanetToolStripMenuItem.Name = "BasicPlanetToolStripMenuItem";
            this.BasicPlanetToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 1]";
            this.BasicPlanetToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.BasicPlanetToolStripMenuItem.Text = "Basic Planet";
            this.BasicPlanetToolStripMenuItem.ToolTipText = "A Basic Planet Camera";
            this.BasicPlanetToolStripMenuItem.Click += new System.EventHandler(this.BasicPlanetToolStripMenuItem_Click_1);
            // 
            // OpenWorldToolStripMenuItem
            // 
            this.OpenWorldToolStripMenuItem.Name = "OpenWorldToolStripMenuItem";
            this.OpenWorldToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 1]";
            this.OpenWorldToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.OpenWorldToolStripMenuItem.Text = "Open World";
            this.OpenWorldToolStripMenuItem.ToolTipText = "An Open World Camera that rotates and moves with mario";
            this.OpenWorldToolStripMenuItem.Click += new System.EventHandler(this.OpenWorldToolStripMenuItem_Click);
            // 
            // SpawnToolStripMenuItem
            // 
            this.SpawnToolStripMenuItem.Name = "SpawnToolStripMenuItem";
            this.SpawnToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.SpawnToolStripMenuItem.Text = "Spawn";
            this.SpawnToolStripMenuItem.ToolTipText = "Spawn Points";
            // 
            // EventsToolStripMenuItem
            // 
            this.EventsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScenarioStartersToolStripMenuItem,
            this.LaunchStarsToolStripMenuItem,
            this.SimpleDemoExecutorToolStripMenuItem});
            this.EventsToolStripMenuItem.Name = "EventsToolStripMenuItem";
            this.EventsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.EventsToolStripMenuItem.Text = "Events";
            this.EventsToolStripMenuItem.ToolTipText = "Events (Like using Launch Stars)";
            // 
            // ScenarioStartersToolStripMenuItem
            // 
            this.ScenarioStartersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScenarioStarterSmoothMovingAToolStripMenuItem});
            this.ScenarioStartersToolStripMenuItem.Name = "ScenarioStartersToolStripMenuItem";
            this.ScenarioStartersToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.ScenarioStartersToolStripMenuItem.Text = "Scenario Starters";
            this.ScenarioStartersToolStripMenuItem.ToolTipText = "ScenarioStarter";
            // 
            // ScenarioStarterSmoothMovingAToolStripMenuItem
            // 
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.Name = "ScenarioStarterSmoothMovingAToolStripMenuItem";
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 3]";
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.Text = "Smooth Moving A";
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.ToolTipText = "The Camera moves smoothly, and at the last 2 second, it freezes in position.";
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.Click += new System.EventHandler(this.ScenarioStarterSmoothMovingAToolStripMenuItem_Click);
            // 
            // LaunchStarsToolStripMenuItem
            // 
            this.LaunchStarsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaunchStarSmoothMovingAToolStripMenuItem,
            this.LaunchStarSmoothShakingAToolStripMenuItem});
            this.LaunchStarsToolStripMenuItem.Name = "LaunchStarsToolStripMenuItem";
            this.LaunchStarsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.LaunchStarsToolStripMenuItem.Text = "Launch Stars";
            this.LaunchStarsToolStripMenuItem.ToolTipText = "SuperSpinDriver";
            // 
            // LaunchStarSmoothMovingAToolStripMenuItem
            // 
            this.LaunchStarSmoothMovingAToolStripMenuItem.Name = "LaunchStarSmoothMovingAToolStripMenuItem";
            this.LaunchStarSmoothMovingAToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 3]";
            this.LaunchStarSmoothMovingAToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.LaunchStarSmoothMovingAToolStripMenuItem.Text = "Smooth Moving A";
            this.LaunchStarSmoothMovingAToolStripMenuItem.ToolTipText = "The first second it stays in place, then, the angle changes less smoothly, and so" +
    "metimes \'stutters\' when the path isn\'t a curve, the last .5 second it freezes in" +
    " place.";
            this.LaunchStarSmoothMovingAToolStripMenuItem.Click += new System.EventHandler(this.LaunchStarSmoothMovingAToolStripMenuItem_Click);
            // 
            // LaunchStarSmoothShakingAToolStripMenuItem
            // 
            this.LaunchStarSmoothShakingAToolStripMenuItem.Name = "LaunchStarSmoothShakingAToolStripMenuItem";
            this.LaunchStarSmoothShakingAToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 3]";
            this.LaunchStarSmoothShakingAToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.LaunchStarSmoothShakingAToolStripMenuItem.Text = "Smooth Shaking A";
            this.LaunchStarSmoothShakingAToolStripMenuItem.Click += new System.EventHandler(this.LaunchStarSmoothShakingAToolStripMenuItem_Click);
            // 
            // SimpleDemoExecutorToolStripMenuItem
            // 
            this.SimpleDemoExecutorToolStripMenuItem.Name = "SimpleDemoExecutorToolStripMenuItem";
            this.SimpleDemoExecutorToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.SimpleDemoExecutorToolStripMenuItem.Text = "Simple Demo Executor";
            this.SimpleDemoExecutorToolStripMenuItem.Click += new System.EventHandler(this.SimpleDemoExecutorToolStripMenuItem_Click);
            // 
            // OtherToolStripMenuItem
            // 
            this.OtherToolStripMenuItem.Name = "OtherToolStripMenuItem";
            this.OtherToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.OtherToolStripMenuItem.Text = "Other";
            this.OtherToolStripMenuItem.ToolTipText = "Other";
            // 
            // LoadPresetToolStripMenuItem
            // 
            this.LoadPresetToolStripMenuItem.Name = "LoadPresetToolStripMenuItem";
            this.LoadPresetToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.LoadPresetToolStripMenuItem.Text = "Load LCPP";
            this.LoadPresetToolStripMenuItem.ToolTipText = "Load Preset from .lcpp file";
            this.LoadPresetToolStripMenuItem.Click += new System.EventHandler(this.LoadPresetToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Delete;
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Delete";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.DeleteToolStripMenuItem.Text = "Delete";
            this.DeleteToolStripMenuItem.ToolTipText = "Delete the selected Camera";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckForErrorsToolStripMenuItem,
            this.PreviewToolStripMenuItem,
            this.ExportPresetToolStripMenuItem,
            this.IDAssistantToolStripMenuItem,
            this.AutoSortToolStripMenuItem,
            this.PluginsToolStripMenuItem});
            this.ToolsToolStripMenuItem.Enabled = false;
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.ToolsToolStripMenuItem.Text = "Tools";
            // 
            // CheckForErrorsToolStripMenuItem
            // 
            this.CheckForErrorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ErrorCheckSelectedCameraToolStripMenuItem,
            this.ErrorCheckAllCamerasToolStripMenuItem});
            this.CheckForErrorsToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Check_Errors;
            this.CheckForErrorsToolStripMenuItem.Name = "CheckForErrorsToolStripMenuItem";
            this.CheckForErrorsToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.CheckForErrorsToolStripMenuItem.Text = "Check for Errors";
            this.CheckForErrorsToolStripMenuItem.ToolTipText = "Check your cameras for errors";
            // 
            // ErrorCheckSelectedCameraToolStripMenuItem
            // 
            this.ErrorCheckSelectedCameraToolStripMenuItem.Name = "ErrorCheckSelectedCameraToolStripMenuItem";
            this.ErrorCheckSelectedCameraToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ErrorCheckSelectedCameraToolStripMenuItem.Text = "Selected Camera";
            this.ErrorCheckSelectedCameraToolStripMenuItem.ToolTipText = "Scan the selected Camera for errors";
            this.ErrorCheckSelectedCameraToolStripMenuItem.Click += new System.EventHandler(this.ErrorCheckSelectedCameraToolStripMenuItem_Click);
            // 
            // ErrorCheckAllCamerasToolStripMenuItem
            // 
            this.ErrorCheckAllCamerasToolStripMenuItem.Name = "ErrorCheckAllCamerasToolStripMenuItem";
            this.ErrorCheckAllCamerasToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ErrorCheckAllCamerasToolStripMenuItem.Text = "All Cameras";
            this.ErrorCheckAllCamerasToolStripMenuItem.ToolTipText = "Scan All Cameras for errors";
            this.ErrorCheckAllCamerasToolStripMenuItem.Click += new System.EventHandler(this.ErrorCheckAllCamerasToolStripMenuItem_Click);
            // 
            // PreviewToolStripMenuItem
            // 
            this.PreviewToolStripMenuItem.Enabled = false;
            this.PreviewToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Preview;
            this.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem";
            this.PreviewToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.PreviewToolStripMenuItem.Text = "Preview";
            this.PreviewToolStripMenuItem.ToolTipText = "Unavailable ";
            // 
            // ExportPresetToolStripMenuItem
            // 
            this.ExportPresetToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Export_Preset;
            this.ExportPresetToolStripMenuItem.Name = "ExportPresetToolStripMenuItem";
            this.ExportPresetToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.ExportPresetToolStripMenuItem.Text = "Export Preset";
            this.ExportPresetToolStripMenuItem.ToolTipText = "Opens the Preset Creator";
            this.ExportPresetToolStripMenuItem.Click += new System.EventHandler(this.ExportPresetToolStripMenuItem_Click);
            // 
            // IDAssistantToolStripMenuItem
            // 
            this.IDAssistantToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Assistant;
            this.IDAssistantToolStripMenuItem.Name = "IDAssistantToolStripMenuItem";
            this.IDAssistantToolStripMenuItem.ShortcutKeyDisplayString = "Shft+Ctrl+I";
            this.IDAssistantToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.IDAssistantToolStripMenuItem.Text = "Identification Assistant";
            this.IDAssistantToolStripMenuItem.ToolTipText = "Spawns a window to help you with Camera IDs";
            this.IDAssistantToolStripMenuItem.Click += new System.EventHandler(this.IDAssistantToolStripMenuItem_Click);
            // 
            // AutoSortToolStripMenuItem
            // 
            this.AutoSortToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Reoganize;
            this.AutoSortToolStripMenuItem.Name = "AutoSortToolStripMenuItem";
            this.AutoSortToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.AutoSortToolStripMenuItem.Text = "Auto Sort";
            this.AutoSortToolStripMenuItem.ToolTipText = "Automatically reorganizes the Camera List";
            this.AutoSortToolStripMenuItem.Click += new System.EventHandler(this.AutoSortToolStripMenuItem_Click);
            // 
            // PluginsToolStripMenuItem
            // 
            this.PluginsToolStripMenuItem.Enabled = false;
            this.PluginsToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.Plugins;
            this.PluginsToolStripMenuItem.Name = "PluginsToolStripMenuItem";
            this.PluginsToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.PluginsToolStripMenuItem.Text = "Plugins";
            this.PluginsToolStripMenuItem.ToolTipText = "No Plugins";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GitHubIssuesPageToolStripMenuItem,
            this.GitHubReleasesPageToolStripMenuItem,
            this.GitHubWikipediaToolStripMenuItem});
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AboutToolStripMenuItem.Text = "About";
            // 
            // GitHubIssuesPageToolStripMenuItem
            // 
            this.GitHubIssuesPageToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.IssuePage;
            this.GitHubIssuesPageToolStripMenuItem.Name = "GitHubIssuesPageToolStripMenuItem";
            this.GitHubIssuesPageToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.GitHubIssuesPageToolStripMenuItem.Text = "GitHub Issues Page";
            this.GitHubIssuesPageToolStripMenuItem.ToolTipText = "Found a bug?\r\nClick this to go to the GitHub Issues Page.";
            this.GitHubIssuesPageToolStripMenuItem.Click += new System.EventHandler(this.GitHubIssuesPageToolStripMenuItem_Click);
            // 
            // GitHubReleasesPageToolStripMenuItem
            // 
            this.GitHubReleasesPageToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.ReleasesPage;
            this.GitHubReleasesPageToolStripMenuItem.Name = "GitHubReleasesPageToolStripMenuItem";
            this.GitHubReleasesPageToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.GitHubReleasesPageToolStripMenuItem.Text = "GitHub Releases Page";
            this.GitHubReleasesPageToolStripMenuItem.ToolTipText = "Want to check and see if you have the Latest version of Launch Cam Plus?\r\nClick h" +
    "ere to see all Launch Cam Plus Releases.";
            this.GitHubReleasesPageToolStripMenuItem.Click += new System.EventHandler(this.GitHubReleasesPageToolStripMenuItem_Click);
            // 
            // GitHubWikipediaToolStripMenuItem
            // 
            this.GitHubWikipediaToolStripMenuItem.Image = global::LaunchCamPlus.Properties.Resources.WikiPage;
            this.GitHubWikipediaToolStripMenuItem.Name = "GitHubWikipediaToolStripMenuItem";
            this.GitHubWikipediaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.GitHubWikipediaToolStripMenuItem.Text = "GitHub Wikipedia";
            this.GitHubWikipediaToolStripMenuItem.ToolTipText = "Want to know more about how to use Launch Cam Plus?\r\nRead the Launch Cam Plus Wik" +
    "ipedia by clicking this link";
            this.GitHubWikipediaToolStripMenuItem.Click += new System.EventHandler(this.GitHubWikipediaToolStripMenuItem_Click);
            // 
            // CameraListBox
            // 
            this.CameraListBox.Enabled = false;
            this.CameraListBox.FormattingEnabled = true;
            this.CameraListBox.HorizontalScrollbar = true;
            this.CameraListBox.Items.AddRange(new object[] {
            "No BCAM loaded",
            "-------------------------",
            "Launch Cam Plus Made by:",
            "- Super Hackio",
            "-------------------------",
            "Found a Bug?",
            "Let Me know:",
            "> Github Issues Page",
            "> Discord Servers",
            "     -Super Hackio Incorporated",
            "",
            "",
            "Inspired by: thegreatwaluigi",
            " "});
            this.CameraListBox.Location = new System.Drawing.Point(12, 27);
            this.CameraListBox.Name = "CameraListBox";
            this.CameraListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CameraListBox.Size = new System.Drawing.Size(207, 368);
            this.CameraListBox.TabIndex = 1;
            this.MainToolTip.SetToolTip(this.CameraListBox, "Click to select a Camera");
            this.CameraListBox.SelectedIndexChanged += new System.EventHandler(this.CameraListBox_SelectedIndexChanged);
            // 
            // NewFileTimer
            // 
            this.NewFileTimer.Tick += new System.EventHandler(this.NewFileTimer_Tick);
            // 
            // CamIDTextBox
            // 
            this.CamIDTextBox.Enabled = false;
            this.CamIDTextBox.Location = new System.Drawing.Point(291, 27);
            this.CamIDTextBox.Name = "CamIDTextBox";
            this.CamIDTextBox.Size = new System.Drawing.Size(321, 20);
            this.CamIDTextBox.TabIndex = 2;
            this.MainToolTip.SetToolTip(this.CamIDTextBox, "Camera Identification.\r\nUsed by the game to tell what this camera is used for.\r\nE" +
        "xample: \"c:0000\" is used by a Camera Area with Camera ID 0.");
            this.CamIDTextBox.TextChanged += new System.EventHandler(this.CamIDTextBox_TextChanged);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(225, 30);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(60, 13);
            this.IDLabel.TabIndex = 3;
            this.IDLabel.Text = "Camera ID:";
            this.MainToolTip.SetToolTip(this.IDLabel, "Camera Identification.\r\nUsed by the game to tell what this camera is used for.\r\nE" +
        "xample: \"c:0000\" is used by a Camera Area with Camera ID 0.\r\n");
            // 
            // CamTypeComboBox
            // 
            this.CamTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CamTypeComboBox.Enabled = false;
            this.CamTypeComboBox.FormattingEnabled = true;
            this.CamTypeComboBox.Location = new System.Drawing.Point(304, 53);
            this.CamTypeComboBox.Name = "CamTypeComboBox";
            this.CamTypeComboBox.Size = new System.Drawing.Size(308, 21);
            this.CamTypeComboBox.TabIndex = 4;
            this.MainToolTip.SetToolTip(this.CamTypeComboBox, "Camera Type.\r\nThe standard option is CAM_TYPE_XZ_PARA");
            this.CamTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.CamTypeComboBox_SelectedIndexChanged);
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(225, 56);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(73, 13);
            this.TypeLabel.TabIndex = 5;
            this.TypeLabel.Text = "Camera Type:";
            this.MainToolTip.SetToolTip(this.TypeLabel, "Camera Type.\r\nThe standard option is CAM_TYPE_XZ_PARA");
            // 
            // CopyTimer
            // 
            this.CopyTimer.Tick += new System.EventHandler(this.CopyTimer_Tick);
            // 
            // RotationTrackBar
            // 
            this.RotationTrackBar.Enabled = false;
            this.RotationTrackBar.LargeChange = 45;
            this.RotationTrackBar.Location = new System.Drawing.Point(304, 80);
            this.RotationTrackBar.Maximum = 360;
            this.RotationTrackBar.Name = "RotationTrackBar";
            this.RotationTrackBar.Size = new System.Drawing.Size(237, 45);
            this.RotationTrackBar.SmallChange = 5;
            this.RotationTrackBar.TabIndex = 6;
            this.RotationTrackBar.TickFrequency = 45;
            this.MainToolTip.SetToolTip(this.RotationTrackBar, "Change the current angle with this");
            this.RotationTrackBar.Value = 180;
            this.RotationTrackBar.Scroll += new System.EventHandler(this.RotationTrackBar_Scroll);
            // 
            // RotationAxisComboBox
            // 
            this.RotationAxisComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RotationAxisComboBox.Enabled = false;
            this.RotationAxisComboBox.FormattingEnabled = true;
            this.RotationAxisComboBox.Items.AddRange(new object[] {
            "X Axis",
            "Y Axis",
            "Z Axis"});
            this.RotationAxisComboBox.Location = new System.Drawing.Point(225, 80);
            this.RotationAxisComboBox.Name = "RotationAxisComboBox";
            this.RotationAxisComboBox.Size = new System.Drawing.Size(73, 21);
            this.RotationAxisComboBox.TabIndex = 7;
            this.MainToolTip.SetToolTip(this.RotationAxisComboBox, "Angle Axis.\r\nX Axis will rotate Up/Down\r\nY Axis will rotate Left/Right\r\nZ Axis wi" +
        "ll Roll the camera\r\n");
            this.RotationAxisComboBox.SelectedIndexChanged += new System.EventHandler(this.RotationAxisComboBox_SelectedIndexChanged);
            // 
            // RotationValueNumericUpDown
            // 
            this.RotationValueNumericUpDown.DecimalPlaces = 7;
            this.RotationValueNumericUpDown.Enabled = false;
            this.RotationValueNumericUpDown.Location = new System.Drawing.Point(225, 105);
            this.RotationValueNumericUpDown.Maximum = new decimal(new int[] {
            270,
            0,
            0,
            0});
            this.RotationValueNumericUpDown.Minimum = new decimal(new int[] {
            270,
            0,
            0,
            -2147483648});
            this.RotationValueNumericUpDown.Name = "RotationValueNumericUpDown";
            this.RotationValueNumericUpDown.Size = new System.Drawing.Size(73, 20);
            this.RotationValueNumericUpDown.TabIndex = 8;
            this.MainToolTip.SetToolTip(this.RotationValueNumericUpDown, "Shows the exact number that will be used for this angle");
            this.RotationValueNumericUpDown.ValueChanged += new System.EventHandler(this.RotationValueNumericUpDown_ValueChanged);
            // 
            // RotationDegRadioButton
            // 
            this.RotationDegRadioButton.AutoSize = true;
            this.RotationDegRadioButton.Checked = true;
            this.RotationDegRadioButton.Enabled = false;
            this.RotationDegRadioButton.Location = new System.Drawing.Point(547, 81);
            this.RotationDegRadioButton.Name = "RotationDegRadioButton";
            this.RotationDegRadioButton.Size = new System.Drawing.Size(65, 17);
            this.RotationDegRadioButton.TabIndex = 9;
            this.RotationDegRadioButton.TabStop = true;
            this.RotationDegRadioButton.Text = "Degrees";
            this.MainToolTip.SetToolTip(this.RotationDegRadioButton, "Degrees:\r\n0, 90, 180, etc.");
            this.RotationDegRadioButton.UseVisualStyleBackColor = true;
            this.RotationDegRadioButton.CheckedChanged += new System.EventHandler(this.RotationDegRadioButton_CheckedChanged);
            // 
            // RotationRadRadioButton
            // 
            this.RotationRadRadioButton.AutoSize = true;
            this.RotationRadRadioButton.Enabled = false;
            this.RotationRadRadioButton.Location = new System.Drawing.Point(547, 105);
            this.RotationRadRadioButton.Name = "RotationRadRadioButton";
            this.RotationRadRadioButton.Size = new System.Drawing.Size(64, 17);
            this.RotationRadRadioButton.TabIndex = 10;
            this.RotationRadRadioButton.Text = "Radians";
            this.MainToolTip.SetToolTip(this.RotationRadRadioButton, "Radians:\r\n0, 1.5708, 3.14159, etc.");
            this.RotationRadRadioButton.UseVisualStyleBackColor = true;
            this.RotationRadRadioButton.CheckedChanged += new System.EventHandler(this.RotationRadRadioButton_CheckedChanged);
            // 
            // CamZoomNumericUpDown
            // 
            this.CamZoomNumericUpDown.Enabled = false;
            this.CamZoomNumericUpDown.Location = new System.Drawing.Point(269, 131);
            this.CamZoomNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.CamZoomNumericUpDown.Name = "CamZoomNumericUpDown";
            this.CamZoomNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.CamZoomNumericUpDown.TabIndex = 11;
            this.MainToolTip.SetToolTip(this.CamZoomNumericUpDown, "Camera Zoom\r\nDetermines how far away the camera will be from the Fixpoint\r\nExampl" +
        "e: 1000 with CAM_TYPE_XZ_PARA will have the camera\r\nbe close to the player, but " +
        "not too close.");
            this.CamZoomNumericUpDown.ValueChanged += new System.EventHandler(this.CamZoomumericUpDown_ValueChanged);
            // 
            // ZoomLabel
            // 
            this.ZoomLabel.AutoSize = true;
            this.ZoomLabel.Location = new System.Drawing.Point(226, 133);
            this.ZoomLabel.Name = "ZoomLabel";
            this.ZoomLabel.Size = new System.Drawing.Size(37, 13);
            this.ZoomLabel.TabIndex = 12;
            this.ZoomLabel.Text = "Zoom:";
            this.MainToolTip.SetToolTip(this.ZoomLabel, "Camera Zoom\r\nDetermines how far away the camera will be from the Fixpoint\r\nExampl" +
        "e: 1000 with CAM_TYPE_XZ_PARA will have the camera\r\nbe close to the player, but " +
        "not too close.");
            // 
            // FOVLabel
            // 
            this.FOVLabel.AutoSize = true;
            this.FOVLabel.Location = new System.Drawing.Point(420, 160);
            this.FOVLabel.Name = "FOVLabel";
            this.FOVLabel.Size = new System.Drawing.Size(72, 13);
            this.FOVLabel.TabIndex = 14;
            this.FOVLabel.Text = "Field Of View:";
            // 
            // CamFOVNumericUpDown
            // 
            this.CamFOVNumericUpDown.Enabled = false;
            this.CamFOVNumericUpDown.Location = new System.Drawing.Point(532, 158);
            this.CamFOVNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.CamFOVNumericUpDown.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147418112});
            this.CamFOVNumericUpDown.Name = "CamFOVNumericUpDown";
            this.CamFOVNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.CamFOVNumericUpDown.TabIndex = 13;
            this.CamFOVNumericUpDown.ValueChanged += new System.EventHandler(this.FOVNumericUpDown_ValueChanged);
            // 
            // CamIntLabel
            // 
            this.CamIntLabel.AutoSize = true;
            this.CamIntLabel.Location = new System.Drawing.Point(226, 159);
            this.CamIntLabel.Name = "CamIntLabel";
            this.CamIntLabel.Size = new System.Drawing.Size(90, 13);
            this.CamIntLabel.TabIndex = 16;
            this.CamIntLabel.Text = "Transition Speed:";
            this.MainToolTip.SetToolTip(this.CamIntLabel, "Transition Speed\r\nSmaller numbers mean that the transition is faster.\r\n100 means " +
        "it takes one second to change.");
            // 
            // CamIntNumericUpDown
            // 
            this.CamIntNumericUpDown.Enabled = false;
            this.CamIntNumericUpDown.Location = new System.Drawing.Point(345, 157);
            this.CamIntNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.CamIntNumericUpDown.Name = "CamIntNumericUpDown";
            this.CamIntNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.CamIntNumericUpDown.TabIndex = 15;
            this.MainToolTip.SetToolTip(this.CamIntNumericUpDown, "Transition Speed\r\nSmaller numbers mean that the transition is faster.\r\n100 means " +
        "it takes one second to change.");
            this.CamIntNumericUpDown.ValueChanged += new System.EventHandler(this.CamIntnumericUpDown_ValueChanged);
            // 
            // CamEndIntLabel
            // 
            this.CamEndIntLabel.AutoSize = true;
            this.CamEndIntLabel.Location = new System.Drawing.Point(226, 185);
            this.CamEndIntLabel.Name = "CamEndIntLabel";
            this.CamEndIntLabel.Size = new System.Drawing.Size(112, 13);
            this.CamEndIntLabel.TabIndex = 18;
            this.CamEndIntLabel.Text = "End Transition Speed:";
            this.MainToolTip.SetToolTip(this.CamEndIntLabel, "End Transition Speed\r\nSmaller numbers mean that the transition is faster.\r\n100 me" +
        "ans it takes one second to deactivate");
            // 
            // CamEndIntNumericUpDown
            // 
            this.CamEndIntNumericUpDown.Enabled = false;
            this.CamEndIntNumericUpDown.Location = new System.Drawing.Point(345, 183);
            this.CamEndIntNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.CamEndIntNumericUpDown.Name = "CamEndIntNumericUpDown";
            this.CamEndIntNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.CamEndIntNumericUpDown.TabIndex = 17;
            this.CamEndIntNumericUpDown.ValueChanged += new System.EventHandler(this.CamEndIntNumericUpDown_ValueChanged);
            // 
            // GndIntLabel
            // 
            this.GndIntLabel.AutoSize = true;
            this.GndIntLabel.Location = new System.Drawing.Point(226, 211);
            this.GndIntLabel.Name = "GndIntLabel";
            this.GndIntLabel.Size = new System.Drawing.Size(79, 13);
            this.GndIntLabel.TabIndex = 20;
            this.GndIntLabel.Text = "Ground Speed:";
            this.MainToolTip.SetToolTip(this.GndIntLabel, "Ground Speed\r\nUnconfirmed");
            // 
            // GndIntNumericUpDown
            // 
            this.GndIntNumericUpDown.Enabled = false;
            this.GndIntNumericUpDown.Location = new System.Drawing.Point(345, 209);
            this.GndIntNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.GndIntNumericUpDown.Name = "GndIntNumericUpDown";
            this.GndIntNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.GndIntNumericUpDown.TabIndex = 19;
            this.MainToolTip.SetToolTip(this.GndIntNumericUpDown, "Ground Speed\r\nUnconfirmed");
            this.GndIntNumericUpDown.ValueChanged += new System.EventHandler(this.GndIntNumericUpDown_ValueChanged);
            // 
            // AllowDPadRotationCheckBox
            // 
            this.AllowDPadRotationCheckBox.AutoSize = true;
            this.AllowDPadRotationCheckBox.Enabled = false;
            this.AllowDPadRotationCheckBox.Location = new System.Drawing.Point(356, 132);
            this.AllowDPadRotationCheckBox.Name = "AllowDPadRotationCheckBox";
            this.AllowDPadRotationCheckBox.Size = new System.Drawing.Size(127, 17);
            this.AllowDPadRotationCheckBox.TabIndex = 21;
            this.AllowDPadRotationCheckBox.Text = "Enable DPad rotation";
            this.MainToolTip.SetToolTip(this.AllowDPadRotationCheckBox, "Enable/Disable the ability to rotate the Camera using the DPAD");
            this.AllowDPadRotationCheckBox.UseVisualStyleBackColor = true;
            this.AllowDPadRotationCheckBox.CheckedChanged += new System.EventHandler(this.AllowDPadRotationCheckBox_CheckedChanged);
            // 
            // MaxYLabel
            // 
            this.MaxYLabel.AutoSize = true;
            this.MaxYLabel.Location = new System.Drawing.Point(420, 185);
            this.MaxYLabel.Name = "MaxYLabel";
            this.MaxYLabel.Size = new System.Drawing.Size(93, 13);
            this.MaxYLabel.TabIndex = 23;
            this.MaxYLabel.Text = "Max Y Movement:";
            // 
            // MaxYNumericUpDown
            // 
            this.MaxYNumericUpDown.Enabled = false;
            this.MaxYNumericUpDown.Location = new System.Drawing.Point(532, 183);
            this.MaxYNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.MaxYNumericUpDown.Name = "MaxYNumericUpDown";
            this.MaxYNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.MaxYNumericUpDown.TabIndex = 22;
            this.MaxYNumericUpDown.ValueChanged += new System.EventHandler(this.MaxYNumericUpDown_ValueChanged);
            // 
            // MinYLabel
            // 
            this.MinYLabel.AutoSize = true;
            this.MinYLabel.Location = new System.Drawing.Point(420, 211);
            this.MinYLabel.Name = "MinYLabel";
            this.MinYLabel.Size = new System.Drawing.Size(90, 13);
            this.MinYLabel.TabIndex = 25;
            this.MinYLabel.Text = "Min Y Movement:";
            // 
            // MinYNumericUpDown
            // 
            this.MinYNumericUpDown.Enabled = false;
            this.MinYNumericUpDown.Location = new System.Drawing.Point(532, 209);
            this.MinYNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.MinYNumericUpDown.Name = "MinYNumericUpDown";
            this.MinYNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.MinYNumericUpDown.TabIndex = 24;
            this.MinYNumericUpDown.ValueChanged += new System.EventHandler(this.MinYNumericUpDown_ValueChanged);
            // 
            // Num2CheckBox
            // 
            this.Num2CheckBox.AutoSize = true;
            this.Num2CheckBox.Enabled = false;
            this.Num2CheckBox.Location = new System.Drawing.Point(433, 362);
            this.Num2CheckBox.Name = "Num2CheckBox";
            this.Num2CheckBox.Size = new System.Drawing.Size(101, 17);
            this.Num2CheckBox.TabIndex = 26;
            this.Num2CheckBox.Text = "No DPad Reset";
            this.MainToolTip.SetToolTip(this.Num2CheckBox, "Disable/Enable the camera resetting it\'s DPad Rotation");
            this.Num2CheckBox.UseVisualStyleBackColor = true;
            this.Num2CheckBox.CheckedChanged += new System.EventHandler(this.Num2CheckBox_CheckedChanged);
            // 
            // GroundMoveDelayLabel
            // 
            this.GroundMoveDelayLabel.AutoSize = true;
            this.GroundMoveDelayLabel.Location = new System.Drawing.Point(226, 237);
            this.GroundMoveDelayLabel.Name = "GroundMoveDelayLabel";
            this.GroundMoveDelayLabel.Size = new System.Drawing.Size(105, 13);
            this.GroundMoveDelayLabel.TabIndex = 28;
            this.GroundMoveDelayLabel.Text = "Ground Move Delay:";
            this.MainToolTip.SetToolTip(this.GroundMoveDelayLabel, "Ground Move Delay\r\nUnconfirmed");
            // 
            // GroundMoveDelayNumericUpDown
            // 
            this.GroundMoveDelayNumericUpDown.Enabled = false;
            this.GroundMoveDelayNumericUpDown.Location = new System.Drawing.Point(345, 235);
            this.GroundMoveDelayNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.GroundMoveDelayNumericUpDown.Name = "GroundMoveDelayNumericUpDown";
            this.GroundMoveDelayNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.GroundMoveDelayNumericUpDown.TabIndex = 27;
            this.MainToolTip.SetToolTip(this.GroundMoveDelayNumericUpDown, "Ground Move Delay\r\nUnconfirmed");
            this.GroundMoveDelayNumericUpDown.ValueChanged += new System.EventHandler(this.GroundMoveDelayNumericUpDown_ValueChanged);
            // 
            // AirDelayLabel
            // 
            this.AirDelayLabel.AutoSize = true;
            this.AirDelayLabel.Location = new System.Drawing.Point(420, 237);
            this.AirDelayLabel.Name = "AirDelayLabel";
            this.AirDelayLabel.Size = new System.Drawing.Size(82, 13);
            this.AirDelayLabel.TabIndex = 30;
            this.AirDelayLabel.Text = "Air Move Delay:";
            // 
            // AirMoveDelayNumericUpDown
            // 
            this.AirMoveDelayNumericUpDown.Enabled = false;
            this.AirMoveDelayNumericUpDown.Location = new System.Drawing.Point(532, 235);
            this.AirMoveDelayNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.AirMoveDelayNumericUpDown.Name = "AirMoveDelayNumericUpDown";
            this.AirMoveDelayNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.AirMoveDelayNumericUpDown.TabIndex = 29;
            this.AirMoveDelayNumericUpDown.ValueChanged += new System.EventHandler(this.AirMoveDelayNumericUpDown_ValueChanged);
            // 
            // HeightZoomLabel
            // 
            this.HeightZoomLabel.AutoSize = true;
            this.HeightZoomLabel.Location = new System.Drawing.Point(420, 263);
            this.HeightZoomLabel.Name = "HeightZoomLabel";
            this.HeightZoomLabel.Size = new System.Drawing.Size(71, 13);
            this.HeightZoomLabel.TabIndex = 34;
            this.HeightZoomLabel.Text = "Height Zoom:";
            this.MainToolTip.SetToolTip(this.HeightZoomLabel, resources.GetString("HeightZoomLabel.ToolTip"));
            // 
            // HeightZoomNumericUpDown
            // 
            this.HeightZoomNumericUpDown.Enabled = false;
            this.HeightZoomNumericUpDown.Location = new System.Drawing.Point(532, 261);
            this.HeightZoomNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.HeightZoomNumericUpDown.Name = "HeightZoomNumericUpDown";
            this.HeightZoomNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.HeightZoomNumericUpDown.TabIndex = 33;
            this.MainToolTip.SetToolTip(this.HeightZoomNumericUpDown, resources.GetString("HeightZoomNumericUpDown.ToolTip"));
            this.HeightZoomNumericUpDown.ValueChanged += new System.EventHandler(this.HeightZoomNumericUpDown_ValueChanged);
            // 
            // FrontZoomLabel
            // 
            this.FrontZoomLabel.AutoSize = true;
            this.FrontZoomLabel.Location = new System.Drawing.Point(226, 263);
            this.FrontZoomLabel.Name = "FrontZoomLabel";
            this.FrontZoomLabel.Size = new System.Drawing.Size(64, 13);
            this.FrontZoomLabel.TabIndex = 32;
            this.FrontZoomLabel.Text = "Front Zoom:";
            this.MainToolTip.SetToolTip(this.FrontZoomLabel, "Front Zoom\r\nThe Distance ahead of Mario to look at.\r\nHigher numbers means that th" +
        "e camera will show further ahead of mario.\r\nUsed in CAM_TYPE_FOLLOW");
            // 
            // FrontZoomNumericUpDown
            // 
            this.FrontZoomNumericUpDown.Enabled = false;
            this.FrontZoomNumericUpDown.Location = new System.Drawing.Point(345, 261);
            this.FrontZoomNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.FrontZoomNumericUpDown.Name = "FrontZoomNumericUpDown";
            this.FrontZoomNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.FrontZoomNumericUpDown.TabIndex = 31;
            this.MainToolTip.SetToolTip(this.FrontZoomNumericUpDown, "Front Zoom\r\nThe Distance ahead of Mario to look at.\r\nHigher numbers means that th" +
        "e camera will show further ahead of mario.\r\nUsed in CAM_TYPE_FOLLOW");
            this.FrontZoomNumericUpDown.ValueChanged += new System.EventHandler(this.FrontZoomNumericUpDown_ValueChanged);
            // 
            // LowerLabel
            // 
            this.LowerLabel.AutoSize = true;
            this.LowerLabel.Location = new System.Drawing.Point(353, 289);
            this.LowerLabel.Name = "LowerLabel";
            this.LowerLabel.Size = new System.Drawing.Size(73, 13);
            this.LowerLabel.TabIndex = 38;
            this.LowerLabel.Text = "Lower Border:";
            // 
            // UpperLabel
            // 
            this.UpperLabel.AutoSize = true;
            this.UpperLabel.Location = new System.Drawing.Point(226, 289);
            this.UpperLabel.Name = "UpperLabel";
            this.UpperLabel.Size = new System.Drawing.Size(73, 13);
            this.UpperLabel.TabIndex = 36;
            this.UpperLabel.Text = "Upper Border:";
            // 
            // UpperNumericUpDown
            // 
            this.UpperNumericUpDown.DecimalPlaces = 2;
            this.UpperNumericUpDown.Enabled = false;
            this.UpperNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.UpperNumericUpDown.Location = new System.Drawing.Point(305, 287);
            this.UpperNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.UpperNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.UpperNumericUpDown.Name = "UpperNumericUpDown";
            this.UpperNumericUpDown.Size = new System.Drawing.Size(42, 20);
            this.UpperNumericUpDown.TabIndex = 35;
            this.UpperNumericUpDown.ValueChanged += new System.EventHandler(this.UpperNumericUpDown_ValueChanged);
            // 
            // LowerNumericUpDown
            // 
            this.LowerNumericUpDown.DecimalPlaces = 2;
            this.LowerNumericUpDown.Enabled = false;
            this.LowerNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LowerNumericUpDown.Location = new System.Drawing.Point(432, 287);
            this.LowerNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LowerNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.LowerNumericUpDown.Name = "LowerNumericUpDown";
            this.LowerNumericUpDown.Size = new System.Drawing.Size(42, 20);
            this.LowerNumericUpDown.TabIndex = 39;
            this.LowerNumericUpDown.ValueChanged += new System.EventHandler(this.LowerNumericUpDown_ValueChanged);
            // 
            // UDownNumericUpDown
            // 
            this.UDownNumericUpDown.Enabled = false;
            this.UDownNumericUpDown.Location = new System.Drawing.Point(538, 287);
            this.UDownNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.UDownNumericUpDown.Name = "UDownNumericUpDown";
            this.UDownNumericUpDown.Size = new System.Drawing.Size(64, 20);
            this.UDownNumericUpDown.TabIndex = 41;
            this.UDownNumericUpDown.ValueChanged += new System.EventHandler(this.UDownNumericUpDown_ValueChanged);
            // 
            // UDownLabel
            // 
            this.UDownLabel.AutoSize = true;
            this.UDownLabel.Location = new System.Drawing.Point(480, 289);
            this.UDownLabel.Name = "UDownLabel";
            this.UDownLabel.Size = new System.Drawing.Size(52, 13);
            this.UDownLabel.TabIndex = 40;
            this.UDownLabel.Text = "[UDown]:";
            // 
            // CoordinateGroupBox
            // 
            this.CoordinateGroupBox.Controls.Add(this.ZNumericUpDown);
            this.CoordinateGroupBox.Controls.Add(this.YNumericUpDown);
            this.CoordinateGroupBox.Controls.Add(this.XNumericUpDown);
            this.CoordinateGroupBox.Controls.Add(this.CoordinateComboBox);
            this.CoordinateGroupBox.Location = new System.Drawing.Point(225, 313);
            this.CoordinateGroupBox.Name = "CoordinateGroupBox";
            this.CoordinateGroupBox.Size = new System.Drawing.Size(114, 121);
            this.CoordinateGroupBox.TabIndex = 42;
            this.CoordinateGroupBox.TabStop = false;
            this.CoordinateGroupBox.Text = "Coordinates";
            // 
            // ZNumericUpDown
            // 
            this.ZNumericUpDown.DecimalPlaces = 7;
            this.ZNumericUpDown.Enabled = false;
            this.ZNumericUpDown.Location = new System.Drawing.Point(6, 95);
            this.ZNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ZNumericUpDown.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147418112});
            this.ZNumericUpDown.Name = "ZNumericUpDown";
            this.ZNumericUpDown.Size = new System.Drawing.Size(102, 20);
            this.ZNumericUpDown.TabIndex = 45;
            this.MainToolTip.SetToolTip(this.ZNumericUpDown, "Z Position");
            this.ZNumericUpDown.ValueChanged += new System.EventHandler(this.ZNumericUpDown_ValueChanged);
            // 
            // YNumericUpDown
            // 
            this.YNumericUpDown.DecimalPlaces = 7;
            this.YNumericUpDown.Enabled = false;
            this.YNumericUpDown.Location = new System.Drawing.Point(6, 69);
            this.YNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.YNumericUpDown.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147418112});
            this.YNumericUpDown.Name = "YNumericUpDown";
            this.YNumericUpDown.Size = new System.Drawing.Size(102, 20);
            this.YNumericUpDown.TabIndex = 44;
            this.MainToolTip.SetToolTip(this.YNumericUpDown, "Y Position");
            this.YNumericUpDown.ValueChanged += new System.EventHandler(this.YNumericUpDown_ValueChanged);
            // 
            // XNumericUpDown
            // 
            this.XNumericUpDown.DecimalPlaces = 7;
            this.XNumericUpDown.Enabled = false;
            this.XNumericUpDown.Location = new System.Drawing.Point(6, 43);
            this.XNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.XNumericUpDown.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147418112});
            this.XNumericUpDown.Name = "XNumericUpDown";
            this.XNumericUpDown.Size = new System.Drawing.Size(102, 20);
            this.XNumericUpDown.TabIndex = 43;
            this.MainToolTip.SetToolTip(this.XNumericUpDown, "X position");
            this.XNumericUpDown.ValueChanged += new System.EventHandler(this.XNumericUpDown_ValueChanged);
            // 
            // CoordinateComboBox
            // 
            this.CoordinateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CoordinateComboBox.Enabled = false;
            this.CoordinateComboBox.FormattingEnabled = true;
            this.CoordinateComboBox.Items.AddRange(new object[] {
            "Fixed Point",
            "World Point",
            "Player Offset",
            "Unknown [Up]",
            "Panning Bounds"});
            this.CoordinateComboBox.Location = new System.Drawing.Point(6, 16);
            this.CoordinateComboBox.Name = "CoordinateComboBox";
            this.CoordinateComboBox.Size = new System.Drawing.Size(102, 21);
            this.CoordinateComboBox.TabIndex = 43;
            this.MainToolTip.SetToolTip(this.CoordinateComboBox, resources.GetString("CoordinateComboBox.ToolTip"));
            this.CoordinateComboBox.SelectedIndexChanged += new System.EventHandler(this.CoordinateComboBox_SelectedIndexChanged);
            // 
            // DisableResetCheckBox
            // 
            this.DisableResetCheckBox.AutoSize = true;
            this.DisableResetCheckBox.Enabled = false;
            this.DisableResetCheckBox.Location = new System.Drawing.Point(345, 339);
            this.DisableResetCheckBox.Name = "DisableResetCheckBox";
            this.DisableResetCheckBox.Size = new System.Drawing.Size(92, 17);
            this.DisableResetCheckBox.TabIndex = 43;
            this.DisableResetCheckBox.Text = "Disable Reset";
            this.MainToolTip.SetToolTip(this.DisableResetCheckBox, "Disables the Camera angle from resetting.");
            this.DisableResetCheckBox.UseVisualStyleBackColor = true;
            this.DisableResetCheckBox.CheckedChanged += new System.EventHandler(this.DisableResetCheckBox_CheckedChanged);
            // 
            // EventFrameLabel
            // 
            this.EventFrameLabel.AutoSize = true;
            this.EventFrameLabel.Location = new System.Drawing.Point(345, 315);
            this.EventFrameLabel.Name = "EventFrameLabel";
            this.EventFrameLabel.Size = new System.Drawing.Size(74, 13);
            this.EventFrameLabel.TabIndex = 45;
            this.EventFrameLabel.Text = "Event Length:";
            this.MainToolTip.SetToolTip(this.EventFrameLabel, "Length of the Event.\r\n100 = 1 second");
            // 
            // EventLengthNumericUpDown
            // 
            this.EventLengthNumericUpDown.Enabled = false;
            this.EventLengthNumericUpDown.Location = new System.Drawing.Point(425, 313);
            this.EventLengthNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.EventLengthNumericUpDown.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147418112});
            this.EventLengthNumericUpDown.Name = "EventLengthNumericUpDown";
            this.EventLengthNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.EventLengthNumericUpDown.TabIndex = 44;
            this.MainToolTip.SetToolTip(this.EventLengthNumericUpDown, "Length of the Event.\r\n100 = 1 second");
            this.EventLengthNumericUpDown.ValueChanged += new System.EventHandler(this.EventLengthNumericUpDown_ValueChanged);
            // 
            // EventPriorityLabel
            // 
            this.EventPriorityLabel.AutoSize = true;
            this.EventPriorityLabel.Location = new System.Drawing.Point(500, 315);
            this.EventPriorityLabel.Name = "EventPriorityLabel";
            this.EventPriorityLabel.Size = new System.Drawing.Size(72, 13);
            this.EventPriorityLabel.TabIndex = 47;
            this.EventPriorityLabel.Text = "Event Priority:";
            this.MainToolTip.SetToolTip(this.EventPriorityLabel, "Priority of the current Event\r\nHigher Priorities will overthrow already playing e" +
        "vents with lower Priority\r\n");
            // 
            // EventPriorityNumericUpDown
            // 
            this.EventPriorityNumericUpDown.Enabled = false;
            this.EventPriorityNumericUpDown.Location = new System.Drawing.Point(578, 313);
            this.EventPriorityNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.EventPriorityNumericUpDown.Name = "EventPriorityNumericUpDown";
            this.EventPriorityNumericUpDown.Size = new System.Drawing.Size(34, 20);
            this.EventPriorityNumericUpDown.TabIndex = 46;
            this.MainToolTip.SetToolTip(this.EventPriorityNumericUpDown, "Priority of the current Event\r\nHigher Priorities will overthrow already playing e" +
        "vents with lower Priority");
            this.EventPriorityNumericUpDown.ValueChanged += new System.EventHandler(this.EventPriorityNumericUpDown_ValueChanged);
            // 
            // SharpZoomCheckBox
            // 
            this.SharpZoomCheckBox.AutoSize = true;
            this.SharpZoomCheckBox.Enabled = false;
            this.SharpZoomCheckBox.Location = new System.Drawing.Point(433, 339);
            this.SharpZoomCheckBox.Name = "SharpZoomCheckBox";
            this.SharpZoomCheckBox.Size = new System.Drawing.Size(137, 17);
            this.SharpZoomCheckBox.TabIndex = 48;
            this.SharpZoomCheckBox.Text = "Sharp Zoom Movement";
            this.MainToolTip.SetToolTip(this.SharpZoomCheckBox, "Makes the movement done with Front Zoom and Height Zoom not be smooth");
            this.SharpZoomCheckBox.UseVisualStyleBackColor = true;
            this.SharpZoomCheckBox.CheckedChanged += new System.EventHandler(this.SharpZoomCheckBox_CheckedChanged);
            // 
            // EnableBlurCheckbox
            // 
            this.EnableBlurCheckbox.AutoSize = true;
            this.EnableBlurCheckbox.Enabled = false;
            this.EnableBlurCheckbox.Location = new System.Drawing.Point(345, 362);
            this.EnableBlurCheckbox.Name = "EnableBlurCheckbox";
            this.EnableBlurCheckbox.Size = new System.Drawing.Size(80, 17);
            this.EnableBlurCheckbox.TabIndex = 49;
            this.EnableBlurCheckbox.Text = "Enable Blur";
            this.MainToolTip.SetToolTip(this.EnableBlurCheckbox, "Enables a Blurry effect when moving the camera");
            this.EnableBlurCheckbox.UseVisualStyleBackColor = true;
            this.EnableBlurCheckbox.CheckedChanged += new System.EventHandler(this.EnableBlurCheckbox_CheckedChanged);
            // 
            // NoCollisionCheckBox
            // 
            this.NoCollisionCheckBox.AutoSize = true;
            this.NoCollisionCheckBox.Enabled = false;
            this.NoCollisionCheckBox.Location = new System.Drawing.Point(534, 362);
            this.NoCollisionCheckBox.Name = "NoCollisionCheckBox";
            this.NoCollisionCheckBox.Size = new System.Drawing.Size(82, 17);
            this.NoCollisionCheckBox.TabIndex = 50;
            this.NoCollisionCheckBox.Text = "Collisionless";
            this.MainToolTip.SetToolTip(this.NoCollisionCheckBox, "Allows the camera to go through walls");
            this.NoCollisionCheckBox.UseVisualStyleBackColor = true;
            this.NoCollisionCheckBox.CheckedChanged += new System.EventHandler(this.NoCollisionCheckBox_CheckedChanged);
            // 
            // DisableFirstPersonCheckBox
            // 
            this.DisableFirstPersonCheckBox.AutoSize = true;
            this.DisableFirstPersonCheckBox.Enabled = false;
            this.DisableFirstPersonCheckBox.Location = new System.Drawing.Point(489, 132);
            this.DisableFirstPersonCheckBox.Name = "DisableFirstPersonCheckBox";
            this.DisableFirstPersonCheckBox.Size = new System.Drawing.Size(119, 17);
            this.DisableFirstPersonCheckBox.TabIndex = 51;
            this.DisableFirstPersonCheckBox.Text = "Disable First Person";
            this.MainToolTip.SetToolTip(this.DisableFirstPersonCheckBox, "Enable/Disable the ability to use First Person View\r\n");
            this.DisableFirstPersonCheckBox.UseVisualStyleBackColor = true;
            this.DisableFirstPersonCheckBox.CheckedChanged += new System.EventHandler(this.DisableFirstPersonCheckBox_CheckedChanged);
            // 
            // GEndTransCheckBox
            // 
            this.GEndTransCheckBox.AutoSize = true;
            this.GEndTransCheckBox.Enabled = false;
            this.GEndTransCheckBox.Location = new System.Drawing.Point(534, 410);
            this.GEndTransCheckBox.Name = "GEndTransCheckBox";
            this.GEndTransCheckBox.Size = new System.Drawing.Size(78, 17);
            this.GEndTransCheckBox.TabIndex = 54;
            this.GEndTransCheckBox.Text = "CamEndInt";
            this.MainToolTip.SetToolTip(this.GEndTransCheckBox, "Unknown");
            this.GEndTransCheckBox.UseVisualStyleBackColor = true;
            this.GEndTransCheckBox.CheckedChanged += new System.EventHandler(this.GEndTransCheckBox_CheckedChanged);
            // 
            // GThruCheckBox
            // 
            this.GThruCheckBox.AutoSize = true;
            this.GThruCheckBox.Enabled = false;
            this.GThruCheckBox.Location = new System.Drawing.Point(433, 410);
            this.GThruCheckBox.Name = "GThruCheckBox";
            this.GThruCheckBox.Size = new System.Drawing.Size(48, 17);
            this.GThruCheckBox.TabIndex = 53;
            this.GThruCheckBox.Text = "Thru";
            this.MainToolTip.SetToolTip(this.GThruCheckBox, "Unknown");
            this.GThruCheckBox.UseVisualStyleBackColor = true;
            this.GThruCheckBox.CheckedChanged += new System.EventHandler(this.GThruCheckBox_CheckedChanged);
            // 
            // GEndErpFrameCheckBox
            // 
            this.GEndErpFrameCheckBox.AutoSize = true;
            this.GEndErpFrameCheckBox.Enabled = false;
            this.GEndErpFrameCheckBox.Location = new System.Drawing.Point(345, 410);
            this.GEndErpFrameCheckBox.Name = "GEndErpFrameCheckBox";
            this.GEndErpFrameCheckBox.Size = new System.Drawing.Size(90, 17);
            this.GEndErpFrameCheckBox.TabIndex = 52;
            this.GEndErpFrameCheckBox.Text = "EndErpFrame";
            this.MainToolTip.SetToolTip(this.GEndErpFrameCheckBox, "Unknown");
            this.GEndErpFrameCheckBox.UseVisualStyleBackColor = true;
            this.GEndErpFrameCheckBox.CheckedChanged += new System.EventHandler(this.GEndErpFrameCheckBox_CheckedChanged);
            // 
            // EventTransCheckBox
            // 
            this.EventTransCheckBox.AutoSize = true;
            this.EventTransCheckBox.Enabled = false;
            this.EventTransCheckBox.Location = new System.Drawing.Point(534, 386);
            this.EventTransCheckBox.Name = "EventTransCheckBox";
            this.EventTransCheckBox.Size = new System.Drawing.Size(75, 17);
            this.EventTransCheckBox.TabIndex = 57;
            this.EventTransCheckBox.Text = "Use Trans";
            this.MainToolTip.SetToolTip(this.EventTransCheckBox, "Enable the use of the Transition Speed\r\n(Event Cameras)");
            this.EventTransCheckBox.UseVisualStyleBackColor = true;
            this.EventTransCheckBox.CheckedChanged += new System.EventHandler(this.EventTransCheckBox_CheckedChanged);
            // 
            // EventEndTransCheckBox
            // 
            this.EventEndTransCheckBox.AutoSize = true;
            this.EventEndTransCheckBox.Enabled = false;
            this.EventEndTransCheckBox.Location = new System.Drawing.Point(433, 386);
            this.EventEndTransCheckBox.Name = "EventEndTransCheckBox";
            this.EventEndTransCheckBox.Size = new System.Drawing.Size(97, 17);
            this.EventEndTransCheckBox.TabIndex = 56;
            this.EventEndTransCheckBox.Text = "Use End Trans";
            this.MainToolTip.SetToolTip(this.EventEndTransCheckBox, "Enable the use of the End Transition Speed\r\n(Event Cameras)");
            this.EventEndTransCheckBox.UseVisualStyleBackColor = true;
            this.EventEndTransCheckBox.CheckedChanged += new System.EventHandler(this.EventEndTransCheckBox_CheckedChanged);
            // 
            // VPanCheckBox
            // 
            this.VPanCheckBox.AutoSize = true;
            this.VPanCheckBox.Enabled = false;
            this.VPanCheckBox.Location = new System.Drawing.Point(345, 385);
            this.VPanCheckBox.Name = "VPanCheckBox";
            this.VPanCheckBox.Size = new System.Drawing.Size(84, 17);
            this.VPanCheckBox.TabIndex = 55;
            this.VPanCheckBox.Text = "Pan Bounds";
            this.MainToolTip.SetToolTip(this.VPanCheckBox, "Toggles the use of the Panning Bounds\r\nPanning bounds determind how far mario can" +
        " move before the camera moves to catch up\r\n");
            this.VPanCheckBox.UseVisualStyleBackColor = true;
            this.VPanCheckBox.CheckedChanged += new System.EventHandler(this.VPanCheckBox_CheckedChanged);
            // 
            // MainToolTip
            // 
            this.MainToolTip.AutomaticDelay = 100;
            this.MainToolTip.AutoPopDelay = 15000;
            this.MainToolTip.InitialDelay = 1000;
            this.MainToolTip.ReshowDelay = 200;
            this.MainToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.MainToolTip.ToolTipTitle = "Help";
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Enabled = false;
            this.MoveUpButton.Location = new System.Drawing.Point(12, 406);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(100, 23);
            this.MoveUpButton.TabIndex = 58;
            this.MoveUpButton.Text = "Move Up";
            this.MainToolTip.SetToolTip(this.MoveUpButton, "Move the selected camera up");
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Enabled = false;
            this.MoveDownButton.Location = new System.Drawing.Point(118, 406);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(101, 23);
            this.MoveDownButton.TabIndex = 59;
            this.MoveDownButton.Text = "Move Down";
            this.MainToolTip.SetToolTip(this.MoveDownButton, "Move the selected Camera down");
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // RailCamIDLabel
            // 
            this.RailCamIDLabel.AutoSize = true;
            this.RailCamIDLabel.Location = new System.Drawing.Point(345, 133);
            this.RailCamIDLabel.Name = "RailCamIDLabel";
            this.RailCamIDLabel.Size = new System.Drawing.Size(81, 13);
            this.RailCamIDLabel.TabIndex = 60;
            this.RailCamIDLabel.Text = "Camera Rail ID:";
            this.MainToolTip.SetToolTip(this.RailCamIDLabel, "Camera Rail ID\r\nThe ID of the Camera Rail to link to.\r\nPath Argument 0 on a Camer" +
        "a Rail defines this ID.");
            this.RailCamIDLabel.Visible = false;
            // 
            // RailCamIDNumericUpDown
            // 
            this.RailCamIDNumericUpDown.Location = new System.Drawing.Point(432, 131);
            this.RailCamIDNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.RailCamIDNumericUpDown.Name = "RailCamIDNumericUpDown";
            this.RailCamIDNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.RailCamIDNumericUpDown.TabIndex = 61;
            this.MainToolTip.SetToolTip(this.RailCamIDNumericUpDown, "Camera Rail ID\r\nThe ID of the Camera Rail to link to.\r\nPath Argument 0 on a Camer" +
        "a Rail defines this ID.");
            this.RailCamIDNumericUpDown.Visible = false;
            this.RailCamIDNumericUpDown.ValueChanged += new System.EventHandler(this.RailCamIDNumericUpDown_ValueChanged);
            // 
            // DiscordTimer
            // 
            this.DiscordTimer.Interval = 1000;
            this.DiscordTimer.Tick += new System.EventHandler(this.DiscordTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.RailCamIDNumericUpDown);
            this.Controls.Add(this.RailCamIDLabel);
            this.Controls.Add(this.MoveDownButton);
            this.Controls.Add(this.MoveUpButton);
            this.Controls.Add(this.EventTransCheckBox);
            this.Controls.Add(this.EventEndTransCheckBox);
            this.Controls.Add(this.VPanCheckBox);
            this.Controls.Add(this.GEndTransCheckBox);
            this.Controls.Add(this.GThruCheckBox);
            this.Controls.Add(this.GEndErpFrameCheckBox);
            this.Controls.Add(this.DisableFirstPersonCheckBox);
            this.Controls.Add(this.NoCollisionCheckBox);
            this.Controls.Add(this.EnableBlurCheckbox);
            this.Controls.Add(this.SharpZoomCheckBox);
            this.Controls.Add(this.EventPriorityLabel);
            this.Controls.Add(this.EventPriorityNumericUpDown);
            this.Controls.Add(this.EventFrameLabel);
            this.Controls.Add(this.EventLengthNumericUpDown);
            this.Controls.Add(this.DisableResetCheckBox);
            this.Controls.Add(this.CoordinateGroupBox);
            this.Controls.Add(this.UDownNumericUpDown);
            this.Controls.Add(this.UDownLabel);
            this.Controls.Add(this.LowerNumericUpDown);
            this.Controls.Add(this.LowerLabel);
            this.Controls.Add(this.UpperLabel);
            this.Controls.Add(this.UpperNumericUpDown);
            this.Controls.Add(this.HeightZoomLabel);
            this.Controls.Add(this.HeightZoomNumericUpDown);
            this.Controls.Add(this.FrontZoomLabel);
            this.Controls.Add(this.FrontZoomNumericUpDown);
            this.Controls.Add(this.AirDelayLabel);
            this.Controls.Add(this.AirMoveDelayNumericUpDown);
            this.Controls.Add(this.GroundMoveDelayLabel);
            this.Controls.Add(this.GroundMoveDelayNumericUpDown);
            this.Controls.Add(this.Num2CheckBox);
            this.Controls.Add(this.MinYLabel);
            this.Controls.Add(this.MinYNumericUpDown);
            this.Controls.Add(this.MaxYLabel);
            this.Controls.Add(this.MaxYNumericUpDown);
            this.Controls.Add(this.AllowDPadRotationCheckBox);
            this.Controls.Add(this.GndIntLabel);
            this.Controls.Add(this.GndIntNumericUpDown);
            this.Controls.Add(this.CamEndIntLabel);
            this.Controls.Add(this.CamEndIntNumericUpDown);
            this.Controls.Add(this.CamIntLabel);
            this.Controls.Add(this.CamIntNumericUpDown);
            this.Controls.Add(this.FOVLabel);
            this.Controls.Add(this.CamFOVNumericUpDown);
            this.Controls.Add(this.ZoomLabel);
            this.Controls.Add(this.CamZoomNumericUpDown);
            this.Controls.Add(this.RotationRadRadioButton);
            this.Controls.Add(this.RotationDegRadioButton);
            this.Controls.Add(this.RotationValueNumericUpDown);
            this.Controls.Add(this.RotationAxisComboBox);
            this.Controls.Add(this.RotationTrackBar);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.CamTypeComboBox);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.CamIDTextBox);
            this.Controls.Add(this.CameraListBox);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Launch Cam Plus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationValueNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamZoomNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamFOVNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamIntNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamEndIntNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GndIntNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroundMoveDelayNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AirMoveDelayNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightZoomNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontZoomNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpperNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDownNumericUpDown)).EndInit();
            this.CoordinateGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventLengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventPriorityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RailCamIDNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PresetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CameraAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SpawnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OtherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StandardCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckForErrorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ErrorCheckSelectedCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ErrorCheckAllCamerasToolStripMenuItem;
        private System.Windows.Forms.ListBox CameraListBox;
        private System.Windows.Forms.Timer NewFileTimer;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.ComboBox CamTypeComboBox;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Timer CopyTimer;
        private System.Windows.Forms.ToolStripMenuItem TopDownToolStripMenuItem;
        private System.Windows.Forms.TrackBar RotationTrackBar;
        private System.Windows.Forms.ComboBox RotationAxisComboBox;
        private System.Windows.Forms.NumericUpDown RotationValueNumericUpDown;
        private System.Windows.Forms.RadioButton RotationDegRadioButton;
        private System.Windows.Forms.RadioButton RotationRadRadioButton;
        private System.Windows.Forms.ToolStripMenuItem PreviewToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown CamZoomNumericUpDown;
        private System.Windows.Forms.Label ZoomLabel;
        private System.Windows.Forms.Label FOVLabel;
        private System.Windows.Forms.NumericUpDown CamFOVNumericUpDown;
        private System.Windows.Forms.Label CamIntLabel;
        private System.Windows.Forms.NumericUpDown CamIntNumericUpDown;
        private System.Windows.Forms.Label CamEndIntLabel;
        private System.Windows.Forms.NumericUpDown CamEndIntNumericUpDown;
        private System.Windows.Forms.Label GndIntLabel;
        private System.Windows.Forms.NumericUpDown GndIntNumericUpDown;
        private System.Windows.Forms.CheckBox AllowDPadRotationCheckBox;
        private System.Windows.Forms.Label MaxYLabel;
        private System.Windows.Forms.NumericUpDown MaxYNumericUpDown;
        private System.Windows.Forms.Label MinYLabel;
        private System.Windows.Forms.NumericUpDown MinYNumericUpDown;
        private System.Windows.Forms.CheckBox Num2CheckBox;
        private System.Windows.Forms.Label GroundMoveDelayLabel;
        private System.Windows.Forms.NumericUpDown GroundMoveDelayNumericUpDown;
        private System.Windows.Forms.Label AirDelayLabel;
        private System.Windows.Forms.NumericUpDown AirMoveDelayNumericUpDown;
        private System.Windows.Forms.Label HeightZoomLabel;
        private System.Windows.Forms.NumericUpDown HeightZoomNumericUpDown;
        private System.Windows.Forms.Label FrontZoomLabel;
        private System.Windows.Forms.NumericUpDown FrontZoomNumericUpDown;
        private System.Windows.Forms.Label LowerLabel;
        private System.Windows.Forms.Label UpperLabel;
        private System.Windows.Forms.NumericUpDown UpperNumericUpDown;
        private System.Windows.Forms.NumericUpDown LowerNumericUpDown;
        private System.Windows.Forms.NumericUpDown UDownNumericUpDown;
        private System.Windows.Forms.Label UDownLabel;
        private System.Windows.Forms.GroupBox CoordinateGroupBox;
        private System.Windows.Forms.NumericUpDown ZNumericUpDown;
        private System.Windows.Forms.NumericUpDown YNumericUpDown;
        private System.Windows.Forms.NumericUpDown XNumericUpDown;
        private System.Windows.Forms.ComboBox CoordinateComboBox;
        private System.Windows.Forms.CheckBox DisableResetCheckBox;
        private System.Windows.Forms.Label EventFrameLabel;
        private System.Windows.Forms.NumericUpDown EventLengthNumericUpDown;
        private System.Windows.Forms.Label EventPriorityLabel;
        private System.Windows.Forms.NumericUpDown EventPriorityNumericUpDown;
        private System.Windows.Forms.CheckBox SharpZoomCheckBox;
        private System.Windows.Forms.CheckBox EnableBlurCheckbox;
        private System.Windows.Forms.CheckBox NoCollisionCheckBox;
        private System.Windows.Forms.CheckBox DisableFirstPersonCheckBox;
        private System.Windows.Forms.CheckBox GEndTransCheckBox;
        private System.Windows.Forms.CheckBox GThruCheckBox;
        private System.Windows.Forms.CheckBox GEndErpFrameCheckBox;
        private System.Windows.Forms.CheckBox EventTransCheckBox;
        private System.Windows.Forms.CheckBox EventEndTransCheckBox;
        private System.Windows.Forms.CheckBox VPanCheckBox;
        private System.Windows.Forms.ToolStripMenuItem ScenarioStartersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScenarioStarterSmoothMovingAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportPresetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadPresetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LaunchStarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LaunchStarSmoothMovingAToolStripMenuItem;
        public System.Windows.Forms.TextBox CamIDTextBox;
        private System.Windows.Forms.ToolStripMenuItem IDAssistantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BasicPlanetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LaunchStarSmoothShakingAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimpleDemoExecutorToolStripMenuItem;
        private System.Windows.Forms.ToolTip MainToolTip;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GitHubIssuesPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GitHubReleasesPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GitHubWikipediaToolStripMenuItem;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.ToolStripMenuItem AutoSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenWorldToolStripMenuItem;
        private System.Windows.Forms.Label RailCamIDLabel;
        private System.Windows.Forms.NumericUpDown RailCamIDNumericUpDown;
        private System.Windows.Forms.ToolStripMenuItem PluginsToolStripMenuItem;
        private System.Windows.Forms.Timer DiscordTimer;
    }
}

