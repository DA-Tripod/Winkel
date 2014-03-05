using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Berechnung
{
    public partial class Form1 : Form
    {
        Schrittmotor_1 S_1 = new Schrittmotor_1();
        Schrittmotor_2 S_2 = new Schrittmotor_2();
        Schrittmotor_3 S_3 = new Schrittmotor_3();
        List<Line> lines = new List<Line>();
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                trackBarX.Value = Convert.ToInt32(textBoxX.Text);
                berechnen();
                paintX();
                paintY();
            }
            catch { }
        }
        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                trackBarY.Value = Convert.ToInt32(textBoxY.Text);
                berechnen();
                paintX();
                paintY();
            }
            catch { }
        }

        private void textBoxZ_TextChanged(object sender, EventArgs e)
        {
            try
            {
                trackBarZ.Value = Convert.ToInt32(textBoxZ.Text);
                berechnen();
                paintX();
                paintY();
            }
            catch { }
        }
        private void trackBarX_ValueChanged(object sender, EventArgs e)
        {
            textBoxX.Text = Convert.ToString(trackBarX.Value);
            berechnen();
            paintX();
            paintY();
        }

        private void trackBarY_ValueChanged(object sender, EventArgs e)
        {
            textBoxY.Text = Convert.ToString(trackBarY.Value);
            berechnen();
            paintX();
            paintY();
        }

        private void trackBarZ_ValueChanged(object sender, EventArgs e)
        {
            textBoxZ.Text = Convert.ToString(trackBarZ.Value);
            berechnen();
            paintX();
            paintY();
        }
        private void berechnen()
        {
            labelS1.Text = S_1.S1(trackBarX.Value, trackBarY.Value, trackBarZ.Value).ToString("0.00");
            labelS2.Text = S_2.S2(trackBarX.Value, trackBarY.Value, trackBarZ.Value).ToString("0.00");
            labelS3.Text = S_3.S3(trackBarX.Value, trackBarY.Value, trackBarZ.Value).ToString("0.00");
        }

        private void paintX()
        {
            lines.Clear();
            int y = 30;
            int x = panelX.Width / 2;
            //Kopfplatte
            lines.Add(new Line(new Point(x - 125, y), new Point(x + 125, y)));

            //S1
            lines.Add(new Line(new Point(x, y), new Point(x, y + S_1.oy)));
            lines.Add(new Line(new Point(x, y + S_1.oy), new Point(x - 125 + S_2.dxdraw + 40, y + S_2.zdraw)));
            //S2
            lines.Add(new Line(new Point(x - 125, y), new Point(x - 125 + S_2.ox, y + S_2.oy)));
            lines.Add(new Line(new Point(x - 125 + S_2.ox, y + S_2.oy), new Point(x - 125 + S_2.dxdraw, y + S_2.zdraw)));
            lines.Add(new Line(new Point(x - 125 + S_2.dxdraw, y + S_2.zdraw), new Point(x - 125 + S_2.dxdraw + 40, y + S_2.zdraw)));
            //S3
            lines.Add(new Line(new Point(x + 125, y), new Point(x + 125 + S_3.ox, y + S_3.oy)));
            lines.Add(new Line(new Point(x + 125 + S_3.ox, y + S_3.oy), new Point(x + 125 - S_3.dxdraw, y + S_3.zdraw)));
            lines.Add(new Line(new Point(x + 125 - S_3.dxdraw, y + S_3.zdraw), new Point(x + 125 - S_3.dxdraw - 40, y + S_3.zdraw)));
            panelX.Refresh();
        }

        private void paintY()
        {
            //Arbeitsbreich Z = 300 bis 420 X=Y= -175 bis 175
            lines.Clear();
            int y = 30;
            int x = panelY.Width / 2;
            //Kopfplatte
            lines.Add(new Line(new Point(x - (125 / 2), y), new Point(x + 125, y)));
            //S1
            lines.Add(new Line(new Point(x + 125, y), new Point(x + 125 + S_1.ox, y + S_1.oy)));
            lines.Add(new Line(new Point(x + 125 + S_1.ox, y + S_1.oy), new Point(x + 125 - S_1.dxdraw, y + S_1.zdraw)));
            lines.Add(new Line(new Point(x + 125 - S_1.dxdraw, y + S_1.zdraw), new Point(x + 125 - S_1.dxdraw - 40, y + S_1.zdraw)));
            
            panelY.Refresh();
        }

        private void panelX_Paint(object sender, PaintEventArgs e)
        {
            foreach (Line l in lines)
            {
                Pen myPen = new Pen(Color.Black, 1);
                Graphics g = e.Graphics;
                g.DrawLine(myPen, l.P1, l.P2);
            }
        }

        private void panelY_Paint(object sender, PaintEventArgs e)
        {
            foreach (Line l in lines)
            {
                Pen myPen = new Pen(Color.Black, 1);
                Graphics g = e.Graphics;
                g.DrawLine(myPen, l.P1, l.P2);
            }
        }

        private void buttonSenden_MouseClick(object sender, MouseEventArgs e)
        {
            string lines = textBoxX.Text + ";" + textBoxY.Text + ";" + textBoxZ.Text + ";";

            System.IO.StreamWriter file = new System.IO.StreamWriter("d:\\Users\\Alesandro\\Desktop\\2014\\DA\\Schrittmotorenberechnung\\WerteXYZ.txt");
            file.WriteLine(lines);

            file.Close();
        }

        private void panelX_MouseClick(object sender, MouseEventArgs e)
        {
            int X = 0;

            X = (MousePosition.X - panelX.Width);
            if (X <= 175 && X >= -175) 
            {
                trackBarX.Value = X;
            }
            if (MousePosition.Y <= 240 && MousePosition.Y >= 180)
            {
                trackBarZ.Value = (MousePosition.Y - 30) * 2;
            }
        }
    }
}
