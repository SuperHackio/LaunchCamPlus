using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

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
            //const string appName = "LaunchCamPlus";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread Splashthread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                // Activate the Splash screen to display while loading the main form
                SplashForm Splash = new SplashForm(1);
                Splash.ShowDialog();
            });
            Splashthread.Start();//Now the splash actually hides the load times lol
            MainForm M = null;

            bool LoadedMainForm = false;
            bool LoadedPlugins = false;
            bool CheckedUpdates = false;
            while (!LoadedMainForm | !LoadedPlugins | !CheckedUpdates)
            {
                if (!LoadedMainForm)
                {
                    M = new MainForm();
                    LoadedMainForm = true;
                }

                if (!LoadedPlugins)
                {
                    M.LoadPlugins();
                    LoadedPlugins = true;
                }

                if (!CheckedUpdates)
                {
                    if (M.CheckForUpdates())
                        M.HasUpdateReady();
                    CheckedUpdates = true;
                }
            }
            while (Splashthread.IsAlive)
            {
                //Wait for the splash thread to finish
            }

            if (M == null)
                throw new Exception("Main form failed to initilize");
            
            AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            {
                if (eventArgs.Exception.InnerException is EntryPointNotFoundException)
                {
                    MessageBox.Show(eventArgs.Exception.Message, "Loading...");
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.FailFast("Exited the Intro Camera Editor");
                }
                else if (eventArgs.Exception is System.IO.IOException)
                {
                    System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Crash.txt", "Report this error to Super Hackio --> https://github.com/SuperHackio/LaunchCamPlus/issues <--" + Environment.NewLine + "The Error is: " + eventArgs.Exception.Message + Environment.NewLine + "The error was made in: " + eventArgs.Exception.Source + Environment.NewLine + "The Stack Trace is:" + Environment.NewLine + eventArgs.Exception.StackTrace);
                    return;
                }
                else
                {
                    MessageBox.Show("Launch Cam Plus has encountered an error \rPlease read\r\"Crash.txt\"\rfor more information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Crash.txt", "Report this error to Super Hackio --> https://github.com/SuperHackio/LaunchCamPlus/issues <--" + Environment.NewLine + "The Error is: " + eventArgs.Exception.Message + Environment.NewLine + "The error was made in: " + eventArgs.Exception.Source + Environment.NewLine + "The Stack Trace is:" + Environment.NewLine + eventArgs.Exception.StackTrace);
                    Environment.FailFast("Read \"Crash.txt\" for more info");
                }
            };

            bool OpenARCWith = false;
            bool OpenBCAMWith = false;
            bool OpenLCPPWith = false;
            bool OpenLCPCWith = false;
            bool OpenCANMWith = false;

            if (args.Length > 0)
            {
                OpenARCWith = new System.IO.FileInfo(args[0]).Extension == ".arc";
                OpenBCAMWith = new System.IO.FileInfo(args[0]).Extension == ".bcam";
                OpenLCPPWith = new System.IO.FileInfo(args[0]).Extension == ".lcpp";
                OpenLCPCWith = new System.IO.FileInfo(args[0]).Extension == ".lcpc";
                OpenCANMWith = new System.IO.FileInfo(args[0]).Extension == ".canm";
            }
            try
            {
                if (OpenLCPPWith && MessageBox.Show("Compress this LCPP?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LCPCManager.LCPC LCPC = new LCPCManager.LCPC(args[0]);
                    return;
                }
                if (OpenLCPCWith && MessageBox.Show("Decompress this LCPC?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LCPCManager.LCPC LCPC = new LCPCManager.LCPC(new System.IO.FileStream(args[0],System.IO.FileMode.Open));
                    LCPPManager.LCPP Export = new LCPPManager.LCPP(args[0].Replace(".lcpc", ".lcpp"),LCPC.LCPP.PresetList,LCPC.LCPP.Name,LCPC.LCPP.Creator);
                    return;
                }
                if (args.Length > 0 && (args[0] == "-secret" || OpenCANMWith))
                {
                    if (OpenCANMWith)
                        Application.Run(new IntroForm(args[0]));
                    else
                        Application.Run(new IntroForm());
                }
                else
                {
                    if (OpenBCAMWith || OpenARCWith)
                        Application.Run(new MainForm(args[0]));
                    else
                        Application.Run(M);
                }
            }
            catch (Exception)
            {
                
            }

        }
    }
}
