using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CANMFiles;

namespace LaunchCamPlus
{
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        OpenFileDialog ofd = new OpenFileDialog() { Filter = "Camera Keyframes (*.canm)|*.canm" };
        SaveFileDialog sfd = new SaveFileDialog() { Filter = "Camera Keyframes (*.canm)|*.canm" };
        CANM canm;
        bool Loading = false;



        public void SetAppStatus(bool trigger)
        {
            XPosComboBox.Enabled = trigger;
            YPosComboBox.Enabled = trigger;
            ZPosComboBox.Enabled = trigger;
            XDirComboBox.Enabled = trigger;
            YDirComboBox.Enabled = trigger; 
            ZDirComboBox.Enabled = trigger;
            UnknownComboBox.Enabled = trigger;
            ZoomComboBox.Enabled = trigger;

            XPosTimeNumericUpDown.Enabled = trigger;
            YPosTimeNumericUpDown.Enabled = trigger;
            ZPosTimeNumericUpDown.Enabled = trigger;
            XDirTimeNumericUpDown.Enabled = trigger;
            YDirTimeNumericUpDown.Enabled = trigger;
            ZDirTimeNumericUpDown.Enabled = trigger;
            UnknownTimeNumericUpDown.Enabled = trigger;
            ZoomTimeNumericUpDown.Enabled = trigger;

            XPosValueNumericUpDown.Enabled = trigger;
            YPosValueNumericUpDown.Enabled = trigger;
            ZPosValueNumericUpDown.Enabled = trigger;
            XDirValueNumericUpDown.Enabled = trigger;
            YDirValueNumericUpDown.Enabled = trigger;
            ZDirValueNumericUpDown.Enabled = trigger;
            UnknownValueNumericUpDown.Enabled = trigger;
            ZoomValueNumericUpDown.Enabled = trigger;

            XPosVelocityNumericUpDown.Enabled = trigger;
            YPosVelocityNumericUpDown.Enabled = trigger;
            ZPosVelocityNumericUpDown.Enabled = trigger;
            XDirVelocityNumericUpDown.Enabled = trigger;
            YDirVelocityNumericUpDown.Enabled = trigger;
            ZDirVelocityNumericUpDown.Enabled = trigger;
            UnknownVelocityNumericUpDown.Enabled = trigger;
            ZoomVelocityNumericUpDown.Enabled = trigger;

            AddXPosButton.Enabled = trigger;
            RemoveXPosButton.Enabled = trigger;
            AddYPosButton.Enabled = trigger;
            RemoveYPosButton.Enabled = trigger;
            AddZPosButton.Enabled = trigger;
            RemoveZPosButton.Enabled = trigger;
            AddXDirButton.Enabled = trigger;
            RemoveXDirButton.Enabled = trigger;
            AddYDirButton.Enabled = trigger;
            RemoveYDirButton.Enabled = trigger;
            AddZDirButton.Enabled = trigger;
            RemoveZDirButton.Enabled = trigger;
            AddUnknownButton.Enabled = trigger;
            RemoveUnknownButton.Enabled = trigger;
            AddZoomButton.Enabled = trigger;
            RemoveZoomButton.Enabled = trigger;

            SaveToolStripMenuItem.Enabled = trigger;

            if (trigger)
            {
                ScanTimer.Start();
            }
            else
            {
                ScanTimer.Stop();
            }
        }


        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.FilterIndex = 1;
            ofd.FileName = "";

            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                XPosComboBox.Items.Clear();
                YPosComboBox.Items.Clear();
                ZPosComboBox.Items.Clear();
                XDirComboBox.Items.Clear();
                YDirComboBox.Items.Clear();
                ZDirComboBox.Items.Clear();
                UnknownComboBox.Items.Clear();
                ZoomComboBox.Items.Clear();
                FileStream canmFile = new FileStream(ofd.FileName,FileMode.Open);
                canm = null;
                canm = new CANM(canmFile);
                canmFile.Close();

                for (int i = 0; i < canm.Keys[0].KeyframeCount; i++)
                {
                    XPosComboBox.Items.Add("Keyframe "+i);
                }
                XPosComboBox.SelectedIndex = 0;
                for (int i = 0; i < canm.Keys[1].KeyframeCount; i++)
                {
                    YPosComboBox.Items.Add("Keyframe " + i);
                }
                YPosComboBox.SelectedIndex = 0;
                for (int i = 0; i < canm.Keys[2].KeyframeCount; i++)
                {
                    ZPosComboBox.Items.Add("Keyframe " + i);
                }
                ZPosComboBox.SelectedIndex = 0;


