using Hack.io.CANM;
using Hack.io.RARC;
using Hack.io.Utility;
using Hack.io.YAZ0;
using LaunchCamPlus.CameraPanels;
using LaunchCamPlus.ExtraControls;
using LaunchCamPlus.Formats;
using LaunchCamPlus.Properties;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using static LaunchCamPlus.Formats.BCAMUtility;

namespace LaunchCamPlus;

public partial class CameraEditorForm : Form, IReloadTheme
{
    private const string DEFAULT_EDITOR_KEY = "DEFAULT";
    private const string FILTER_OPEN = "Supported Files|*.bcam;*.arc;*.rarc;*.canm|Camera Files|*.bcam|Level Archive|*.rarc;*.arc|Keyframed Cameras|*.canm";
    private const string FILTER_BCAM = "Supported Files|*.bcam;*.arc;*.rarc|Camera Files|*.bcam|Level Archive|*.rarc;*.arc";
    private const string FILTER_CANM = "Supported Files|*.canm|Keyframed Cameras|*.canm";
    private readonly OpenFileDialog ofd = new() { Filter = FILTER_OPEN };
    private readonly SaveFileDialog sfd = new() { Filter = FILTER_BCAM };
    [AllowNull]
    private string Filename { get; set; }
    [AllowNull]
    public BCAM Cameras { get; set; }
    [AllowNull]
    private CANM KeyframeCamera { get; set; }
    private bool DisableEditorChange;

    private readonly SettingsPanel PreBufferedSettings;
    private readonly IdentificationAssistant PreBufferedAssistant;
    private readonly AboutPanel PreBufferedAbout;
    private readonly PresetSelectorPanel PreBufferedPresets;
    private readonly PresetCreatorPanel PreBufferedCreator;
    private readonly CANMEditPanel PreBufferedCANM;
    private readonly Dictionary<string, CameraPanelBase> PreBufferedPanels;

    private Control? CurrentPanel => MainSplitContainer.Panel2.Controls.Count > 0 ? MainSplitContainer.Panel2.Controls[0] : null;

    public CameraEditorForm(string[] args)
    {
        InitializeComponent();
        CenterToScreen();
        Text = Application.ProductName + " - " + Application.ProductVersion;
        CameraListBox.SetDoubleBuffered();
        MainSplitContainer.Panel1.SetDoubleBuffered();
        MainSplitContainer.Panel2.SetDoubleBuffered();

        PreBufferedSettings = new() { Dock = DockStyle.Fill };
        PreBufferedAbout = new() { Dock = DockStyle.Fill };
        PreBufferedPresets = new() { Dock = DockStyle.Fill };
        PreBufferedCreator = new() { Dock = DockStyle.Fill };
        PreBufferedCANM = new() { Dock = DockStyle.Fill, LengthChanger = UpdateTime };
        PreBufferedCANM.DataListBox.KeyDown += CameraListBox_KeyDown;
        PreBufferedAssistant = new() { Dock = DockStyle.Bottom };
        IdentificationAssistantToolStripMenuItem.Click += Program.Settings.OnChanged;
        PreBufferedAssistant.ApplyButton.Click += ApplyButton_Click;
        PreBufferedPanels = new()
            {
                { DEFAULT_EDITOR_KEY, new DefaultCameraPanel() { Dock = DockStyle.Fill } },
                //{ "CAM_TYPE_EYEPOS_FIX_THERE", new EyeposFixThereCameraPanel() { Dock = DockStyle.Fill } },
                //{ "CAM_TYPE_POINT_FIX", new PointFixCameraPanel() { Dock = DockStyle.Fill } },
                //{ "CAM_TYPE_RAIL_FOLLOW", new RailFollowCameraPanel() { Dock = DockStyle.Fill } },
                { "CAM_TYPE_XZ_PARA", new XZParaCameraPanel() { Dock = DockStyle.Fill } },
                { "CAM_TYPE_TOWER", new TowerCameraPanel() { Dock = DockStyle.Fill } },
                { "CAM_TYPE_FOLLOW", new FollowCameraPanel() { Dock = DockStyle.Fill } },
                { "CAM_TYPE_WONDER_PLANET", new WonderPlanetCameraPanel() { Dock = DockStyle.Fill } },
            };

        if (args.Length > 0)
        {
            Console.WriteLine("Argument recieved!");
            Console.WriteLine(Program.ConsoleHalfSplitter);
            Open(args[0]);
            Console.WriteLine(Program.ConsoleHalfSplitter);
        }
        if (Program.Settings.IsShowAboutOnBoot || Program.ShowNeedsUpdate)
            AboutToolStripMenuItem_Click(this, EventArgs.Empty);

        if (Program.Settings.IsIdentificationAssistOpen)
            IdentificationAssistantToolStripMenuItem_Click(null, EventArgs.Empty);
        else
            Console.WriteLine("ID Assist: Off");

        UpdateControlState(this, true);
    }

