using Hack.io.Utility;
using LaunchCamPlus.ExtraControls;
using LaunchCamPlus.Formats;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace LaunchCamPlus;

internal static class Program
{
    public static string SETTINGS_PATH => GetFromAppPath("Settings.lcps");
    public static string PRESETS_PATH => GetFromAppPath("Presets");
    public const string UPDATEALERT_URL = "https://raw.githubusercontent.com/SuperHackio/LaunchCamPlus/master/LaunchCamPlus/UpdateAlert.txt";
    public const string GIT_RELEASE_URL = "https://github.com/SuperHackio/LaunchCamPlus/releases";
    public const string ConsoleSplitter = "=====================================================";
    public const string ConsoleHalfSplitter = "----------------------------------";

    public static Settings Settings { get; private set; } = new(SETTINGS_PATH);
    public static UpdateInformation? UpdateInfo;
    public static bool IsProgramReady { get; set; } = false;
    public static bool ShowNeedsUpdate { get; set; } = false;
    public static bool IsUnsavedChanges { get; set; } = false;
    public static bool IsGameFileLittleEndian { get; set; } = false;
    public static bool PresetSelectorNeedsReload { get; set; }
    public static bool PresetCreatorNeedsReload { get; set; }

    private static CameraEditorForm? Editor;
    private static readonly string[] NewlineSeparators = ["\r\n", "\r", "\n"];

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        // Prevents floats being written to the .dae with commas instead of periods on European systems.
        CultureInfo.CurrentCulture = new("", false);

        Console.Title = Application.ProductName + " " + Application.ProductVersion + " - Console";
        Console.WriteLine("Initilizing...");
        Console.WriteLine();
        Console.WriteLine("Preparing the Splash...");

        Task SplashTask = Task.Run(() =>
        {
            SplashForm SF = new(3);
            Console.WriteLine("Running Splash Screen:");
            SF.ShowDialog();
            SF.Dispose();
        });

        if (!Directory.Exists(PRESETS_PATH))
            Directory.CreateDirectory(PRESETS_PATH);

        if (args.Any(A => A.Equals("-le")))
        {
            IsGameFileLittleEndian = true;
            args = args.Where(A => !A.Equals("-le")).ToArray();
        }

        Thread.Sleep(250);
        Console.WriteLine();
        Console.WriteLine("Checking for Updates...");

        UpdateInfo = IsUpdateExist();

        if (UpdateInfo != null && UpdateInfo.Value.IsNewer())
        {
            if (UpdateInfo.Value.IsUpdateRequired)
            {
                Console.WriteLine("An update is availible!");
                Console.WriteLine($"Please visit {GIT_RELEASE_URL} to pick it up");
                Console.WriteLine();
                Console.WriteLine(UpdateInfo);
                Thread.Sleep(1000);
                Console.WriteLine("Could not prepare the Editor.\nPlease update Launch Cam Plus.");
                Console.WriteLine();
                Thread.Sleep(500);
                Console.WriteLine("Pressing ENTER will close the program.");
                _ = Console.ReadLine();
                return;
            }
            Console.WriteLine("An update is availible!");
            Console.WriteLine($"Please visit {GIT_RELEASE_URL} to pick it up");
            Console.WriteLine("Or click the \"Help\" button at the top of the Editor and click \"Github Releases\".");
            Console.WriteLine();
            Console.WriteLine(UpdateInfo);
            ShowNeedsUpdate = true;
        }
        else
            Console.WriteLine("No update is availible");

        Console.WriteLine();
        Console.WriteLine("Preparing the Editor...");
        Editor = new(args);
        ReloadTheme();
        Thread.Sleep(250);
        Console.WriteLine("Editor successfully prepared!");
        Thread.Sleep(250);
        Console.WriteLine("Please Wait...");
        IsProgramReady = true;

