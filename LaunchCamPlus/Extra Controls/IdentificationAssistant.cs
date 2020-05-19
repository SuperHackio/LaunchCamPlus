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

namespace LaunchCamPlus
{
    public partial class IdentificationAssistant : UserControl
    {
        public IdentificationAssistant()
        {
            InitializeComponent();
            CategoryComboBox.SelectedIndex = 0;
            EventComboBox.DataSource = new BindingSource(BCAMEx.Events, null);
            EventComboBox.DisplayMember = "Value";
            EventComboBox.ValueMember = "Key";
            this.SetDoubleBuffered();
            EventComboBox.SetDoubleBuffered();
            CategoryComboBox.SetDoubleBuffered();
        }

        public void ReloadTheme()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is Label)
                {
                    Controls[i].ForeColor = ProgramColours.TextColour;
                }
                else if (Controls[i] is ColourNumericUpDown)
                {
                    Controls[i].BackColor = ProgramColours.WindowColour;
                    Controls[i].ForeColor = ProgramColours.TextColour;
                    ((ColourNumericUpDown)Controls[i]).BorderColor = ProgramColours.BorderColour;
                }
                else if (Controls[i] is ColourTextBox)
                {
                    Controls[i].BackColor = ProgramColours.WindowColour;
                    Controls[i].ForeColor = ProgramColours.TextColour;
                    ((ColourTextBox)Controls[i]).BorderColor = ProgramColours.BorderColour;
                }
                else if (Controls[i] is Button)
                {
                    Controls[i].BackColor = ProgramColours.ControlBackColor;
                    Controls[i].ForeColor = ProgramColours.TextColour;
                }
                else if (Controls[i] is ColourComboBox)
                {
                    Controls[i].BackColor = ProgramColours.WindowColour;
                    Controls[i].ForeColor = ProgramColours.TextColour;
                    ((ColourComboBox)Controls[i]).BorderColor = ProgramColours.BorderColour;
                }
            }
        }

        private void IdentificationAssistant_Resize(object sender, EventArgs e)
        {
            CategoryComboBox.Size = new Size(PartLabel.Location.X-CategoryComboBox.Location.X-3, CategoryComboBox.Size.Height);
            CamIDNumericUpDown.Size = new Size(CategoryComboBox.Size.Width, CamIDNumericUpDown.Size.Height);

            EventComboBox.Size = new Size(ApplyButton.Location.X - EventComboBox.Location.X - 3, EventComboBox.Size.Height);
            SubCamIDNumericUpDown.Size = new Size(EventComboBox.Size.Width, SubCamIDNumericUpDown.Size.Height);
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CategoryComboBox.SelectedIndex)
            {
                case 2:
                case 3:
                    EventComboBox.Enabled = true;
                    EventComboBox.DataSource = new BindingSource(CategoryComboBox.SelectedIndex == 3 ? BCAMEx.OtherEvents : BCAMEx.Events, null);
                    break;
                case 0:
                case 1:
                    EventComboBox.Enabled = false;
                    break;
            }
            BuildEvent();
        }

        private void EventComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EventComboBox.SelectedIndex == -1)
            {
                SubCamIDNumericUpDown.Enabled = false;
                return;
            }
            SubCamIDNumericUpDown.Enabled = ((dynamic)EventComboBox.SelectedItem).Value.NeedsSubID;
            CamIDNumericUpDown.Enabled = ((dynamic)EventComboBox.SelectedItem).Value.NeedsID;
            BuildEvent();
        }

        private void CamIDNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BuildEvent();
        }

        private void SubCamIDNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BuildEvent();
        }

        private void BuildEvent()
        {
            string final = "";
            switch (CategoryComboBox.SelectedIndex)
            {
                case 0:
                    final += "c:" + ((int)CamIDNumericUpDown.Value).ToString("x4");
                    break;
                case 1:
                    final += "s:" + ((int)CamIDNumericUpDown.Value).ToString("x4");
                    break;
                case 2:
                    final += "e:"+EventComboBox.SelectedValue.ToString();
                    if (((dynamic)EventComboBox.SelectedItem).Value.NeedsSubID)
                    {
                        final += $":{((int)CamIDNumericUpDown.Value).ToString("000")}:{((int)SubCamIDNumericUpDown.Value).ToString("00")}番目";
                    }
                    else if (((dynamic)EventComboBox.SelectedItem).Value.NeedsID)
                    {
                        final += $"{((int)CamIDNumericUpDown.Value).ToString("000")}";
                    }
                    break;
                case 3:
                    final += "o:" + EventComboBox.SelectedValue.ToString();
                    break;
            }
            IDTextBox.Text = final;
        }

        public string GetID
        {
            get
            {
                BuildEvent();
                return IDTextBox.Text;
            }
        }

        private void GetNextFreeIDButton_Click(object sender, EventArgs e)
        {
            if (((CameraEditorForm)ParentForm).Cameras == null)
                return;

            switch (CategoryComboBox.SelectedIndex)
            {
                case 0:
                    CamIDNumericUpDown.Value = BCAMEx.CalculateNextCameraArea(((CameraEditorForm)ParentForm).Cameras);
                    break;
                case 1:
                    CamIDNumericUpDown.Value = BCAMEx.CalculateNextStart(((CameraEditorForm)ParentForm).Cameras);
                    break;
                case 2:
                    CamIDNumericUpDown.Value = BCAMEx.CalculateNextEvent(((CameraEditorForm)ParentForm).Cameras, BCAMEx.Events[EventComboBox.SelectedValue.ToString()]);
                    break;
                default:
                    break;
            }
        }
    }
}
