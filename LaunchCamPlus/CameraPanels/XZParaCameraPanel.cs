﻿using System;
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
    public partial class XZParaCameraPanel : CameraPanelBase
    {
        public XZParaCameraPanel()
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
            RotationXNumericUpDown.Value = (decimal)Entry.RotationX.RadianToDegree();
            RotationYNumericUpDown.Value = (decimal)Entry.RotationY.RadianToDegree();
            RotationZNumericUpDown.Value = (decimal)Entry.RotationZ.RadianToDegree();
            ZoomNumericUpDown.Value = (decimal)Entry.Zoom;
            Num1CheckBox.Checked = Entry.Num1 > 0;
            Num2CheckBox.Checked = Entry.Num2 > 0;
            StringTextBox.Text = Entry.String;
            FieldOfViewNumericUpDown.Value = (decimal)Entry.FieldOfView;
            JumpingYNumericUpDown.Value = (decimal)Entry.MaxY;
            FallingYNumericUpDown.Value = (decimal)Entry.MinY;
            CamIntNumericUpDown.Value = Entry.TransitionTime;
            CamEndIntNumericUpDown.Value = Entry.TransitionEndTime;
            FrontOffsetNumericUpDown.Value = (decimal)Entry.FrontOffset;
            HeightOffsetNumericUpDown.Value = (decimal)Entry.HeightOffset;
            GroundDelayNumericUpDown.Value = Entry.GroundMoveDelay;
            AirDelayNumericUpDown.Value = Entry.AirMoveDelay;
            UpperBorderNumericUpDown.Value = (decimal)Entry.UpperBorder;
            LowerBorderNumericUpDown.Value = (decimal)Entry.LowerBorder;
            EventFrameNumericUpDown.Value = Entry.EventFrames;

            FixpointVector3NumericUpDown.LoadVector3(Entry.FixPointOffset);
            VerticalPanAxisVector3NumericUpDown.LoadVector3(Entry.VerticalPanAxis);
            UpAxisVector3NumericUpDown.LoadVector3(Entry.UpAxis);
            
            FieldOfViewCheckBox.Checked = Entry.EnableFoV;
            SharpZoomCheckBox.Checked = !Entry.SharpZoom;
            DisableAntiBlurCheckBox.Checked = Entry.DisableAntiBlur;
            DisableCollisionCheckBox.Checked = Entry.DisableCollision;
            DisableFirstPersonCheckBox.Checked = !Entry.DisableFirstPerson;
            GFlagEndErpFrameCheckBox.Checked = Entry.GFlagEndErpFrame;
            GFlagThroughCheckBox.Checked = Entry.GFlagThrough;
            GFlagEndTimeNumericUpDown.Value = (decimal)Entry.GFlagEndTime;
            UseVerticalPanAxisCheckBox.Checked = Entry.EnableVerticalPanAxis;
            EventUseTimeCheckBox.Checked = Entry.EventUseTransitionTime;
            EventUseEndTimeCheckBox.Checked = Entry.EventUseTransitionEndTime;
        }
        
        public override void UnLoadCamera(BCAMEntry Entry)
        {
            base.UnLoadCamera(Entry);
            Entry.RotationX = ((float)RotationXNumericUpDown.Value).DegreeToRadian();
            Entry.RotationY = ((float)RotationYNumericUpDown.Value).DegreeToRadian();
            Entry.RotationZ = ((float)RotationZNumericUpDown.Value).DegreeToRadian();
            Entry.Zoom = (float)ZoomNumericUpDown.Value;
            Entry.Num1 = Num1CheckBox.Checked ? 1 : 0;
            Entry.Num2 = Num2CheckBox.Checked ? 1 : 0;
            Entry.String = StringTextBox.Text;
            Entry.FieldOfView = (float)FieldOfViewNumericUpDown.Value;
            Entry.MaxY = (float)JumpingYNumericUpDown.Value;
            Entry.MinY = (float)FallingYNumericUpDown.Value;
            Entry.TransitionTime = (int)CamIntNumericUpDown.Value;
            Entry.TransitionEndTime = (int)CamEndIntNumericUpDown.Value;
            Entry.FrontOffset = (float)FrontOffsetNumericUpDown.Value;
            Entry.HeightOffset = (float)HeightOffsetNumericUpDown.Value;
            Entry.GroundMoveDelay = (int)GroundDelayNumericUpDown.Value;
            Entry.AirMoveDelay = (int)AirDelayNumericUpDown.Value;
            Entry.UpperBorder = (float)UpperBorderNumericUpDown.Value;
            Entry.LowerBorder = (float)LowerBorderNumericUpDown.Value;
            Entry.EventFrames = (int)EventFrameNumericUpDown.Value;
            Entry.EventPriority = Entry.IsOfCategory("e") ? 1 : 0;
            Entry.FixPointOffset = FixpointVector3NumericUpDown.GetVector3();
            Entry.VerticalPanAxis = VerticalPanAxisVector3NumericUpDown.GetVector3();
            Entry.UpAxis = UpAxisVector3NumericUpDown.GetVector3();
            Entry.DisableReset = false;
            Entry.EnableFoV = FieldOfViewCheckBox.Checked;
            Entry.SharpZoom = !SharpZoomCheckBox.Checked;
            Entry.DisableAntiBlur = DisableAntiBlurCheckBox.Checked;
            Entry.DisableCollision = DisableCollisionCheckBox.Checked;
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
