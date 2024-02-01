namespace LaunchCamPlus.ExtraControls;

public partial class SettingsPanel : UserControl, IReloadTheme
{
    public SettingsPanel()
    {
        InitializeComponent();
        Loading = true;
        DarkModeCheckBox.Checked = Program.Settings.IsDarkMode;
        UseHexCheckBox.Checked = Program.Settings.IsUseHexId;
        LongNumberCheckBox.Checked = Program.Settings.IsUseLongId;
        YAZ0CheckBox.Checked = Program.Settings.IsUseYaz0;
        EnforceCompressCheckbox.Checked = Program.Settings.IsUseOnboardCompression;
        UniqueEditorsCheckbox.Checked = Program.Settings.IsUseUniqueEditor;
        IsUseSMG1DefaultsCheckBox.Checked = Program.Settings.IsUseSMG1Defaults;
        ShowAboutCheckBox.Checked = Program.Settings.IsShowAboutOnBoot;
        string tmp = Program.Settings.SplashSize.Width + "x" + Program.Settings.SplashSize.Height;
        SplashSizeComboBox.SelectedItem = tmp;
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        DarkModeCheckBox.CheckedChanged += Program.Settings.OnChanged;
        UseHexCheckBox.CheckedChanged += Program.Settings.OnChanged;
        LongNumberCheckBox.CheckedChanged += Program.Settings.OnChanged;
        YAZ0CheckBox.CheckedChanged += Program.Settings.OnChanged;
        EnforceCompressCheckbox.CheckedChanged += Program.Settings.OnChanged;
        UniqueEditorsCheckbox.CheckedChanged += Program.Settings.OnChanged;
        IsUseSMG1DefaultsCheckBox.CheckedChanged += Program.Settings.OnChanged;
        ShowAboutCheckBox.CheckedChanged += Program.Settings.OnChanged;
        SplashSizeComboBox.SelectedIndexChanged += Program.Settings.OnChanged;

        Loading = false;
    }

    private readonly bool Loading = false;

    public void ReloadTheme() => ControlEx.ReloadTheme(this);

    private void SettingsPanel_Resize(object sender, EventArgs e)
    {
        LogoPictureBox.Size = new Size(LogoPictureBox.Size.Width, VisualSettingsGroupBox.Location.Y - 6);
    }

    private void DarkModeCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;

        Program.Settings.IsDarkMode = DarkModeCheckBox.Checked;
        Console.WriteLine($"Theme Changed to {(DarkModeCheckBox.Checked ? "Dark Theme" : "Light Theme")}");
        Program.ReloadTheme();
    }

    private void UseHexCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;
        Program.Settings.IsUseHexId = UseHexCheckBox.Checked;
        Console.WriteLine($"Hex Numbers {(UseHexCheckBox.Checked ? "Enabled" : "Disabled")}");
        Program.ReloadEditorList();
    }

    private void LongNumberCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;
        Program.Settings.IsUseLongId = LongNumberCheckBox.Checked;
        Console.WriteLine($"Long Numbers {(LongNumberCheckBox.Checked ? "Enabled" : "Disabled")}");
        Program.ReloadEditorList();
    }

    private void YAZ0CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;
        Program.Settings.IsUseYaz0 = YAZ0CheckBox.Checked;
        Console.WriteLine($"YAZ0 Saving {(YAZ0CheckBox.Checked ? "Enabled" : "Disabled")}");
    }

    private void EnforceCompressCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;
        Program.Settings.IsUseOnboardCompression = EnforceCompressCheckbox.Checked;
        Console.WriteLine($"Advanced Saving {(EnforceCompressCheckbox.Checked ? "Enabled" : "Disabled")}");
    }

    private void UniqueEditorsCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;
        Program.Settings.IsUseUniqueEditor = UniqueEditorsCheckbox.Checked;
        Console.WriteLine($"Default Editor Only {(!UniqueEditorsCheckbox.Checked ? "Enabled" : "Disabled")}");
    }

    private void ShowAboutCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;
        Program.Settings.IsShowAboutOnBoot = ShowAboutCheckBox.Checked;
        Console.WriteLine($"Show About on Launch {(ShowAboutCheckBox.Checked ? "Enabled" : "Disabled")}");
    }

    private void SplashSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;
        string A = SplashSizeComboBox.SelectedItem?.ToString() ?? "846x462";
        Program.Settings.SplashSize = new Size(int.Parse(A.Split('x')[0]), int.Parse(A.Split('x')[1]));
        Console.WriteLine($"Splash Size set to {Program.Settings.SplashSize.Width}x{Program.Settings.SplashSize.Height}");
    }

    private void ShowSplashButton_Click(object sender, EventArgs e)
    {
        Console.WriteLine();
        Console.WriteLine("Preparing the Splash...");
        Task SplashTask = Task.Run(() =>
        {
            SplashForm SF = new(3);
            Console.WriteLine("Running Splash Screen:");
            SF.ShowDialog();
            SF.Dispose();
        });
        SplashTask.Wait();
        Console.WriteLine("Splash Completed!");
    }

    private void IsUseSMG1DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;
        Program.Settings.IsUseSMG1Defaults = IsUseSMG1DefaultsCheckBox.Checked;
        Console.WriteLine($"SMG1 Defaults {(IsUseSMG1DefaultsCheckBox.Checked ? "Enabled" : "Disabled")}");
    }
}
