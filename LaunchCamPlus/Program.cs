using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashForm Splash = new SplashForm();
            MainForm M = new MainForm();

            Splash.ShowDialog();
            
            AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            {
                if (eventArgs.Exception.InnerException is EntryPointNotFoundException)
                {
                    MessageBox.Show(eventArgs.Exception.Message, "Loading...");
                    Application.Run(new MainForm());
                }
                else
                {
                    MessageBox.Show("Launch Cam Plus has encountered an error \rPlease read\r\"Crash.txt\"\rfor more information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Crash.txt", "Report this error to Super Hackio --> https://github.com/SuperHackio/LaunchCamPlus/issues <--" + Environment.NewLine + "The Error is: " + eventArgs.Exception.Message + Environment.NewLine + "The error was made in: " + eventArgs.Exception.Source + Environment.NewLine + "The Stack Trace is:" + Environment.NewLine + eventArgs.Exception.StackTrace);
                    Environment.FailFast("Read \"Crash.txt\" for more info");
                }
            };

            bool OpenBCAMWith = false;
            bool OpenLCPPWith = false;
            bool OpenLCPCWith = false;
            //bool OpenCANMWith = false;

            if (args.Length > 0)
            {
                OpenBCAMWith = new System.IO.FileInfo(args[0]).Extension == ".bcam";
                OpenLCPPWith = new System.IO.FileInfo(args[0]).Extension == ".lcpp";
                OpenLCPCWith = new System.IO.FileInfo(args[0]).Extension == ".lcpc";
                //OpenCANMWith = new System.IO.FileInfo(args[0]).Extension == ".canm";
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
                if (args.Length > 0 && args[0] == "-secret")
                {
                    Application.Run(new IntroForm());
                }
                else
                {
                    if (OpenBCAMWith)
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
