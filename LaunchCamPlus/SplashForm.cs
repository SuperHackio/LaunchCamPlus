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
        public SplashForm(int L)
        {
            InitializeComponent();
            CenterToScreen();
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            timer.Start();
            loadtime = L;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time++;
            if (time > loadtime)
            {
                //time = 0;
                //SplashForm_Paint(this, new PaintEventArgs(CreateGraphics(),new Rectangle(0,0,Width,Height)));
                timer.Stop();
                Close();
            }
        }

        Timer timer;
        
        int time = 0;
        int loadtime = 0;

        private void SplashForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (!Directory.Exists("Splash"))
            {
                Close();
                return;
            }
            string[] Splashes = Directory.GetFiles("Splash","*.png",SearchOption.AllDirectories);
            if (Splashes.Length == 0)
            {
                Close();
                return;
            }

            int ran = new Random().Next(0, Splashes.Length-1);
            Bitmap b = ResizeBitmap(new Bitmap(Splashes[ran]), Width, Height);
            g.DrawImage(b, 0, 0);
            
            g.DrawImage(ResizeBitmap(new Bitmap(Properties.Resources.LCPCanvas), Width, Height), 0, 0);
            BringToFront();
        }

        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }
    }
}
