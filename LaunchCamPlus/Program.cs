using System;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaunchCamPlus.Properties;

namespace LaunchCamPlus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Console.Title = Application.ProductName + " " + Application.ProductVersion + " - Console";
            if (Settings.Default.IsFirstLaunch)
            {
                string FullfilePath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                string VersionDirectoryfilePath = Path.GetFullPath(Path.Combine(FullfilePath, @"..\..\" + Application.ProductVersion));
                string BasePath = Path.GetFullPath(Path.Combine(FullfilePath, @"..\..\"));
                Settings.Default.Upgrade();
                if (Directory.Exists(BasePath) && !Settings.Default.IsFirstLaunch)
                {
                    Console.WriteLine("Updating User Settings...");
                    DirectoryInfo DirInfo = new DirectoryInfo(BasePath);
                    DirectoryInfo[] Dirs = DirInfo.GetDirectories();
                    for (int i = 0; i < Dirs.Length; i++)
                        if (!Dirs[i].FullName.Equals(VersionDirectoryfilePath))
                            Directory.Delete(Dirs[i].FullName, true);
                }
                else
                {
                    Console.WriteLine("First time launch: Initilizing User Settings...");
                    Settings.Default.IsFirstLaunch = false;
                    Settings.Default.Save();
                }
            }

            Console.WriteLine("Initilizing...");
            Console.WriteLine();
            Console.WriteLine("Preparing the Splash...");
            Task SplashTask = Task.Run(() =>
            {
                SplashForm SF = new SplashForm(3);
                Console.WriteLine("Running Splash Screen:");
                SF.ShowDialog();
                SF.Dispose();
            });
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Checking for Updates...");
            if (IsUpdateReady)
            {
                Console.WriteLine("An update is availible!");
                Console.WriteLine("Please visit https://github.com/SuperHackio/LaunchCamPlus/releases to pick it up");
                Console.WriteLine("Or click the \"Help\" button at the top of the Editor and click \"Github Releases\".");
                ShowNeedsUpdate = true;
            }
            else
                Console.WriteLine("No update is availible");
            Console.WriteLine();
            Console.WriteLine("Preparing the Editor...");
            CameraEditorForm Editor = new CameraEditorForm(args);
            Thread.Sleep(500);
            Console.WriteLine("Editor successfully prepared!");
            Thread.Sleep(500);
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

        public static bool IsProgramReady { get; set; } = false;
        public static string GetFromAppPath(string Target) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Target);
        public static string PresetPath
        {
            get
            {
                if (_presetpath == null)
                    _presetpath = GetFromAppPath("Presets");
                return _presetpath;
            }
        }
        private static string _presetpath = null;
        public static string ConsoleSplitter => "=====================================================";
        public static string ConsoleHalfSplitter => "----------------------------------";
        public static bool IsUnsavedChanges { get; set; }
        public static bool IsUpdateReady
        {
            get
            {
                try
                {
                    new System.Net.WebClient().DownloadFile("https://raw.githubusercontent.com/SuperHackio/LaunchCamPlus/master/LaunchCamPlus/UpdateAlert.txt", @AppDomain.CurrentDomain.BaseDirectory + "VersionCheck.txt");

                    Version Internet = new Version(File.ReadAllText(@AppDomain.CurrentDomain.BaseDirectory + "VersionCheck.txt"));
                    File.Delete(@AppDomain.CurrentDomain.BaseDirectory + "VersionCheck.txt");
                    Version Local = new Version(Application.ProductVersion);
                    return Local.CompareTo(Internet) < 0;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to retireive update information:\n" + e.Message);
                    //Imagine not having internet lol
                    return false;
                }
            }
            
        }
        public static bool ShowNeedsUpdate { get; set; } = false;

        public static System.Text.Encoding StringEncoder { get; } = System.Text.Encoding.GetEncoding(932);
        public static bool PresetSelectorNeedsReload { get; set; }
        public static bool PresetCreatorNeedsReload { get; set; }


        public static readonly string WaitSfx = GetFromAppPath("sfx/Wait.wav");
        public static readonly string SuccessSfx = GetFromAppPath("sfx/Success.wav");
        public static readonly string FailureSfx = GetFromAppPath("sfx/Failure.wav");
        public static bool CanPlaySfx(string file) => Settings.Default.EnableSFX && File.Exists(file);
    }

    public static class ProgramColours
    {
        public static Color ControlBackColor => Settings.Default.IsDarkMode ? Color.FromArgb(62, 62, 66) : Color.FromArgb(240,240,240);
        public static Color WindowColour => Settings.Default.IsDarkMode ? Color.FromArgb(37, 37, 38) : Color.FromArgb(255, 255, 255);
        public static Color TextColour => Settings.Default.IsDarkMode ? Color.FromArgb(241, 241, 241) : Color.FromArgb(0, 0, 0);
        public static Color BorderColour => Settings.Default.IsDarkMode ? Color.FromArgb(50, 50, 50) : Color.Gray;
    }
}
