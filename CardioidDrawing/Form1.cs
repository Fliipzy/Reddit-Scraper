using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardioidDrawing
{
    public partial class Form1 : Form
    {
        Cardioid cardioid = new Cardioid();

        public static int Panel_Width;
        public static int Panel_Height;

        public Form1()
        {
            InitializeComponent();
            Panel_Width = panel1.Width;
            Panel_Height = panel1.Height;

            cardioid.PointsAmount = 200;
            cardioid.Times = 2;
            cardioid.ForegroundColor = Color.Black;
            cardioid.BackgroundColor = Color.White;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            cardioid.PointsAmount = (int)numericUpDown1.Value;
            cardioid.Times = (int)numericUpDown2.Value;
            cardioid.Draw(e.Graphics);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                cardioid.ForegroundColor = colorDialog1.Color;
                button1.BackColor = colorDialog1.Color;
                panel1.Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog2.ShowDialog();

            if (result == DialogResult.OK)
            {
                cardioid.BackgroundColor = colorDialog2.Color;
                button2.BackColor = colorDialog2.Color;
                panel1.Invalidate();
            }
        }
    }
}
