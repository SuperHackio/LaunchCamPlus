using Hack.io.Utility;
using LaunchCamPlus.Formats;

namespace LaunchCamPlus.CameraPanels;

public partial class ObjParallelCameraPanel : CameraPanelBase
{
    public ObjParallelCameraPanel()
    {
        InitializeComponent();
        OnCameraIdChange += CameraVariant.SetStatus;
    }

    public override void LoadCamera(BCAM.Entry Entry)
    {
        Loading = true;
        base.LoadCamera(Entry);

        VersionColourNumericUpDown.Value = Entry.Version;
        AngleBColourNumericUpDown.Value = -(decimal)Entry.AngleA.RadianToDegree();
        AngleAColourNumericUpDown.Value = (decimal)Entry.AngleB.RadianToDegree();
        RollColourNumericUpDown.Value = (decimal)Entry.Roll.RadianToDegree();
        DistColourNumericUpDown.Value = (decimal)Entry.Dist;
        FovYColourNumericUpDown.Value = (decimal)RoundAndClampFoV(Entry.FieldOfViewY);
        WOffsetVector3NumericUpDown.LoadVector3(Entry.WOffset);

        NoResetCheckBox.Checked = Entry.NoReset == 1;
        NoFovYCheckBox.Checked = Entry.NoFieldOfViewY == 1;
        AntiBlurOffCheckBox.Checked = Entry.AntiBlurOff != 1;
        CollisionOffCheckBox.Checked = Entry.CollisionOff == 1;
        SubjectiveOffCheckBox.Checked = Entry.SubjectiveOff != 1;

        CameraVariant.LoadCamera(Entry);
        CameraLOfs.LoadCamera(Entry);

        StringColourTextBox.Text = Entry.String;
        Loading = false;
    }

    public override void UnloadCamera()
    {
        base.UnloadCamera();
        Item.Version = (int)VersionColourNumericUpDown.Value;
        Item.AngleA = -((float)AngleBColourNumericUpDown.Value).DegreeToRadian();
        Item.AngleB = ((float)AngleAColourNumericUpDown.Value).DegreeToRadian();
        Item.Roll = ((float)RollColourNumericUpDown.Value).DegreeToRadian();
        Item.Dist = (float)DistColourNumericUpDown.Value;
        Item.FieldOfViewY = (float)FovYColourNumericUpDown.Value;
        Item.WOffset = WOffsetVector3NumericUpDown.GetVector3();

        Item.NoReset = NoResetCheckBox.Checked ? 1 : 0;
        Item.NoFieldOfViewY = NoFovYCheckBox.Checked ? 1 : 0;
        Item.AntiBlurOff = !AntiBlurOffCheckBox.Checked ? 1 : 0;
        Item.CollisionOff = CollisionOffCheckBox.Checked ? 1 : 0;
        Item.SubjectiveOff = !SubjectiveOffCheckBox.Checked ? 1 : 0;

        BCAM.Entry Entry = Item;
        CameraVariant.UnloadCamera(ref Entry);
        CameraLOfs.UnloadCamera(ref Entry);

        Item.String = StringColourTextBox.Text;
    }

    private void NoFovYCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        FovYColourNumericUpDown.Enabled = NoFovYCheckBox.Checked;
    }
}
