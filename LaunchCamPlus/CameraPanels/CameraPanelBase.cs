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
using LaunchCamPlus.Properties;

namespace LaunchCamPlus.CameraPanels
{
    public partial class CameraPanelBase : UserControl, ICameraPanel
    {
        protected CameraPanelBase() 
        {
            InitializeComponent();
            Loading = true;
            TypeComboBox.DataSource = Enum.GetValues(typeof(CameraType));
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            TypeComboBox.Resize += (s, e) => {
                if (!TypeComboBox.IsHandleCreated)
                    return;

                TypeComboBox.BeginInvoke(new Action(() => {
                    var parent = TypeComboBox.FindForm();
                    if (parent == null)
                        return;

                    if (parent.ActiveControl == null)
                        return;

                    if (parent.ActiveControl == TypeComboBox)
                        return;

                    TypeComboBox.SelectionLength = 0;
                }));
            };
            TypeComboBox.MouseWheel += TypeComboBox_MouseWheel;
            Loading = false;
        }

        public string CameraType { get; set; }
        protected bool Loading = false;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;      // WS_EX_COMPOSITED
                return handleParam;
            }
        }

        public virtual void ReloadTheme()
        {
            TypeComboBox.ForeColor =
                IDTextBox.ForeColor =
                TypeLabel.ForeColor =
                IDLabel.ForeColor = ProgramColours.TextColour;

            IDTextBox.BackColor =
            IDTextBox.BorderColor =
                TypeComboBox.BackColor = ProgramColours.WindowColour;

            TypeComboBox.BorderColor = ProgramColours.BorderColour;
        }

        public virtual void ResizeEnd()
        {

        }


        public virtual void LoadCamera(BCAMEntry Entry)
        {
            Loading = true;
            IDTextBox.Text = Entry.Identification;
            TypeComboBox.Text = Entry.Type;
            Loading = false;
        }

        public virtual void UnLoadCamera(BCAMEntry Entry)
        {
            Entry.Identification = IDTextBox.Text;
            Entry.Type = TypeComboBox.Text;
        }

        private void IDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            int cursorpos = IDTextBox.SelectionStart;
            ((CameraEditorForm)ParentForm).RefreshSelected(IDTextBox.Text);
            IDTextBox.Focus();
            IDTextBox.SelectionStart = cursorpos;
            IDTextBox.SelectionLength = 0;
        }

        public void UpdateID(string id) => IDTextBox.Text = id;

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading || Settings.Default.IsUseDefaultOnly)
                return;

            ((CameraEditorForm)ParentForm)?.ReloadEditor(true);
        }

        void TypeComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (sender is ComboBox cb && !cb.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        public string CurrentCameraType { get { return TypeComboBox.Text; } }
    }

    /// <summary>
    /// The Enumerator of Camera Types
    /// </summary>
    public enum CameraType
    {
        CAM_TYPE_2D_SLIDE, //Slides 4 ways only. (Not forward or backward)
        CAM_TYPE_ANIM,
        CAM_TYPE_BEHIND_DEBUG,
        CAM_TYPE_BLACK_HOLE,
        CAM_TYPE_BOSS_DONKETSU,
        CAM_TYPE_CHARMED_FIX,
        CAM_TYPE_CHARMED_VECREG,
        CAM_TYPE_CHARMED_VECREG_TOWER,
        CAM_TYPE_CUBE_PLANET, //Allows the camera to rotate to fit the current gravity
        CAM_TYPE_DEAD,
        CAM_TYPE_DONKETSU_TEST,
        CAM_TYPE_DPD,
        CAM_TYPE_EYEPOS_FIX, //Moves the camera to a fixed location
        CAM_TYPE_EYEPOS_FIX_THERE, //Freezes the camera on place - Only rotates until freed
        CAM_TYPE_EYE_FIXED_THERE_TEST,
        CAM_TYPE_FOLLOW,
        CAM_TYPE_FOO_FIGHTER, //Red Star Related
        CAM_TYPE_FOO_FIGHTER_PLANET, //Red Star Related
        CAM_TYPE_FREEZE,
        CAM_TYPE_FRONT_AND_BACK,
        CAM_TYPE_GROUND,
        CAM_TYPE_ICECUBE_PLANET,
        CAM_TYPE_INNER_CYLINDER,
        CAM_TYPE_INWARD_SPHERE,
        CAM_TYPE_INWARD_TOWER, //Moves around a fixpoint so the fixpoint X & Z pos is never visible (Unconfirmed)
        CAM_TYPE_INWARD_TOWER_TEST,
        CAM_TYPE_MEDIAN_PLANET,
        CAM_TYPE_MEDIAN_TOWER,
        CAM_TYPE_MTXREG_PARALLEL,
        CAM_TYPE_OBJ_PARALLEL, //Moves based on Mario's position. Usually used for Flying
        CAM_TYPE_POINT_FIX,
        CAM_TYPE_RACE_FOLLOW,
        CAM_TYPE_RAIL_DEMO,
        CAM_TYPE_RAIL_FOLLOW,
        CAM_TYPE_RAIL_WATCH,
        CAM_TYPE_SLIDER,
        CAM_TYPE_SPHERE_TRUNDLE,
        CAM_TYPE_SPIRAL_DEMO,
        CAM_TYPE_SUBJECTIVE,
        CAM_TYPE_TALK, //NPC Camera
        CAM_TYPE_TOWER, //Moves around a fixpoint so the fixpoint X & Z pos is always visible
        CAM_TYPE_TOWER_POS,
        CAM_TYPE_TRIPOD_PLANET,
        CAM_TYPE_TRUNDLE,
        CAM_TYPE_TWISTED_PASSAGE,
        CAM_TYPE_WATER_FOLLOW,
        CAM_TYPE_WATER_PLANET,
        CAM_TYPE_WATER_PLANET_BOSS,
        CAM_TYPE_WONDER_PLANET,
        CAM_TYPE_XZ_PARA //The most basic camera ever.
    }
}
