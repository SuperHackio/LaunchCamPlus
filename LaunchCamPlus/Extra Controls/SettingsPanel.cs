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
    public partial class SettingsPanel : UserControl
    {
        public SettingsPanel(CameraEditorForm parent)
        {
            InitializeComponent();
            Loading = true;
            ParentCameraEditor = parent;
            DarkModeCheckBox.Checked = Settings.Default.IsDarkMode;
            UseHexCheckBox.Checked = Settings.Default.IsUseHexID;
            LongNumberCheckBox.Checked = Settings.Default.IsUseLongID;
            YAZ0CheckBox.Checked = Settings.Default.IsUseYAZ0;
            EnforceCompressCheckbox.Checked = Settings.Default.IsEnforceCompress;
            UniqueEditorsCheckbox.Checked = !Settings.Default.IsUseDefaultOnly;
            ShowAboutCheckBox.Checked = Settings.Default.IsShowAboutOnLaunch;
            SfxCheckBox.Checked = Settings.Default.EnableSFX;
            string tmp = Settings.Default.SplashSize.Width + "x" + Settings.Default.SplashSize.Height;
            SplashSizeComboBox.SelectedItem = tmp;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Loading = false;
        }

        CameraEditorForm ParentCameraEditor;
        bool Loading = false;

        private void DarkModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            Settings.Default.IsDarkMode = DarkModeCheckBox.Checked;
            Console.WriteLine($"Theme Changed to {(DarkModeCheckBox.Checked ? "Dark Theme":"Light Theme")}");
            ParentCameraEditor.ReloadTheme();
        }

        public void ReloadTheme()
        {
            ForeColor =
                SplashSizeComboBox.ForeColor =
                VisualSettingsGroupBox.ForeColor =
                InternalSettingsGroupBox.ForeColor =
                FunSettingsGroupBox.ForeColor = ProgramColours.TextColour;

            SplashSizeComboBox.BackColor = ProgramColours.WindowColour;
            SplashSizeComboBox.BorderColor = ProgramColours.BorderColour;
        }

        private void SettingsPanel_Resize(object sender, EventArgs e)
        {
            LogoPictureBox.Size = new Size(LogoPictureBox.Size.Width, VisualSettingsGroupBox.Location.Y-6);
        }

        private void UseHexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            Settings.Default.IsUseHexID = UseHexCheckBox.Checked;
            Console.WriteLine($"Hex Numbers {(UseHexCheckBox.Checked ? "Enabled":"Disabled")}");
            ParentCameraEditor.ReloadCameraListBox();
        }

        private void LongNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            Settings.Default.IsUseLongID = LongNumberCheckBox.Checked;
            Console.WriteLine($"Long Numbers {(LongNumberCheckBox.Checked ? "Enabled" : "Disabled")}");
            ParentCameraEditor.ReloadCameraListBox();
        }

        private void YAZ0CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            Settings.Default.IsUseYAZ0 = YAZ0CheckBox.Checked;
            Console.WriteLine($"YAZ0 Saving {(YAZ0CheckBox.Checked ? "Enabled" : "Disabled")}");
        }

        private void EnforceCompressCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            Settings.Default.IsEnforceCompress = EnforceCompressCheckbox.Checked;
            Console.WriteLine($"Advanced Saving {(EnforceCompressCheckbox.Checked ? "Enabled" : "Disabled")}");
        }

        private void UniqueEditorsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            Settings.Default.IsUseDefaultOnly = !UniqueEditorsCheckbox.Checked;
            Console.WriteLine($"Default Editor Only {(!UniqueEditorsCheckbox.Checked ? "Enabled" : "Disabled")}");
        }

        private void SplashSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            Settings.Default.SplashSize = new Size(int.Parse(SplashSizeComboBox.SelectedItem.ToString().Split('x')[0]), int.Parse(SplashSizeComboBox.SelectedItem.ToString().Split('x')[1]));
            Console.WriteLine($"Splash Size set to {Settings.Default.SplashSize.Width}x{Settings.Default.SplashSize.Height}");
        }

        private void ShowSplashButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Preparing the Splash...");
            Task SplashTask = Task.Run(() =>
            {
                SplashForm SF = new SplashForm(3);
                Console.WriteLine("Running Splash Screen:");
                SF.ShowDialog();
                SF.Dispose();
            });
            SplashTask.Wait();
            Console.WriteLine("Splash Completed!");
        }

        private void ShowAboutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            Settings.Default.IsShowAboutOnLaunch = ShowAboutCheckBox.Checked;
            Console.WriteLine($"Show About on Launch {(ShowAboutCheckBox.Checked ? "Enabled" : "Disabled")}");
        }

        private void SfxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            Settings.Default.EnableSFX = SfxCheckBox.Checked;
            Console.WriteLine($"Sound Effects {(SfxCheckBox.Checked ? "Enabled" : "Disabled")}");
        }
    }
}