    public void Open(string file)
    {
        if (Program.IsGameFileLittleEndian)
            StreamUtil.SetEndianLittle();
        else
            StreamUtil.SetEndianBig();

        CameraListBox.SelectedIndex = -1;
        Filename = file;

        FileInfo FI = new(file);
        if (File.Exists(Filename) && FI.IsFileLocked())
        {
            Console.WriteLine("The chosen file cannot be accessed. The file has not been modified, and your changes have not been saved.");
            return;
        }

        if (FI.Extension.Equals(".canm"))
        {
            OpenCANM();
            UpdateControlState(this, true);
            return;
        }
        OpenBCAM();
        UpdateControlState(this, true);

        void OpenBCAM()
        {
            KeyframeCamera = null;
            switch (FI.Extension)
            {
                case ".bcam":
                    Console.WriteLine("Loading as a Binary Camera file:");
                    Cameras = new();
                    FileUtil.LoadFile(Filename, Cameras.Load);
                    Console.WriteLine("Load Complete!");
                    break;
                case ".arc":
                case ".rarc":
                    Console.WriteLine("Loading as an Archive:");
                    List<(Func<Stream, bool> CheckFunc, Func<byte[], byte[]> DecodeFunction)> DecompFuncs =
                    [
                        (YAZ0.Check, YAZ0.Decompress)
                    ];
                    RARC Archive = new();
                    int encodingselection = FileUtil.LoadFileWithDecompression(Filename, Archive.Load, [.. DecompFuncs]);
                    if (encodingselection == -1)
                        FileUtil.LoadFile(Filename, Archive.Load);
                    if (Archive.Root is null)
                    {
                        Console.WriteLine("Load Failed! Could not decompress or load the archive!");
                        return;
                    }
                    Console.WriteLine("Archive Loaded. Looking for the .bcam...");
                    string? CameraParamPath = Archive.GetItemKeyFromNoCase("Camera/CameraParam.bcam");
                    if (CameraParamPath == null)
                    {
                        CameraParamPath = Archive.GetItemKeyFromNoCase("ActorInfo/CameraParam.bcam");
                        if (CameraParamPath == null)
                        {
                            Console.WriteLine("Load Failed! No BCAM was found inside the archive!\n(Maybe it was in the wrong place?)");
                            return;
                        }
                    }
                    Console.WriteLine(".bcam found.");
                    object? c = Archive[CameraParamPath]; //It shouldn't be possible for this to be null right now
                    if (c is null)
                    {
                        Console.WriteLine("YOU SHOULD NOT SEE THIS MESSAGE");
                        return;
                    }
                    RARC.File cc = (RARC.File)c;
                    Cameras = new();
                    Cameras.Load((MemoryStream)cc);
                    Console.WriteLine("Load Complete!");
                    break;
            }
            Console.WriteLine();

            Console.WriteLine("Writing the Camera List:");

            CameraListBox.Enabled = false;
            CameraListBox.Items.Clear();
            for (int i = 0; i < Cameras.EntryCount; i++)
            {
                CameraListBox.Items.Add(Cameras[i].GetTranslatedName());
                Console.Write($"\r{Math.Min((int)((i + 1) / (float)CameraListBox.Items.Count * 100), 100)}%          ");
            }
            Console.WriteLine("Complete");

            CancelPreset(null);
            if (Cameras.EntryCount > 0)
                CameraListBox.SelectedIndex = 0;
            CameraListBox.Enabled = true;
            SaveToolStripMenuItem.Enabled = true;
            SaveAsToolStripMenuItem.Enabled = true;
            ExportPresetToolStripMenuItem.Enabled = true;
            Program.IsUnsavedChanges = false;
        }
        void OpenCANM()
        {
            Console.WriteLine("Loading as a CANM file:");
            Cameras = null;
            KeyframeCamera = new();
            FileUtil.LoadFile(Filename, KeyframeCamera.Load);
            Console.WriteLine("Load Complete!");

            CameraListBox.Enabled = false;
            InitCanmListBox();
            CancelPreset(null);
            UpdateControlState(this, true);
            CameraListBox.SelectedIndex = 0;
            CameraListBox.Enabled = true;
            SaveToolStripMenuItem.Enabled = true;
            SaveAsToolStripMenuItem.Enabled = true;
            ExportPresetToolStripMenuItem.Enabled = false;
            Program.IsUnsavedChanges = false;
        }
    }

