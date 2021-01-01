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
    public partial class RailFollowCameraPanel : CameraPanelBase
    {
        public RailFollowCameraPanel()
        {
            InitializeComponent();
            SetupUnsaved();
        }


        public override void LoadCamera(BCAMEntry Entry)
        {
            base.LoadCamera(Entry);
            Loading = true;
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
            UpperBorderNumericUpDown.Value = (decimal)Entry.UpperBorder;
            LowerBorderNumericUpDown.Value = (decimal)Entry.LowerBorder;
            EventFrameNumericUpDown.Value = Entry.EventFrames;

            FixpointVector3NumericUpDown.LoadVector3(Entry.FixPointOffset);
            WorldOffsetXNumericUpDown.Value = (decimal)Entry.WorldPointOffset.XValue;
            WorldOffsetYNumericUpDown.Value = (decimal)Entry.WorldPointOffset.YValue;
            VerticalPanAxisVector3NumericUpDown.LoadVector3(Entry.VerticalPanAxis);
            UpAxisVector3NumericUpDown.LoadVector3(Entry.UpAxis);
            
            FieldOfViewCheckBox.Checked = Entry.EnableFoV;
            SharpZoomCheckBox.Checked = Entry.StaticLookOffset;
            DisableCollisionCheckBox.Checked = !Entry.DisableCollision;
            DisableFirstPersonCheckBox.Checked = !Entry.DisableFirstPerson;
            UseVerticalPanAxisCheckBox.Checked = Entry.EnableVerticalPanAxis;
            EventUseTimeCheckBox.Checked = Entry.EventUseTransitionTime;
            EventUseEndTimeCheckBox.Checked = Entry.EventUseTransitionEndTime;
            Loading = false;
        }

        public override void UnLoadCamera(BCAMEntry Entry)
        {
            base.UnLoadCamera(Entry);
            Entry.RotationX = 0.0f;
            Entry.RotationY = 0.0f;
            Entry.RotationZ = 0.0f;
            Entry.Zoom = (float)ZoomNumericUpDown.Value;
            Entry.Num1 = 0;
            Entry.Num2 = 0;
            Entry.String = StringTextBox.Text;
            Entry.FieldOfView = (float)FieldOfViewNumericUpDown.Value;
            Entry.MaxY = 300;
            Entry.MinY = 800;
            Entry.TransitionTime = (int)CamIntNumericUpDown.Value;
            Entry.TransitionEndTime = (int)CamEndIntNumericUpDown.Value;
            Entry.LookOffset = 0.0f;
            Entry.LookOffsetVertical = 0.0f;
            Entry.GroundMoveDelay = 120;
            Entry.AirMoveDelay = 120;
            Entry.UpperBorder = 0.0f;
            Entry.LowerBorder = 0.0f;
            Entry.EventFrames = (int)EventFrameNumericUpDown.Value;
            Entry.FixPointOffset = FixpointVector3NumericUpDown.GetVector3();
            Entry.WorldPointOffset = new Vector3<float>((float)WorldOffsetXNumericUpDown.Value, (float)WorldOffsetYNumericUpDown.Value, 0);
            Entry.PlayerOffset = new Vector3<float>(((float)Num1NumericUpDown.Value).DegreeToRadian(), ((float)Num2NumericUpDown.Value).DegreeToRadian(), 0);
            Entry.VerticalPanAxis = new Vector3<float>(0, 0, 0);
            Entry.UpAxis = UpAxisVector3NumericUpDown.GetVector3();
            Entry.DisableReset = false;
            Entry.EnableFoV = FieldOfViewCheckBox.Checked;
            Entry.StaticLookOffset = false;//SharpZoomCheckBox.Checked;
            Entry.DisableAntiBlur = false;// DisableAntiBlurCheckBox.Checked;
            Entry.DisableCollision = DisableCollisionCheckBox.Checked;
            Entry.DisableFirstPerson = !DisableFirstPersonCheckBox.Checked;
            Entry.GFlagEndErpFrame = false;// GFlagEndErpFrameCheckBox.Checked;
            Entry.GFlagThrough = false;// GFlagThroughCheckBox.Checked;
            Entry.GFlagEndTime = 0;// (int)GFlagEndTimeNumericUpDown.Value;
            Entry.EnableVerticalPanAxis = false;
            Entry.EventUseTransitionTime = EventUseTimeCheckBox.Checked;
            Entry.EventUseTransitionEndTime = EventUseEndTimeCheckBox.Checked;

            Entry.UDown = 120;
            Entry.TransitionGroundTime = 160;

            base.UnLoadCamera(Entry);
            Entry.RotationX = 0.0f;
            Entry.RotationY = 0.0f;
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
            Entry.GroundMoveDelay = 120;
            Entry.AirMoveDelay = 120;
            Entry.UpperBorder = (float)UpperBorderNumericUpDown.Value;
            Entry.LowerBorder = (float)LowerBorderNumericUpDown.Value;
            Entry.EventFrames = (int)EventFrameNumericUpDown.Value;
            Entry.EventPriority = Entry.IsOfCategory("e") ? 1 : 0;
            Entry.FixPointOffset = FixpointVector3NumericUpDown.GetVector3();
            Entry.WorldPointOffset = new Vector3<float>((float)WorldOffsetXNumericUpDown.Value, (float)WorldOffsetYNumericUpDown.Value, 0);
            Entry.PlayerOffset = new Vector3<float>();
            Entry.VerticalPanAxis = VerticalPanAxisVector3NumericUpDown.GetVector3();
            Entry.UpAxis = UpAxisVector3NumericUpDown.GetVector3();
            Entry.DisableReset = false;
            Entry.EnableFoV = FieldOfViewCheckBox.Checked;
            Entry.StaticLookOffset = SharpZoomCheckBox.Checked;
            Entry.DisableAntiBlur = false;
            Entry.DisableCollision = !DisableCollisionCheckBox.Checked;
            Entry.DisableFirstPerson = !DisableFirstPersonCheckBox.Checked;
            Entry.GFlagEndErpFrame = false;
            Entry.GFlagThrough = false;
            Entry.GFlagEndTime = 0;
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
