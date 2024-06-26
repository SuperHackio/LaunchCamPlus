using LaunchCamPlus.ExtraControls;
using LaunchCamPlus.Formats;
using System.Text.RegularExpressions;

namespace LaunchCamPlus
{
    public partial class IdentificationAssistant : UserControl
    {
        public IdentificationAssistant()
        {
            InitializeComponent();
            CategoryComboBox.SelectedIndex = 0;
            EventComboBox.DataSource = new BindingSource(BCAMUtility.EventData.Events, null);
            EventComboBox.DisplayMember = "Value";
            EventComboBox.ValueMember = "Key";
            this.SetDoubleBuffered();
            EventComboBox.SetDoubleBuffered();
            CategoryComboBox.SetDoubleBuffered();
            CamIDNumericUpDown.ValueChange2 += CamIDNumericUpDown_ValueChanged;
            SubCamIDNumericUpDown.ValueChange2 += CamIDNumericUpDown_ValueChanged;
        }

        public void ReloadTheme() => ControlEx.ReloadTheme(this);

        private void IdentificationAssistant_Resize(object sender, EventArgs e)
        {
            CategoryComboBox.Size = new Size(PartLabel.Location.X - CategoryComboBox.Location.X - 3, CategoryComboBox.Size.Height);
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
                    EventComboBox.DataSource = new BindingSource(CategoryComboBox.SelectedIndex == 3 ? BCAMUtility.EventData.OtherEvents : BCAMUtility.EventData.Events, null);
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

        private void CamIDNumericUpDown_ValueChanged(EventArgs e)
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
                    if (EventComboBox.SelectedValue is null)
                        break;
                    string? x = EventComboBox.SelectedValue.ToString();
                    if (x is null)
                        break;
                    if (!x.StartsWith("g:"))
                        final += "e:";
                    final += x;
                    if (((dynamic)EventComboBox.SelectedItem).Value.NeedsSubID)
                    {
                        final += $":{(int)CamIDNumericUpDown.Value:000}:{(int)SubCamIDNumericUpDown.Value:00}番目";
                    }
                    else if (((dynamic)EventComboBox.SelectedItem).Value.NeedsID)
                    {
                        final += $"{(int)CamIDNumericUpDown.Value:000}";
                    }
                    break;
                case 3:
                    final += "o:" + EventComboBox.SelectedValue?.ToString();
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
            CameraEditorForm? x = (CameraEditorForm?)ParentForm;
            if (x is null || x.Cameras is null)
                return;

            switch (CategoryComboBox.SelectedIndex)
            {
                case 0:
                    CamIDNumericUpDown.Value = BCAMUtility.GetNextOpenShortNumber(x.Cameras, BCAMUtility.CameraAreaIDRegex());
                    break;
                case 1:
                    CamIDNumericUpDown.Value = BCAMUtility.GetNextOpenShortNumber(x.Cameras, BCAMUtility.StartIDRegex());
                    break;
                case 2:
                    if (EventComboBox.SelectedValue is null)
                        break;
                    string? why = EventComboBox.SelectedValue.ToString();
                    if (why is null)
                        break;
                    BCAMUtility.EventData evt = BCAMUtility.EventData.Events[why];
                    Regex EventRegex = BCAMUtility.CreateEventIDRegex(why, evt.NeedsSubID);
                    CamIDNumericUpDown.Value = BCAMUtility.GetNextOpenEventNumber(x.Cameras, EventRegex);
                    break;
                default:
                    break;
            }
        }
    }
}
