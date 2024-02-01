using LaunchCamPlus.ExtraControls;
using LaunchCamPlus.Formats;
using System.Diagnostics.CodeAnalysis;

namespace LaunchCamPlus.CameraPanels
{
    public partial class CameraPanelBase : UserControl, ICameraPanel, IReloadTheme
    {
        public string CameraType
        {
            get => Item?.Type ?? "";
            set => Item.Type = value;
        }
        protected bool Loading = false;
        [AllowNull] //don't use the ? here
        protected BCAM.Entry _Item;
        public BCAM.Entry Item
        {
            get => _Item;
            set => _Item = value;
        }

        protected delegate void CameraIdChangeDelegate(string CameraId);
        protected event CameraIdChangeDelegate? OnCameraIdChange = null;

        protected CameraPanelBase()
        {
            InitializeComponent();
            Loading = true;
            TypeComboBox.DataSource = Enum.GetValues(typeof(BCAM.CameraType));
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            TypeComboBox.Resize += (s, e) =>
            {
                if (!TypeComboBox.IsHandleCreated)
                    return;

                TypeComboBox.BeginInvoke(new Action(() =>
                {
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
            SetupUnsaved();
            Loading = false;
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;      // WS_EX_COMPOSITED
                return handleParam;
            }
        }

        public void ReloadTheme() => ControlEx.ReloadTheme(this);

        public virtual void ResizeEnd()
        {

        }


        public virtual void LoadCamera(BCAM.Entry Entry)
        {
            Item = Entry;
            IDTextBox.Text = Entry.Identification;
            TypeComboBox.Text = Entry.Type;
        }

        public virtual void UnloadCamera()
        {
            Item.Identification = IDTextBox.Text;
            char x = Item.Identification.ToLower()[0];
            if (x == 's' || x == 'c')
            {
                Item.Identification = Item.Identification.ToLower();
            }
            Item.Type = TypeComboBox.Text;
        }

        private void IDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                Item.Identification = IDTextBox.Text;
                Program.UpdateCameraId(Item);
            }
            OnCameraIdChange?.Invoke(Item.Identification);
            //int cursorpos = IDTextBox.SelectionStart;
            //((CameraEditorForm)ParentForm).RefreshSelected(IDTextBox.Text);
            //IDTextBox.Focus();
            //IDTextBox.SelectionStart = cursorpos;
            //IDTextBox.SelectionLength = 0;
        }

        public void UpdateID(string id)
        {
            IDTextBox.Text = id;
            IndicateChangeMade();
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading || !Program.Settings.IsUseUniqueEditor)
                return;

            Item.Type = TypeComboBox.Text;
            Program.ReloadEditorPanel();
        }

        void TypeComboBox_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (sender is ComboBox cb && !cb.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        public string CurrentCameraType => TypeComboBox.Text;

        protected void IndicateChangeMade() => Program.IsUnsavedChanges = !Loading || Program.IsUnsavedChanges;
        protected void IndicateChangeMade(EventArgs e) => IndicateChangeMade();
        protected void IndicateChangeMade(object? sender, EventArgs e) => IndicateChangeMade();


        protected void SetupUnsaved()
        {
            foreach (Control c in Controls)
            {
                if (c is ColourNumericUpDown CNUD)
                    CNUD.ValueChange2 += IndicateChangeMade;
                else if (c is ColourTextBox CTB)
                    CTB.TextChanged += IndicateChangeMade;
                else if (c is Vector3NumericUpDown V3NUD)
                    V3NUD.ValueChanged += IndicateChangeMade;
                else if (c is CheckBox CB)
                    CB.CheckedChanged += IndicateChangeMade;
                else if (c is ComboBox CMB)
                    CMB.SelectedIndexChanged += IndicateChangeMade;
            }
        }
    }


}
