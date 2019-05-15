using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cameras;
using LCPPManager;
using LCPCManager;

namespace LaunchCamPlus
{
    public partial class PresetForm : Form
    {
        public PresetForm(List<Camera> CamList)
        {
            InitializeComponent();
            CenterToParent();
            CameraList = new List<Camera>(CamList);
            foreach (Camera C in CameraList)
            {
                CameraListBox.Items.Add(C.Identification);
            }
            CameraListBox.SelectedIndex = 0;
            AddCamButton.Enabled = true;
            RemoveCamButton.Enabled = false;

            PresetNameTextBox.Text = "My Preset";
            PresetCreatorTextBox.Text = "Me";
        }

        SaveFileDialog psfd = new SaveFileDialog() { Filter = "Camera Preset |*.lcpp|Compressed Camera Preset |*.lcpc" }; //presets
        List<Camera> CameraList;
        List<Camera> PresetList = new List<Camera>();

        bool looping = false;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            psfd.FilterIndex = 1;
            psfd.FileName = "";
            psfd.ShowDialog();

            if (psfd.FileName != "")
            {
                if (psfd.FilterIndex != 1)
                {
                    new LCPP(psfd.FileName.Replace(".lcpc",".lcpp"), PresetList, PresetNameTextBox.Text, PresetCreatorTextBox.Text);
                    new LCPC(psfd.FileName.Replace(".lcpc",".lcpp"));
                    System.IO.File.Delete(psfd.FileName.Replace(".lcpc", ".lcpp"));
                }
                else
                {
                    new LCPP(psfd.FileName, PresetList, PresetNameTextBox.Text, PresetCreatorTextBox.Text);
                }
                Close();
            }
        }

        private void AddCamButton_Click(object sender, EventArgs e)
        {
            PresetList.Add(CameraList[CameraListBox.SelectedIndex]);
            PresetListBox.Items.Add(CameraList[CameraListBox.SelectedIndex].Identification);
            SaveButton.Enabled = true;
            RemoveCamButton.Enabled = true;
            if (PresetListBox.SelectedIndex < 0)
            {
                PresetListBox.SelectedIndex = 0;
            }

            CameraList.RemoveAt(CameraListBox.SelectedIndex);
            CameraListBox.Items.RemoveAt(CameraListBox.SelectedIndex);

            if (CameraList.Count == 0)
            {
                AddCamButton.Enabled = false;
            }

            if (CameraListBox.SelectedIndex < 0 && CameraList.Count != 0)
            {
                CameraListBox.SelectedIndex = 0;
            }
            else if(CameraList.Count != 0)
            {
                CameraListBox.SelectedIndex--;
            }
        }

        private void RemoveCamButton_Click(object sender, EventArgs e)
        {
            CameraListBox.Items.Add(PresetList[PresetListBox.SelectedIndex].Identification);
            CameraList.Add(PresetList[PresetListBox.SelectedIndex]);
            PresetList.RemoveAt(PresetListBox.SelectedIndex);
            PresetListBox.Items.RemoveAt(PresetListBox.SelectedIndex);
            if (PresetList.Count == 0)
            {
                SaveButton.Enabled = false;
                RemoveCamButton.Enabled = false;
            }
            AddCamButton.Enabled = true;
            if (PresetListBox.SelectedIndex < 0 && PresetList.Count != 0)
            {
                PresetListBox.SelectedIndex = 0;
            }
            else if(PresetList.Count != 0)
            {
                PresetListBox.SelectedIndex--;
            }
        }

        private void PresetNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!looping)
            {
                if (System.Text.Encoding.GetEncoding(932).GetBytes(PresetNameTextBox.Text).Length > 64)
                {
                    MessageBox.Show("Limit is 64 bytes","Encoder Overload");
                    while (System.Text.Encoding.GetEncoding(932).GetBytes(PresetNameTextBox.Text).Length > 64)
                    {
                        looping = true;
                        PresetNameTextBox.Text = PresetNameTextBox.Text.Remove(PresetNameTextBox.Text.Length - 1, 1);
                    }
                    looping = false;
                }
            }
        }

        private void PresetCreatorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!looping)
            {
                if (System.Text.Encoding.GetEncoding(932).GetBytes(PresetCreatorTextBox.Text).Length > 64)
                {
                    MessageBox.Show("Limit is 64 bytes", "Encoder Overload");
                    while (System.Text.Encoding.GetEncoding(932).GetBytes(PresetCreatorTextBox.Text).Length > 64)
                    {
                        looping = true;
                        PresetCreatorTextBox.Text = PresetCreatorTextBox.Text.Remove(PresetCreatorTextBox.Text.Length - 1, 1);
                    }
                    looping = false;
                }
            }
        }
    }
}
