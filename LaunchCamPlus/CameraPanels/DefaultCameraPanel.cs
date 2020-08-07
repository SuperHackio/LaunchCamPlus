using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hack.io.BCAM;

namespace LaunchCamPlus.CameraPanels
{
    public partial class DefaultCameraPanel : CameraPanelBase
    {
        public DefaultCameraPanel() : base()
        {
            InitializeComponent();
            SetupUnsaved();
        }

        public override void LoadCamera(BCAMEntry Entry)
        {
            base.LoadCamera(Entry);
            Loading = true;
            RotationXNumericUpDown.Value = (decimal)Entry.RotationX.RadianToDegree();
            RotationYNumericUpDown.Value = (decimal)Entry.RotationY.RadianToDegree();
            RotationZNumericUpDown.Value = (decimal)Entry.RotationZ.RadianToDegree();
            ZoomNumericUpDown.Value = (decimal)Entry.Zoom;
            Num1NumericUpDown.Value = Entry.Num1;
            Num2NumericUpDown.Value = Entry.Num2;
            StringTextBox.Text = Entry.String;
            FieldOfViewNumericUpDown.Value = (decimal)Entry.FieldOfView;
            JumpingYNumericUpDown.Value = (decimal)Entry.MaxY;
            FallingYNumericUpDown.Value = (decimal)Entry.MinY;
            CamIntNumericUpDown.Value = Entry.TransitionTime;
            CamEndIntNumericUpDown.Value = Entry.TransitionEndTime;
            FrontOffsetNumericUpDown.Value = (decimal)Entry.LookOffset;
            HeightOffsetNumericUpDown.Value = (decimal)Entry.LookOffsetVertical;
            GroundDelayNumericUpDown.Value = Entry.GroundMoveDelay;
            AirDelayNumericUpDown.Value = Entry.AirMoveDelay;
            UpperBorderNumericUpDown.Value = (decimal)Entry.UpperBorder;
            LowerBorderNumericUpDown.Value = (decimal)Entry.LowerBorder;
            EventFrameNumericUpDown.Value = Entry.EventFrames;
            EventPriorityNumericUpDown.Value = Entry.EventPriority;

            FixpointVector3NumericUpDown.LoadVector3(Entry.FixPointOffset);
            WorldOffsetVector3NumericUpDown.LoadVector3(Entry.WorldPointOffset);
            PlayerOffsetVector3NumericUpDown.LoadVector3(Entry.PlayerOffset);
            VerticalPanAxisVector3NumericUpDown.LoadVector3(Entry.VerticalPanAxis);
            UpAxisVector3NumericUpDown.LoadVector3(Entry.UpAxis);

            DisableResetCheckBox.Checked = !Entry.DisableReset;
            FieldOfViewCheckBox.Checked = Entry.EnableFoV;
            SharpZoomCheckBox.Checked = Entry.StaticLookOffset;
            DisableAntiBlurCheckBox.Checked = Entry.DisableAntiBlur;
            DisableCollisionCheckBox.Checked = !Entry.DisableCollision;
            DisableFirstPersonCheckBox.Checked = !Entry.DisableFirstPerson;
            GFlagEndErpFrameCheckBox.Checked = Entry.GFlagEndErpFrame;
            GFlagThroughCheckBox.Checked = Entry.GFlagThrough;
            GFlagEndTimeNumericUpDown.Value = (decimal)Entry.GFlagEndTime;
            UseVerticalPanAxisCheckBox.Checked = Entry.EnableVerticalPanAxis;
            EventUseTimeCheckBox.Checked = Entry.EventUseTransitionTime;
            EventUseEndTimeCheckBox.Checked = Entry.EventUseTransitionEndTime;
            Loading = false;
        }

        public override void UnLoadCamera(BCAMEntry Entry)
        {
            base.UnLoadCamera(Entry);
            Entry.RotationX = ((float)RotationXNumericUpDown.Value).DegreeToRadian();
            Entry.RotationY = ((float)RotationYNumericUpDown.Value).DegreeToRadian();
            Entry.RotationZ = ((float)RotationZNumericUpDown.Value).DegreeToRadian();
            Entry.Zoom = (float)ZoomNumericUpDown.Value;
            Entry.Num1 = (int)Num1NumericUpDown.Value;
            Entry.Num2 = (int)Num2NumericUpDown.Value;
            Entry.String = StringTextBox.Text;
            Entry.FieldOfView = (float)FieldOfViewNumericUpDown.Value;
            Entry.MaxY = (float)JumpingYNumericUpDown.Value;
            Entry.MinY = (float)FallingYNumericUpDown.Value;
            Entry.TransitionTime = (int)CamIntNumericUpDown.Value;
            Entry.TransitionEndTime = (int)CamEndIntNumericUpDown.Value;
            Entry.LookOffset = (float)FrontOffsetNumericUpDown.Value;
            Entry.LookOffsetVertical = (float)HeightOffsetNumericUpDown.Value;
            Entry.GroundMoveDelay = (int)GroundDelayNumericUpDown.Value;
            Entry.AirMoveDelay = (int)AirDelayNumericUpDown.Value;
            Entry.UpperBorder = (float)UpperBorderNumericUpDown.Value;
            Entry.LowerBorder = (float)LowerBorderNumericUpDown.Value;
            Entry.EventFrames = (int)EventFrameNumericUpDown.Value;
            Entry.EventPriority = (int)EventPriorityNumericUpDown.Value;
            Entry.FixPointOffset = FixpointVector3NumericUpDown.GetVector3();
            Entry.WorldPointOffset = WorldOffsetVector3NumericUpDown.GetVector3();
            Entry.PlayerOffset = PlayerOffsetVector3NumericUpDown.GetVector3();
            Entry.VerticalPanAxis = VerticalPanAxisVector3NumericUpDown.GetVector3();
            Entry.UpAxis = UpAxisVector3NumericUpDown.GetVector3();
            Entry.DisableReset = !DisableResetCheckBox.Checked;
            Entry.EnableFoV = FieldOfViewCheckBox.Checked;
            Entry.StaticLookOffset = SharpZoomCheckBox.Checked;
            Entry.DisableAntiBlur = DisableAntiBlurCheckBox.Checked;
            Entry.DisableCollision = !DisableCollisionCheckBox.Checked;
            Entry.DisableFirstPerson = !DisableFirstPersonCheckBox.Checked;
            Entry.GFlagEndErpFrame = GFlagEndErpFrameCheckBox.Checked;
            Entry.GFlagThrough = GFlagThroughCheckBox.Checked;
            Entry.GFlagEndTime = (int)GFlagEndTimeNumericUpDown.Value;
            Entry.EnableVerticalPanAxis = UseVerticalPanAxisCheckBox.Checked;
            Entry.EventUseTransitionTime = EventUseTimeCheckBox.Checked;
            Entry.EventUseTransitionEndTime = EventUseEndTimeCheckBox.Checked;

            Entry.UDown = 120;
            Entry.TransitionGroundTime = 120;
        }

        private void FieldOfViewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FieldOfViewNumericUpDown.Enabled = FieldOfViewCheckBox.Checked;
        }

        private void UseVerticalPanAxisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            VerticalPanAxisVector3NumericUpDown.Enabled = UseVerticalPanAxisCheckBox.Checked;
        }
    }
}
