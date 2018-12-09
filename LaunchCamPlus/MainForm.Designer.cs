namespace LaunchCamPlus
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
            this.SpawnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScenarioStartersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScenarioStarterSmoothMovingAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaunchStarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaunchStarSmoothMovingAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.LOffsetVLabel = new System.Windows.Forms.Label();
            this.LOffsetVNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LOffsetLabel = new System.Windows.Forms.Label();
            this.LOffsetNumericUpDown = new System.Windows.Forms.NumericUpDown();
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
            this.LOffsetRPOffCheckBox = new System.Windows.Forms.CheckBox();
            this.EnableBlurCheckbox = new System.Windows.Forms.CheckBox();
            this.NoCollisionCheckBox = new System.Windows.Forms.CheckBox();
            this.NoPOVCheckBox = new System.Windows.Forms.CheckBox();
            this.GEndTransCheckBox = new System.Windows.Forms.CheckBox();
            this.GThruCheckBox = new System.Windows.Forms.CheckBox();
            this.GEndErpFrameCheckBox = new System.Windows.Forms.CheckBox();
            this.EventTransCheckBox = new System.Windows.Forms.CheckBox();
            this.EventEndTransCheckBox = new System.Windows.Forms.CheckBox();
            this.VPanCheckBox = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.LOffsetVNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOffsetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpperNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDownNumericUpDown)).BeginInit();
            this.CoordinateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventPriorityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ToolsToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(832, 28);
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
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.NewToolStripMenuItem.Text = "New";
            this.NewToolStripMenuItem.ToolTipText = "Starts a new Camera file";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.ToolTipText = "Opens a .bcam Camera File";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S ";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.ToolTipText = "Saves the .bcam";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Enabled = false;
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.ShortcutKeyDisplayString = "Shft+Ctrl+S ";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
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
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.EditToolStripMenuItem.Text = "Edit";
            // 
            // AddNewToolStripMenuItem
            // 
            this.AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem";
            this.AddNewToolStripMenuItem.ShortcutKeyDisplayString = "Shft+Ctrl+A";
            this.AddNewToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.AddNewToolStripMenuItem.Text = "Add";
            this.AddNewToolStripMenuItem.ToolTipText = "Adds a new Camera";
            this.AddNewToolStripMenuItem.Click += new System.EventHandler(this.AddNewToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeyDisplayString = "Shft+Ctrl+C";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.CopyToolStripMenuItem.Text = "Copy";
            this.CopyToolStripMenuItem.ToolTipText = "Copies the selected Camera";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Enabled = false;
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeyDisplayString = "Shft+Ctrl+V";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
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
            this.PresetsToolStripMenuItem.Name = "PresetsToolStripMenuItem";
            this.PresetsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.PresetsToolStripMenuItem.Text = "Presets";
            this.PresetsToolStripMenuItem.ToolTipText = "Official Preset Library";
            // 
            // CameraAreaToolStripMenuItem
            // 
            this.CameraAreaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StandardCameraToolStripMenuItem,
            this.TopDownToolStripMenuItem,
            this.BasicPlanetToolStripMenuItem});
            this.CameraAreaToolStripMenuItem.Name = "CameraAreaToolStripMenuItem";
            this.CameraAreaToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.CameraAreaToolStripMenuItem.Text = "General";
            this.CameraAreaToolStripMenuItem.ToolTipText = "Camera Areas";
            // 
            // StandardCameraToolStripMenuItem
            // 
            this.StandardCameraToolStripMenuItem.Name = "StandardCameraToolStripMenuItem";
            this.StandardCameraToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 1]";
            this.StandardCameraToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.StandardCameraToolStripMenuItem.Text = "Standard Camera";
            this.StandardCameraToolStripMenuItem.ToolTipText = "Standard Camera";
            this.StandardCameraToolStripMenuItem.Click += new System.EventHandler(this.StandardCameraToolStripMenuItem_Click);
            // 
            // TopDownToolStripMenuItem
            // 
            this.TopDownToolStripMenuItem.Name = "TopDownToolStripMenuItem";
            this.TopDownToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 1]";
            this.TopDownToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.TopDownToolStripMenuItem.Text = "Top Down";
            this.TopDownToolStripMenuItem.ToolTipText = "Top Down Camera";
            this.TopDownToolStripMenuItem.Click += new System.EventHandler(this.TopDownToolStripMenuItem_Click);
            // 
            // BasicPlanetToolStripMenuItem
            // 
            this.BasicPlanetToolStripMenuItem.Name = "BasicPlanetToolStripMenuItem";
            this.BasicPlanetToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 1]";
            this.BasicPlanetToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.BasicPlanetToolStripMenuItem.Text = "Basic Planet";
            this.BasicPlanetToolStripMenuItem.Click += new System.EventHandler(this.BasicPlanetToolStripMenuItem_Click_1);
            // 
            // SpawnToolStripMenuItem
            // 
            this.SpawnToolStripMenuItem.Name = "SpawnToolStripMenuItem";
            this.SpawnToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.SpawnToolStripMenuItem.Text = "Spawn";
            this.SpawnToolStripMenuItem.ToolTipText = "Spawn Points";
            // 
            // EventsToolStripMenuItem
            // 
            this.EventsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScenarioStartersToolStripMenuItem,
            this.LaunchStarsToolStripMenuItem});
            this.EventsToolStripMenuItem.Name = "EventsToolStripMenuItem";
            this.EventsToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.EventsToolStripMenuItem.Text = "Events";
            this.EventsToolStripMenuItem.ToolTipText = "Events (Like using Launch Stars)";
            // 
            // ScenarioStartersToolStripMenuItem
            // 
            this.ScenarioStartersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScenarioStarterSmoothMovingAToolStripMenuItem});
            this.ScenarioStartersToolStripMenuItem.Name = "ScenarioStartersToolStripMenuItem";
            this.ScenarioStartersToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.ScenarioStartersToolStripMenuItem.Text = "Scenario Starters";
            this.ScenarioStartersToolStripMenuItem.ToolTipText = "ScenarioStarter";
            // 
            // ScenarioStarterSmoothMovingAToolStripMenuItem
            // 
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.Name = "ScenarioStarterSmoothMovingAToolStripMenuItem";
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 3]";
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.Text = "Smooth Moving A";
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.ToolTipText = "The Camera moves smoothly, and at the last 2 second, it freezes in position.";
            this.ScenarioStarterSmoothMovingAToolStripMenuItem.Click += new System.EventHandler(this.ScenarioStarterSmoothMovingAToolStripMenuItem_Click);
            // 
            // LaunchStarsToolStripMenuItem
            // 
            this.LaunchStarsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaunchStarSmoothMovingAToolStripMenuItem});
            this.LaunchStarsToolStripMenuItem.Name = "LaunchStarsToolStripMenuItem";
            this.LaunchStarsToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.LaunchStarsToolStripMenuItem.Text = "Launch Stars";
            this.LaunchStarsToolStripMenuItem.ToolTipText = "SuperSpinDriver";
            // 
            // LaunchStarSmoothMovingAToolStripMenuItem
            // 
            this.LaunchStarSmoothMovingAToolStripMenuItem.Name = "LaunchStarSmoothMovingAToolStripMenuItem";
            this.LaunchStarSmoothMovingAToolStripMenuItem.ShortcutKeyDisplayString = "[Adds 3]";
            this.LaunchStarSmoothMovingAToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.LaunchStarSmoothMovingAToolStripMenuItem.Text = "Smooth Moving A";
            this.LaunchStarSmoothMovingAToolStripMenuItem.ToolTipText = "The first second it stays in place, then, the angle changes less smoothly, and so" +
    "metimes \'stutters\' when the path isn\'t a curve, the last .5 second it freezes in" +
    " place.";
            this.LaunchStarSmoothMovingAToolStripMenuItem.Click += new System.EventHandler(this.LaunchStarSmoothMovingAToolStripMenuItem_Click);
            // 
            // OtherToolStripMenuItem
            // 
            this.OtherToolStripMenuItem.Name = "OtherToolStripMenuItem";
            this.OtherToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.OtherToolStripMenuItem.Text = "Other";
            this.OtherToolStripMenuItem.ToolTipText = "Other";
            // 
            // LoadPresetToolStripMenuItem
            // 
            this.LoadPresetToolStripMenuItem.Name = "LoadPresetToolStripMenuItem";
            this.LoadPresetToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.LoadPresetToolStripMenuItem.Text = "Load LCPP";
            this.LoadPresetToolStripMenuItem.ToolTipText = "Load Preset from .lcpp file";
            this.LoadPresetToolStripMenuItem.Click += new System.EventHandler(this.LoadPresetToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Delete";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
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
            this.IDAssistantToolStripMenuItem});
            this.ToolsToolStripMenuItem.Enabled = false;
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.ToolsToolStripMenuItem.Text = "Tools";
            // 
            // CheckForErrorsToolStripMenuItem
            // 
            this.CheckForErrorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ErrorCheckSelectedCameraToolStripMenuItem,
            this.ErrorCheckAllCamerasToolStripMenuItem});
            this.CheckForErrorsToolStripMenuItem.Enabled = false;
            this.CheckForErrorsToolStripMenuItem.Name = "CheckForErrorsToolStripMenuItem";
            this.CheckForErrorsToolStripMenuItem.Size = new System.Drawing.Size(316, 26);
            this.CheckForErrorsToolStripMenuItem.Text = "Check for Errors";
            this.CheckForErrorsToolStripMenuItem.ToolTipText = "Unavailable";
            // 
            // ErrorCheckSelectedCameraToolStripMenuItem
            // 
            this.ErrorCheckSelectedCameraToolStripMenuItem.Enabled = false;
            this.ErrorCheckSelectedCameraToolStripMenuItem.Name = "ErrorCheckSelectedCameraToolStripMenuItem";
            this.ErrorCheckSelectedCameraToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.ErrorCheckSelectedCameraToolStripMenuItem.Text = "Selected Camera";
            this.ErrorCheckSelectedCameraToolStripMenuItem.ToolTipText = "Unavailible";
            // 
            // ErrorCheckAllCamerasToolStripMenuItem
            // 
            this.ErrorCheckAllCamerasToolStripMenuItem.Enabled = false;
            this.ErrorCheckAllCamerasToolStripMenuItem.Name = "ErrorCheckAllCamerasToolStripMenuItem";
            this.ErrorCheckAllCamerasToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.ErrorCheckAllCamerasToolStripMenuItem.Text = "All Cameras";
            this.ErrorCheckAllCamerasToolStripMenuItem.ToolTipText = "Unaviable";
            // 
            // PreviewToolStripMenuItem
            // 
            this.PreviewToolStripMenuItem.Enabled = false;
            this.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem";
            this.PreviewToolStripMenuItem.Size = new System.Drawing.Size(316, 26);
            this.PreviewToolStripMenuItem.Text = "Preview";
            this.PreviewToolStripMenuItem.ToolTipText = "Unavailable ";
            // 
            // ExportPresetToolStripMenuItem
            // 
            this.ExportPresetToolStripMenuItem.Name = "ExportPresetToolStripMenuItem";
            this.ExportPresetToolStripMenuItem.Size = new System.Drawing.Size(316, 26);
            this.ExportPresetToolStripMenuItem.Text = "Export Preset";
            this.ExportPresetToolStripMenuItem.ToolTipText = "Opens the Preset Creator";
            this.ExportPresetToolStripMenuItem.Click += new System.EventHandler(this.ExportPresetToolStripMenuItem_Click);
            // 
            // IDAssistantToolStripMenuItem
            // 
            this.IDAssistantToolStripMenuItem.Name = "IDAssistantToolStripMenuItem";
            this.IDAssistantToolStripMenuItem.ShortcutKeyDisplayString = "Shft+Ctrl+I";
            this.IDAssistantToolStripMenuItem.Size = new System.Drawing.Size(316, 26);
            this.IDAssistantToolStripMenuItem.Text = "Identification Assistant";
            this.IDAssistantToolStripMenuItem.ToolTipText = "Spawns a window to help you with Camera IDs";
            this.IDAssistantToolStripMenuItem.Click += new System.EventHandler(this.IDAssistantToolStripMenuItem_Click);
            // 
            // CameraListBox
            // 
            this.CameraListBox.Enabled = false;
            this.CameraListBox.FormattingEnabled = true;
            this.CameraListBox.ItemHeight = 16;
            this.CameraListBox.Items.AddRange(new object[] {
            "No BCAM loaded",
            "-------------------------",
            "Launch Cam Plus Made by:",
            "Super Hackio",
            "-------------------------",
            "Found a Bug?",
            "Let Me know:",
            "> Github Issues Page",
            "> Discord Servers",
            "     -Super Hackio INC",
            "",
            "",
            "Inspired by: thegreatwaluigi"});
            this.CameraListBox.Location = new System.Drawing.Point(16, 33);
            this.CameraListBox.Margin = new System.Windows.Forms.Padding(4);
            this.CameraListBox.Name = "CameraListBox";
            this.CameraListBox.Size = new System.Drawing.Size(275, 500);
            this.CameraListBox.TabIndex = 1;
            this.CameraListBox.SelectedIndexChanged += new System.EventHandler(this.CameraListBox_SelectedIndexChanged);
            // 
            // NewFileTimer
            // 
            this.NewFileTimer.Tick += new System.EventHandler(this.NewFileTimer_Tick);
            // 
            // CamIDTextBox
            // 
            this.CamIDTextBox.Enabled = false;
            this.CamIDTextBox.Location = new System.Drawing.Point(388, 33);
            this.CamIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CamIDTextBox.Name = "CamIDTextBox";
            this.CamIDTextBox.Size = new System.Drawing.Size(427, 22);
            this.CamIDTextBox.TabIndex = 2;
            this.CamIDTextBox.TextChanged += new System.EventHandler(this.CamIDTextBox_TextChanged);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(300, 37);
            this.IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(78, 17);
            this.IDLabel.TabIndex = 3;
            this.IDLabel.Text = "Camera ID:";
            // 
            // CamTypeComboBox
            // 
            this.CamTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CamTypeComboBox.Enabled = false;
            this.CamTypeComboBox.FormattingEnabled = true;
            this.CamTypeComboBox.Location = new System.Drawing.Point(405, 65);
            this.CamTypeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.CamTypeComboBox.Name = "CamTypeComboBox";
            this.CamTypeComboBox.Size = new System.Drawing.Size(409, 24);
            this.CamTypeComboBox.TabIndex = 4;
            this.CamTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.CamTypeComboBox_SelectedIndexChanged);
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(300, 69);
            this.TypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(97, 17);
            this.TypeLabel.TabIndex = 5;
            this.TypeLabel.Text = "Camera Type:";
            // 
            // CopyTimer
            // 
            this.CopyTimer.Tick += new System.EventHandler(this.CopyTimer_Tick);
            // 
            // RotationTrackBar
            // 
            this.RotationTrackBar.Enabled = false;
            this.RotationTrackBar.LargeChange = 45;
            this.RotationTrackBar.Location = new System.Drawing.Point(405, 98);
            this.RotationTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.RotationTrackBar.Maximum = 360;
            this.RotationTrackBar.Name = "RotationTrackBar";
            this.RotationTrackBar.Size = new System.Drawing.Size(316, 56);
            this.RotationTrackBar.SmallChange = 5;
            this.RotationTrackBar.TabIndex = 6;
            this.RotationTrackBar.TickFrequency = 45;
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
            this.RotationAxisComboBox.Location = new System.Drawing.Point(300, 98);
            this.RotationAxisComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.RotationAxisComboBox.Name = "RotationAxisComboBox";
            this.RotationAxisComboBox.Size = new System.Drawing.Size(96, 24);
            this.RotationAxisComboBox.TabIndex = 7;
            this.RotationAxisComboBox.SelectedIndexChanged += new System.EventHandler(this.RotationAxisComboBox_SelectedIndexChanged);
            // 
            // RotationValueNumericUpDown
            // 
            this.RotationValueNumericUpDown.DecimalPlaces = 7;
            this.RotationValueNumericUpDown.Enabled = false;
            this.RotationValueNumericUpDown.Location = new System.Drawing.Point(300, 129);
            this.RotationValueNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.RotationValueNumericUpDown.Size = new System.Drawing.Size(97, 22);
            this.RotationValueNumericUpDown.TabIndex = 8;
            this.RotationValueNumericUpDown.ValueChanged += new System.EventHandler(this.RotationValueNumericUpDown_ValueChanged);
            // 
            // RotationDegRadioButton
            // 
            this.RotationDegRadioButton.AutoSize = true;
            this.RotationDegRadioButton.Checked = true;
            this.RotationDegRadioButton.Enabled = false;
            this.RotationDegRadioButton.Location = new System.Drawing.Point(729, 100);
            this.RotationDegRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.RotationDegRadioButton.Name = "RotationDegRadioButton";
            this.RotationDegRadioButton.Size = new System.Drawing.Size(83, 21);
            this.RotationDegRadioButton.TabIndex = 9;
            this.RotationDegRadioButton.TabStop = true;
            this.RotationDegRadioButton.Text = "Degrees";
            this.RotationDegRadioButton.UseVisualStyleBackColor = true;
            this.RotationDegRadioButton.CheckedChanged += new System.EventHandler(this.RotationDegRadioButton_CheckedChanged);
            // 
            // RotationRadRadioButton
            // 
            this.RotationRadRadioButton.AutoSize = true;
            this.RotationRadRadioButton.Enabled = false;
            this.RotationRadRadioButton.Location = new System.Drawing.Point(729, 129);
            this.RotationRadRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.RotationRadRadioButton.Name = "RotationRadRadioButton";
            this.RotationRadRadioButton.Size = new System.Drawing.Size(81, 21);
            this.RotationRadRadioButton.TabIndex = 10;
            this.RotationRadRadioButton.Text = "Radians";
            this.RotationRadRadioButton.UseVisualStyleBackColor = true;
            this.RotationRadRadioButton.CheckedChanged += new System.EventHandler(this.RotationRadRadioButton_CheckedChanged);
            // 
            // CamZoomNumericUpDown
            // 
            this.CamZoomNumericUpDown.Enabled = false;
            this.CamZoomNumericUpDown.Location = new System.Drawing.Point(359, 161);
            this.CamZoomNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.CamZoomNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.CamZoomNumericUpDown.Name = "CamZoomNumericUpDown";
            this.CamZoomNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.CamZoomNumericUpDown.TabIndex = 11;
            this.CamZoomNumericUpDown.ValueChanged += new System.EventHandler(this.CamZoomumericUpDown_ValueChanged);
            // 
            // ZoomLabel
            // 
            this.ZoomLabel.AutoSize = true;
            this.ZoomLabel.Location = new System.Drawing.Point(301, 164);
            this.ZoomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ZoomLabel.Name = "ZoomLabel";
            this.ZoomLabel.Size = new System.Drawing.Size(48, 17);
            this.ZoomLabel.TabIndex = 12;
            this.ZoomLabel.Text = "Zoom:";
            // 
            // FOVLabel
            // 
            this.FOVLabel.AutoSize = true;
            this.FOVLabel.Location = new System.Drawing.Point(460, 164);
            this.FOVLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FOVLabel.Name = "FOVLabel";
            this.FOVLabel.Size = new System.Drawing.Size(94, 17);
            this.FOVLabel.TabIndex = 14;
            this.FOVLabel.Text = "Field Of View:";
            // 
            // CamFOVNumericUpDown
            // 
            this.CamFOVNumericUpDown.Enabled = false;
            this.CamFOVNumericUpDown.Location = new System.Drawing.Point(564, 161);
            this.CamFOVNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.CamFOVNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.CamFOVNumericUpDown.TabIndex = 13;
            this.CamFOVNumericUpDown.ValueChanged += new System.EventHandler(this.FOVNumericUpDown_ValueChanged);
            // 
            // CamIntLabel
            // 
            this.CamIntLabel.AutoSize = true;
            this.CamIntLabel.Location = new System.Drawing.Point(301, 196);
            this.CamIntLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CamIntLabel.Name = "CamIntLabel";
            this.CamIntLabel.Size = new System.Drawing.Size(120, 17);
            this.CamIntLabel.TabIndex = 16;
            this.CamIntLabel.Text = "Transition Speed:";
            // 
            // CamIntNumericUpDown
            // 
            this.CamIntNumericUpDown.Enabled = false;
            this.CamIntNumericUpDown.Location = new System.Drawing.Point(459, 193);
            this.CamIntNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.CamIntNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.CamIntNumericUpDown.Name = "CamIntNumericUpDown";
            this.CamIntNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.CamIntNumericUpDown.TabIndex = 15;
            this.CamIntNumericUpDown.ValueChanged += new System.EventHandler(this.CamIntnumericUpDown_ValueChanged);
            // 
            // CamEndIntLabel
            // 
            this.CamEndIntLabel.AutoSize = true;
            this.CamEndIntLabel.Location = new System.Drawing.Point(301, 228);
            this.CamEndIntLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CamEndIntLabel.Name = "CamEndIntLabel";
            this.CamEndIntLabel.Size = new System.Drawing.Size(149, 17);
            this.CamEndIntLabel.TabIndex = 18;
            this.CamEndIntLabel.Text = "End Transition Speed:";
            // 
            // CamEndIntNumericUpDown
            // 
            this.CamEndIntNumericUpDown.Enabled = false;
            this.CamEndIntNumericUpDown.Location = new System.Drawing.Point(459, 225);
            this.CamEndIntNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.CamEndIntNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.CamEndIntNumericUpDown.Name = "CamEndIntNumericUpDown";
            this.CamEndIntNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.CamEndIntNumericUpDown.TabIndex = 17;
            this.CamEndIntNumericUpDown.ValueChanged += new System.EventHandler(this.CamEndIntNumericUpDown_ValueChanged);
            // 
            // GndIntLabel
            // 
            this.GndIntLabel.AutoSize = true;
            this.GndIntLabel.Location = new System.Drawing.Point(301, 260);
            this.GndIntLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GndIntLabel.Name = "GndIntLabel";
            this.GndIntLabel.Size = new System.Drawing.Size(105, 17);
            this.GndIntLabel.TabIndex = 20;
            this.GndIntLabel.Text = "Ground Speed:";
            // 
            // GndIntNumericUpDown
            // 
            this.GndIntNumericUpDown.Enabled = false;
            this.GndIntNumericUpDown.Location = new System.Drawing.Point(459, 257);
            this.GndIntNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.GndIntNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.GndIntNumericUpDown.Name = "GndIntNumericUpDown";
            this.GndIntNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.GndIntNumericUpDown.TabIndex = 19;
            this.GndIntNumericUpDown.ValueChanged += new System.EventHandler(this.GndIntNumericUpDown_ValueChanged);
            // 
            // AllowDPadRotationCheckBox
            // 
            this.AllowDPadRotationCheckBox.AutoSize = true;
            this.AllowDPadRotationCheckBox.Enabled = false;
            this.AllowDPadRotationCheckBox.Location = new System.Drawing.Point(665, 162);
            this.AllowDPadRotationCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.AllowDPadRotationCheckBox.Name = "AllowDPadRotationCheckBox";
            this.AllowDPadRotationCheckBox.Size = new System.Drawing.Size(153, 21);
            this.AllowDPadRotationCheckBox.TabIndex = 21;
            this.AllowDPadRotationCheckBox.Text = "Allow DPad rotation";
            this.AllowDPadRotationCheckBox.UseVisualStyleBackColor = true;
            this.AllowDPadRotationCheckBox.CheckedChanged += new System.EventHandler(this.AllowDPadRotationCheckBox_CheckedChanged);
            // 
            // MaxYLabel
            // 
            this.MaxYLabel.AutoSize = true;
            this.MaxYLabel.Location = new System.Drawing.Point(560, 228);
            this.MaxYLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxYLabel.Name = "MaxYLabel";
            this.MaxYLabel.Size = new System.Drawing.Size(119, 17);
            this.MaxYLabel.TabIndex = 23;
            this.MaxYLabel.Text = "Max Y Movement:";
            // 
            // MaxYNumericUpDown
            // 
            this.MaxYNumericUpDown.Enabled = false;
            this.MaxYNumericUpDown.Location = new System.Drawing.Point(709, 225);
            this.MaxYNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.MaxYNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.MaxYNumericUpDown.Name = "MaxYNumericUpDown";
            this.MaxYNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.MaxYNumericUpDown.TabIndex = 22;
            this.MaxYNumericUpDown.ValueChanged += new System.EventHandler(this.MaxYNumericUpDown_ValueChanged);
            // 
            // MinYLabel
            // 
            this.MinYLabel.AutoSize = true;
            this.MinYLabel.Location = new System.Drawing.Point(560, 260);
            this.MinYLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MinYLabel.Name = "MinYLabel";
            this.MinYLabel.Size = new System.Drawing.Size(116, 17);
            this.MinYLabel.TabIndex = 25;
            this.MinYLabel.Text = "Min Y Movement:";
            // 
            // MinYNumericUpDown
            // 
            this.MinYNumericUpDown.Enabled = false;
            this.MinYNumericUpDown.Location = new System.Drawing.Point(709, 257);
            this.MinYNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.MinYNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.MinYNumericUpDown.Name = "MinYNumericUpDown";
            this.MinYNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.MinYNumericUpDown.TabIndex = 24;
            this.MinYNumericUpDown.ValueChanged += new System.EventHandler(this.MinYNumericUpDown_ValueChanged);
            // 
            // Num2CheckBox
            // 
            this.Num2CheckBox.AutoSize = true;
            this.Num2CheckBox.Enabled = false;
            this.Num2CheckBox.Location = new System.Drawing.Point(564, 194);
            this.Num2CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.Num2CheckBox.Name = "Num2CheckBox";
            this.Num2CheckBox.Size = new System.Drawing.Size(137, 21);
            this.Num2CheckBox.TabIndex = 26;
            this.Num2CheckBox.Text = "Unknown [Num2]";
            this.Num2CheckBox.UseVisualStyleBackColor = true;
            this.Num2CheckBox.CheckedChanged += new System.EventHandler(this.Num2CheckBox_CheckedChanged);
            // 
            // GroundMoveDelayLabel
            // 
            this.GroundMoveDelayLabel.AutoSize = true;
            this.GroundMoveDelayLabel.Location = new System.Drawing.Point(301, 292);
            this.GroundMoveDelayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GroundMoveDelayLabel.Name = "GroundMoveDelayLabel";
            this.GroundMoveDelayLabel.Size = new System.Drawing.Size(138, 17);
            this.GroundMoveDelayLabel.TabIndex = 28;
            this.GroundMoveDelayLabel.Text = "Ground Move Delay:";
            // 
            // GroundMoveDelayNumericUpDown
            // 
            this.GroundMoveDelayNumericUpDown.Enabled = false;
            this.GroundMoveDelayNumericUpDown.Location = new System.Drawing.Point(459, 289);
            this.GroundMoveDelayNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.GroundMoveDelayNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.GroundMoveDelayNumericUpDown.Name = "GroundMoveDelayNumericUpDown";
            this.GroundMoveDelayNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.GroundMoveDelayNumericUpDown.TabIndex = 27;
            this.GroundMoveDelayNumericUpDown.ValueChanged += new System.EventHandler(this.GroundMoveDelayNumericUpDown_ValueChanged);
            // 
            // AirDelayLabel
            // 
            this.AirDelayLabel.AutoSize = true;
            this.AirDelayLabel.Location = new System.Drawing.Point(560, 292);
            this.AirDelayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AirDelayLabel.Name = "AirDelayLabel";
            this.AirDelayLabel.Size = new System.Drawing.Size(107, 17);
            this.AirDelayLabel.TabIndex = 30;
            this.AirDelayLabel.Text = "Air Move Delay:";
            // 
            // AirMoveDelayNumericUpDown
            // 
            this.AirMoveDelayNumericUpDown.Enabled = false;
            this.AirMoveDelayNumericUpDown.Location = new System.Drawing.Point(709, 289);
            this.AirMoveDelayNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.AirMoveDelayNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.AirMoveDelayNumericUpDown.Name = "AirMoveDelayNumericUpDown";
            this.AirMoveDelayNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.AirMoveDelayNumericUpDown.TabIndex = 29;
            this.AirMoveDelayNumericUpDown.ValueChanged += new System.EventHandler(this.AirMoveDelayNumericUpDown_ValueChanged);
            // 
            // LOffsetVLabel
            // 
            this.LOffsetVLabel.AutoSize = true;
            this.LOffsetVLabel.Location = new System.Drawing.Point(560, 324);
            this.LOffsetVLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LOffsetVLabel.Name = "LOffsetVLabel";
            this.LOffsetVLabel.Size = new System.Drawing.Size(137, 17);
            this.LOffsetVLabel.TabIndex = 34;
            this.LOffsetVLabel.Text = "Unknown [LOffsetV]:";
            // 
            // LOffsetVNumericUpDown
            // 
            this.LOffsetVNumericUpDown.Enabled = false;
            this.LOffsetVNumericUpDown.Location = new System.Drawing.Point(709, 321);
            this.LOffsetVNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.LOffsetVNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.LOffsetVNumericUpDown.Name = "LOffsetVNumericUpDown";
            this.LOffsetVNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.LOffsetVNumericUpDown.TabIndex = 33;
            this.LOffsetVNumericUpDown.ValueChanged += new System.EventHandler(this.LOffsetVNumericUpDown_ValueChanged);
            // 
            // LOffsetLabel
            // 
            this.LOffsetLabel.AutoSize = true;
            this.LOffsetLabel.Location = new System.Drawing.Point(301, 324);
            this.LOffsetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LOffsetLabel.Name = "LOffsetLabel";
            this.LOffsetLabel.Size = new System.Drawing.Size(128, 17);
            this.LOffsetLabel.TabIndex = 32;
            this.LOffsetLabel.Text = "Unknown [LOffset]:";
            // 
            // LOffsetNumericUpDown
            // 
            this.LOffsetNumericUpDown.Enabled = false;
            this.LOffsetNumericUpDown.Location = new System.Drawing.Point(459, 321);
            this.LOffsetNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.LOffsetNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.LOffsetNumericUpDown.Name = "LOffsetNumericUpDown";
            this.LOffsetNumericUpDown.Size = new System.Drawing.Size(93, 22);
            this.LOffsetNumericUpDown.TabIndex = 31;
            this.LOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.LOffsetNumericUpDown_ValueChanged);
            // 
            // LowerLabel
            // 
            this.LowerLabel.AutoSize = true;
            this.LowerLabel.Location = new System.Drawing.Point(471, 356);
            this.LowerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LowerLabel.Name = "LowerLabel";
            this.LowerLabel.Size = new System.Drawing.Size(97, 17);
            this.LowerLabel.TabIndex = 38;
            this.LowerLabel.Text = "Lower Border:";
            // 
            // UpperLabel
            // 
            this.UpperLabel.AutoSize = true;
            this.UpperLabel.Location = new System.Drawing.Point(301, 356);
            this.UpperLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpperLabel.Name = "UpperLabel";
            this.UpperLabel.Size = new System.Drawing.Size(98, 17);
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
            this.UpperNumericUpDown.Location = new System.Drawing.Point(407, 353);
            this.UpperNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.UpperNumericUpDown.Size = new System.Drawing.Size(56, 22);
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
            this.LowerNumericUpDown.Location = new System.Drawing.Point(576, 353);
            this.LowerNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.LowerNumericUpDown.Size = new System.Drawing.Size(56, 22);
            this.LowerNumericUpDown.TabIndex = 39;
            this.LowerNumericUpDown.ValueChanged += new System.EventHandler(this.LowerNumericUpDown_ValueChanged);
            // 
            // UDownNumericUpDown
            // 
            this.UDownNumericUpDown.Enabled = false;
            this.UDownNumericUpDown.Location = new System.Drawing.Point(717, 353);
            this.UDownNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.UDownNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.UDownNumericUpDown.Name = "UDownNumericUpDown";
            this.UDownNumericUpDown.Size = new System.Drawing.Size(85, 22);
            this.UDownNumericUpDown.TabIndex = 41;
            this.UDownNumericUpDown.ValueChanged += new System.EventHandler(this.UDownNumericUpDown_ValueChanged);
            // 
            // UDownLabel
            // 
            this.UDownLabel.AutoSize = true;
            this.UDownLabel.Location = new System.Drawing.Point(640, 356);
            this.UDownLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UDownLabel.Name = "UDownLabel";
            this.UDownLabel.Size = new System.Drawing.Size(65, 17);
            this.UDownLabel.TabIndex = 40;
            this.UDownLabel.Text = "[UDown]:";
            // 
            // CoordinateGroupBox
            // 
            this.CoordinateGroupBox.Controls.Add(this.ZNumericUpDown);
            this.CoordinateGroupBox.Controls.Add(this.YNumericUpDown);
            this.CoordinateGroupBox.Controls.Add(this.XNumericUpDown);
            this.CoordinateGroupBox.Controls.Add(this.CoordinateComboBox);
            this.CoordinateGroupBox.Location = new System.Drawing.Point(300, 385);
            this.CoordinateGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.CoordinateGroupBox.Name = "CoordinateGroupBox";
            this.CoordinateGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.CoordinateGroupBox.Size = new System.Drawing.Size(152, 149);
            this.CoordinateGroupBox.TabIndex = 42;
            this.CoordinateGroupBox.TabStop = false;
            this.CoordinateGroupBox.Text = "Coordinates";
            // 
            // ZNumericUpDown
            // 
            this.ZNumericUpDown.DecimalPlaces = 7;
            this.ZNumericUpDown.Enabled = false;
            this.ZNumericUpDown.Location = new System.Drawing.Point(8, 117);
            this.ZNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.ZNumericUpDown.Size = new System.Drawing.Size(136, 22);
            this.ZNumericUpDown.TabIndex = 45;
            this.ZNumericUpDown.ValueChanged += new System.EventHandler(this.ZNumericUpDown_ValueChanged);
            // 
            // YNumericUpDown
            // 
            this.YNumericUpDown.DecimalPlaces = 7;
            this.YNumericUpDown.Enabled = false;
            this.YNumericUpDown.Location = new System.Drawing.Point(8, 85);
            this.YNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.YNumericUpDown.Size = new System.Drawing.Size(136, 22);
            this.YNumericUpDown.TabIndex = 44;
            this.YNumericUpDown.ValueChanged += new System.EventHandler(this.YNumericUpDown_ValueChanged);
            // 
            // XNumericUpDown
            // 
            this.XNumericUpDown.DecimalPlaces = 7;
            this.XNumericUpDown.Enabled = false;
            this.XNumericUpDown.Location = new System.Drawing.Point(8, 53);
            this.XNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.XNumericUpDown.Size = new System.Drawing.Size(136, 22);
            this.XNumericUpDown.TabIndex = 43;
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
            "VPan Axis"});
            this.CoordinateComboBox.Location = new System.Drawing.Point(8, 20);
            this.CoordinateComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.CoordinateComboBox.Name = "CoordinateComboBox";
            this.CoordinateComboBox.Size = new System.Drawing.Size(135, 24);
            this.CoordinateComboBox.TabIndex = 43;
            this.CoordinateComboBox.SelectedIndexChanged += new System.EventHandler(this.CoordinateComboBox_SelectedIndexChanged);
            // 
            // DisableResetCheckBox
            // 
            this.DisableResetCheckBox.AutoSize = true;
            this.DisableResetCheckBox.Enabled = false;
            this.DisableResetCheckBox.Location = new System.Drawing.Point(460, 417);
            this.DisableResetCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.DisableResetCheckBox.Name = "DisableResetCheckBox";
            this.DisableResetCheckBox.Size = new System.Drawing.Size(118, 21);
            this.DisableResetCheckBox.TabIndex = 43;
            this.DisableResetCheckBox.Text = "Disable Reset";
            this.DisableResetCheckBox.UseVisualStyleBackColor = true;
            this.DisableResetCheckBox.CheckedChanged += new System.EventHandler(this.DisableResetCheckBox_CheckedChanged);
            // 
            // EventFrameLabel
            // 
            this.EventFrameLabel.AutoSize = true;
            this.EventFrameLabel.Location = new System.Drawing.Point(460, 388);
            this.EventFrameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EventFrameLabel.Name = "EventFrameLabel";
            this.EventFrameLabel.Size = new System.Drawing.Size(96, 17);
            this.EventFrameLabel.TabIndex = 45;
            this.EventFrameLabel.Text = "Event Length:";
            // 
            // EventLengthNumericUpDown
            // 
            this.EventLengthNumericUpDown.Enabled = false;
            this.EventLengthNumericUpDown.Location = new System.Drawing.Point(567, 385);
            this.EventLengthNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.EventLengthNumericUpDown.Size = new System.Drawing.Size(92, 22);
            this.EventLengthNumericUpDown.TabIndex = 44;
            this.EventLengthNumericUpDown.ValueChanged += new System.EventHandler(this.EventLengthNumericUpDown_ValueChanged);
            // 
            // EventPriorityLabel
            // 
            this.EventPriorityLabel.AutoSize = true;
            this.EventPriorityLabel.Location = new System.Drawing.Point(667, 388);
            this.EventPriorityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EventPriorityLabel.Name = "EventPriorityLabel";
            this.EventPriorityLabel.Size = new System.Drawing.Size(96, 17);
            this.EventPriorityLabel.TabIndex = 47;
            this.EventPriorityLabel.Text = "Event Priority:";
            // 
            // EventPriorityNumericUpDown
            // 
            this.EventPriorityNumericUpDown.Enabled = false;
            this.EventPriorityNumericUpDown.Location = new System.Drawing.Point(771, 385);
            this.EventPriorityNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.EventPriorityNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.EventPriorityNumericUpDown.Name = "EventPriorityNumericUpDown";
            this.EventPriorityNumericUpDown.Size = new System.Drawing.Size(45, 22);
            this.EventPriorityNumericUpDown.TabIndex = 46;
            this.EventPriorityNumericUpDown.ValueChanged += new System.EventHandler(this.EventPriorityNumericUpDown_ValueChanged);
            // 
            // LOffsetRPOffCheckBox
            // 
            this.LOffsetRPOffCheckBox.AutoSize = true;
            this.LOffsetRPOffCheckBox.Enabled = false;
            this.LOffsetRPOffCheckBox.Location = new System.Drawing.Point(591, 417);
            this.LOffsetRPOffCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.LOffsetRPOffCheckBox.Name = "LOffsetRPOffCheckBox";
            this.LOffsetRPOffCheckBox.Size = new System.Drawing.Size(184, 21);
            this.LOffsetRPOffCheckBox.TabIndex = 48;
            this.LOffsetRPOffCheckBox.Text = "Unknown [LOffsetRPOff]";
            this.LOffsetRPOffCheckBox.UseVisualStyleBackColor = true;
            this.LOffsetRPOffCheckBox.CheckedChanged += new System.EventHandler(this.LOffsetRPOffCheckBox_CheckedChanged);
            // 
            // EnableBlurCheckbox
            // 
            this.EnableBlurCheckbox.AutoSize = true;
            this.EnableBlurCheckbox.Enabled = false;
            this.EnableBlurCheckbox.Location = new System.Drawing.Point(460, 446);
            this.EnableBlurCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.EnableBlurCheckbox.Name = "EnableBlurCheckbox";
            this.EnableBlurCheckbox.Size = new System.Drawing.Size(103, 21);
            this.EnableBlurCheckbox.TabIndex = 49;
            this.EnableBlurCheckbox.Text = "Enable Blur";
            this.EnableBlurCheckbox.UseVisualStyleBackColor = true;
            this.EnableBlurCheckbox.CheckedChanged += new System.EventHandler(this.EnableBlurCheckbox_CheckedChanged);
            // 
            // NoCollisionCheckBox
            // 
            this.NoCollisionCheckBox.AutoSize = true;
            this.NoCollisionCheckBox.Enabled = false;
            this.NoCollisionCheckBox.Location = new System.Drawing.Point(575, 446);
            this.NoCollisionCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.NoCollisionCheckBox.Name = "NoCollisionCheckBox";
            this.NoCollisionCheckBox.Size = new System.Drawing.Size(107, 21);
            this.NoCollisionCheckBox.TabIndex = 50;
            this.NoCollisionCheckBox.Text = "Collisionless";
            this.NoCollisionCheckBox.UseVisualStyleBackColor = true;
            this.NoCollisionCheckBox.CheckedChanged += new System.EventHandler(this.NoCollisionCheckBox_CheckedChanged);
            // 
            // NoPOVCheckBox
            // 
            this.NoPOVCheckBox.AutoSize = true;
            this.NoPOVCheckBox.Enabled = false;
            this.NoPOVCheckBox.Location = new System.Drawing.Point(692, 446);
            this.NoPOVCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.NoPOVCheckBox.Name = "NoPOVCheckBox";
            this.NoPOVCheckBox.Size = new System.Drawing.Size(128, 21);
            this.NoPOVCheckBox.TabIndex = 51;
            this.NoPOVCheckBox.Text = "No PointOfView";
            this.NoPOVCheckBox.UseVisualStyleBackColor = true;
            this.NoPOVCheckBox.CheckedChanged += new System.EventHandler(this.NoPOVCheckBox_CheckedChanged);
            // 
            // GEndTransCheckBox
            // 
            this.GEndTransCheckBox.AutoSize = true;
            this.GEndTransCheckBox.Enabled = false;
            this.GEndTransCheckBox.Location = new System.Drawing.Point(692, 503);
            this.GEndTransCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.GEndTransCheckBox.Name = "GEndTransCheckBox";
            this.GEndTransCheckBox.Size = new System.Drawing.Size(98, 21);
            this.GEndTransCheckBox.TabIndex = 54;
            this.GEndTransCheckBox.Text = "CamEndInt";
            this.GEndTransCheckBox.UseVisualStyleBackColor = true;
            this.GEndTransCheckBox.CheckedChanged += new System.EventHandler(this.GEndTransCheckBox_CheckedChanged);
            // 
            // GThruCheckBox
            // 
            this.GThruCheckBox.AutoSize = true;
            this.GThruCheckBox.Enabled = false;
            this.GThruCheckBox.Location = new System.Drawing.Point(605, 502);
            this.GThruCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.GThruCheckBox.Name = "GThruCheckBox";
            this.GThruCheckBox.Size = new System.Drawing.Size(60, 21);
            this.GThruCheckBox.TabIndex = 53;
            this.GThruCheckBox.Text = "Thru";
            this.GThruCheckBox.UseVisualStyleBackColor = true;
            this.GThruCheckBox.CheckedChanged += new System.EventHandler(this.GThruCheckBox_CheckedChanged);
            // 
            // GEndErpFrameCheckBox
            // 
            this.GEndErpFrameCheckBox.AutoSize = true;
            this.GEndErpFrameCheckBox.Enabled = false;
            this.GEndErpFrameCheckBox.Location = new System.Drawing.Point(460, 502);
            this.GEndErpFrameCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.GEndErpFrameCheckBox.Name = "GEndErpFrameCheckBox";
            this.GEndErpFrameCheckBox.Size = new System.Drawing.Size(117, 21);
            this.GEndErpFrameCheckBox.TabIndex = 52;
            this.GEndErpFrameCheckBox.Text = "EndErpFrame";
            this.GEndErpFrameCheckBox.UseVisualStyleBackColor = true;
            this.GEndErpFrameCheckBox.CheckedChanged += new System.EventHandler(this.GEndErpFrameCheckBox_CheckedChanged);
            // 
            // EventTransCheckBox
            // 
            this.EventTransCheckBox.AutoSize = true;
            this.EventTransCheckBox.Enabled = false;
            this.EventTransCheckBox.Location = new System.Drawing.Point(700, 474);
            this.EventTransCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.EventTransCheckBox.Name = "EventTransCheckBox";
            this.EventTransCheckBox.Size = new System.Drawing.Size(96, 21);
            this.EventTransCheckBox.TabIndex = 57;
            this.EventTransCheckBox.Text = "Use Trans";
            this.EventTransCheckBox.UseVisualStyleBackColor = true;
            this.EventTransCheckBox.CheckedChanged += new System.EventHandler(this.EventTransCheckBox_CheckedChanged);
            // 
            // EventEndTransCheckBox
            // 
            this.EventEndTransCheckBox.AutoSize = true;
            this.EventEndTransCheckBox.Enabled = false;
            this.EventEndTransCheckBox.Location = new System.Drawing.Point(563, 474);
            this.EventEndTransCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.EventEndTransCheckBox.Name = "EventEndTransCheckBox";
            this.EventEndTransCheckBox.Size = new System.Drawing.Size(125, 21);
            this.EventEndTransCheckBox.TabIndex = 56;
            this.EventEndTransCheckBox.Text = "Use End Trans";
            this.EventEndTransCheckBox.UseVisualStyleBackColor = true;
            this.EventEndTransCheckBox.CheckedChanged += new System.EventHandler(this.EventEndTransCheckBox_CheckedChanged);
            // 
            // VPanCheckBox
            // 
            this.VPanCheckBox.AutoSize = true;
            this.VPanCheckBox.Enabled = false;
            this.VPanCheckBox.Location = new System.Drawing.Point(460, 474);
            this.VPanCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.VPanCheckBox.Name = "VPanCheckBox";
            this.VPanCheckBox.Size = new System.Drawing.Size(89, 21);
            this.VPanCheckBox.TabIndex = 55;
            this.VPanCheckBox.Text = "VPanUse";
            this.VPanCheckBox.UseVisualStyleBackColor = true;
            this.VPanCheckBox.CheckedChanged += new System.EventHandler(this.VPanCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 543);
            this.Controls.Add(this.EventTransCheckBox);
            this.Controls.Add(this.EventEndTransCheckBox);
            this.Controls.Add(this.VPanCheckBox);
            this.Controls.Add(this.GEndTransCheckBox);
            this.Controls.Add(this.GThruCheckBox);
            this.Controls.Add(this.GEndErpFrameCheckBox);
            this.Controls.Add(this.NoPOVCheckBox);
            this.Controls.Add(this.NoCollisionCheckBox);
            this.Controls.Add(this.EnableBlurCheckbox);
            this.Controls.Add(this.LOffsetRPOffCheckBox);
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
            this.Controls.Add(this.LOffsetVLabel);
            this.Controls.Add(this.LOffsetVNumericUpDown);
            this.Controls.Add(this.LOffsetLabel);
            this.Controls.Add(this.LOffsetNumericUpDown);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Launch Cam Plus";
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
            ((System.ComponentModel.ISupportInitialize)(this.LOffsetVNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOffsetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpperNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDownNumericUpDown)).EndInit();
            this.CoordinateGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventLengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventPriorityNumericUpDown)).EndInit();
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
        private System.Windows.Forms.Label LOffsetVLabel;
        private System.Windows.Forms.NumericUpDown LOffsetVNumericUpDown;
        private System.Windows.Forms.Label LOffsetLabel;
        private System.Windows.Forms.NumericUpDown LOffsetNumericUpDown;
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
        private System.Windows.Forms.CheckBox LOffsetRPOffCheckBox;
        private System.Windows.Forms.CheckBox EnableBlurCheckbox;
        private System.Windows.Forms.CheckBox NoCollisionCheckBox;
        private System.Windows.Forms.CheckBox NoPOVCheckBox;
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
    }
}