    private void Save()
    {
        if (Program.IsGameFileLittleEndian)
            StreamUtil.SetEndianLittle();
        else
            StreamUtil.SetEndianBig();

        Console.WriteLine();
        FileInfo fi = new(Filename);
        if (File.Exists(Filename) && fi.IsFileLocked())
        {
            Console.WriteLine("The chosen file cannot be accessed. The file has not been modified, and your changes have not been saved.");
            return;
        }

        if (CurrentPanel is not null and ICameraPanel ICP)
        {
            ICP.UnloadCamera();
        }

        if (KeyframeCamera is not null)
        {
            Console.WriteLine("Saving as a Camera Animation:");
            FileUtil.SaveFile(Filename, KeyframeCamera.Save);
            Console.WriteLine("Save Complete!");
            Console.WriteLine("Current time of Save: " + DateTime.Now.ToString("h:mm tt"));
            Program.IsUnsavedChanges = false;
            Console.WriteLine();
            return;
        }

        if (Program.Settings.IsUseOnboardCompression)
            AdvancedSave();
        else
            Cameras.Optimize(BCAM.PreferredHashOrder); //""""Optimize"""" we're really just putting all the hashes in fresh

        BaseSave();

        switch (fi.Extension)
        {
            case ".bcam":
                Console.WriteLine("Saving as a Binary Camera file:");
                FileUtil.SaveFile(Filename, Cameras.Save);
                break;
            case ".arc":
            case ".rarc":
                if (!File.Exists(Filename))
                {
                    MessageBox.Show("The output archive does not exist. Your changes have not been saved.\n(LCP cannot create new archives for this purpose)");
                    return;
                }
                Console.WriteLine("Loading the target Archive:");
                List<(Func<Stream, bool> CheckFunc, Func<byte[], byte[]> DecodeFunction)> DecompFuncs =
                    [
                        (YAZ0.Check, YAZ0.Decompress)
                    ];
                RARC Archive = new();
                if (FileUtil.LoadFileWithDecompression(Filename, Archive.Load, [.. DecompFuncs]) == -1)
                    FileUtil.LoadFile(Filename, Archive.Load);
                Console.WriteLine("Archive Loaded. Looking for the .bcam to replace...");

                string? FinalPath = new string?[] { Archive.GetItemKeyFromNoCase("Camera/CameraParam.bcam"), Archive.GetItemKeyFromNoCase("ActorInfo/CameraParam.bcam") }.FirstOrDefault(s => !string.IsNullOrEmpty(s));
                if (FinalPath is null)
                {
                    Console.WriteLine("Error finding a bcam");
                    DialogResult dr = MessageBox.Show("The archive has no .bcam to replace.\nWould you like to create one?", "Missing .bcam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    Console.WriteLine($"MessageBox Response: {dr}");
                    if (dr != DialogResult.Yes)
                    {
                        Console.WriteLine("The chosen file has not been modified, and your changes have not been saved.");
                        return;
                    }
                    FinalPath = "Camera/CameraParam.bcam";
                    Console.WriteLine("Injecting...");
                }
                else
                    Console.WriteLine(".bcam found. Saving...");

                MemoryStream ms = new();
                Cameras.Save(ms);
                RARC.File Dest = new();
                Dest.Load(ms);

                Archive[FinalPath] = Dest;

                Console.WriteLine(".bcam saved into the archive.");
                Console.WriteLine("Saving the archive...");
                FileUtil.SaveFile(Filename, Archive.Save);
                if (Program.Settings.IsUseYaz0)
                {
                    Yaz0BackgroundWorker.RunWorkerAsync(Filename);

                    UpdateControlState(this, false);
                    while (Yaz0BackgroundWorker.IsBusy)
                        Application.DoEvents();
                    Console.WriteLine("\nYaz0 Encoding Complete!");
                    UpdateControlState(this, true);
                }
                break;
        }
        Console.WriteLine("Save Complete!");
        Console.WriteLine("Current time of Save: " + DateTime.Now.ToString("h:mm tt"));
        Program.IsUnsavedChanges = false;
        Console.WriteLine();

        void AdvancedSave()
        {
            //For each camera in the list, test to see if the field can be removed from the BCSV
            List<uint> KeptHashes = [];
            for (int i = 0; i < Cameras.EntryCount; i++)
            {
                Cameras[i].OptimizeForCamType();
                uint[] k = Cameras[i].ContainedHashes;
                for (int x = 0; x < k.Length; x++)
                {
                    if (!KeptHashes.Contains(k[x]))
                        KeptHashes.Add(k[x]);
                }
            }

            KeptHashes = KeptHashes.SortBy(BCAM.PreferredHashOrder);
            Cameras.Optimize(KeptHashes);
            Console.WriteLine($"Advanced calculations retained {KeptHashes.Count} of {BCAM.PreferredHashOrder.Length} fields.");
        }

        void BaseSave()
        {
            //For each camera entry, add the default value if no value is present
            for (int i = 0; i < Cameras.EntryCount; i++)
            {
                BCAM.Entry CurrentEntry = Cameras[i];
                for (int h = 0; h < BCAM.PreferredHashOrder.Length; h++)
                {
                    uint hash = BCAM.PreferredHashOrder[h];
                    if (!Cameras.ContainsField(hash))
                    {
                        if (CurrentEntry.Contains(hash))
                            CurrentEntry.Remove(hash);
                    }
                    else
                    {
                        object? obj = CurrentEntry.GetDataOrCamTypeDefault(hash);
                        if (obj is not null)
                            CurrentEntry.TryAdd(hash, obj);
                    }

                }
            }
        }
    }

    public void ReloadTheme()
    {
        EditorMenuStrip.Renderer = Program.Settings.IsDarkMode ? new MyRenderer() : default;
        for (int i = 0; i < FileToolStripMenuItem.DropDownItems.Count; i++)
        {
            FileToolStripMenuItem.DropDownItems[i].BackColor = ProgramColours.WindowColour;
            FileToolStripMenuItem.DropDownItems[i].ForeColor = ProgramColours.TextColour;
        }
        for (int i = 0; i < EditToolStripMenuItem.DropDownItems.Count; i++)
        {
            EditToolStripMenuItem.DropDownItems[i].BackColor = ProgramColours.WindowColour;
            EditToolStripMenuItem.DropDownItems[i].ForeColor = ProgramColours.TextColour;
        }
        for (int i = 0; i < AddCameraToolStripMenuItem.DropDownItems.Count; i++)
        {
            AddCameraToolStripMenuItem.DropDownItems[i].BackColor = ProgramColours.WindowColour;
            AddCameraToolStripMenuItem.DropDownItems[i].ForeColor = ProgramColours.TextColour;
        }
        for (int i = 0; i < ToolsToolStripMenuItem.DropDownItems.Count; i++)
        {
            ToolsToolStripMenuItem.DropDownItems[i].BackColor = ProgramColours.WindowColour;
            ToolsToolStripMenuItem.DropDownItems[i].ForeColor = ProgramColours.TextColour;
        }
        for (int i = 0; i < HelpToolStripMenuItem.DropDownItems.Count; i++)
        {
            HelpToolStripMenuItem.DropDownItems[i].BackColor = ProgramColours.WindowColour;
            HelpToolStripMenuItem.DropDownItems[i].ForeColor = ProgramColours.TextColour;
        }
        EditorMenuStrip.BackColor =
            EditToolStripMenuItem.BackColor =
            ToolsToolStripMenuItem.BackColor =
            HelpToolStripMenuItem.BackColor =
            MainSplitContainer.Panel1.BackColor =
            MainSplitContainer.Panel2.BackColor =
            BackColor = ProgramColours.ControlBackColor;

        CameraListBox.BackColor = ProgramColours.WindowColour;
        FileToolStripMenuItem.ForeColor =
            EditToolStripMenuItem.ForeColor =
            ToolsToolStripMenuItem.ForeColor =
            HelpToolStripMenuItem.ForeColor =
            CameraListBox.ForeColor = ProgramColours.TextColour;

        PreBufferedSettings.ReloadTheme();
        PreBufferedAbout.ReloadTheme();
        PreBufferedAssistant.ReloadTheme();
        PreBufferedPresets.ReloadTheme();
        PreBufferedCreator.ReloadTheme();
        PreBufferedCANM.ReloadTheme();
        for (int p = 0; p < PreBufferedPanels.Count; p++)
        {
            PreBufferedPanels.ElementAt(p).Value.ReloadTheme();
        }

        if (Program.Settings.IsDarkMode)
        {
            AutoSortToolStripMenuItem.Image = Resources.ReorganizeLight;
            IdentificationAssistantToolStripMenuItem.Image = Resources.AssistantLight;
            WikiToolStripMenuItem.Image = Resources.WikiPageLight;
            IssuesToolStripMenuItem.Image = Resources.IssuePageLight;
            GithubReleasesToolStripMenuItem.Image = Resources.ReleasesPageLight;
        }
        else
        {
            AutoSortToolStripMenuItem.Image = Resources.Reorganize;
            IdentificationAssistantToolStripMenuItem.Image = Resources.Assistant;
            WikiToolStripMenuItem.Image = Resources.WikiPage;
            IssuesToolStripMenuItem.Image = Resources.IssuePage;
            GithubReleasesToolStripMenuItem.Image = Resources.ReleasesPage;
        }

        if (Program.ShowNeedsUpdate)
        {
            GithubReleasesToolStripMenuItem.BackColor = HelpToolStripMenuItem.BackColor = Program.Settings.IsDarkMode ? Color.DarkGreen : Color.LightGreen;
        }
    }

    public void ReloadPanel()
    {
        if (CameraListBox.SelectedIndex > -1)
            ChangePanel(PreBufferedPanels[GetPanelKey(Cameras[CameraListBox.SelectedIndex].Type)]);
        else
            ChangePanel(CurrentPanel);
    }

    public void ReloadCameraListBox()
    {
        if (Cameras is null || Cameras.EntryCount == 0)
            return;
        for (int i = 0; i < Cameras.EntryCount; i++)
        {
            CameraListBox.Items[i] = Cameras[i].GetTranslatedName();
        }
    }

    private void ChangePanel(Control? ctrl, int? NewSelectedIndex = null)
    {
        if (CurrentPanel is ICameraPanel p)
            p.UnloadCamera();

        if (NewSelectedIndex is not null)
            CameraListBox.SelectedIndex = NewSelectedIndex.Value;

        if (!ReferenceEquals(CurrentPanel, ctrl))
        {
            MainSplitContainer.Panel2.Controls.Clear();
            if (ctrl is not null)
                MainSplitContainer.Panel2.Controls.Add(ctrl);
        }

        if (ctrl is ICameraPanel p2 && CameraListBox.SelectedIndex > -1)
            p2.LoadCamera(Cameras[CameraListBox.SelectedIndex]);

        Invalidate();
    }

    private void CameraListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DisableEditorChange)
            return;

