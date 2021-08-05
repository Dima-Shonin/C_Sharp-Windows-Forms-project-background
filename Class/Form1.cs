using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class
{
    public partial class Form1 : Form
    {
        Bitmap sky;
        Bitmap plane;
        Bitmap cloude;
        Graphics graf;
        int dx;
        Rectangle r1,cloud;
        Random rand;
        Boolean life=true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            graf.DrawImage(sky, new Point(0,0));
            if (r1.X < this.ClientRectangle.Width)
            {
             
                r1.X += dx;
            }
            else
            {              
                r1.X = -40;
                r1.Y = 20 + rand.Next(ClientSize.Height - 40 - plane.Height);
                dx =5+rand.Next(20);
            }
            graf.DrawImage(plane, r1.X, r1.Y);
            if (!life)
            {                
                this.Invalidate(r1);
            }
            else
            {
                Rectangle r2 = new Rectangle(20, 20, sky.Width - 40, sky.Height - 40);
                
                graf.DrawImage(cloude, cloud.X+100, cloud.Y+240, cloud.Width * 2, cloud.Height * 2);
                graf.DrawImage(cloude, cloud.X+250, cloud.Y+60, cloud.Width * 2, cloud.Height * 2);
                graf.DrawImage(cloude, cloud.X , cloud.Y - 100, cloud.Width * 2, cloud.Height * 2);
                graf.DrawImage(cloude, cloud.X+400, cloud.Y +200, cloud.Width * 2, cloud.Height * 2);
                graf.DrawImage(cloude, cloud.X+400, cloud.Y - 100, cloud.Width * 2, cloud.Height * 2);
                graf.DrawRectangle(Pens.Black, r2.X, r2.Y, r2.Width - 1, r2.Height - 1);
              
                Invalidate(r2);
            }


        }


        public Form1()
        {
            InitializeComponent();
            sky = new Bitmap("sky.bmp");
            plane = new Bitmap("plane2.bmp");
            cloude = new Bitmap("Cloude.png");
            BackgroundImage = new Bitmap("sky.bmp");

            plane.MakeTransparent();
            ClientSize=new Size(new Point(BackgroundImage.Width, BackgroundImage.Height));
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            graf = Graphics.FromImage(BackgroundImage);
            rand = new Random();
            r1.X = -40;
            r1.Y=20 + rand.Next(50);
            r1.Width = plane.Width;
            r1.Height = plane.Height;
            cloud.X = 100;
            cloud.Y = 150;
            cloud.Width = plane.Width;
            cloud.Height = plane.Height;
            dx = 5;
            timer1.Interval =20;
            timer1.Enabled = true;


        }


       
    }
}
