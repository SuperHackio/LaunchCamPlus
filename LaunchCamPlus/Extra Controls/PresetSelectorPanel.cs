using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Hackio.IO.BCAM;

namespace LaunchCamPlus
{
    public partial class PresetSelectorPanel : UserControl
    {
        public PresetSelectorPanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void PresetPanel_Load(object sender, EventArgs e)
        {
            GenerateTreeview(Program.PresetPath);
        }

        public void ReloadTheme()
        {
            ForeColor =
                PresetsTreeView.ForeColor =
                PresetsTreeView.LineColor =
                SelectButton.ForeColor =
                RefreshButton.ForeColor = ProgramColours.TextColour;
            PresetsTreeView.BackColor = ProgramColours.WindowColour;
            SelectButton.BackColor = RefreshButton.BackColor = ProgramColours.ControlBackColor;
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
            Program.PresetSelectorNeedsReload = false;
        }

        private void PresetsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectButton.Enabled = !(PresetsTreeView.SelectedNode is null || !(PresetsTreeView.SelectedNode.Tag is FileInfo));
            SelectButton.Text = SelectButton.Enabled ? "Add " + PresetsTreeView.SelectedNode?.Text : "Select a preset to add";
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (((CameraEditorForm)ParentForm).Cameras == null)
            {
                Console.WriteLine(Program.ConsoleHalfSplitter);
                Console.WriteLine("Failed to add the preset!\nNo camera file is active");
                Console.WriteLine(Program.ConsoleHalfSplitter);
                return;
            }
            try
            {
                string full = ((FileInfo)PresetsTreeView.SelectedNode.Tag).FullName;
                if(!File.Exists(full))
                {
                    PresetsTreeView.SelectedNode.Remove();
                    throw new FileNotFoundException($"Could not find file '{full}'.");
                }
                Console.WriteLine("Loading preset...");
                LCPP CurrentPreset = new LCPP(full);
                for (int i = 0; i < CurrentPreset.Count; i++)
                {
                    BCAMEntry entry = new BCAMEntry();
                    entry.FromClipboard(CurrentPreset[i]);
                    ((CameraEditorForm)ParentForm).AddCamera(entry);
                    Console.Write($"\r{Math.Min(((float)(i + 1) / (float)CurrentPreset.Count) * 100.0f, 100.0f)}%          ");
                }
                Console.WriteLine();
                Console.WriteLine("Preset loaded successfully!");
                if (CurrentPreset.Count == 0)
                    Console.WriteLine("(Though the preset has no cameras...)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(Program.ConsoleHalfSplitter);
                Console.WriteLine("Preset Failed to load!\n" + ex.GetType().FullName+": "+ex.Message);
                Console.WriteLine(Program.ConsoleHalfSplitter);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            GenerateTreeview(Program.PresetPath);
            Program.PresetCreatorNeedsReload = true;
        }
    }
}
