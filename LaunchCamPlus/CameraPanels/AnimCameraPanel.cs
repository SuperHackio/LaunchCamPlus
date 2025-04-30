using Hack.io.Utility;
using LaunchCamPlus.Formats;

namespace LaunchCamPlus.CameraPanels;

public partial class AnimCameraPanel : CameraPanelBase
{
    public AnimCameraPanel()
    {
        InitializeComponent();
    }

    public override void LoadCamera(BCAM.Entry Entry)
    {
        Loading = true;
        base.LoadCamera(Entry);
        VersionColourNumericUpDown.Value = Entry.Version;
        Num1ColourNumericUpDown.Value = Entry.Num1;
        Num2ColourNumericUpDown.Value = Entry.Num2;
        Loading = false;
    }

    public override void UnloadCamera()
    {
        base.UnloadCamera();
        Item.Version = (int)VersionColourNumericUpDown.Value;
        Item.Num1 = (int)Num1ColourNumericUpDown.Value;
        Item.Num2 = (int)Num2ColourNumericUpDown.Value;
    }
}
