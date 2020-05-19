using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hackio.IO.BCAM;

namespace LaunchCamPlus.CameraPanels
{
    public partial class EyeposFixThereCameraPanel : CameraPanelBase
    {
        public EyeposFixThereCameraPanel()
        {
            InitializeComponent();
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
            RotationZNumericUpDown.Value = (decimal)Entry.RotationZ.RadianToDegree();
            Num1CheckBox.Checked = Entry.Num1 > 0;
            StringTextBox.Text = Entry.String;
            CamIntNumericUpDown.Value = Entry.TransitionTime;
            CamEndIntNumericUpDown.Value = Entry.TransitionEndTime;
            FrontOffsetNumericUpDown.Value = (decimal)Entry.FrontOffset;
            HeightOffsetNumericUpDown.Value = (decimal)Entry.HeightOffset;
            EventFrameNumericUpDown.Value = Entry.EventFrames;

            FixpointVector3NumericUpDown.LoadVector3(Entry.FixPointOffset);
            UpAxisVector3NumericUpDown.LoadVector3(Entry.UpAxis);
            
            SharpZoomCheckBox.Checked = !Entry.SharpZoom;
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
            Entry.RotationY = 0.0f;
            Entry.RotationZ = ((float)RotationZNumericUpDown.Value).DegreeToRadian();
            Entry.Num1 = Num1CheckBox.Checked ? 1 : 0;
            //Entry.Num2 = Num2CheckBox.Checked ? 1 : 0;
            Entry.String = StringTextBox.Text;
            Entry.FieldOfView = 45.0f;
            Entry.MaxY = 0;
            Entry.MinY = 0;
            Entry.TransitionTime = (int)CamIntNumericUpDown.Value;
            Entry.TransitionEndTime = (int)CamEndIntNumericUpDown.Value;
            Entry.FrontOffset = (float)FrontOffsetNumericUpDown.Value;
            Entry.HeightOffset = (float)HeightOffsetNumericUpDown.Value;
            Entry.GroundMoveDelay = 0;
            Entry.AirMoveDelay = 0;
            Entry.UpperBorder = 0.0f;
            Entry.LowerBorder = 0.0f;
            Entry.EventFrames = (int)EventFrameNumericUpDown.Value;
            Entry.EventPriority = Entry.IsOfCategory("e") ? 1 : 0;
            Entry.FixPointOffset = FixpointVector3NumericUpDown.GetVector3();
            Entry.VerticalPanAxis = new Vector3<float>();
            Entry.UpAxis = UpAxisVector3NumericUpDown.GetVector3();
            Entry.DisableReset = false;
            Entry.EnableFoV = false;
            Entry.SharpZoom = !SharpZoomCheckBox.Checked;
            Entry.DisableAntiBlur = false;
            Entry.DisableCollision = false;
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
    }
}
