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
    public partial class DefaultCameraPanel : CameraPanelBase
    {
        public DefaultCameraPanel() : base()
        {
            InitializeComponent();
        }

        public override void ResizeEnd()
        {
            //ZoomLabel.Location = new Point(146 - (int)((MinimumSize.Width - Width) / 3.5f), Num1Label.Location.Y);
            //ZoomNumericUpDown.Location = new Point(ZoomLabel.Location.X + ZoomLabel.Width + 6, ZoomNumericUpDown.Location.Y);

            //FieldOfViewLabel.Location = new Point(ZoomLabel.Location.X, FieldOfViewLabel.Location.Y);
            //FieldOfViewNumericUpDown.Location = new Point(FieldOfViewLabel.Location.X + FieldOfViewLabel.Width + 6, FieldOfViewNumericUpDown.Location.Y);

            //Num1Label.Location = new Point(305 - (int)((MinimumSize.Width-Width)/1.5f), Num1Label.Location.Y);
            //Num1NumericUpDown.Location = new Point(Num1Label.Location.X + Num1Label.Width + 6, Num1NumericUpDown.Location.Y);

            //Num2Label.Location = new Point(305 - (int)((MinimumSize.Width - Width) / 1.5f), Num2Label.Location.Y);
            //Num2NumericUpDown.Location = new Point(Num1NumericUpDown.Location.X, Num2NumericUpDown.Location.Y);
            //JumpingYNumericUpDown.Location = new Point(Num1NumericUpDown.Location.X, JumpingYNumericUpDown.Location.Y);
            //FallingYNumericUpDown.Location = new Point(Num1NumericUpDown.Location.X, FallingYNumericUpDown.Location.Y);

            //MaxYLabel.Location = new Point(305 - (int)((MinimumSize.Width - Width) / 1.5f), MaxYLabel.Location.Y);
            //MinYLabel.Location = new Point(305 - (int)((MinimumSize.Width - Width) / 1.5f), MinYLabel.Location.Y);

            //RotationZNumericUpDown.Width = RotationYNumericUpDown.Width = RotationXNumericUpDown.Width = (ZoomLabel.Location.X - RotationXNumericUpDown.Location.X) - 6;
            
            //ZoomNumericUpDown.Width = (Num1Label.Location.X - ZoomNumericUpDown.Location.X) - 6;
            //FieldOfViewNumericUpDown.Width = (Num2Label.Location.X - FieldOfViewNumericUpDown.Location.X) - 6;

            //JumpingYNumericUpDown.Width = FallingYNumericUpDown.Width = Num1NumericUpDown.Width = Num2NumericUpDown.Width = (Width - Num1NumericUpDown.Location.X) - 6;
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
            }
        }

        public override void LoadCamera(BCAMEntry Entry)
        {
            base.LoadCamera(Entry);
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
            FrontOffsetNumericUpDown.Value = (decimal)Entry.FrontOffset;
            HeightOffsetNumericUpDown.Value = (decimal)Entry.HeightOffset;
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

            DisableResetCheckBox.Checked = Entry.DisableReset;
            FieldOfViewCheckBox.Checked = Entry.EnableFoV;
            SharpZoomCheckBox.Checked = Entry.SharpZoom;
            DisableAntiBlurCheckBox.Checked = Entry.DisableAntiBlur;
            DisableCollisionCheckBox.Checked = Entry.DisableCollision;
            DisableFirstPersonCheckBox.Checked = Entry.DisableFirstPerson;
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
            Entry.Num1 = (int)Num1NumericUpDown.Value;
            Entry.Num2 = (int)Num2NumericUpDown.Value;
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
            Entry.EventPriority = (int)EventPriorityNumericUpDown.Value;
            Entry.FixPointOffset = FixpointVector3NumericUpDown.GetVector3();
            Entry.WorldPointOffset = WorldOffsetVector3NumericUpDown.GetVector3();
            Entry.PlayerOffset = PlayerOffsetVector3NumericUpDown.GetVector3();
            Entry.VerticalPanAxis = VerticalPanAxisVector3NumericUpDown.GetVector3();
            Entry.UpAxis = UpAxisVector3NumericUpDown.GetVector3();
            Entry.DisableReset = DisableResetCheckBox.Checked;
            Entry.EnableFoV = FieldOfViewCheckBox.Checked;
            Entry.SharpZoom = SharpZoomCheckBox.Checked;
            Entry.DisableAntiBlur = DisableAntiBlurCheckBox.Checked;
            Entry.DisableCollision = DisableCollisionCheckBox.Checked;
            Entry.DisableFirstPerson = DisableFirstPersonCheckBox.Checked;
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
    }
}
