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
using LaunchCamPlus.Formats;
using LaunchCamPlus.ExtraControls;

namespace LaunchCamPlus
{
    public partial class PresetCreatorPanel : UserControl, IReloadTheme
    {
        public PresetCreatorPanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            loading = true;
            PresetCreatorTextBox.Text = Program.Settings.CreatorName;
            loading = false;
        }

        private void PresetCreatorPanel_Load(object sender, EventArgs e)
        {
            GenerateTreeview(Program.PRESETS_PATH);
        }

        public List<KeyValuePair<BCAM.Entry, int>> Cameras = [];
        private string? PreviousFilename;
        private string? PreviousPresetname;
        private bool setprev = true;
        private readonly bool loading = false;

        public void ReloadTheme() => ControlEx.ReloadTheme(this);

        public void Reset()
        {
            PresetListBox.Items.Clear();
            GenerateTreeview(Program.PRESETS_PATH);
        }

        public void GenerateTreeview(string FolderPath)
        {
            PresetsTreeView.Nodes.Clear();

            Stack<TreeNode> stack = new();
            DirectoryInfo rootDirectory = new(FolderPath);
            TreeNode node = new(rootDirectory.Name) { Tag = rootDirectory, ImageIndex = 1, SelectedImageIndex = 1 };
            stack.Push(node);

            while (stack.Count > 0)
            {
                TreeNode currentNode = stack.Pop();
                DirectoryInfo directoryInfo = (DirectoryInfo)currentNode.Tag;
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                foreach (DirectoryInfo directory in directories)
                {
                    TreeNode childDirectoryNode = new(directory.Name) { Tag = directory, ImageIndex = 1, SelectedImageIndex = 1 };
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
                                LCPP CurrentPreset = new(file.FullName);
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

        public bool ContainsCamera(BCAM.Entry target)
        {
            for (int i = 0; i < Cameras.Count; i++)
            {
                if (ReferenceEquals(target, Cameras[i].Key))
                    return true;
            }
            return false;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            if (ParentForm is not null)
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
                SavePresetButton.Text = "Save Preset as " + fi.Name;
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
            if (ParentForm is null)
                return;

            KeyValuePair<BCAM.Entry, int>? StolenCamera = ((CameraEditorForm)ParentForm).StealSelected();
            if (StolenCamera is null)
                return;

            Cameras.Add(StolenCamera.Value);
            PresetListBox.Items.Add(StolenCamera.Value.Key.GetTranslatedName());
        }

        private void RemoveCameraButton_Click(object sender, EventArgs e)
        {
            if (PresetListBox.SelectedIndex == -1 || ParentForm is null)
                return;
            ((CameraEditorForm)ParentForm).RecieveStolenCamera(Cameras[PresetListBox.SelectedIndex]);
            Cameras.RemoveAt(PresetListBox.SelectedIndex);
            PresetListBox.Items.RemoveAt(PresetListBox.SelectedIndex);
        }

        private void SavePresetButton_Click(object sender, EventArgs e)
        {
            FilenameTextBox.Text = FilenameTextBox.Text.Replace(".lcpp", "");
            if (FilenameTextBox.Text.Length == 0)
            {
                Console.WriteLine("File name is empty!\nPlease give a name to the file");
                return;
            }

            if (PresetsTreeView.SelectedNode?.Tag is FileInfo fi)
            {
                if (MessageBox.Show("Will you overwrite the existing file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LCPP OutFile = new() { Name = PresetNameTextBox.Text, Creator = PresetCreatorTextBox.Text };
                    for (int i = 0; i < Cameras.Count; i++)
                        OutFile.Add(Cameras[i].Key);

                    OutFile.Save(fi.FullName, null);
                    Console.WriteLine("Preset Saved!");
                }
            }
            else if (PresetsTreeView.SelectedNode?.Tag is DirectoryInfo di)
            {
                if (di.GetFiles().Any(O => O.Name.Equals(FilenameTextBox.Text + ".lcpp")))
                {
                    if (MessageBox.Show("Will you overwrite the existing file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                }
                LCPP OutFile = new() { Name = PresetNameTextBox.Text, Creator = PresetCreatorTextBox.Text };
                for (int i = 0; i < Cameras.Count; i++)
                    OutFile.Add(Cameras[i].Key);

                OutFile.Save(Path.Combine(di.FullName, FilenameTextBox.Text + ".lcpp"), null);
                Console.WriteLine("Preset Saved!");
            }

            GenerateTreeview(Program.PRESETS_PATH);
            Program.PresetSelectorNeedsReload = true;
        }

        private void PresetCreatorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            Program.Settings.CreatorName = PresetCreatorTextBox.Text;
        }
    }
}
