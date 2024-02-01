using LaunchCamPlus.Properties;

namespace LaunchCamPlus;

public partial class SplashForm : Form
{
    private static string SPLASH_PATH => Program.GetFromAppPath("Splash");
    private int Time = 0;
    private readonly int loadtime = 0;
    private readonly bool Loop = false;

    public SplashForm(int Length, bool loop = false)
    {
        InitializeComponent();
        Size = Program.Settings.SplashSize;
        CenterToScreen();
        SplashTimer.Start();
        loadtime = Length;
        Loop = loop;
    }

    private Bitmap GetSplash()
    {
        Random RNG = new();
        if (!Directory.Exists(SPLASH_PATH))
            return RenderSplash(Width, Height, Resources.DefaultSplash, Resources.LCPCanvas);

        string[] SplashOptions = Directory.GetFiles(SPLASH_PATH, "*.png", SearchOption.AllDirectories);
        string Selection = Select();

        Bitmap bitmap = new(Selection);
        Bitmap Final = RenderSplash(Width, Height, bitmap, Resources.LCPCanvas);
        bitmap.Dispose();

        return Final;

        string Select()
        {
            if (SplashOptions.Length == 1)
                return SplashOptions[0];

            byte limit = 0;
            string Selection = SplashOptions[0];
            while (limit < 5)
            {
                int value = RNG.Next(0, SplashOptions.Length);
                Selection = SplashOptions[value];
                if (!Selection.Equals(Program.Settings.LastSplash))
                    break;
            }
            return Selection;
        }
    }

    public static Bitmap RenderSplash(int width, int height, params Bitmap[] Bitmaps)
    {
        Bitmap result = new(width, height);
        using (Graphics g = Graphics.FromImage(result))
        {
            for (int i = 0; i < Bitmaps.Length; i++)
                g.DrawImage(Bitmaps[i], 0, 0, width, height);
            g.Dispose();
        }
        return result;
    }

    private void SplashTimer_Tick(object sender, EventArgs e)
    {
        Time++;
        if (Time > loadtime)
        {
            Time = 0;
            if (Loop)
                Invalidate();
            else
            {
                if (!Program.IsProgramReady)
                {
                    Invalidate();
                    GC.Collect();
                }
                else
                {
                    SplashTimer.Stop();
                    Close();
                }
            }
        }
    }

    private void SplashForm_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        Bitmap Splash = GetSplash();
        g.DrawImage(Splash, 0, 0);
        Splash.Dispose();
    }
}
