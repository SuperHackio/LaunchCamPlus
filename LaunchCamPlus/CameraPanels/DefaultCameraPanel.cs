using LaunchCamPlus.Formats;

namespace LaunchCamPlus.CameraPanels;

public partial class DefaultCameraPanel : CameraPanelBase
{
    public DefaultCameraPanel() : base()
    {
        InitializeComponent();
    }

    public override void LoadCamera(BCAM.Entry Entry)
    {
        Loading = true;
        base.LoadCamera(Entry);

        VersionColourNumericUpDown.Value = Entry.Version;
        AngleBColourNumericUpDown.Value = (decimal)Entry.AngleB;
        AngleAColourNumericUpDown.Value = (decimal)Entry.AngleA;
        RollColourNumericUpDown.Value = (decimal)Entry.Roll;
        DistColourNumericUpDown.Value = (decimal)Entry.Dist;
        FovYColourNumericUpDown.Value = (decimal)Entry.FieldOfViewY;
        LOffsetColourNumericUpDown.Value = (decimal)Entry.LookOffset;
        LOffsetVColourNumericUpDown.Value = (decimal)Entry.LookOffsetVertical;
        Num1ColourNumericUpDown.Value = Entry.Num1;
        Num2ColourNumericUpDown.Value = Entry.Num2;
        UpperColourNumericUpDown.Value = (decimal)Entry.UpperBorder;
        LowerColourNumericUpDown.Value = (decimal)Entry.LowerBorder;
        CamIntColourNumericUpDown.Value = Entry.CamInt;
        CamEndIntColourNumericUpDown.Value = Entry.CamEndInt;
        GndIntColourNumericUpDown.Value = Entry.GndInt;
        PushDelayColourNumericUpDown.Value = Entry.PushDelay;
        PushDelayLowColourNumericUpDown.Value = Entry.PushDelayLow;
        UPlayColourNumericUpDown.Value = (decimal)Entry.UPlay;
        LPlayColourNumericUpDown.Value = (decimal)Entry.LPlay;
        UDownColourNumericUpDown.Value = Entry.UDown;
        EvFrmColourNumericUpDown.Value = Entry.EventFrames;
        EvPriorityColourNumericUpDown.Value = Entry.EventPriority;
        GFlagCamEndIntColourNumericUpDown.Value = Entry.GFlagEndTime;

        WOffsetVector3NumericUpDown.LoadVector3(Entry.WOffset);
        WPointVector3NumericUpDown.LoadVector3(Entry.WPoint);
        AxisVector3NumericUpDown.LoadVector3(Entry.Axis);
        VPanAxisVector3NumericUpDown.LoadVector3(Entry.VerticalPanAxis);
        UpVector3NumericUpDown.LoadVector3(Entry.Up);

        NoResetCheckBox.Checked = Entry.NoReset == 1;
        NoFovYCheckBox.Checked = Entry.NoFieldOfViewY == 1;
        LOfsErpOffCheckBox.Checked = Entry.LookOffsetErpOff == 1;
        AntiBlurOffCheckBox.Checked = Entry.AntiBlurOff == 1;
        CollisionOffCheckBox.Checked = Entry.CollisionOff == 1;
        SubjectiveOffCheckBox.Checked = Entry.SubjectiveOff == 1;
        GFlagEnableEndErpFrameCheckBox.Checked = Entry.GFlagEndErpFrame == 1;
        GFlagThruCheckBox.Checked = Entry.GFlagThrough == 1;
        VPanUseCheckbox.Checked = Entry.VPanAxisUse == 1;
        EFlagErpFrmCheckBox.Checked = Entry.EventUseTransitionTime == 1;
        EFlagEndErpFrmCheckBox.Checked = Entry.EventUseTransitionEndTime == 1;

        StringColourTextBox.Text = Entry.String;
        Loading = false;
    }

    public override void UnloadCamera()
    {
        base.UnloadCamera();
        Item.Version = (int)VersionColourNumericUpDown.Value;
        Item.AngleB = (float)AngleBColourNumericUpDown.Value;
        Item.AngleA = (float)AngleAColourNumericUpDown.Value;
        Item.Roll = (float)RollColourNumericUpDown.Value;
        Item.Dist = (float)DistColourNumericUpDown.Value;
        Item.FieldOfViewY = (float)FovYColourNumericUpDown.Value;
        Item.LookOffset = (float)LOffsetColourNumericUpDown.Value;
        Item.LookOffsetVertical = (float)LOffsetVColourNumericUpDown.Value;
        Item.Num1 = (int)Num1ColourNumericUpDown.Value;
        Item.Num2 = (int)Num2ColourNumericUpDown.Value;
        Item.UpperBorder = (float)UpperColourNumericUpDown.Value;
        Item.LowerBorder = (float)LowerColourNumericUpDown.Value;
        Item.CamInt = (int)CamIntColourNumericUpDown.Value;
        Item.CamEndInt = (int)CamEndIntColourNumericUpDown.Value;
        Item.GndInt = (int)GndIntColourNumericUpDown.Value;
        Item.PushDelay = (int)PushDelayColourNumericUpDown.Value;
        Item.PushDelayLow = (int)PushDelayLowColourNumericUpDown.Value;
        Item.UPlay = (float)UPlayColourNumericUpDown.Value;
        Item.LPlay = (float)LPlayColourNumericUpDown.Value;
        Item.UDown = (int)UDownColourNumericUpDown.Value;
        Item.EventFrames = (int)EvFrmColourNumericUpDown.Value;
        Item.EventPriority = (int)EvPriorityColourNumericUpDown.Value;
        Item.GFlagEndTime = (int)GFlagCamEndIntColourNumericUpDown.Value;

        Item.WOffset = WOffsetVector3NumericUpDown.GetVector3();
        Item.WPoint = WPointVector3NumericUpDown.GetVector3();
        Item.Axis = AxisVector3NumericUpDown.GetVector3();
        Item.VerticalPanAxis = VPanAxisVector3NumericUpDown.GetVector3();
        Item.Up = UpVector3NumericUpDown.GetVector3();

        Item.NoReset = NoResetCheckBox.Checked ? 1 : 0;
        Item.NoFieldOfViewY = NoFovYCheckBox.Checked ? 1 : 0;
        Item.LookOffsetErpOff = LOfsErpOffCheckBox.Checked ? 1 : 0;
        Item.AntiBlurOff = AntiBlurOffCheckBox.Checked ? 1 : 0;
        Item.CollisionOff = CollisionOffCheckBox.Checked ? 1 : 0;
        Item.SubjectiveOff = SubjectiveOffCheckBox.Checked ? 1 : 0;
        Item.GFlagEndErpFrame = GFlagEnableEndErpFrameCheckBox.Checked ? 1 : 0;
        Item.GFlagThrough = GFlagThruCheckBox.Checked ? 1 : 0;
        Item.VPanAxisUse = VPanUseCheckbox.Checked ? 1 : 0;
        Item.EventUseTransitionTime = EFlagErpFrmCheckBox.Checked ? 1 : 0;
        Item.EventUseTransitionEndTime = EFlagEndErpFrmCheckBox.Checked ? 1 : 0;

        Item.String = StringColourTextBox.Text;
    }



    private void NoFovYCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        FovYColourNumericUpDown.Enabled = NoFovYCheckBox.Checked;
    }

    private void VPanUseCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        VPanAxisVector3NumericUpDown.Enabled = VPanUseCheckbox.Checked;
    }
}
