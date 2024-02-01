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

namespace LaunchCamPlus.ExtraControls;

public partial class CameraHeightControl : UserControl
{
    public CameraHeightControl()
    {
        InitializeComponent();
    }

    public void LoadCamera(in BCAM.Entry Entry)
    {
        UpperColourNumericUpDown.Value = (decimal)Entry.UpperBorder;
        LowerColourNumericUpDown.Value = (decimal)Entry.LowerBorder;
        PushDelayColourNumericUpDown.Value = Entry.PushDelay;
        PushDelayLowColourNumericUpDown.Value = Entry.PushDelayLow;
        UPlayColourNumericUpDown.Value = (decimal)Entry.UPlay;
        LPlayColourNumericUpDown.Value = (decimal)Entry.LPlay;
        VPanUseCheckBox.Checked = Entry.VPanAxisUse >= 1;
    }

    public void UnloadCamera(ref BCAM.Entry Item)
    {
        Item.UpperBorder = (float)UpperColourNumericUpDown.Value;
        Item.LowerBorder = (float)LowerColourNumericUpDown.Value;
        Item.PushDelay = (int)PushDelayColourNumericUpDown.Value;
        Item.PushDelayLow = (int)PushDelayLowColourNumericUpDown.Value;
        Item.UPlay = (float)UPlayColourNumericUpDown.Value;
        Item.LPlay = (float)LPlayColourNumericUpDown.Value;
        Item.VPanAxisUse = VPanUseCheckBox.Checked ? 1 : 0;
    }

    private void VPanUseCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        UpperColourNumericUpDown.Enabled = VPanUseCheckBox.Checked;
        LowerColourNumericUpDown.Enabled = VPanUseCheckBox.Checked;
        PushDelayColourNumericUpDown.Enabled = VPanUseCheckBox.Checked;
        PushDelayLowColourNumericUpDown.Enabled = VPanUseCheckBox.Checked;
        UPlayColourNumericUpDown.Enabled = VPanUseCheckBox.Checked;
        LPlayColourNumericUpDown.Enabled = VPanUseCheckBox.Checked;
    }
}
