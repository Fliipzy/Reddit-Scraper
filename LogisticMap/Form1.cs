using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticMap
{
    public partial class Form1 : Form
    {
        CoordinateSystem coordinateSystem;

        public Form1()
        {
            InitializeComponent();
            coordinateSystem = new CoordinateSystem(4, 1, panel1);

        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {

            Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            coordinateSystem.DrawCoordinateSystem(e.Graphics);
            PlotPoints(e.Graphics, 10000);
        }

        public void PlotPoints(Graphics gfx, int amount)
        {
            double iterationLambdaAdd = 4d / (double)amount;
            double currentLambda = 0;

            for (int i = 0; i < amount; i++)
            {
                List<PointF> points = GetPlotPoints(currentLambda, 0.5);
                currentLambda += iterationLambdaAdd;

                foreach (PointF point in points)
                {
                    if (point.Y < panel1.Height)
                    {
                        gfx.FillRectangle(Brushes.Red, point.X, point.Y, 2, 2);

                    }
                }
            }

        }

        public List<PointF> GetPlotPoints (double lambda, double population)
        {
            List<PointF> points = new List<PointF>();

            if (lambda > 2.7)
            {
                for (int i = 0; i < 100; i++)
                {
                    population = lambda * population * (1 - population);
                    population = Math.Round(population, 3);

                    if (i > 50)
                    {
                        double x0 = ((lambda - 0) * ((panel1.Width - 30) - 25) / (4 - 0)) + 25;
                        double y0 = ((population - 0) * (20 - (panel1.Height - 30)) / (1 - 0)) + (panel1.Height - 30);
                        points.Add(new PointF((float)x0, (float)y0));
                    }
                }
                return points;
            }

            else
            {
                for (int i = 0; i < 100; i++)
                {
                    population = lambda * population * (1 - population);
                    population = Math.Round(population, 3);

                    if (i > 50)
                    {
                        double x0 = ((lambda - 0) * ((panel1.Width - 30) - 25) / (4 - 0)) + 25;
                        double y0 = ((population - 0) * (20 - (panel1.Height - 30)) / (1 - 0)) + (panel1.Height - 30);
                        points.Add(new PointF((float)x0, (float)y0));
                    }
                }
                return points;
            }
            
        }
    }
}
