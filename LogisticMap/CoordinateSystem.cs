using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticMap
{
    class CoordinateSystem
    {
        public Color FunctionColor { get; set; }

        public double X_Max { get; set; }
        public double Y_Max { get; set; }

        private Panel drawContainer;
        private float panel_width;
        private float panel_height;

        private PointF orego;
        private PointF xAxisEndPoint;

        public CoordinateSystem(double x_max, double y_max, Panel panel)
        {
            this.X_Max = x_max;
            this.Y_Max = y_max;

            this.drawContainer = panel;
            panel_width = panel.Width;
            panel_height = panel.Height;
            orego = new PointF(25, panel_height - 30);
            xAxisEndPoint = new PointF(panel_width - 30, panel_height - 30);
        }

        public void DrawCoordinateSystem(Graphics gfx)
        {

            //Draw X and Y lines
            gfx.DrawLine(Pens.Black, 25, 20, 25, panel_height - 30);
            gfx.DrawLine(Pens.Black, 25, panel_height - 30, panel_width - 30, panel_height - 30);

            gfx.DrawLine(Pens.Black, 20, 20, 30, 20);
            gfx.DrawLine(Pens.Black, panel_width - 30 , panel_height - 35, panel_width - 30, panel_height - 25);

            //Write numbers on axis X Y
            gfx.DrawString(X_Max.ToString(), SystemFonts.DefaultFont, Brushes.Black, xAxisEndPoint.X - 5 * X_Max.ToString().ToCharArray().Length, xAxisEndPoint.Y + 6);
            gfx.DrawString(Y_Max.ToString(), SystemFonts.DefaultFont, Brushes.Black, 8, 15);
        }

        
    }
}
