using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Hackio.IO.YAZ0;
using Hackio.IO.RARC;
using Hackio.IO.BCAM;
using Hackio.IO.Util;
using LaunchCamPlus.CameraPanels;
using LaunchCamPlus.Properties;
using System.Media;
using System.Diagnostics;

namespace LaunchCamPlus
{
    public partial class CameraEditorForm : Form
    {
        public CameraEditorForm(string[] args)
        {
            InitializeComponent();
            CenterToScreen();
            //I would set these in the designer but VS keeps breaking for some reason
            MainSplitContainer.SplitterWidth = 1;
            MainSplitContainer.SplitterDistance = 224;
            MainSplitContainer.Panel1MinSize = 224;
            MainSplitContainer.Panel2MinSize = 443;
            Text = Application.ProductName + " - " + Application.ProductVersion;
            CameraListBox.SetDoubleBuffered();
            MainSplitContainer.Panel1.SetDoubleBuffered();
            MainSplitContainer.Panel2.SetDoubleBuffered();

            PreBufferedSettings = new SettingsPanel(this) { Dock = DockStyle.Fill };
            PreBufferedAbout = new AboutPanel() { Dock = DockStyle.Fill };
            PreBufferedPresets = new PresetSelectorPanel() { Dock = DockStyle.Fill };
            PreBufferedCreator = new PresetCreatorPanel() { Dock = DockStyle.Fill };
            PreBufferedAssistant = new IdentificationAssistant() { Dock = DockStyle.Bottom };
            PreBufferedAssistant.ApplyButton.Click += ApplyButton_Click;
            PreBufferedPanels = new Dictionary<string, CameraPanelBase>
            {
                { "DEFAULT", new DefaultCameraPanel() { Dock = DockStyle.Fill } },
                { "CAM_TYPE_EYEPOS_FIX_THERE", new EyeposFixThereCameraPanel() { Dock = DockStyle.Fill } },
                { "CAM_TYPE_WONDER_PLANET", new WanderPlanetCameraPanel() { Dock = DockStyle.Fill } },
                { "CAM_TYPE_XZ_PARA", new XZParaCameraPanel() { Dock = DockStyle.Fill } }
            };

            ReloadTheme();
            if (Settings.Default.IsIdentificationAssistOpen)
                IdentificationAssistantToolStripMenuItem_Click(null, null);
            else
                Console.WriteLine("ID Assist: Off");


            if (args.Length > 0)
            {
                Console.WriteLine("Argument recieved!");
                Console.WriteLine(Program.ConsoleHalfSplitter);
                Open(args[0]);
                Console.WriteLine(Program.ConsoleHalfSplitter);
            }
            if (Settings.Default.IsShowAboutOnLaunch)
                AboutToolStripMenuItem_Click(null, null);

            MainSplitContainer.Panel2.ControlRemoved += Panel2_ControlRemoved;
        }

        OpenFileDialog ofd = new OpenFileDialog() { Filter = "Supported Files|*.bcam;*.arc;*.rarc|Camera Files|*.bcam|Level Archive|*.rarc;*.arc" };
        SaveFileDialog sfd = new SaveFileDialog() { Filter = "Supported Files|*.bcam;*.arc;*.rarc|Camera Files|*.bcam|Level Archive|*.rarc;*.arc" };
        string Filename { get; set; }
        public BCAM Cameras { get; set; }
        Dictionary<string, CameraPanelBase> PreBufferedPanels;
        int PrevListID;

        private SettingsPanel PreBufferedSettings;
        private IdentificationAssistant PreBufferedAssistant;
        private AboutPanel PreBufferedAbout;
        private PresetSelectorPanel PreBufferedPresets;
        private PresetCreatorPanel PreBufferedCreator;

        #region Main Menustrip