        SplashTask.Wait();
        Console.WriteLine("Running the Editor:");
        Console.WriteLine(ConsoleSplitter);
        Application.Run(Editor);
        Console.WriteLine(ConsoleSplitter);
        Console.WriteLine("Editor Finished!");
        Console.WriteLine("Thank you for using Super Hackio's Launch Cam Plus!");
        Thread.Sleep(1000);
    }

    public static void ReloadTheme() => Editor?.ReloadTheme();
    public static void ReloadEditorPanel() => Editor?.ReloadPanel();
    public static void ReloadEditorList() => Editor?.ReloadCameraListBox();
    public static void UpdateCameraId(BCAM.Entry entry) => Editor?.UpdateCameraId(entry);
    public static string GetFromAppPath(string Target) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Target);

    static UpdateInformation? IsUpdateExist()
    {
#if false
        Console.WriteLine("-- LCP is in DEBUG MODE --");
        return null;
#else
        try
        {
            using HttpClient client = new() { Timeout = new(0,0,15) };
            string content = client.GetStringAsync(UPDATEALERT_URL).Result;
            string[] lines = content.Split(NewlineSeparators, StringSplitOptions.None);
            return new(lines);
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to retrieve update information:\n" + e.Message);
            return null;
        }
#endif
    }

    internal struct UpdateInformation
    {
        public Version Version;
        public List<string> Notes;
        public bool IsUpdateRequired = false;

        public UpdateInformation(string[] Data)
        {
            Version = new(Data[0]);

            Notes = new();
            bool IsStarted = false;
            for (int i = 1; i < Data.Length; i++)
            {
                if (!IsStarted)
                {
                    if (Data[i].Equals("#required", StringComparison.OrdinalIgnoreCase))
                        IsUpdateRequired = true;
                    if (Data[i].Equals("#notes", StringComparison.OrdinalIgnoreCase))
                        IsStarted = true;
                    continue;
                }

                Notes.Add(Data[i]);
            }
        }

        public readonly bool IsNewer()
        {
            Version Local = new(Application.ProductVersion);
            return Local.CompareTo(Version) < 0;
        }

        public override readonly string ToString()
        {
            string v = Notes.Count > 0 ?"\n\n" : "";
            for (int i = 0; i < Notes.Count; i++)
                v += Notes[i] + Environment.NewLine;

            return
                $"""
                ---- Release information ----
                Launch Cam Plus Version {Version.Major}.{Version.Minor}.{Version.MajorRevision}.{Version.Build}{v}
                -----------------------------
                """;
        }
    }
}

public static class ControlEx
{
    [DebuggerStepThrough]
    public static void SetDoubleBuffered(this Control control)
    {
        // set instance non-public property with name "DoubleBuffered" to true
        typeof(Control).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, control, new object[] { true });
    }

    public static void ReloadTheme(Control control)
    {
        if (control is not IReloadTheme)
        {
            if (control is ColourComboBox CCB)
            {
                control.ForeColor = ProgramColours.TextColour;
                control.BackColor = ProgramColours.WindowColour;
                CCB.BorderColor = ProgramColours.BorderColour;
            }
            else if (control is ColourTextBox CTB)
            {
                control.ForeColor = ProgramColours.TextColour;
                control.BackColor = ProgramColours.WindowColour;
                CTB.BorderColor = ProgramColours.BorderColour;
            }
            else if (control is ColourNumericUpDown CNUD)
            {
                control.ForeColor = ProgramColours.TextColour;
                control.BackColor = ProgramColours.WindowColour;
                CNUD.BorderColor = ProgramColours.BorderColour;
            }
            else if (control is Vector3NumericUpDown V3NUD)
            {
                V3NUD.ReloadTheme();
            }
            else if (control is GroupBox or Button)
            {
                control.ForeColor = ProgramColours.TextColour;
                control.BackColor = ProgramColours.ControlBackColor;
            }
            else if (control is Label or CheckBox)
            {
                control.ForeColor = ProgramColours.TextColour;
            }
            else if (control is TreeView Tv)
            {
                Tv.LineColor = control.ForeColor = ProgramColours.TextColour;
                control.BackColor = ProgramColours.WindowColour;
            }
            else if (control is ListBox)
            {
                control.ForeColor = ProgramColours.TextColour;
                control.BackColor = ProgramColours.WindowColour;
            }
            else if (control is J3DTrackControl)
            {
                control.ForeColor = ProgramColours.TextColour;
                control.BackColor = ProgramColours.WindowColour;
            }
        }

        for (int i = 0; i < control.Controls.Count; i++)
            ReloadTheme(control.Controls[i]);
    }
}