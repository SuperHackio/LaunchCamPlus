using Hack.io.Utility;
using LaunchCamPlus.Formats;

namespace LaunchCamPlus.CameraPanels;

public partial class SpiralDemoCameraPanel : CameraPanelBase
{
    private int Num2Backup;
    private decimal? BackupNum1A = null, BackupNum1B = null;
    public SpiralDemoCameraPanel()
    {
        InitializeComponent();
        OnCameraIdChange += CameraVariant.SetStatus;
        Num1AColourNumericUpDown.ValueChange2 += Num1AColourNumericUpDown_ValueChanged;
        Num1BColourNumericUpDown.ValueChange2 += Num1BColourNumericUpDown_ValueChanged;
    }

    public override void LoadCamera(BCAM.Entry Entry)
    {
        Loading = true;
        base.LoadCamera(Entry);

        VersionColourNumericUpDown.Value = Entry.Version;
        //AngleBColourNumericUpDown.Value = (decimal)Entry.AngleB.RadianToDegree();
        //AngleAColourNumericUpDown.Value = (decimal)Entry.AngleA.RadianToDegree();
        RollColourNumericUpDown.Value = (decimal)Entry.Roll.RadianToDegree();
        //DistColourNumericUpDown.Value = (decimal)Entry.Dist;
        FovYColourNumericUpDown.Value = (decimal)Entry.FieldOfViewY;
        WOffsetVector3NumericUpDown.LoadVector3(Entry.WOffset);

        BackupNum1A = null;
        BackupNum1B = null;
        Num1AColourNumericUpDown.Value = (Entry.Num1 >> 16) & 0xFFFF;
        Num1BColourNumericUpDown.Value = Entry.Num1 & 0xFFFF;
        Num2Backup = Entry.Num2;
        if (Num2Backup == 0)
            Num2LinearRadioButton.Checked = true;
        else if (Num2Backup == 1)
            Num2SmoothRadioButton.Checked = true;
        else
            Num2NoneRadioButton.Checked = true;

        WPointXColourNumericUpDown.Value = (decimal)Entry.WPointX.RadianToDegree();
        WPointYColourNumericUpDown.Value = (decimal)Entry.WPointY;
        WPointZColourNumericUpDown.Value = (decimal)Entry.WPointZ;
        AxisXColourNumericUpDown.Value = (decimal)Entry.AxisX.RadianToDegree();
        AxisYColourNumericUpDown.Value = (decimal)Entry.AxisY;
        AxisZColourNumericUpDown.Value = (decimal)Entry.AxisZ;

        NoResetCheckBox.Checked = Entry.NoReset == 1;
        NoFovYCheckBox.Checked = Entry.NoFieldOfViewY == 1;
        //AntiBlurOffCheckBox.Checked = Entry.AntiBlurOff != 1;
        CollisionOffCheckBox.Checked = Entry.CollisionOff == 1;
        SubjectiveOffCheckBox.Checked = Entry.SubjectiveOff != 1;

        CameraVariant.LoadCamera(Entry);
        //CameraHeightArrange.LoadCamera(Entry);
        //CameraLOfs.LoadCamera(Entry);

        StringColourTextBox.Text = Entry.String;
        Loading = false;

        Num1AColourNumericUpDown_ValueChanged(EventArgs.Empty);
        Num1BColourNumericUpDown_ValueChanged(EventArgs.Empty);
    }

    public override void UnloadCamera()
    {
        base.UnloadCamera();
        Item.Version = (int)VersionColourNumericUpDown.Value;
        //Item.AngleB = ((float)AngleBColourNumericUpDown.Value).DegreeToRadian();
        //Item.AngleA = ((float)AngleAColourNumericUpDown.Value).DegreeToRadian();
        Item.Roll = ((float)RollColourNumericUpDown.Value).DegreeToRadian();
        //Item.Dist = (float)DistColourNumericUpDown.Value;
        Item.FieldOfViewY = (float)FovYColourNumericUpDown.Value;
        Item.WOffset = WOffsetVector3NumericUpDown.GetVector3();

        ushort Num1A = (ushort)((int)Num1AColourNumericUpDown.Value & 0xFFFF);
        ushort Num1B = (ushort)((int)Num1BColourNumericUpDown.Value & 0xFFFF);
        Item.Num1 = (Num1A << 16) | Num1B;

        if (Num2LinearRadioButton.Checked)
            Item.Num2 = 0;
        else if (Num2SmoothRadioButton.Checked)
            Item.Num2 = 1;
        else
            Item.Num2 = (Num2Backup == 0 || Num2Backup == 1) ? 555 : Num2Backup;

        Item.WPointX = ((float)WPointXColourNumericUpDown.Value).DegreeToRadian();
        Item.WPointY = (float)WPointYColourNumericUpDown.Value;
        Item.WPointZ = (float)WPointZColourNumericUpDown.Value;
        Item.AxisX = ((float)AxisXColourNumericUpDown.Value).DegreeToRadian();
        Item.AxisY = (float)AxisYColourNumericUpDown.Value;
        Item.AxisZ = (float)AxisZColourNumericUpDown.Value;

        Item.NoReset = NoResetCheckBox.Checked ? 1 : 0;
        Item.NoFieldOfViewY = NoFovYCheckBox.Checked ? 1 : 0;
        //Item.AntiBlurOff = !AntiBlurOffCheckBox.Checked ? 1 : 0;
        Item.CollisionOff = CollisionOffCheckBox.Checked ? 1 : 0;
        Item.SubjectiveOff = !SubjectiveOffCheckBox.Checked ? 1 : 0;

        BCAM.Entry Entry = Item;
        CameraVariant.UnloadCamera(ref Entry);
        //CameraHeightArrange.UnloadCamera(ref Entry);
        //CameraLOfs.UnloadCamera(ref Entry);

        Item.String = StringColourTextBox.Text;
    }

    private void NoFovYCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        FovYColourNumericUpDown.Enabled = NoFovYCheckBox.Checked;
    }

    private void Num1AColourNumericUpDown_ValueChanged(EventArgs e)
    {
        if (Num1AColourNumericUpDown.Value == Num1BColourNumericUpDown.Value)
        {
            MessageBox.Show("Rotation Time cannot equal Rotation Start Delay!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ExplainInvalidDataToConsole();
            Num1AColourNumericUpDown.Value = BackupNum1A ?? Num1BColourNumericUpDown.Value + 1;
        }
        else
            BackupNum1A = Num1AColourNumericUpDown.Value;
    }

    private void Num1BColourNumericUpDown_ValueChanged(EventArgs e)
    {
        if (Num1BColourNumericUpDown.Value == Num1AColourNumericUpDown.Value)
        {
            MessageBox.Show("Rotation Start Delay cannot equal Rotation Time!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ExplainInvalidDataToConsole();
            Num1BColourNumericUpDown.Value = BackupNum1B ?? Num1AColourNumericUpDown.Value - 1;
        }
        else
            BackupNum1B = Num1BColourNumericUpDown.Value;
    }

    private void ExplainInvalidDataToConsole() => MessageToConsole("If the Rotation Start Delay and Rotation Time are equal, the game will explode.\nNo seriously, it produces the same effect as if you fell into a PullBackArea that failed to put you on ground properly.");
}
