using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaunchCamPlus.Properties;

namespace LaunchCamPlus
{
    public partial class AboutPanel : UserControl
    {
        public AboutPanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void ReloadTheme()
        {
            ForeColor = InformationTextBox.ForeColor = ProgramColours.TextColour;
            InformationTextBox.BackColor = ProgramColours.ControlBackColor;
            InformationTextBox.BorderColor = ProgramColours.BorderColour;
        }

        private void AboutPanel_Resize(object sender, EventArgs e)
        {
            LogoPictureBox.Size = new Size(LogoPictureBox.Size.Width, 50);
        }
    }
}