                for (int i = 0; i < canm.Keys[3].KeyframeCount; i++)
                {
                    XDirComboBox.Items.Add("Keyframe " + i);
                }
                XDirComboBox.SelectedIndex = 0;
                for (int i = 0; i < canm.Keys[4].KeyframeCount; i++)
                {
                    YDirComboBox.Items.Add("Keyframe " + i);
                }
                YDirComboBox.SelectedIndex = 0;
                for (int i = 0; i < canm.Keys[5].KeyframeCount; i++)
                {
                    ZDirComboBox.Items.Add("Keyframe " + i);
                }
                ZDirComboBox.SelectedIndex = 0;

                for (int i = 0; i < canm.Keys[6].KeyframeCount; i++)
                {
                    UnknownComboBox.Items.Add("Keyframe " + i);
                }
                UnknownComboBox.SelectedIndex = 0;
                for (int i = 0; i < canm.Keys[7].KeyframeCount; i++)
                {
                    ZoomComboBox.Items.Add("Keyframe " + i);
                }
                ZoomComboBox.SelectedIndex = 0;

                SetAppStatus(true);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < canm.Keys.Count; i++)
            {
                canm.Keys[i].KeyframeCount = canm.Keys[i].Keyframes.Count;
            }

            sfd.FilterIndex = 1;
            sfd.FileName = "";

            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                FileStream canmFile = new FileStream(sfd.FileName, FileMode.Create);
                canm.Write(canmFile);
                canmFile.Close();
            }
        }

        #region Editing
        private void XPosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loading = true;
            XPosTimeNumericUpDown.Value = (decimal)canm.Keys[0].Keyframes[XPosComboBox.SelectedIndex].Time;
            XPosValueNumericUpDown.Value = (decimal)canm.Keys[0].Keyframes[XPosComboBox.SelectedIndex].Value;
            XPosVelocityNumericUpDown.Value = (decimal)canm.Keys[0].Keyframes[XPosComboBox.SelectedIndex].Velocity;
            Loading = false;
        }

        private void YPosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loading = true;
            YPosTimeNumericUpDown.Value = (decimal)canm.Keys[1].Keyframes[YPosComboBox.SelectedIndex].Time;
            YPosValueNumericUpDown.Value = (decimal)canm.Keys[1].Keyframes[YPosComboBox.SelectedIndex].Value;
            YPosVelocityNumericUpDown.Value = (decimal)canm.Keys[1].Keyframes[YPosComboBox.SelectedIndex].Velocity;
            Loading = false;
        }

        private void ZPosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loading = true;
            ZPosTimeNumericUpDown.Value = (decimal)canm.Keys[2].Keyframes[ZPosComboBox.SelectedIndex].Time;
            ZPosValueNumericUpDown.Value = (decimal)canm.Keys[2].Keyframes[ZPosComboBox.SelectedIndex].Value;
            ZPosVelocityNumericUpDown.Value = (decimal)canm.Keys[2].Keyframes[ZPosComboBox.SelectedIndex].Velocity;
            Loading = false;
        }

        private void XDirComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loading = true;
            XDirTimeNumericUpDown.Value = (decimal)canm.Keys[3].Keyframes[XDirComboBox.SelectedIndex].Time;
            XDirValueNumericUpDown.Value = (decimal)canm.Keys[3].Keyframes[XDirComboBox.SelectedIndex].Value;
            XDirVelocityNumericUpDown.Value = (decimal)canm.Keys[3].Keyframes[XDirComboBox.SelectedIndex].Velocity;
            Loading = false;
        }

        private void YDirComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loading = true;
            YDirTimeNumericUpDown.Value = (decimal)canm.Keys[4].Keyframes[YDirComboBox.SelectedIndex].Time;
            YDirValueNumericUpDown.Value = (decimal)canm.Keys[4].Keyframes[YDirComboBox.SelectedIndex].Value;
            YDirVelocityNumericUpDown.Value = (decimal)canm.Keys[4].Keyframes[YDirComboBox.SelectedIndex].Velocity;
            Loading = false;
        }

        private void ZDirComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loading = true;
            ZDirTimeNumericUpDown.Value = (decimal)canm.Keys[5].Keyframes[ZDirComboBox.SelectedIndex].Time;
            ZDirValueNumericUpDown.Value = (decimal)canm.Keys[5].Keyframes[ZDirComboBox.SelectedIndex].Value;
            ZDirVelocityNumericUpDown.Value = (decimal)canm.Keys[5].Keyframes[ZDirComboBox.SelectedIndex].Velocity;
            Loading = false;
        }

        private void UnknownComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loading = true;
            UnknownTimeNumericUpDown.Value = (decimal)canm.Keys[6].Keyframes[UnknownComboBox.SelectedIndex].Time;
            UnknownValueNumericUpDown.Value = (decimal)canm.Keys[6].Keyframes[UnknownComboBox.SelectedIndex].Value;
            UnknownVelocityNumericUpDown.Value = (decimal)canm.Keys[6].Keyframes[UnknownComboBox.SelectedIndex].Velocity;
            Loading = false;
        }

        private void ZoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loading = true;
            ZoomTimeNumericUpDown.Value = (decimal)canm.Keys[7].Keyframes[ZoomComboBox.SelectedIndex].Time;
            ZoomValueNumericUpDown.Value = (decimal)canm.Keys[7].Keyframes[ZoomComboBox.SelectedIndex].Value;
            ZoomVelocityNumericUpDown.Value = (decimal)canm.Keys[7].Keyframes[ZoomComboBox.SelectedIndex].Velocity;
            Loading = false;
        }

        private void XPosTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[0].Keyframes[XPosComboBox.SelectedIndex].Time = (float)XPosTimeNumericUpDown.Value;
            }
        }

        private void XPosValueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[0].Keyframes[XPosComboBox.SelectedIndex].Value = (float)XPosValueNumericUpDown.Value;
            }
        }

        private void XPosVelocityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[0].Keyframes[XPosComboBox.SelectedIndex].Velocity = (float)XPosVelocityNumericUpDown.Value;
            }
        }

        private void YPosTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[1].Keyframes[YPosComboBox.SelectedIndex].Time = (float)YPosTimeNumericUpDown.Value;
            }
        }

        private void YPosValueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[1].Keyframes[YPosComboBox.SelectedIndex].Value = (float)YPosValueNumericUpDown.Value;
            }
        }

        private void YPosVelocityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[1].Keyframes[YPosComboBox.SelectedIndex].Velocity = (float)YPosVelocityNumericUpDown.Value;
            }
        }

        private void ZPosTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[2].Keyframes[ZPosComboBox.SelectedIndex].Time = (float)ZPosTimeNumericUpDown.Value;
            }
        }

        private void ZPosValueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[2].Keyframes[ZPosComboBox.SelectedIndex].Value = (float)ZPosValueNumericUpDown.Value;
            }
        }

        private void ZPosVelocityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[2].Keyframes[ZPosComboBox.SelectedIndex].Velocity = (float)ZPosVelocityNumericUpDown.Value;
            }
        }

        private void XDirTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[3].Keyframes[XDirComboBox.SelectedIndex].Time = (float)XDirTimeNumericUpDown.Value;
            }
        }

        private void XDirValueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[3].Keyframes[XDirComboBox.SelectedIndex].Value = (float)XDirValueNumericUpDown.Value;
            }
        }

        private void XDirVelocityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[3].Keyframes[XDirComboBox.SelectedIndex].Velocity = (float)XDirVelocityNumericUpDown.Value;
            }
        }

        private void YDirTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[4].Keyframes[YDirComboBox.SelectedIndex].Time = (float)YDirTimeNumericUpDown.Value;
            }
        }

        private void YDirValueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[4].Keyframes[YDirComboBox.SelectedIndex].Value = (float)YDirValueNumericUpDown.Value;
            }
        }

        private void YDirVelocityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[4].Keyframes[YDirComboBox.SelectedIndex].Velocity = (float)YDirVelocityNumericUpDown.Value;
            }
        }

        private void ZDirTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[5].Keyframes[ZDirComboBox.SelectedIndex].Time = (float)ZDirTimeNumericUpDown.Value;
            }
        }

        private void ZDirValueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[5].Keyframes[ZDirComboBox.SelectedIndex].Value = (float)ZDirValueNumericUpDown.Value;
            }
        }

        private void ZDirVelocityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[5].Keyframes[ZDirComboBox.SelectedIndex].Velocity = (float)ZDirVelocityNumericUpDown.Value;
            }
        }

        private void UnknownTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[6].Keyframes[UnknownComboBox.SelectedIndex].Time = (float)UnknownTimeNumericUpDown.Value;
            }
        }

        private void UnknownValueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[6].Keyframes[UnknownComboBox.SelectedIndex].Value = (float)UnknownValueNumericUpDown.Value;
            }
        }

        private void UnknownVelocityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[6].Keyframes[UnknownComboBox.SelectedIndex].Velocity = (float)UnknownVelocityNumericUpDown.Value;
            }
        }

        private void ZoomTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[7].Keyframes[ZoomComboBox.SelectedIndex].Time = (float)ZoomTimeNumericUpDown.Value;
            }
        }

        private void ZoomValueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[7].Keyframes[ZoomComboBox.SelectedIndex].Value = (float)ZoomValueNumericUpDown.Value;
            }
        }

        private void ZoomVelocityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                canm.Keys[7].Keyframes[ZoomComboBox.SelectedIndex].Velocity = (float)ZoomVelocityNumericUpDown.Value;
            }
        }
        #endregion

        #region Adding/Removing
        private void AddXPosButton_Click(object sender, EventArgs e)
        {
            canm.Keys[0].Keyframes.Add(new Keyframe());
            XPosComboBox.Items.Add("Keyframe " + XPosComboBox.Items.Count);
        }

        private void RemoveXPosButton_Click(object sender, EventArgs e)
        {
            int tmp = XPosComboBox.SelectedIndex;
            canm.Keys[0].Keyframes.RemoveAt(XPosComboBox.SelectedIndex);
            XPosComboBox.Items.RemoveAt(XPosComboBox.SelectedIndex);
            if (tmp == 0)
            {
                XPosComboBox.SelectedIndex = 0;
            }
            else
            {
                XPosComboBox.SelectedIndex = tmp - 1;
            }
            for (int i = 0; i < XPosComboBox.Items.Count; i++)
            {
                XPosComboBox.Items[i] = "Keyframe " + i;
            }
        }

        private void AddYPosButton_Click(object sender, EventArgs e)
        {
            canm.Keys[1].Keyframes.Add(new Keyframe());
            YPosComboBox.Items.Add("Keyframe " + YPosComboBox.Items.Count);
        }

        private void RemoveYPosButton_Click(object sender, EventArgs e)
        {
            int tmp = YPosComboBox.SelectedIndex;
            canm.Keys[1].Keyframes.RemoveAt(YPosComboBox.SelectedIndex);
            YPosComboBox.Items.RemoveAt(YPosComboBox.SelectedIndex);
            if (tmp == 0)
            {
                YPosComboBox.SelectedIndex = 0;
            }
            else
            {
                YPosComboBox.SelectedIndex = tmp - 1;
            }
            for (int i = 0; i < YPosComboBox.Items.Count; i++)
            {
                YPosComboBox.Items[i] = "Keyframe " + i;
            }
        }

        private void AddZPosButton_Click(object sender, EventArgs e)
        {
            canm.Keys[2].Keyframes.Add(new Keyframe());
            ZPosComboBox.Items.Add("Keyframe " + ZPosComboBox.Items.Count);
        }

        private void RemoveZPosButton_Click(object sender, EventArgs e)
        {
            int tmp = ZPosComboBox.SelectedIndex;
            canm.Keys[2].Keyframes.RemoveAt(ZPosComboBox.SelectedIndex);
            ZPosComboBox.Items.RemoveAt(ZPosComboBox.SelectedIndex);
            if (tmp == 0)
            {
                ZPosComboBox.SelectedIndex = 0;
            }
            else
            {
                ZPosComboBox.SelectedIndex = tmp - 1;
            }
            for (int i = 0; i < ZPosComboBox.Items.Count; i++)
            {
                ZPosComboBox.Items[i] = "Keyframe " + i;
            }
        }

        private void AddXDirButton_Click(object sender, EventArgs e)
        {
            canm.Keys[3].Keyframes.Add(new Keyframe());
            XDirComboBox.Items.Add("Keyframe " + XDirComboBox.Items.Count);
        }

        private void RemoveXDirButton_Click(object sender, EventArgs e)
        {
            int tmp = XDirComboBox.SelectedIndex;
            canm.Keys[3].Keyframes.RemoveAt(XDirComboBox.SelectedIndex);
            XDirComboBox.Items.RemoveAt(XDirComboBox.SelectedIndex);
            if (tmp == 0)
            {
                XDirComboBox.SelectedIndex = 0;
            }
            else
            {
                XDirComboBox.SelectedIndex = tmp - 1;
            }
            for (int i = 0; i < XDirComboBox.Items.Count; i++)
            {
                XDirComboBox.Items[i] = "Keyframe " + i;
            }
        }

        private void AddYDirButton_Click(object sender, EventArgs e)
        {
            canm.Keys[4].Keyframes.Add(new Keyframe());
            YDirComboBox.Items.Add("Keyframe " + YDirComboBox.Items.Count);
        }

        private void RemoveYDirButton_Click(object sender, EventArgs e)
        {
            int tmp = YDirComboBox.SelectedIndex;
            canm.Keys[4].Keyframes.RemoveAt(YDirComboBox.SelectedIndex);
            YDirComboBox.Items.RemoveAt(YDirComboBox.SelectedIndex);
            if (tmp == 0)
            {
                YDirComboBox.SelectedIndex = 0;
            }
            else
            {
                YDirComboBox.SelectedIndex = tmp - 1;
            }
            for (int i = 0; i < YDirComboBox.Items.Count; i++)
            {
                YDirComboBox.Items[i] = "Keyframe " + i;
            }
        }

        private void AddZDirButton_Click(object sender, EventArgs e)
        {
            canm.Keys[5].Keyframes.Add(new Keyframe());
            ZDirComboBox.Items.Add("Keyframe " + ZDirComboBox.Items.Count);
        }

        private void RemoveZDirButton_Click(object sender, EventArgs e)
        {
            int tmp = ZDirComboBox.SelectedIndex;
            canm.Keys[5].Keyframes.RemoveAt(ZDirComboBox.SelectedIndex);
            ZDirComboBox.Items.RemoveAt(ZDirComboBox.SelectedIndex);
            if (tmp == 0)
            {
                ZDirComboBox.SelectedIndex = 0;
            }
            else
            {
                ZDirComboBox.SelectedIndex = tmp - 1;
            }
            for (int i = 0; i < ZDirComboBox.Items.Count; i++)
            {
                ZDirComboBox.Items[i] = "Keyframe " + i;
            }
        }

        private void AddUnknownButton_Click(object sender, EventArgs e)
        {
            canm.Keys[6].Keyframes.Add(new Keyframe());
            UnknownComboBox.Items.Add("Keyframe " + UnknownComboBox.Items.Count);
        }

        private void RemoveUnknownButton_Click(object sender, EventArgs e)
        {
            int tmp = UnknownComboBox.SelectedIndex;
            canm.Keys[6].Keyframes.RemoveAt(UnknownComboBox.SelectedIndex);
            UnknownComboBox.Items.RemoveAt(UnknownComboBox.SelectedIndex);
            if (tmp == 0)
            {
                UnknownComboBox.SelectedIndex = 0;
            }
            else
            {
                UnknownComboBox.SelectedIndex = tmp - 1;
            }
            for (int i = 0; i < UnknownComboBox.Items.Count; i++)
            {
                UnknownComboBox.Items[i] = "Keyframe " + i;
            }
        }

        private void AddZoomButton_Click(object sender, EventArgs e)
        {
            canm.Keys[7].Keyframes.Add(new Keyframe());
            ZoomComboBox.Items.Add("Keyframe " + ZoomComboBox.Items.Count);
        }

        private void RemoveZoomButton_Click(object sender, EventArgs e)
        {
            int tmp = ZoomComboBox.SelectedIndex;
            canm.Keys[7].Keyframes.RemoveAt(ZoomComboBox.SelectedIndex);
            ZoomComboBox.Items.RemoveAt(ZoomComboBox.SelectedIndex);
            if (tmp == 0)
            {
                ZoomComboBox.SelectedIndex = 0;
            }
            else
            {
                ZoomComboBox.SelectedIndex = tmp - 1;
            }
            for (int i = 0; i < ZoomComboBox.Items.Count; i++)
            {
                ZoomComboBox.Items[i] = "Keyframe " + i;
            }
        }
        #endregion

        private void ScanTimer_Tick(object sender, EventArgs e)
        {
            RemoveXPosButton.Enabled = XPosComboBox.Items.Count == 1 ? false : true;
            RemoveYPosButton.Enabled = YPosComboBox.Items.Count == 1 ? false : true;
            RemoveZPosButton.Enabled = ZPosComboBox.Items.Count == 1 ? false : true;
            RemoveXDirButton.Enabled = XDirComboBox.Items.Count == 1 ? false : true;
            RemoveYDirButton.Enabled = YDirComboBox.Items.Count == 1 ? false : true;
            RemoveZDirButton.Enabled = ZDirComboBox.Items.Count == 1 ? false : true;
            RemoveUnknownButton.Enabled = UnknownComboBox.Items.Count == 1 ? false : true;
            RemoveZoomButton.Enabled = ZoomComboBox.Items.Count == 1 ? false : true;
        }

        private void WhatIsThisToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("This is the secret Intro Camera Editor in Launch Cam Plus. Don't tell anyone if you somehow find this.", "It's a secret to everyone!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void WhatIsAnIntroCameraToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("An Intro Camera is used right after you select a star in SMG1/SMG2 and the camera pans around the level.", "Simple.", MessageBoxButtons.OK, MessageBoxIcon.Question);

        private void WhereDoIGetAcanmToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("Stage/Camera/StartScenarioX.canm." + "\n" + "Can be found with WiiExplorer or by dumping the .arc", "File Managment Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        private void WhatAreTheseNumbersToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("Top: Time - The camera will use the value at this time" + "\n" + "Middle: Value - The value for this keyframe" + "\n" + "Bottom: Velocity - A sort of smoother, per say.", "Every puzzle has an answer", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void HowDoIChangeKeyframesToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("Click where it says \"Keyframe\"", "How did you not get this?", MessageBoxButtons.OK, MessageBoxIcon.Question);

        private void AddingAndRemovingKeyframesToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("Next to each value name, there are two buttons." + "\n" + "[+] Add Keyframe" + "\n" + "[–] Remove Keyframe", "L is real.", MessageBoxButtons.OK, MessageBoxIcon.Question);

        private void ExitToLaunchCamPlusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random ran = new Random();
            int i = ran.Next(0, 13);
            switch (i)
            {
                case 0:
                    throw new Exception("* Did you have a bad time?",new EntryPointNotFoundException());
                case 1:
                    throw new Exception("* Seeing this message fills you with Determination", new EntryPointNotFoundException());
                case 2:
                    throw new Exception("Super Hackio was here", new EntryPointNotFoundException());
                case 3:
                    throw new Exception("Noot Noot", new EntryPointNotFoundException());
                case 4:
                    throw new Exception(":thonk:", new EntryPointNotFoundException());
                case 5:
                    throw new Exception("Wanna Sprite Cranberry?", new EntryPointNotFoundException());
                case 6:
                    throw new Exception("You've been gnomed.", new EntryPointNotFoundException());
                case 7:
                    throw new Exception("Once upon a time..."+"\n"+"In a galaxy far far away...", new EntryPointNotFoundException());
                case 8:
                    throw new Exception("Do you know da wae", new EntryPointNotFoundException());
                case 9:
                    throw new Exception("Steamed hams", new EntryPointNotFoundException());
                case 10:
                    MessageBox.Show("No U","Loading...",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case 11:
                    throw new Exception("The FitnessGram Pacer Test is a multistage aerobic capacity test that progressively gets more difficult as it continues. The 20 meter pacer test will begin in 30 seconds. Line up at the start.The running speed starts slowly, but gets faster each minute after you hear this signal. [beep] A single lap should be completed each time you hear this sound. [ding] Remember to run in a straight line and run as long possible. The second time you fail to complete a lap before the sound. Your test will begin on the word start. On your mark, get ready, start.", new EntryPointNotFoundException());
                case 12:
                    throw new Exception("Hi, Phil Swift here with Flex Tape! The super-strong waterproof tape! That can instantly patch, bond, seal, and repair! Flex tape is no ordinary tape; its triple thick adhesive virtually welds itself to the surface, instantly stopping the toughest leaks. Leaky pipes can cause major damage, but Flex Tape grips on tight and bonds instantly! Plus, Flex Tape’s powerful adhesive is so strong, it even works underwater! Now you can repair leaks in pools and spas in water without draining them! Flex Tape is perfect for marine, campers and RVs! Flex Tape is super strong, and once it's on, it holds on tight! And for emergency auto repair, Flex Tape keeps its grip, even in the toughest conditions! Big storms can cause big damage, but Flex Tape comes super wide, so you can easily patch large holes. To show the power of Flex Tape, I sawed this boat in half! And repaired it with only Flex Tape! Not only does Flex Tape’s powerful adhesive hold the boat together, but it creates a super strong water tight seal, so the inside is completly dry! Yee-doggy! Just cut, peel, stick and seal! Imagine everything you can do with the power of Flex Tape!", new EntryPointNotFoundException());
                case 13:
                    throw new Exception("SnooPING AS usual I see?", new EntryPointNotFoundException());
            }
        }

        private void UnknownGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
