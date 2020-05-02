using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Hackio.IO.BCAM;

namespace LaunchCamPlus
{
    public partial class PresetCreatorPanel : UserControl
    {
        public PresetCreatorPanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            loading = true;
            PresetCreatorTextBox.Text = Properties.Settings.Default.CreatorNameLast;
            loading = false;
        }

        private void PresetCreatorPanel_Load(object sender, EventArgs e)
        {
            GenerateTreeview(Program.PresetPath);
        }

        public List<KeyValuePair<BCAMEntry, int>> Cameras = new List<KeyValuePair<BCAMEntry, int>>();
        private string PreviousFilename;
        private string PreviousPresetname;
        private bool setprev = true;
        private bool loading = false;

        public void ReloadTheme()
        {
            ForeColor =
                PresetsTreeView.ForeColor =
                PresetsTreeView.LineColor =
                PresetListBox.ForeColor =
                PresetNameTextBox.ForeColor = 
                PresetCreatorTextBox.ForeColor =
                FilenameTextBox.ForeColor = ProgramColours.TextColour;
            PresetsTreeView.BackColor = 
                PresetNameTextBox.BackColor =
                PresetCreatorTextBox.BackColor =
                FilenameTextBox.BackColor =
                PresetListBox.BackColor = ProgramColours.WindowColour;
            SavePresetButton.BackColor = ProgramColours.ControlBackColor;
        }

        public void Reset()
        {
            PresetListBox.Items.Clear();
            GenerateTreeview(Program.GetFromAppPath("Presets"));
        }

        public void GenerateTreeview(string FolderPath)
        {
            PresetsTreeView.Nodes.Clear();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            DirectoryInfo rootDirectory = new DirectoryInfo(FolderPath);
            TreeNode node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory, ImageIndex = 1, SelectedImageIndex = 1 };
            stack.Push(node);

            while (stack.Count > 0)
            {
                TreeNode currentNode = stack.Pop();
                DirectoryInfo directoryInfo = (DirectoryInfo)currentNode.Tag;
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                foreach (DirectoryInfo directory in directories)
                {
                    TreeNode childDirectoryNode = new TreeNode(directory.Name) { Tag = directory, ImageIndex = 1, SelectedImageIndex = 1 };
                    currentNode.Nodes.Add(childDirectoryNode);
                    stack.Push(childDirectoryNode);
                }
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    switch (file.Extension)
                    {
                        case ".lcpp":
                            try
                            {
                                LCPP CurrentPreset = new LCPP(file.FullName);
                                currentNode.Nodes.Add(new TreeNode($"\"{CurrentPreset.Name}\" by {CurrentPreset.Creator} ({file.Name})") { Tag = file, ImageIndex = 0, SelectedImageIndex = 0 });
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error Loading {file.Name}\n{e.Message}");
                                Console.WriteLine();
                                Console.WriteLine("Skipping...");
                            }
                            break;
                        case ".lcpb":
                            break;
                    }
                }
            }

            PresetsTreeView.Nodes.Add(node);
            PresetsTreeView.ExpandAll();
            Program.PresetCreatorNeedsReload = false;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            ((CameraEditorForm)ParentForm).CancelPreset(Cameras);
        }

        private void PresetsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (PresetsTreeView.SelectedNode?.Tag is FileInfo fi)
            {
                if (setprev)
                {
                    PreviousFilename = FilenameTextBox.Text;
                    PreviousPresetname = PresetNameTextBox.Text;
                    setprev = false;
                }
                FilenameTextBox.Text = fi.Name.Replace(fi.Extension, "");
                PresetNameTextBox.Text = PresetsTreeView.SelectedNode.Text.Split('"')[1];
                SavePresetButton.Text = "Save Preset as "+fi.Name;
                SavePresetButton.Enabled = true;
            }
            else if (PresetsTreeView.SelectedNode?.Tag is DirectoryInfo di)
            {
                if (!setprev)
                {
                    FilenameTextBox.Text = PreviousFilename;
                    PresetNameTextBox.Text = PreviousPresetname;
                    PreviousFilename = "";
                    PreviousPresetname = "";
                    setprev = true;
                }
                SavePresetButton.Text = "Save Preset in " + di.Name;
                SavePresetButton.Enabled = true;
            }
            else
            {
                if (!setprev)
                {
                    FilenameTextBox.Text = PreviousFilename;
                    PresetNameTextBox.Text = PreviousPresetname;
                    PreviousFilename = "";
                    PreviousPresetname = "";
                    setprev = true;
                }
                SavePresetButton.Text = "Save";
                SavePresetButton.Enabled = false;
            }
        }

        private void AddCameraButton_Click(object sender, EventArgs e)
        {
            KeyValuePair<BCAMEntry, int> StolenCamera = ((CameraEditorForm)ParentForm).StealSelected();
            if (StolenCamera.Key is null)
                return;

            Cameras.Add(StolenCamera);
            PresetListBox.Items.Add(StolenCamera.Key.GetTranslatedName());
        }

        private void RemoveCameraButton_Click(object sender, EventArgs e)
        {
            if (PresetListBox.SelectedIndex == -1)
                return;
            ((CameraEditorForm)ParentForm).RecieveStolenCamera(Cameras[PresetListBox.SelectedIndex]);
            Cameras.RemoveAt(PresetListBox.SelectedIndex);
            PresetListBox.Items.RemoveAt(PresetListBox.SelectedIndex);
        }

        private void SavePresetButton_Click(object sender, EventArgs e)
        {
            FilenameTextBox.Text = FilenameTextBox.Text.Replace(".lcpp","");
            if (FilenameTextBox.Text.Length == 0)
            {
                Console.WriteLine("File name is empty!\nPlease give a name to the file");
                return;
            }

            if (PresetsTreeView.SelectedNode?.Tag is FileInfo fi)
            {
                if (MessageBox.Show("Will you overwrite the existing file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LCPP OutFile = new LCPP() { Name = PresetNameTextBox.Text, Creator = PresetCreatorTextBox.Text };
                    for (int i = 0; i < Cameras.Count; i++)
                        OutFile.Add(Cameras[i].Key);

                    OutFile.Save(fi.FullName, Properties.Settings.Default.IsCompressPresets);
                    Console.WriteLine("Preset Saved!");
                }
            }
            else if (PresetsTreeView.SelectedNode?.Tag is DirectoryInfo di)
            {
                if (di.GetFiles().Any(O => O.Name.Equals(FilenameTextBox.Text+".lcpp")))
                {
                    if (MessageBox.Show("Will you overwrite the existing file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                }
                LCPP OutFile = new LCPP() { Name = PresetNameTextBox.Text, Creator = PresetCreatorTextBox.Text };
                for (int i = 0; i < Cameras.Count; i++)
                    OutFile.Add(Cameras[i].Key);

                OutFile.Save(Path.Combine(di.FullName, FilenameTextBox.Text+".lcpp"), Properties.Settings.Default.IsCompressPresets);
                Console.WriteLine("Preset Saved!");
            }

            GenerateTreeview(Program.PresetPath);
            Program.PresetSelectorNeedsReload = true;
        }

        private void PresetCreatorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            Properties.Settings.Default.CreatorNameLast = PresetCreatorTextBox.Text;
        }
    }
}
