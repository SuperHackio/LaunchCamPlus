using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchCamPlus
{
    public partial class Vector3NumericUpDown : UserControl
    {
        public Vector3NumericUpDown()
        {
            InitializeComponent();
            XValueNumericUpDown.ValueChange2 += NumberValueChanged;
            YValueNumericUpDown.ValueChange2 += NumberValueChanged;
            ZValueNumericUpDown.ValueChange2 += NumberValueChanged;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get
            {
                return NameLabel.Text;
            }
            set
            {
                NameLabel.Text = value;
            }
        }

        public void ReloadTheme()
        {
            XValueNumericUpDown.BackColor = YValueNumericUpDown.BackColor = ZValueNumericUpDown.BackColor = ProgramColours.WindowColour;
            NameLabel.ForeColor = XValueNumericUpDown.ForeColor = YValueNumericUpDown.ForeColor = ZValueNumericUpDown.ForeColor = ProgramColours.TextColour;
            XValueNumericUpDown.BorderColor = YValueNumericUpDown.BorderColor = ZValueNumericUpDown.BorderColor = ProgramColours.BorderColour;
        }

        public void LoadVector3(Vector3<float> Input)
        {
            XValueNumericUpDown.Value = (decimal)Input.XValue;
            YValueNumericUpDown.Value = (decimal)Input.YValue;
            ZValueNumericUpDown.Value = (decimal)Input.ZValue;
        }

        public Vector3<float> GetVector3()
        {
            return new Vector3<float>((float)XValueNumericUpDown.Value, (float)YValueNumericUpDown.Value, (float)ZValueNumericUpDown.Value);
        }

        [Category("Action")]
        [Browsable(true)]
        public event EventHandler ValueChanged;

        private void NumberValueChanged(EventArgs e)
        {
            ValueChanged(null, e);
        }
    }
}