        if (CurrentPanel is PresetCreatorPanel)
        {
            PreBufferedAssistant.ApplyButton.Enabled = false;
            return;
        }
        PreBufferedAssistant.ApplyButton.Enabled = CameraListBox.SelectedIndex > -1;

        if (CameraListBox.SelectedIndex > -1)
        {
            if (Cameras is not null)
                ChangePanel(PreBufferedPanels[GetPanelKey(Cameras[CameraListBox.SelectedIndex].Type)]);
            else
            {
                //load the CANM panel instead
                ChangePanel(PreBufferedCANM);
                LoadCanm((CANM.TrackSelection)CameraListBox.SelectedIndex);
            }
        }
        else
            ChangePanel(null);
    }

    private void CameraListBox_KeyDown(object? sender, KeyEventArgs e)
    {
        if (CameraListBox.SelectedIndex == -1)
            return;

        if (e.Control && e.KeyCode == Keys.C)
        {
            e.SuppressKeyPress = true;
            CopyCamera();
        }
        else if (e.Control && e.KeyCode == Keys.V)
        {
            e.SuppressKeyPress = true;
            PasteCamera();
        }
        else if (e.Control && e.Shift && e.KeyCode == Keys.V)
        {
            e.SuppressKeyPress = true;
            AddNewFromClipboardToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        else if (e.Control && e.KeyCode == Keys.A)
        {
            e.SuppressKeyPress = true;
            AddDefaultCameraToolStripMenuItem_Click(null, EventArgs.Empty);
            AddCANMKeyframeToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        else if (e.Control && e.KeyCode == Keys.Delete)
        {
            e.SuppressKeyPress = true;
            DeleteCameraToolStripMenuItem_Click(null, EventArgs.Empty);
            DeleteCANMKeyframeToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        else if (e.Control && e.KeyCode == Keys.Home)
        {
            e.SuppressKeyPress = true;
            MoveToTopToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        else if (e.Control && e.KeyCode == Keys.End)
        {
            e.SuppressKeyPress = true;
            MoveToBottomToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        else if (e.Control && e.KeyCode == Keys.PageUp)
        {
            e.SuppressKeyPress = true;
            MoveUpToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        else if (e.Control && e.KeyCode == Keys.PageDown)
        {
            e.SuppressKeyPress = true;
            MoveDownToolStripMenuItem_Click(null, EventArgs.Empty);
        }
    }

    private void CameraListBox_MouseUp(object sender, MouseEventArgs e)
    {
        if (KeyframeCamera is null)
            return;

        if (e.Button != MouseButtons.Right)
            return;

        if (CameraListBox.SelectedIndex < 0)
            return;

        int index = CameraListBox.IndexFromPoint(e.Location);
        if (index == ListBox.NoMatches)
            return;

        CameraListBox.SelectedIndex = -1;
        int Selected = index;
        CANM.Track t = KeyframeCamera[(CANM.TrackSelection)Selected];
        t.UseSingleSlope = !t.UseSingleSlope;
        InitCanmListBox();
        CameraListBox.SelectedIndex = Selected;
    }

    public KeyValuePair<BCAM.Entry, int>? StealSelected()
    {
        if (Cameras is null || CameraListBox.SelectedIndex == -1)
            return null;

        BCAM.Entry val = Cameras[CameraListBox.SelectedIndex];
        if (PreBufferedCreator.ContainsCamera(val))
            return null;

        int index = CameraListBox.SelectedIndex;
        //Cameras[CameraListBox.SelectedIndex] = null;
        CameraListBox.Items[CameraListBox.SelectedIndex] = "<Already in preset>";
        return new(val, index);
    }

    public void RecieveStolenCamera(KeyValuePair<BCAM.Entry, int> Input)
    {
        //Cameras[Input.Value] = Input.Key;
        CameraListBox.Items[Input.Value] = Input.Key.GetTranslatedName();
    }

    public void CancelPreset(List<KeyValuePair<BCAM.Entry, int>>? Cams)
    {
        MainSplitContainer.Panel2.Controls.Clear();
        if (Cams is not null)
            for (int i = 0; i < Cams.Count; i++)
                RecieveStolenCamera(Cams[i]);
        ReloadCameraListBox();

        PreBufferedCreator.Cameras = [];
        PreBufferedCreator.Reset();


        EditToolStripMenuItem.Enabled = true;
        for (int i = 0; i < EditToolStripMenuItem.DropDownItems.Count; i++)
            EditToolStripMenuItem.DropDownItems[i].Enabled = true;
        AddCameraToolStripMenuItem.Enabled = true;
        PresetsToolStripMenuItem.Enabled = true;
        AutoSortToolStripMenuItem.Enabled = true;
    }

    private void UpdateControlState(Control panel, bool enabled)
    {
        foreach (Control ctrl in panel.Controls)
        {
            ctrl.Enabled = enabled;
        }

        if (panel is CameraEditorForm)
        {
            EditToolStripMenuItem.Enabled = true;
            for (int i = 0; i < EditToolStripMenuItem.DropDownItems.Count; i++)
                EditToolStripMenuItem.DropDownItems[i].Enabled = true;
            AddCameraToolStripMenuItem.Enabled = true;
            PresetsToolStripMenuItem.Enabled = true;
            AutoSortToolStripMenuItem.Enabled = true;

            if (KeyframeCamera is not null)
            {
                MoveToTopToolStripMenuItem.Enabled =
                MoveUpToolStripMenuItem.Enabled =
                MoveDownToolStripMenuItem.Enabled =
                MoveToBottomToolStripMenuItem.Enabled =
                ExportPresetToolStripMenuItem.Enabled =
                AddNewFromClipboardToolStripMenuItem.Enabled =
                PresetsToolStripMenuItem.Enabled =
                AutoSortToolStripMenuItem.Enabled = false;
                UpdateControlState(PreBufferedAssistant, false);

                if (EditToolStripMenuItem.DropDownItems.Contains(AddCameraToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Remove(AddCameraToolStripMenuItem);
                if (EditToolStripMenuItem.DropDownItems.Contains(DeleteCameraToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Remove(DeleteCameraToolStripMenuItem);

                if (!EditToolStripMenuItem.DropDownItems.Contains(DeleteCANMKeyframeToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Insert(0, DeleteCANMKeyframeToolStripMenuItem);
                if (!EditToolStripMenuItem.DropDownItems.Contains(AddCANMKeyframeToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Insert(0, AddCANMKeyframeToolStripMenuItem);

                if (!EditToolStripMenuItem.DropDownItems.Contains(SetAllToLinearToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Add(SetAllToLinearToolStripMenuItem);
                if (!EditToolStripMenuItem.DropDownItems.Contains(SetAllToZeroToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Add(SetAllToZeroToolStripMenuItem);

                ReloadTheme();
            }
            else
            {
                MoveToTopToolStripMenuItem.Enabled =
                MoveUpToolStripMenuItem.Enabled =
                MoveDownToolStripMenuItem.Enabled =
                MoveToBottomToolStripMenuItem.Enabled =
                ExportPresetToolStripMenuItem.Enabled =
                AddNewFromClipboardToolStripMenuItem.Enabled =
                PresetsToolStripMenuItem.Enabled =
                AutoSortToolStripMenuItem.Enabled = true;
                UpdateControlState(PreBufferedAssistant, true);

                if (!EditToolStripMenuItem.DropDownItems.Contains(DeleteCameraToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Insert(0, DeleteCameraToolStripMenuItem);
                if (!EditToolStripMenuItem.DropDownItems.Contains(AddCameraToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Insert(0, AddCameraToolStripMenuItem);

                if (EditToolStripMenuItem.DropDownItems.Contains(DeleteCANMKeyframeToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Remove(DeleteCANMKeyframeToolStripMenuItem);
                if (EditToolStripMenuItem.DropDownItems.Contains(AddCANMKeyframeToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Remove(AddCANMKeyframeToolStripMenuItem);

                if (EditToolStripMenuItem.DropDownItems.Contains(SetAllToLinearToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Remove(SetAllToLinearToolStripMenuItem);
                if (EditToolStripMenuItem.DropDownItems.Contains(SetAllToZeroToolStripMenuItem))
                    EditToolStripMenuItem.DropDownItems.Remove(SetAllToZeroToolStripMenuItem);

                ReloadTheme();
            }
        }
    }

    #region BCAM
    public void UpdateCameraId(BCAM.Entry entry)
    {
        int ListBoxIndex = CameraListBox.SelectedIndex;
        int IndexOf = Cameras.IndexOf(entry);
        string Translated = entry.GetTranslatedName();
        if (ListBoxIndex > -1 && IndexOf > -1)
        {
            DisableEditorChange = true;
            CameraListBox.SelectedIndex = -1;
            CameraListBox.Items[IndexOf] = Translated;
            CameraListBox.SelectedIndex = ListBoxIndex;
            DisableEditorChange = false;
        }
    }
    public void UpdateCamera(BCAM.Entry entry, int IndexOf)
    {
        Cameras[IndexOf] = entry;
        UpdateCameraId(entry);
        ReloadPanel();
    }

    /// <summary>
    /// Sets the active camera's ID. Returns if there is not a CameraPanelBase active
    /// </summary>
    /// <param name="NewID"></param>
    public void SetCameraId(string NewID)
    {
        if (CurrentPanel is not CameraPanelBase CPB)
            return;
        CPB.UpdateID(NewID);
    }

    private string GetPanelKey(string CamType)
    {
        if (!Program.Settings.IsUseUniqueEditor)
            return DEFAULT_EDITOR_KEY;

        return PreBufferedPanels.ContainsKey(CamType) ? CamType : DEFAULT_EDITOR_KEY;
    }

    public void AddCamera(BCAM.Entry NewCamera)
    {
        Cameras.Add(NewCamera);
        CameraListBox.Items.Add(NewCamera.GetTranslatedName());
        Program.IsUnsavedChanges = true;
    }

    private void CopyCamera()
    {
        if (CurrentPanel is CANMEditPanel canm)
        {
            //Decide what to copy
            return;
        }

        if (CurrentPanel is ICameraPanel p)
            p.UnloadCamera();

        BCAM.Entry Clone = BCAM.Entry.CloneCameraFull(Cameras[CameraListBox.SelectedIndex]);
        Clipboard.SetText(Clone.ToClipboard(BCAM.Entry.CLIPBOARD_HEAD));
        Console.WriteLine($"Copied {Cameras[CameraListBox.SelectedIndex].GetTranslatedName()}!");
    }

    private void PasteCamera()
    {
        if (CurrentPanel is CANMEditPanel)
            return; //No Copy Paste support for CANM

        int temp = CameraListBox.SelectedIndex;
        CameraListBox.SelectedIndex = -1;
        BCAM.Entry Current = new();
        if (Current.FromClipboard(Clipboard.GetText(), BCAM.Entry.CLIPBOARD_HEAD))
            Console.WriteLine("Paste from LCP Successful!");
        else if (Current.FromClipboard(Clipboard.GetText()))
            Console.WriteLine("Paste from BCSV Successful!");
        else
            Console.WriteLine("Clipboard doesn't contain a Valid LCP Camera!");
        CameraListBox.SelectedIndex = temp;
        UpdateCamera(Current, temp);
        Program.IsUnsavedChanges = true;
    }

    private void MoveCamera(CameraMoveOptions Option, int NewSelectedIndex, bool IsOptionEnabled)
    {
        if (Cameras is null || CameraListBox.SelectedIndex < 0 || !IsOptionEnabled)
            return;

        DisableEditorChange = true;
        int previous = CameraListBox.SelectedIndex;
        CameraListBox.SelectedIndex = -1;
        Cameras.MoveCamera(previous, Option);
        ReloadCameraListBox();
        CameraListBox.SelectedIndex = NewSelectedIndex;
        Program.IsUnsavedChanges = true;
        DisableEditorChange = false;
    }
    #endregion

    #region CANM
    private void LoadCanm(CANM.TrackSelection selection)
    {
        PreBufferedCANM.SetTime(KeyframeCamera.Length);
        PreBufferedCANM.LoadTrack(KeyframeCamera[selection], KeyframeCamera.IsFullFrames);

        SetAllToLinearToolStripMenuItem.Enabled = !KeyframeCamera[selection].UseSingleSlope;
    }

    private void InitCanmListBox()
    {
        CameraListBox.Items.Clear();

        CameraListBox.Items.Add("Position X        " + SlopeType(0));
        CameraListBox.Items.Add("Position Y        " + SlopeType(1));
        CameraListBox.Items.Add("Position Z        " + SlopeType(2));
        CameraListBox.Items.Add("Target X\t        " + SlopeType(3));
        CameraListBox.Items.Add("Target Y\t        " + SlopeType(4));
        CameraListBox.Items.Add("Target Z\t        " + SlopeType(5));
        CameraListBox.Items.Add("Roll\t        " + SlopeType(6));
        CameraListBox.Items.Add("Field of View Y" + SlopeType(7));

        string SlopeType(int x)
        {
            return KeyframeCamera[(CANM.TrackSelection)x].UseSingleSlope ? " (Symmetric)" : " (Piece-wise)";
        }
    }

    private void AddCANMKeyframe(CANM.TrackSelection selection)
    {
        CANM.Track TrackSelected = KeyframeCamera[selection];
        float NextFrameId = TrackSelected.GetNextOpenFrame(KeyframeCamera.Length);
        CANM.Track.Frame NewFrame = new() { FrameId = NextFrameId };
        if (NewFrame.FrameId == -1)
        {
            Console.WriteLine("Failed to find space to add the new CANM Keyframe!");
            return;
        }
        TrackSelected.Add(NewFrame);
        TrackSelected.Sort((L, R) => L.FrameId.CompareTo(R.FrameId));
        PreBufferedCANM.SetTime(KeyframeCamera.Length);
        PreBufferedCANM.LoadTrack(KeyframeCamera[selection], KeyframeCamera.IsFullFrames);
    }

    private void DeleteCANMKeyframe(int index, CANM.TrackSelection selection)
    {
        CANM.Track TrackSelected = KeyframeCamera[selection];
        if (index < 0 || index >= TrackSelected.Count)
        {
            Console.WriteLine($"Index out of bounds. {index} is not between 0 and {TrackSelected.Count}");
            return;
        }

        if (TrackSelected.Count == 1)
        {
            Console.WriteLine("Cannot delete the last keyframe as there must be at least one!");
            return;
        }

        TrackSelected.RemoveAt(index);
        PreBufferedCANM.SetTime(KeyframeCamera.Length);
        if (index > 0)
            index--;
        PreBufferedCANM.LoadTrack(KeyframeCamera[selection], KeyframeCamera.IsFullFrames, index);
    }

    private void UpdateTime(int e)
    {
        if (KeyframeCamera is null)
            return;
        KeyframeCamera.Length = e;
    }
    #endregion

    #region MainToolStrip

    #region File
    private void NewToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (Program.IsUnsavedChanges && !IsDiscardChanges())
            return;

        Filename = null;
        MainSplitContainer.Panel2.Controls.Clear();
        Cameras = new BCAM();
        KeyframeCamera = null;
        CameraListBox.Enabled = true;
        SaveToolStripMenuItem.Enabled = true;
        SaveAsToolStripMenuItem.Enabled = true;
        ExportPresetToolStripMenuItem.Enabled = true;
        CameraListBox.Items.Clear();
        Console.WriteLine("New File Started!");
        AddDefaultCameraToolStripMenuItem_Click(null, EventArgs.Empty);
        CameraListBox.SelectedIndex = 0;
        Program.IsUnsavedChanges = false;

        UpdateControlState(this, true);
    }

    private void OpenToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (Program.IsUnsavedChanges && !IsDiscardChanges())
            return;
        Console.WriteLine();
        Console.WriteLine("Supported Files => .bcam .arc .rarc .canm");
        if (ofd.ShowDialog() == DialogResult.OK && File.Exists(ofd.FileName))
        {
            Open(ofd.FileName);
        }
        else
            Console.WriteLine("Open Cancelled");

        Console.WriteLine();
    }

    private void SaveToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (Filename == null)
        {
            SaveAsToolStripMenuItem_Click(sender, e);
        }
        else
        {
            Save();
        }

    }

    private void SaveAsToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        sfd.Filter = KeyframeCamera is null ? FILTER_BCAM : FILTER_CANM;
        if (sfd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(sfd.FileName))
        {
            Filename = sfd.FileName;
            Save();
        }
    }

    private void ExitToolStripMenuItem_Click(object? sender, EventArgs e) => Close();
    #endregion

    #region Edit
    private void AddDefaultCameraToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (KeyframeCamera is not null)
            return;
        if (Cameras is null)
        {
            Console.WriteLine(Program.ConsoleHalfSplitter);
            Console.WriteLine("Failed to add the camera!\nNo camera file is active");
            Console.WriteLine(Program.ConsoleHalfSplitter);
            return;
        }
        BCAM.Entry newCamera = BCAM.Entry.CreateDefaultCamera();
        newCamera.Identification = "c:" + GetNextOpenShortNumber(Cameras, "c").ToString("x4");
        newCamera.Type = "CAM_TYPE_XZ_PARA";
        AddCamera(newCamera);
        Console.WriteLine("Added the Default Camera to the end of the Camera List");
    }

    private void PresetsToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        CameraListBox.SelectedIndex = -1;
        MainSplitContainer.Panel2.Controls.Clear();
        if (Program.PresetSelectorNeedsReload)
            PreBufferedPresets.GenerateTreeview(Program.PRESETS_PATH);
        MainSplitContainer.Panel2.Controls.Add(PreBufferedPresets);
    }

    private void AddNewFromClipboardToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        BCAM.Entry NewFromClipboard = new();

        if (NewFromClipboard.FromClipboard(Clipboard.GetText(), BCAM.Entry.CLIPBOARD_HEAD) || NewFromClipboard.FromClipboard(Clipboard.GetText()))
        {
            if (Cameras is null)
            {
                Console.WriteLine(Program.ConsoleHalfSplitter);
                Console.WriteLine("Failed to add the camera!\nNo camera file is active");
                Console.WriteLine(Program.ConsoleHalfSplitter);
                return;
            }
            AddCamera(NewFromClipboard);
            Console.WriteLine("Camera Added from Clipboard!");
        }
        else
            Console.WriteLine("Clipboard doesn't contain a Valid LCP Camera!" + (Cameras is null ? "\nAnd there is no camera file currently active" : ""));
    }

    private void DeleteCameraToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (Cameras is null || CameraListBox.SelectedIndex < 0)
            return;
        int selectedindex = CameraListBox.SelectedIndex;
        CameraListBox.SelectedIndex = selectedindex - 1;
        Cameras.RemoveAt(selectedindex);
        CameraListBox.Items.RemoveAt(selectedindex);
    }

    private void CopyToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (Cameras is null || CameraListBox.SelectedIndex == -1)
            return;
        CopyCamera();
    }

    private void PasteToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (Cameras is null || CameraListBox.SelectedIndex == -1)
            return;
        PasteCamera();
    }

    private void MoveToTopToolStripMenuItem_Click(object? sender, EventArgs e) => MoveCamera(CameraMoveOptions.TOP, 0, MoveToTopToolStripMenuItem.Enabled);

    private void MoveUpToolStripMenuItem_Click(object? sender, EventArgs e) => MoveCamera(CameraMoveOptions.UP, CameraListBox.SelectedIndex == 0 ? CameraListBox.Items.Count - 1 : CameraListBox.SelectedIndex - 1, MoveUpToolStripMenuItem.Enabled);

    private void MoveDownToolStripMenuItem_Click(object? sender, EventArgs e) => MoveCamera(CameraMoveOptions.DOWN, CameraListBox.SelectedIndex == CameraListBox.Items.Count - 1 ? 0 : CameraListBox.SelectedIndex + 1, MoveDownToolStripMenuItem.Enabled);

    private void MoveToBottomToolStripMenuItem_Click(object? sender, EventArgs e) => MoveCamera(CameraMoveOptions.BOTTOM, CameraListBox.Items.Count - 1, MoveToBottomToolStripMenuItem.Enabled);



    private void AddCANMKeyframeToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (KeyframeCamera is null)
            return;

        AddCANMKeyframe((CANM.TrackSelection)CameraListBox.SelectedIndex);
    }

    private void DeleteCANMKeyframeToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (KeyframeCamera is null || PreBufferedCANM.SelectedIndex < 0)
            return;

        DeleteCANMKeyframe(PreBufferedCANM.SelectedIndex, (CANM.TrackSelection)CameraListBox.SelectedIndex);
    }

    private void SetAllToLinearToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (CameraListBox.SelectedIndex < 0 || KeyframeCamera is null)
            return;

        if (MessageBox.Show("This will set the tangents of all keyframes in the selected track to be Linear.\nAre you sure you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        CANM.Track SelectedTrack = KeyframeCamera[(CANM.TrackSelection)CameraListBox.SelectedIndex];
        for (int i = 0; i < SelectedTrack.Count - 1; i++)
        {
            float Linear = CANMEditPanel.CalculateLinearSlope(SelectedTrack[i], SelectedTrack[i + 1]);
            SelectedTrack[i].OutSlope = Linear;
            SelectedTrack[i + 1].InSlope = Linear;
        }
        PreBufferedCANM.SetTime(KeyframeCamera.Length);
        PreBufferedCANM.LoadTrack(SelectedTrack, KeyframeCamera.IsFullFrames);
    }

    private void SetAllToZeroToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (CameraListBox.SelectedIndex < 0 || KeyframeCamera is null)
            return;

        if (MessageBox.Show("This will set the tangents of all keyframes in the selected track to Zero.\nAre you sure you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        CANM.Track SelectedTrack = KeyframeCamera[(CANM.TrackSelection)CameraListBox.SelectedIndex];
        for (int i = 0; i < SelectedTrack.Count; i++)
        {
            SelectedTrack[i].InSlope = 0;
            SelectedTrack[i].OutSlope = 0;
        }
        PreBufferedCANM.SetTime(KeyframeCamera.Length);
        PreBufferedCANM.LoadTrack(SelectedTrack, KeyframeCamera.IsFullFrames);
    }
    #endregion

    #region Tools
    private void AutoSortToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (Cameras is null)
            return;

        if (CameraListBox.SelectedIndex <= -1)
            return;

        BCAM.Entry Cam = Cameras[CameraListBox.SelectedIndex];
        CameraListBox.SelectedIndex = -1;
        CameraListBox.Enabled = false;

        Cameras.OrderBy(o => o[Cameras[BCAM.HASH_ID]]);
        ReloadCameraListBox();

        CameraListBox.Enabled = true;
        for (int i = 0; i < Cameras.EntryCount; i++)
        {
            if (Cameras[i] == Cam)
            {
                CameraListBox.SelectedIndex = i;
                break;
            }
        }
        Program.IsUnsavedChanges = true;
    }

    private void IdentificationAssistantToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (Controls.Contains(PreBufferedAssistant))
        {
            MinimumSize -= new Size(0, PreBufferedAssistant.MinimumSize.Height);
            Size = MinimumSize; //Take this line out once a good way for scaling high control forms is found
            Controls.Remove(PreBufferedAssistant);
            Program.Settings.IsIdentificationAssistOpen = false;
            Console.WriteLine("ID Assist: Off");
        }
        else
        {
            Controls.Add(PreBufferedAssistant);
            MinimumSize += new Size(0, PreBufferedAssistant.MinimumSize.Height);
            Program.Settings.IsIdentificationAssistOpen = true;
            Console.WriteLine("ID Assist: On");
        }
    }

    private void ExportPresetToolStripMenuItem_Click(object sender, EventArgs e)
    {
        EditToolStripMenuItem.Enabled = false;
        for (int i = 0; i < EditToolStripMenuItem.DropDownItems.Count; i++)
            EditToolStripMenuItem.DropDownItems[i].Enabled = false;
        AddCameraToolStripMenuItem.Enabled = false;
        PresetsToolStripMenuItem.Enabled = false;
        AutoSortToolStripMenuItem.Enabled = false;
        if (Program.PresetCreatorNeedsReload)
            PreBufferedCreator.GenerateTreeview(Program.PRESETS_PATH);

        ChangePanel(PreBufferedCreator, -1);
    }

    private void OptionsToolStripMenuItem_Click(object sender, EventArgs e) => ChangePanel(PreBufferedSettings, -1);
    #endregion

    #region Help
    private void WikiToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("https://github.com/SuperHackio/LaunchCamPlus/wiki");

    private void IssuesToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("https://github.com/SuperHackio/LaunchCamPlus/issues");

    private void GithubReleasesToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("https://github.com/SuperHackio/LaunchCamPlus/releases");

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e) => ChangePanel(PreBufferedAbout, -1);
    #endregion

    #endregion

    private void ApplyButton_Click(object? sender, EventArgs e)
    {
        SetCameraId(PreBufferedAssistant.GetID);
        Console.WriteLine("ID Assistance applied");
    }

    private void Yaz0BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        if (e is null || e.Argument is null)
            return;
        FileInfo FI = new((string)e.Argument);
        byte[] Original = File.ReadAllBytes(FI.FullName);
        byte[] Compressed = YAZ0.Compress(Original, Yaz0BackgroundWorker);
        File.WriteAllBytes(FI.FullName, Compressed);
    }

    private void Yaz0BackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        Console.Write($"\rYaz0 Encoding: {e.ProgressPercentage}%");
    }

    private static bool IsDiscardChanges() => MessageBox.Show("You have Unsaved Changes, are you sure you want to proceed?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
}