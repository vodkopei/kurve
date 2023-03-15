using System;
using System.Drawing;
using System.Windows.Forms;

namespace KochCurve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void DrawKochCurve(Graphics g, Pen pen, int depth, float x1, float y1, float x2, float y2)
        {
            if (depth == 0)
            {
                g.DrawLine(pen, x1, y1, x2, y2);
                return;
            }

            float deltaX = (x2 - x1) / 3;
            float deltaY = (y2 - y1) / 3;

            float xA = x1 + deltaX;
            float yA = y1 + deltaY;

            float xC = x2 - deltaX;
            float yC = y2 - deltaY;

            float xB = xA + (float)(Math.Cos(Math.PI / 3) * deltaX - Math.Sin(Math.PI / 3) * deltaY);
            float yB = yA + (float)(Math.Sin(Math.PI / 3) * deltaX + Math.Cos(Math.PI / 3) * deltaY);

            DrawKochCurve(g, pen, depth - 1, x1, y1, xA, yA);
            DrawKochCurve(g, pen, depth - 1, xA, yA, xB, yB);
            DrawKochCurve(g, pen, depth - 1, xB, yB, xC, yC);
            DrawKochCurve(g, pen, depth - 1, xC, yC, x2, y2);
        }



        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(Color.White);
                DrawKochCurve(g, Pens.Black, 5, 10, pictureBox1.Height / 2, pictureBox1.Width - 10, pictureBox1.Height / 2);
            }

        }



    }
}
