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
    public partial class PointFixCameraPanel : CameraPanelBase
    {
        public PointFixCameraPanel()
        {
            InitializeComponent();
            SetupUnsaved();
        }


        public override void LoadCamera(BCAMEntry Entry)
        {
            base.LoadCamera(Entry);
            Loading = true;
            StringTextBox.Text = Entry.String;
            FieldOfViewNumericUpDown.Value = (decimal)Entry.FieldOfView;
            CamIntNumericUpDown.Value = Entry.TransitionTime;
            CamEndIntNumericUpDown.Value = Entry.TransitionEndTime;
            EventFrameNumericUpDown.Value = Entry.EventFrames;

            FixpointVector3NumericUpDown.LoadVector3(Entry.FixPointOffset);
            WorldOffsetVector3NumericUpDown.LoadVector3(Entry.WorldPointOffset);
            Vector3<float> PlayerOffset = Entry.PlayerOffset;
            PlayerOffsetYNumericUpDown.Value = (decimal)PlayerOffset.YValue.RadianToDegree();
            PlayerOffsetXNumericUpDown.Value = (decimal)PlayerOffset.XValue.RadianToDegree();
            UpAxisVector3NumericUpDown.LoadVector3(Entry.UpAxis);

            FieldOfViewCheckBox.Checked = Entry.EnableFoV;
            DisableCollisionCheckBox.Checked = Entry.DisableCollision;
            DisableFirstPersonCheckBox.Checked = !Entry.DisableFirstPerson;
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
            Entry.EventPriority = Entry.IsOfCategory("e") ? 1 : 0;
            Entry.FixPointOffset = FixpointVector3NumericUpDown.GetVector3();
            Entry.WorldPointOffset = WorldOffsetVector3NumericUpDown.GetVector3();
            Entry.PlayerOffset = new Vector3<float>(((float)PlayerOffsetXNumericUpDown.Value).DegreeToRadian(), ((float)PlayerOffsetYNumericUpDown.Value).DegreeToRadian(), 0);
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
        }

        private void FieldOfViewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FieldOfViewNumericUpDown.Enabled = FieldOfViewCheckBox.Checked;
        }
    }
}
