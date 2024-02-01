using LaunchCamPlus.Formats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchCamPlus.ExtraControls
{
    public partial class CameraVariantControl : UserControl
    {
        public CameraVariantControl()
        {
            InitializeComponent();
        }

        public void SetStatus(string CameraId)
        {
            if (CameraId.StartsWith("e:"))
            {
                CamIntColourNumericUpDown.Enabled = EFlagErpFrmCheckBox.Checked;
                CamEndIntColourNumericUpDown.Enabled = EndErpFrmCheckBox.Checked;
                EFlagErpFrmCheckBox.Enabled =
                EndErpFrmCheckBox.Enabled =
                EvFrmColourNumericUpDown.Enabled =
                EvPriorityColourNumericUpDown.Enabled = true;
                GFlagThruColourNumericUpDown.Enabled = false;
            }
            else if (CameraId.StartsWith("c:") || CameraId.StartsWith("s:") || CameraId.StartsWith("g:"))
            {
                CamIntColourNumericUpDown.Enabled = true;
                CamEndIntColourNumericUpDown.Enabled = EndErpFrmCheckBox.Checked;
                EndErpFrmCheckBox.Enabled = true;
                EFlagErpFrmCheckBox.Enabled =
                EvFrmColourNumericUpDown.Enabled =
                EvPriorityColourNumericUpDown.Enabled = false;
                GFlagThruColourNumericUpDown.Enabled = true;
            }
            else
            {
                // The only enabled one for basic cameras is Enter Time
                CamIntColourNumericUpDown.Enabled = true;
                CamEndIntColourNumericUpDown.Enabled =
                EFlagErpFrmCheckBox.Enabled =
                EndErpFrmCheckBox.Enabled =
                EvFrmColourNumericUpDown.Enabled =
                EvPriorityColourNumericUpDown.Enabled =
                GFlagThruColourNumericUpDown.Enabled = false;
            }
        }

        public void LoadCamera(in BCAM.Entry Entry)
        {
            string CameraId = Entry.Identification;
            CamIntColourNumericUpDown.Value = Entry.CamInt;
            EFlagErpFrmCheckBox.Checked = Entry.EventUseTransitionTime >= 1;
            if (CameraId.StartsWith("e:"))
            {
                CamEndIntColourNumericUpDown.Value = Entry.CamEndInt;
                EndErpFrmCheckBox.Checked = Entry.EventUseTransitionEndTime >= 1;
            }
            else if (CameraId.StartsWith("c:") || CameraId.StartsWith("s:") || CameraId.StartsWith("g:"))
            {
                CamEndIntColourNumericUpDown.Value = Entry.GFlagEndTime;
                EndErpFrmCheckBox.Checked = Entry.GFlagEndErpFrame >= 1;
            }
            EvFrmColourNumericUpDown.Value = Entry.EventFrames;
            EvPriorityColourNumericUpDown.Value = Entry.EventPriority;
            GFlagThruColourNumericUpDown.Value = Entry.GFlagThrough;
            SetStatus(CameraId);
        }

        public void UnloadCamera(ref BCAM.Entry Item)
        {
            string CameraId = Item.Identification;
            Item.CamInt = (int)CamIntColourNumericUpDown.Value;
            Item.EventUseTransitionTime = EFlagErpFrmCheckBox.Checked ? 1 : 0;
            if (CameraId.StartsWith("e:"))
            {
                Item.CamEndInt = (int)CamEndIntColourNumericUpDown.Value;
                Item.EventUseTransitionEndTime = EndErpFrmCheckBox.Checked ? 1 : 0;
            }
            else if (CameraId.StartsWith("c:") || CameraId.StartsWith("s:") || CameraId.StartsWith("g:"))
            {
                Item.GFlagEndTime = (int)CamEndIntColourNumericUpDown.Value;
                Item.GFlagEndErpFrame = EndErpFrmCheckBox.Checked ? 1 : 0;
            }

            Item.EventFrames = (int)EvFrmColourNumericUpDown.Value;
            Item.EventPriority = (int)EvPriorityColourNumericUpDown.Value;
            Item.GFlagThrough = (int)GFlagThruColourNumericUpDown.Value;
        }

        private void EFlagErpFrmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CamIntColourNumericUpDown.Enabled = EFlagErpFrmCheckBox.Checked;
        }

        private void EndErpFrmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CamEndIntColourNumericUpDown.Enabled = EndErpFrmCheckBox.Checked;
        }
    }
}