        #region File
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filename = null;
            MainSplitContainer.Panel2.Controls.Clear();
            Cameras = new BCAM();
            CameraListBox.Enabled = true;
            SaveToolStripMenuItem.Enabled = true;
            SaveAsToolStripMenuItem.Enabled = true;
            ExportPresetToolStripMenuItem.Enabled = true;
            CameraListBox.Items.Clear();
            Console.WriteLine("New File Started!");
            AddDefaultCameraToolStripMenuItem_Click(null, null);
            CameraListBox.SelectedIndex = 0;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Supported Files => .bcam .arc .rarc");
            if (ofd.ShowDialog() == DialogResult.OK && File.Exists(ofd.FileName))
            {
                Open(ofd.FileName);
            }
            else
                Console.WriteLine("Open Cancelled");

            Console.WriteLine();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
            {
                Filename = sfd.FileName;
                Save();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => Close();
        #endregion

        #region Edit
        private void AddDefaultCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Cameras == null)
            {
                Console.WriteLine(Program.ConsoleHalfSplitter);
                Console.WriteLine("Failed to add the camera!\nNo camera file is active");
                Console.WriteLine(Program.ConsoleHalfSplitter);
                return;
            }
            BCAMEntry newcamera = CameraDefaults.Defaults["CAM_TYPE_XZ_PARA"];
            newcamera.Identification = "c:" + BCAMEx.CalculateNextCameraArea(Cameras).ToString("x4");
            newcamera.Type = "CAM_TYPE_XZ_PARA";
            AddCamera(newcamera);
            Console.WriteLine("Added the Default Camera to the end of the Camera List");
        }

