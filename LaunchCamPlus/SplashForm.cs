using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchCamPlus
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            CenterToScreen();
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            timer.Start();
            }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time++;
            if (time > 1)
            {
                //time = 0;
                //SplashForm_Paint(this, new PaintEventArgs(CreateGraphics(),new Rectangle(0,0,Width,Height)));
                timer.Stop();
                this.Close();
            }
        }

        Timer timer;
        
        int time = 0;

        private void SplashForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int ran = new Random().Next(0, 8);
            Bitmap b = null;
            switch (ran)
            {
                default:
                    b = ResizeBitmap(new Bitmap(Properties.Resources.SB4E01_1), Width, Height);
                    break;
                case 0:
                    b = ResizeBitmap(new Bitmap(Properties.Resources.RMGE01_1), Width, Height);
                    break;
                case 1:
                    b = ResizeBitmap(new Bitmap(Properties.Resources.SB4E01_2), Width, Height);
                    break;
                case 2:
                    b = ResizeBitmap(new Bitmap(Properties.Resources.RMGE01_2), Width, Height);
                    break;
                case 3:
                    b = ResizeBitmap(new Bitmap(Properties.Resources.SB4E01_3), Width, Height);
                    break;
                case 4:
                    b = ResizeBitmap(new Bitmap(Properties.Resources.RMGE01_3), Width, Height);
                    break;
                case 5:
                    b = ResizeBitmap(new Bitmap(Properties.Resources.SB4E01_4), Width, Height);
                    break;
                case 6:
                    b = ResizeBitmap(new Bitmap(Properties.Resources.RMGE01_4), Width, Height);
                    break;
            }
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
