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
    public partial class WanderPlanetCameraPanel : CameraPanelBase
    {
        public WanderPlanetCameraPanel()
        {
            InitializeComponent();
            PlayerOffsetYNumericUpDown.ValueChange2 = PlayerOffsetYNumericUpDown_ValueChange2;
            PlayerOffsetXNumericUpDown.ValueChange2 = PlayerOffsetXNumericUpDown_ValueChange2;
        }

        public override void ReloadTheme()
        {
            base.ReloadTheme();

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is Label || Controls[i] is CheckBox)
                {
                    Controls[i].ForeColor = ProgramColours.TextColour;
                }
                if (Controls[i] is ColourNumericUpDown)
                {
                    Controls[i].BackColor = ProgramColours.WindowColour;
                    Controls[i].ForeColor = ProgramColours.TextColour;
                    ((ColourNumericUpDown)Controls[i]).BorderColor = ProgramColours.BorderColour;
                }
                if (Controls[i] is Vector3NumericUpDown)
                {
                    ((Vector3NumericUpDown)Controls[i]).ReloadTheme();
                }
                if (Controls[i] is ColourTextBox)
                {
                    Controls[i].BackColor = ProgramColours.WindowColour;
                    Controls[i].ForeColor = ProgramColours.TextColour;
                    ((ColourTextBox)Controls[i]).BorderColor = ProgramColours.BorderColour;
                }
                if (Controls[i] is GroupBox)
                {
                    Controls[i].ForeColor = ProgramColours.TextColour;
                    Controls[i].BackColor = ProgramColours.ControlBackColor;
                }
            }
        }

        public override void LoadCamera(BCAMEntry Entry)
        {
            base.LoadCamera(Entry);
            RotationYNumericUpDown.Value = Math.Min(RotationYNumericUpDown.Maximum, Math.Max(RotationYNumericUpDown.Minimum, (decimal)Entry.RotationY.RadianToDegree()));
            StringTextBox.Text = Entry.String;
            FieldOfViewNumericUpDown.Value = (decimal)Entry.FieldOfView;
            CamIntNumericUpDown.Value = Entry.TransitionTime;
            CamEndIntNumericUpDown.Value = Entry.TransitionEndTime;
            FrontOffsetNumericUpDown.Value = (decimal)Entry.LookOffset;
            HeightOffsetNumericUpDown.Value = (decimal)Entry.LookOffsetVertical;
            EventFrameNumericUpDown.Value = Entry.EventFrames;

            FixpointVector3NumericUpDown.LoadVector3(Entry.FixPointOffset);
            Vector3<float> PlayerOffset = Entry.PlayerOffset;
            PlayerOffsetYNumericUpDown.Value = (decimal)PlayerOffset.YValue;
            PlayerOffsetXNumericUpDown.Value = (decimal)PlayerOffset.XValue;

            FieldOfViewCheckBox.Checked = Entry.EnableFoV;
            SharpZoomCheckBox.Checked = Entry.StaticLookOffset;
            DisableAntiBlurCheckBox.Checked = Entry.DisableAntiBlur;
            DisableCollisionCheckBox.Checked = Entry.DisableCollision;
            DisableFirstPersonCheckBox.Checked = !Entry.DisableFirstPerson;
            GFlagEndErpFrameCheckBox.Checked = Entry.GFlagEndErpFrame;
            GFlagThroughCheckBox.Checked = Entry.GFlagThrough;
            GFlagEndTimeNumericUpDown.Value = (decimal)Entry.GFlagEndTime;
            EventUseTimeCheckBox.Checked = Entry.EventUseTransitionTime;
            EventUseEndTimeCheckBox.Checked = Entry.EventUseTransitionEndTime;
        }

        public override void UnLoadCamera(BCAMEntry Entry)
        {
            base.UnLoadCamera(Entry);
            Entry.RotationX = 0.0f;
            Entry.RotationY = ((float)RotationYNumericUpDown.Value).DegreeToRadian();
            Entry.RotationZ = 0.0f;
            Entry.Zoom = 0;
            Entry.Num1 = 0;
            Entry.Num2 = 0;
            Entry.String = StringTextBox.Text;
            Entry.FieldOfView = (float)FieldOfViewNumericUpDown.Value;
            Entry.MaxY = 300;
            Entry.MinY = 800;
            Entry.TransitionTime = (int)CamIntNumericUpDown.Value;
            Entry.TransitionEndTime = (int)CamEndIntNumericUpDown.Value;
            Entry.LookOffset = (float)FrontOffsetNumericUpDown.Value;
            Entry.LookOffsetVertical = (float)HeightOffsetNumericUpDown.Value;
            Entry.GroundMoveDelay = 120;
            Entry.AirMoveDelay = 120;
            Entry.UpperBorder = 0.3f;
            Entry.LowerBorder = 0.3f;
            Entry.EventFrames = (int)EventFrameNumericUpDown.Value;
            Entry.EventPriority = Entry.IsOfCategory("e") ? 1 : 0;
            Entry.FixPointOffset = FixpointVector3NumericUpDown.GetVector3();
            Entry.PlayerOffset = new Vector3<float>((float)PlayerOffsetXNumericUpDown.Value, (float)PlayerOffsetYNumericUpDown.Value, 0);
            Entry.VerticalPanAxis = new Vector3<float>(0,0,0);
            Entry.UpAxis = new Vector3<float>(0, 0, 0);
            Entry.DisableReset = false;
            Entry.EnableFoV = FieldOfViewCheckBox.Checked;
            Entry.StaticLookOffset = SharpZoomCheckBox.Checked;
            Entry.DisableAntiBlur = DisableAntiBlurCheckBox.Checked;
            Entry.DisableCollision = DisableCollisionCheckBox.Checked;
            Entry.DisableFirstPerson = !DisableFirstPersonCheckBox.Checked;
            Entry.GFlagEndErpFrame = GFlagEndErpFrameCheckBox.Checked;
            Entry.GFlagThrough = GFlagThroughCheckBox.Checked;
            Entry.GFlagEndTime = (int)GFlagEndTimeNumericUpDown.Value;
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

        private void PlayerOffsetYNumericUpDown_ValueChange2(EventArgs e)
        {
            if (PlayerOffsetYNumericUpDown.Value < PlayerOffsetXNumericUpDown.Value)
                PlayerOffsetXNumericUpDown.Value = PlayerOffsetYNumericUpDown.Value;
        }

        private void PlayerOffsetXNumericUpDown_ValueChange2(EventArgs e)
        {
            if (PlayerOffsetYNumericUpDown.Value < PlayerOffsetXNumericUpDown.Value)
                PlayerOffsetYNumericUpDown.Value = PlayerOffsetXNumericUpDown.Value;
        }
    }
}
