using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFAtest
{
    public partial class Form1 : Form
    {
        public void GenerateFigure()
        {
            pictureBox1.Refresh();
            Graphics g = pictureBox1.CreateGraphics();
            Point[] points = new Point[4];
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                points[i] = new Point(rand.Next(10, pictureBox1.Width-10), rand.Next(10, pictureBox1.Height-10));
            }
            string[] namesArr = { "A", "B", "C", "D" };

            for (int i = 0; i < 4; i++)
            {
                g.DrawString(namesArr[i], new Font("Arial", 10), new SolidBrush(Color.Black), points[i]/*, drawFormat*/);
            }

            g.DrawPolygon(new Pen(Brushes.Red, 1), points);

            Quadrilateral quad = new Quadrilateral(points);
            textBox1.Text = Convert.ToString(quad.GetArea());
            textBox2.Text = Convert.ToString(quad.GetPerimeter());
            label1.Text = quad.IsQuadrilateral() ? "true" : "false";

            g.DrawPolygon(new Pen(Brushes.Red, 1), points);
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateFigure();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GenerateFigure();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
            label6.Text = Convert.ToString(trackBar1.Value);
        }

    }
}
