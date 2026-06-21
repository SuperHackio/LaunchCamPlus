using LaunchCamPlus.Formats;

namespace LaunchCamPlus.CameraPanels;

public partial class EmptyCameraPanel : CameraPanelBase
{
    public EmptyCameraPanel()
    {
        InitializeComponent();
    }

    public override void LoadCamera(BCAM.Entry Entry)
    {
        Loading = true;
        base.LoadCamera(Entry);
        VersionColourNumericUpDown.Value = Entry.Version;
        Loading = false;
    }

    public override void UnloadCamera()
    {
        base.UnloadCamera();
        Item.Version = (int)VersionColourNumericUpDown.Value;
    }
}
