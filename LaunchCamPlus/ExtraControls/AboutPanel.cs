namespace LaunchCamPlus.ExtraControls;

public partial class AboutPanel : UserControl, IReloadTheme
{
    public AboutPanel()
    {
        InitializeComponent();
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        VersionLabel.Text = $"LCP V{Application.ProductVersion}";
#if DEBUG
        UpdateTextLabel.Text = Program.UpdateInfo?.ToString() ?? "- Launch Cam Plus is in DEBUG mode";
#else
        UpdateTextLabel.Text = Program.UpdateInfo?.ToString() ?? "- No Update Information could be retrieved";
#endif
    }

    public void ReloadTheme() => ControlEx.ReloadTheme(this);

    private void AboutPanel_Resize(object sender, EventArgs e)
    {
        LogoPictureBox.Size = new Size(LogoPictureBox.Size.Width, 50);
    }
}
