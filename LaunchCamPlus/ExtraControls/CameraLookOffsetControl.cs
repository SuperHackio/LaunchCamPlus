using LaunchCamPlus.Formats;

namespace LaunchCamPlus.ExtraControls;

public partial class CameraLookOffsetControl : UserControl
{
    public CameraLookOffsetControl()
    {
        InitializeComponent();
    }

    public void LoadCamera(in BCAM.Entry Entry)
    {
        LOfsErpOffCheckBox.Checked = Entry.LookOffsetErpOff == 0; //Invert this for the user
        LOffsetColourNumericUpDown.Value = (decimal)Entry.LookOffset;
        LOffsetVColourNumericUpDown.Value = (decimal)Entry.LookOffsetVertical;
    }

    public void UnloadCamera(ref BCAM.Entry Item)
    {
        Item.LookOffsetErpOff = LOfsErpOffCheckBox.Checked ? 0 : 1; //Invert this for the user
        Item.LookOffset = (float)LOffsetColourNumericUpDown.Value ;
        Item.LookOffsetVertical = (float)LOffsetVColourNumericUpDown.Value;
    }
}