        private void PresetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraListBox.SelectedIndex = -1;
            MainSplitContainer.Panel2.Controls.Clear();
            if (Program.PresetSelectorNeedsReload)
                PreBufferedPresets.GenerateTreeview(Program.PresetPath);
            MainSplitContainer.Panel2.Controls.Add(PreBufferedPresets);
        }

        private void AddNewFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BCAMEntry NewFromClipboard = new BCAMEntry();

            if (NewFromClipboard.FromClipboard(Clipboard.GetText()))
            {
                if (Cameras == null)
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
                Console.WriteLine("Clipboard doesn't contain a Valid LCP Camera!"+(Cameras == null ? "\nAnd there is no camera file currently active":""));
        }

        private void DeleteCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CameraListBox.SelectedIndex == -1)
                return;
            int selectedindex = CameraListBox.SelectedIndex;
            CameraListBox.SelectedIndex = selectedindex - 1;
            Cameras.Remove(selectedindex);
            CameraListBox.Items.RemoveAt(selectedindex);
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CameraListBox.SelectedIndex == -1)
                return;
            CopyCamera();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CameraListBox.SelectedIndex == -1)
                return;
            PasteCamera();
        }

        private void MoveToTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CameraListBox.SelectedIndex < 0 || !MoveToTopToolStripMenuItem.Enabled)
                return;

            int previous = CameraListBox.SelectedIndex;
            CameraListBox.SelectedIndex = -1;
            Cameras.MoveCamera(previous, BCAMEx.CameraMoveOptions.TOP);
            ReloadCameraListBox();
            CameraListBox.SelectedIndex = 0;
        }

        private void MoveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CameraListBox.SelectedIndex < 0 || !MoveUpToolStripMenuItem.Enabled)
                return;

            int previous = CameraListBox.SelectedIndex;
            CameraListBox.SelectedIndex = -1;
            Cameras.MoveCamera(previous, BCAMEx.CameraMoveOptions.UP);
            ReloadCameraListBox();
            CameraListBox.SelectedIndex = previous == 0 ? CameraListBox.Items.Count - 1 : previous - 1;
        }

        private void MoveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CameraListBox.SelectedIndex < 0 || !MoveDownToolStripMenuItem.Enabled)
                return;

            int previous = CameraListBox.SelectedIndex;
            CameraListBox.SelectedIndex = -1;
            Cameras.MoveCamera(previous, BCAMEx.CameraMoveOptions.DOWN);
            ReloadCameraListBox();
            CameraListBox.SelectedIndex = previous == CameraListBox.Items.Count - 1 ? 0 : previous + 1;
        }

        private void MoveToBottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CameraListBox.SelectedIndex < 0 || !MoveToBottomToolStripMenuItem.Enabled)
                return;

            int previous = CameraListBox.SelectedIndex;
            CameraListBox.SelectedIndex = -1;
            Cameras.MoveCamera(previous, BCAMEx.CameraMoveOptions.BOTTOM);
            ReloadCameraListBox();
            CameraListBox.SelectedIndex = CameraListBox.Items.Count - 1;
        }
        #endregion

        #region Tools
        private void AutoSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Cameras is null)
                return;

            BCAMEntry Cam = CameraListBox.SelectedIndex == -1 ? null : Cameras[CameraListBox.SelectedIndex];
            CameraListBox.SelectedIndex = -1;
            CameraListBox.Enabled = false;

            Cameras.Sort();
            ReloadCameraListBox();

            CameraListBox.Enabled = true;
            if (!(Cam is null))
            {
                for (int i = 0; i < Cameras.EntryCount; i++)
                {
                    if (Cameras[i] == Cam)
                    {
                        CameraListBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void IdentificationAssistantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Controls.Contains(PreBufferedAssistant))
            {
                MinimumSize -= new Size(0, PreBufferedAssistant.MinimumSize.Height);
                Size = MinimumSize; //Take this line out once a good way for scaling high control forms is found
                Controls.Remove(PreBufferedAssistant);
                Settings.Default.IsIdentificationAssistOpen = false;
                Console.WriteLine("ID Assist: Off");
            }
            else
            {
                Controls.Add(PreBufferedAssistant);
                MinimumSize += new Size(0, PreBufferedAssistant.MinimumSize.Height);
                Settings.Default.IsIdentificationAssistOpen = true;
                Console.WriteLine("ID Assist: On");
            }
        }

        private void ExportPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainSplitContainer.Panel2.Controls.Count > 0 && MainSplitContainer.Panel2.Controls[0] is CameraPanelBase pnl)
                pnl.UnLoadCamera(Cameras[PrevListID]);
            CameraListBox.SelectedIndex = -1;
            MainSplitContainer.Panel2.Controls.Clear();
            EditToolStripMenuItem.Enabled = false;
            for (int i = 0; i < EditToolStripMenuItem.DropDownItems.Count; i++)
                EditToolStripMenuItem.DropDownItems[i].Enabled = false;
            AddCameraToolStripMenuItem.Enabled = false;
            PresetsToolStripMenuItem.Enabled = false;
            AutoSortToolStripMenuItem.Enabled = false;
            if (Program.PresetCreatorNeedsReload)
                PreBufferedCreator.GenerateTreeview(Program.PresetPath);
            MainSplitContainer.Panel2.Controls.Add(PreBufferedCreator);
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraListBox.SelectedIndex = -1;
            MainSplitContainer.Panel2.Controls.Clear();
            MainSplitContainer.Panel2.Controls.Add(PreBufferedSettings);
        }
        #endregion

        #region Help
        private void WikiToolStripMenuItem_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://github.com/SuperHackio/LaunchCamPlus/wiki");

        private void IssuesToolStripMenuItem_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://github.com/SuperHackio/LaunchCamPlus/issues");

        private void GithubReleasesToolStripMenuItem_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://github.com/SuperHackio/LaunchCamPlus/releases");

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraListBox.SelectedIndex = -1;
            MainSplitContainer.Panel2.Controls.Clear();
            MainSplitContainer.Panel2.Controls.Add(PreBufferedAbout);
        }
        #endregion

        #endregion

        public void Open(string file)
        {
            CameraListBox.SelectedIndex = -1;
            Filename = file;
            SoundPlayer Patience = new SoundPlayer();
            if (File.Exists(Filename) && new FileInfo(file).IsFileLocked())
            {
                Console.WriteLine("The chosen file cannot be accessed. The file has not been modified, and your changes have not been saved.");
                goto OpenFailed;
            }
            if (Program.CanPlaySfx(Program.WaitSfx))
            {
                Patience.SoundLocation = Program.WaitSfx;
                Patience.Load();
                Patience.PlayLooping();
            }
            switch (new FileInfo(file).Extension)
            {
                case ".bcam":
                    Console.WriteLine("Loading as a Binary Camera file:");
                    FileStream fs = new FileStream(file, FileMode.Open);
                    Cameras = new BCAM(fs);
                    fs.Close();
                    Console.WriteLine("Load Complete!");
                    break;
                case ".arc":
                case ".rarc":
                    Console.WriteLine("Loading as an Archive:");
                    RARC Archive = YAZ0.Check(file) ? new RARC(YAZ0.Decompress(file)) : new RARC(file);
                    Console.WriteLine("Archive Loaded. Looking for the .bcam...");
                    List<RARCFile> foundfiles = Archive.FindFileTypes(".bcam");
                    if (foundfiles.Count == 0)
                    {
                        Console.WriteLine("Load Failed! No BCAM was found inside the archive!");
                        goto OpenFailed;
                    }
                    Console.WriteLine(".bcam found.");
                    Cameras = new BCAM(foundfiles[0].GetMemoryStream());
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
                Console.Write($"\r{Math.Min((int)(((float)(i + 1) / (float)CameraListBox.Items.Count) * 100), 100)}%          ");
            }
            Console.WriteLine("Complete");

            if (Cameras.EntryCount > 0)
                CameraListBox.SelectedIndex = 0;
            CameraListBox.Enabled = true;
            SaveToolStripMenuItem.Enabled = true;
            SaveAsToolStripMenuItem.Enabled = true;
            ExportPresetToolStripMenuItem.Enabled = true;

            Patience.Stop();
            if (Program.CanPlaySfx(Program.SuccessSfx))
            {
                Patience.SoundLocation = Program.SuccessSfx;
                Patience.Load();
                Patience.Play();
            }
            return;
        OpenFailed:
            Patience.Stop();
            if (Program.CanPlaySfx(Program.FailureSfx))
            {
                Patience.SoundLocation = Program.FailureSfx;
                Patience.Load();
                Patience.Play();
            }
        }

        private void Save()
        {
            SoundPlayer Patience = new SoundPlayer();
            Console.WriteLine();
            FileInfo fi = new FileInfo(Filename);
            if (File.Exists(Filename) && fi.IsFileLocked())
            {
                Console.WriteLine("The chosen file cannot be accessed. The file has not been modified, and your changes have not been saved.");
                goto SaveFailed;
            }
            if (Program.CanPlaySfx(Program.WaitSfx))
            {
                Patience.SoundLocation = Program.WaitSfx;
                Patience.Load();
                Patience.PlayLooping();
            }
            if (CameraListBox.SelectedIndex != -1)
                ((CameraPanelBase)MainSplitContainer.Panel2.Controls[0]).UnLoadCamera(Cameras[CameraListBox.SelectedIndex]);

            if (Settings.Default.IsEnforceCompress)
                AdvancedSave();
            if (File.Exists(Filename) && fi.IsFileLocked())
            {
                Console.WriteLine("The chosen file cannot be accessed. The file has not been modified, and your changes have not been saved.");
                goto SaveFailed;
            }
            switch (fi.Extension)
            {
                case ".bcam":
                    Console.WriteLine("Saving as a Binary Camera file:");
                    FileStream fs = new FileStream(Filename, FileMode.Create);
                    Cameras.Save(fs);
                    fs.Close();
                    break;
                case ".arc":
                case ".rarc":
                    Console.WriteLine("Loading the target Archive:");
                    RARC Archive = YAZ0.Check(Filename) ? new RARC(YAZ0.Decompress(Filename)) : new RARC(Filename);
                    Console.WriteLine("Archive Loaded. Looking for the .bcam to replace...");
                    List<RARCFile> foundfiles = Archive.FindFileTypes(".bcam");

                    if (foundfiles.Count == 0)
                    {
                        Console.WriteLine("Error finding a bcam");
                        DialogResult dr = MessageBox.Show("The archive has no .bcam to replace.\nWould you like to create one?", "Missing .bcam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        Console.WriteLine($"MessageBox Response: {dr.ToString()}");
                        if (dr != DialogResult.Yes)
                        {
                            Console.WriteLine("The chosen file has not been modified, and your changes have not been saved.");
                            goto SaveFailed;
                        }
                        Console.WriteLine("Injecting...");
                        if (!Archive.Root.SubDirectories.Any(SUB => SUB.Name.ToLower().Equals("camera")))
                            Archive.Root.SubDirectories.Add(new RARCDirectory() { Name = "Camera", Files = new List<RARCFile>() });

                        MemoryStream ms = new MemoryStream();
                        Cameras.Save(ms);
                        Archive.Root.SubDirectories[Archive.Root.GetSubDirIndex("camera")].Files.Add(new RARCFile() { Name = "CameraParam.bcam", FileData = ms.ToArray() });
                    }
                    else
                    {
                        Console.WriteLine(".bcam found. Saving...");
                        MemoryStream ms = new MemoryStream();
                        Cameras.Save(ms);
                        Archive.ReplaceFileByName("cameraparam.bcam", new RARCFile() { Name = "CameraParam.bcam", FileData = ms.ToArray() });
                    }

                    Console.WriteLine(".bcam saved into the archive.");
                    Console.WriteLine("Saving the archive...");
                    Archive.Save(Filename);
                    if (Settings.Default.IsUseYAZ0)
                    {
                        Console.WriteLine("Yaz0 Encoding...");
                        YAZ0.Compress(Filename);
                    }
                    break;
            }
            Console.WriteLine("Save Complete!");
            Console.WriteLine("Current time of Save: "+DateTime.Now.ToString("h:mm tt"));
            Program.IsUnsavedChanges = false;
            Console.WriteLine();
            
            Patience.Stop();
            if (Program.CanPlaySfx(Program.SuccessSfx))
            {
                Patience.SoundLocation = Program.SuccessSfx;
                Patience.Load();
                Patience.Play();
            }
            return;
        SaveFailed:
            Patience.Stop();
            if (Program.CanPlaySfx(Program.FailureSfx))
            {
                Patience.SoundLocation = Program.FailureSfx;
                Patience.Load();
                Patience.Play();
            }
            return;
        }

        private void AdvancedSave()
        {
            if (Cameras.EntryCount == 0)
                return;
            Console.WriteLine("Processing the cameras for advanced saving:");
            CameraListBox.Enabled = false;
            Control ReturnControl = null;
            if (MainSplitContainer.Panel2.Controls.Count > 0 && !(MainSplitContainer.Panel2.Controls[0] is CameraPanelBase))
                ReturnControl = MainSplitContainer.Panel2.Controls[0];
            int currentindex = CameraListBox.SelectedIndex;
            CameraListBox.SelectedIndex = -1;
            for (int i = 0; i < Cameras.EntryCount; i++)
            {
                CameraListBox.SelectedIndex = i;
                Refresh();
                Console.Write($"\r{Math.Min(((float)(i + 1) / (float)Cameras.EntryCount) * 100.0f, 100.0f).ToString("0.0")}%          ");
            }
            Console.WriteLine();
            ((CameraPanelBase)MainSplitContainer.Panel2.Controls[0]).UnLoadCamera(Cameras[CameraListBox.SelectedIndex]);
            CameraListBox.Enabled = true;
            CameraListBox.SelectedIndex = currentindex;
            if (ReturnControl != null)
                MainSplitContainer.Panel2.Controls.Add(ReturnControl);
            Console.WriteLine("Cameras have been processed!");
        }

        public void ReloadTheme()
        {
            EditorMenuStrip.Renderer = Settings.Default.IsDarkMode ? new MyRenderer() : default;
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
            for (int p = 0; p < PreBufferedPanels.Count; p++)
            {
                PreBufferedPanels.ElementAt(p).Value.ReloadTheme();
            }

            if (Settings.Default.IsDarkMode)
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
                GithubReleasesToolStripMenuItem.BackColor = HelpToolStripMenuItem.BackColor = Settings.Default.IsDarkMode ? Color.DarkGreen : Color.LightGreen;
            }
        }

        public void ReloadCameraListBox()
        {
            if (Cameras == null || Cameras.EntryCount == 0)
                return;
            for (int i = 0; i < Cameras.EntryCount; i++)
            {
                CameraListBox.Items[i] = Cameras[i].GetTranslatedName();
            }
        }

        public void RefreshSelected(string newID)
        {
            if (CameraListBox.SelectedIndex > -1)
            {
                Cameras[CameraListBox.SelectedIndex].Identification = newID;
                CameraListBox.Items[CameraListBox.SelectedIndex] = Cameras[CameraListBox.SelectedIndex].GetTranslatedName();
            }
        }

        public void ReloadEditor(bool DoUnload = false, bool SetType = false)
        {
            if (MainSplitContainer.Panel2.Controls[0] is CameraPanelBase CurrentPanel)
            {
                if (DoUnload)
                    CurrentPanel.UnLoadCamera(Cameras[PrevListID]);
                else if (SetType)
                    Cameras[PrevListID].Type = CurrentPanel.CurrentCameraType;

                string PanelKey = GetPanelKey(Cameras[PrevListID].Type);
                if (PanelKey.Equals(CurrentPanel.CameraType))
                {
                    CurrentPanel.LoadCamera(Cameras[PrevListID]);
                }
                else
                {
                    MainSplitContainer.Panel2.Controls.Clear();
                    MainSplitContainer.Panel2.Controls.Add(PreBufferedPanels[PanelKey]);
                    ((CameraPanelBase)MainSplitContainer.Panel2.Controls[0]).LoadCamera(Cameras[PrevListID]);
                }
            }
        }

        private void CameraListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainSplitContainer.Panel2.Controls.Count > 0 && (MainSplitContainer.Panel2.Controls[0] is PresetCreatorPanel))
            {
                PreBufferedAssistant.ApplyButton.Enabled = false;
                return;
            }
            PreBufferedAssistant.ApplyButton.Enabled = CameraListBox.SelectedIndex > -1;
            if (MainSplitContainer.Panel2.Controls.Count > 0 && !(MainSplitContainer.Panel2.Controls[0] is CameraPanelBase))
            {
                MainSplitContainer.Panel2.Controls.Clear();
            }
            if (MainSplitContainer.Panel2.Controls.Count == 0)
            {
                PrevListID = CameraListBox.SelectedIndex;
                if (PrevListID == -1)
                    return;
                if (!Settings.Default.IsUseDefaultOnly && PreBufferedPanels.ContainsKey(Cameras[PrevListID].Type))
                    MainSplitContainer.Panel2.Controls.Add(PreBufferedPanels[Cameras[PrevListID].Type]);
                else
                    MainSplitContainer.Panel2.Controls.Add(PreBufferedPanels["DEFAULT"]);
                    ((CameraPanelBase)MainSplitContainer.Panel2.Controls[0]).LoadCamera(Cameras[PrevListID]);
            }
            else if (CameraListBox.SelectedIndex > -1)
            {
                ((CameraPanelBase)MainSplitContainer.Panel2.Controls[0]).UnLoadCamera(Cameras[PrevListID]);

                PrevListID = CameraListBox.SelectedIndex;

                if (PrevListID > -1)
                    ReloadEditor();
            }
            else
            {
                MainSplitContainer.Panel2.Controls.Clear();
            }
        }

        private string GetPanelKey(string CamType) => Settings.Default.IsUseDefaultOnly ? "DEFAULT" : (!PreBufferedPanels.ContainsKey(CamType) ? "DEFAULT" : CamType);
        
        
        public void AddCamera(BCAMEntry NewCamera)
        {
            Cameras.Add(NewCamera);
            CameraListBox.Items.Add(NewCamera.GetTranslatedName());
        }

        private void CopyCamera()
        {
            Clipboard.SetText(Cameras[CameraListBox.SelectedIndex].ToClipboard());
            Console.WriteLine($"Copied {Cameras[CameraListBox.SelectedIndex].GetTranslatedName()}!");
        }

        private void PasteCamera()
        {
            int temp = CameraListBox.SelectedIndex;
            CameraListBox.SelectedIndex = -1;
            if (Cameras[temp].FromClipboard(Clipboard.GetText()))
                Console.WriteLine("Paste Successful!");
            else
                Console.WriteLine("Clipboard doesn't contain a Valid LCP Camera!");
            CameraListBox.SelectedIndex = temp;
            CameraListBox.Items[temp] = Cameras[temp].GetTranslatedName();
        }

        public KeyValuePair<BCAMEntry, int> StealSelected()
        {
            if (CameraListBox.SelectedIndex == -1 || Cameras[CameraListBox.SelectedIndex] is null)
                return new KeyValuePair<BCAMEntry, int>(null, -1);

            BCAMEntry val = Cameras[CameraListBox.SelectedIndex];
            int index = CameraListBox.SelectedIndex;
            Cameras[CameraListBox.SelectedIndex] = null;
            CameraListBox.Items[CameraListBox.SelectedIndex] = "<Already in preset>";
            return new KeyValuePair<BCAMEntry, int>(val, index);
        }

        public void RecieveStolenCamera(KeyValuePair<BCAMEntry, int> Input)
        {
            Cameras[Input.Value] = Input.Key;
            CameraListBox.Items[Input.Value] = Input.Key.GetTranslatedName();
        }

        public void CancelPreset(List<KeyValuePair<BCAMEntry, int>> Cams)
        {
            MainSplitContainer.Panel2.Controls.Clear();
            for (int i = 0; i < Cams.Count; i++)
                RecieveStolenCamera(Cams[i]);
            ReloadCameraListBox();

            PreBufferedCreator.Cameras = new List<KeyValuePair<BCAMEntry, int>>();
        }

        #region Form Functions
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ((CameraPanelBase)MainSplitContainer.Panel2.Controls[0]).UpdateID(PreBufferedAssistant.GetID);
            Console.WriteLine("ID Assistance applied");
        }

        private void CameraListBox_KeyDown(object sender, KeyEventArgs e)
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
                AddNewFromClipboardToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                AddDefaultCameraToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                DeleteCameraToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.Home)
            {
                e.SuppressKeyPress = true;
                MoveToTopToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.End)
            {
                e.SuppressKeyPress = true;
                MoveToBottomToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.PageUp)
            {
                e.SuppressKeyPress = true;
                MoveUpToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.PageDown)
            {
                e.SuppressKeyPress = true;
                MoveDownToolStripMenuItem_Click(null, null);
            }
        }

        private void Panel2_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control == PreBufferedCreator)
            {
                CancelPreset(PreBufferedCreator.Cameras);
                PreBufferedCreator.Reset();

                EditToolStripMenuItem.Enabled = true;
                for (int i = 0; i < EditToolStripMenuItem.DropDownItems.Count; i++)
                    EditToolStripMenuItem.DropDownItems[i].Enabled = true;
                AddCameraToolStripMenuItem.Enabled = true;
                PresetsToolStripMenuItem.Enabled = true;
                AutoSortToolStripMenuItem.Enabled = true;
            }
        }

        private void CameraEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
            //Put the Unsaved Changes code here...once it comes time to write that
        }
        #endregion

        #region MenuStrip Managers
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }

            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                if (e.Item is ToolStripMenuItem)
                    e.ArrowColor = ProgramColours.TextColour;
                base.OnRenderArrow(e);
            }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color ButtonSelectedHighlight => Color.Black;

            public override Color ButtonSelectedHighlightBorder => Color.Black;

            public override Color ButtonPressedHighlight => Color.Black;

            public override Color ButtonPressedHighlightBorder => Color.Black;

            public override Color ButtonCheckedHighlight => Color.Black;

            public override Color ButtonCheckedHighlightBorder => Color.Black;

            public override Color ButtonPressedBorder => Color.Black;

            public override Color ButtonSelectedBorder => Color.Black;

            public override Color ButtonCheckedGradientBegin => Color.Black;

            public override Color ButtonCheckedGradientMiddle => Color.Black;

            public override Color ButtonCheckedGradientEnd => Color.Black;

            public override Color ButtonSelectedGradientBegin => Color.Black;

            public override Color ButtonSelectedGradientMiddle => Color.Black;

            public override Color ButtonSelectedGradientEnd => Color.Black;

            public override Color ButtonPressedGradientBegin => Color.Black;

            public override Color ButtonPressedGradientMiddle => Color.Black;

            public override Color ButtonPressedGradientEnd => Color.Black;

            public override Color CheckBackground => Color.Black;

            public override Color CheckSelectedBackground => Color.Black;

            public override Color CheckPressedBackground => Color.Black;

            public override Color GripDark => Color.Black;

            public override Color GripLight => Color.Black;

            public override Color ImageMarginGradientBegin => Color.Black;

            public override Color ImageMarginGradientMiddle => Color.Black;

            public override Color ImageMarginGradientEnd => Color.Black;

            public override Color ImageMarginRevealedGradientBegin => Color.Black;

            public override Color ImageMarginRevealedGradientMiddle => Color.Black;

            public override Color ImageMarginRevealedGradientEnd => Color.Black;

            public override Color MenuStripGradientBegin => Color.Black;

            public override Color MenuStripGradientEnd => Color.Black;

            public override Color MenuItemSelected => Color.Black;

            public override Color MenuItemBorder => Color.Black;

            public override Color MenuBorder => Color.Black;

            public override Color MenuItemSelectedGradientBegin => Color.Black;

            public override Color MenuItemSelectedGradientEnd => Color.Black;

            public override Color MenuItemPressedGradientBegin => Color.Black;

            public override Color MenuItemPressedGradientMiddle => Color.White;

            public override Color MenuItemPressedGradientEnd => Color.Black;

            public override Color RaftingContainerGradientBegin => Color.Black;

            public override Color RaftingContainerGradientEnd => Color.Black;

            public override Color SeparatorDark => Color.Black;

            public override Color SeparatorLight => Color.Black;

            public override Color StatusStripGradientBegin => Color.Black;

            public override Color StatusStripGradientEnd => Color.Black;

            public override Color ToolStripBorder => Color.Black;

            public override Color ToolStripDropDownBackground => Color.Black;

            public override Color ToolStripGradientBegin => Color.Black;

            public override Color ToolStripGradientMiddle => Color.Black;

            public override Color ToolStripGradientEnd => Color.Black;

            public override Color ToolStripContentPanelGradientBegin => Color.Black;

            public override Color ToolStripContentPanelGradientEnd => Color.Black;

            public override Color ToolStripPanelGradientBegin => Color.Black;

            public override Color ToolStripPanelGradientEnd => Color.Black;

            public override Color OverflowButtonGradientBegin => Color.Black;

            public override Color OverflowButtonGradientMiddle => Color.Black;

            public override Color OverflowButtonGradientEnd => Color.Black;
        }
        #endregion
    }

    public static class ControlEx
    {
        [DebuggerStepThrough]
        public static void SetDoubleBuffered(this Control control)
        {
            // set instance non-public property with name "DoubleBuffered" to true
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
    }
}
