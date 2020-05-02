using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchCamPlus
{
    public partial class SplashForm : Form
    {
        public SplashForm(int L, bool loop = false)
        {
            InitializeComponent();
            Size = Properties.Settings.Default.SplashSize;
            CenterToScreen();
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            timer.Start();
            loadtime = L;
            Loop = loop;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time++;
            if (time > loadtime)
            {
                time = 0;
                if (Loop)
                    Invalidate();
                else
                {
                    if (!Program.IsProgramReady)
                    {
                        Invalidate();
                        ElapsedTicks++;
                    }
                    else
                    {
                        timer.Stop();
                        Close();
                    }
                }
            }
        }

        Timer timer;
        
        int time = 0;
        int loadtime = 0;
        bool Loop = false;
        int ElapsedTicks;

        private void SplashForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            string[] Splashes = Directory.Exists(Program.GetFromAppPath("Splash")) ? Directory.GetFiles(Program.GetFromAppPath("Splash"), "*.png", SearchOption.AllDirectories) : new string[0];
            if (Splashes.Length == 0)
            {
                Bitmap Default = new Bitmap(Properties.Resources.DefaultSplash);
                Default = ResizeBitmap(Default, Width, Height);
                g.DrawImage(Default, 0, 0);
                return;
            }
            if (Splashes.Length > 1)
            {
                List<string> temp = Splashes.ToList();
                temp.Remove(Properties.Settings.Default.PreviousSplash);
                Splashes = temp.ToArray();
            }

            int ran = new Random().Next(0, Splashes.Length);
            Properties.Settings.Default.PreviousSplash = Splashes[ran];
            Properties.Settings.Default.Save();
            Bitmap ChosenImage = new Bitmap(Splashes[ran]);
            Bitmap b = ResizeBitmap(ChosenImage, Width, Height);
            ChosenImage.Dispose();
            g.DrawImage(b, 0, 0);
            b.Dispose();

            Bitmap OriginalLogo = new Bitmap(Properties.Resources.LCPCanvas);
            Bitmap Logo = ResizeBitmap(OriginalLogo, Width, Height);
            OriginalLogo.Dispose();
            g.DrawImage(Logo, 0, 0);
            Logo.Dispose();
            GC.Collect();
        }

        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
                g.Dispose();
            }
            return result;
        }
    }
}
