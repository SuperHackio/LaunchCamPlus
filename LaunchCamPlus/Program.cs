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
            try
            {
                //if (args[0] == "-compress")
                //{
                //    LCPCManager.LCPC LCPC = new LCPCManager.LCPC(args[1]);
                //}
                if (args[0] == "-secret")
                {
                    Application.Run(new IntroForm());
                }
                else
                {
                    Application.Run(new MainForm());
                }
            }
            catch (Exception e)
            {
                if (e.InnerException is EntryPointNotFoundException)
                {
                    MessageBox.Show(e.Message,"Loading...");
                    Application.Run(new MainForm());
                }
                else
                {
                    Application.Run(new MainForm());
                }
            }

        }
    }
}
