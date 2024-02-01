using Hack.io.Utility;
using LaunchCamPlus.Formats;

namespace LaunchCamPlus.CameraPanels;

public partial class WonderPlanetCameraPanel : CameraPanelBase
{
    public WonderPlanetCameraPanel()
    {
        InitializeComponent();
        OnCameraIdChange += CameraVariant.SetStatus;
    }

    public override void LoadCamera(BCAM.Entry Entry)
    {
        Loading = true;
        base.LoadCamera(Entry);

        VersionColourNumericUpDown.Value = Entry.Version;
        AngleAColourNumericUpDown.Value = (decimal)Entry.AngleA.RadianToDegree();
        RollColourNumericUpDown.Value = (decimal)Entry.Roll.RadianToDegree();
        FovYColourNumericUpDown.Value = (decimal)Entry.FieldOfViewY;
        WOffsetVector3NumericUpDown.LoadVector3(Entry.WOffset);
        AxisXColourNumericUpDown.Value = (decimal)Entry.AxisX;
        AxisYColourNumericUpDown.Value = (decimal)Entry.AxisY;

        NoResetCheckBox.Checked = Entry.NoReset == 1;
        NoFovYCheckBox.Checked = Entry.NoFieldOfViewY == 1;
        AntiBlurOffCheckBox.Checked = Entry.AntiBlurOff != 1;
        CollisionOffCheckBox.Checked = Entry.CollisionOff == 1;
        SubjectiveOffCheckBox.Checked = Entry.SubjectiveOff != 1;

        CameraVariant.LoadCamera(Entry);
        CameraHeightArrange.LoadCamera(Entry);
        CameraLOfs.LoadCamera(Entry);

        StringColourTextBox.Text = Entry.String;
        Loading = false;
    }

    public override void UnloadCamera()
    {
        base.UnloadCamera();
        Item.Version = (int)VersionColourNumericUpDown.Value;
        Item.AngleA = ((float)AngleAColourNumericUpDown.Value).DegreeToRadian();
        Item.Roll = ((float)RollColourNumericUpDown.Value).DegreeToRadian();
        Item.FieldOfViewY = (float)FovYColourNumericUpDown.Value;
        Item.WOffset = WOffsetVector3NumericUpDown.GetVector3();
        Item.AxisX = (float)AxisXColourNumericUpDown.Value;
        Item.AxisY = (float)AxisYColourNumericUpDown.Value;

        Item.NoReset = NoResetCheckBox.Checked ? 1 : 0;
        Item.NoFieldOfViewY = NoFovYCheckBox.Checked ? 1 : 0;
        Item.AntiBlurOff = !AntiBlurOffCheckBox.Checked ? 1 : 0;
        Item.CollisionOff = CollisionOffCheckBox.Checked ? 1 : 0;
        Item.SubjectiveOff = !SubjectiveOffCheckBox.Checked ? 1 : 0;

        BCAM.Entry Entry = Item;
        CameraVariant.UnloadCamera(ref Entry);
        CameraHeightArrange.UnloadCamera(ref Entry);
        CameraLOfs.UnloadCamera(ref Entry);

        Item.String = StringColourTextBox.Text;
    }

    private void NoFovYCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        FovYColourNumericUpDown.Enabled = NoFovYCheckBox.Checked;
    }
}
