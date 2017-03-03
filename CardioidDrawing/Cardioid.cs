using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardioidDrawing
{
    class Cardioid
    {
        public int PointsAmount { get; set; }
        public int Times { get; set; }

        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }

        PointF[] points;

        public void AssignPoints()
        {
            float centerPointX = (float)Form1.Panel_Width / 2;
            float centerPointY = (float)Form1.Panel_Height / 2;

            double angle = 6.28319 / PointsAmount;
            float distance = Form1.Panel_Width / 2;

            points = new PointF[PointsAmount];

            for (int i = 0; i < PointsAmount; i++)
            {
                float xPos = centerPointX + (float)Math.Cos(angle * i) * distance;
                float yPos = centerPointY + (float)Math.Sin(angle * i) * distance;

                points[i] = new PointF(xPos, yPos);
            }
        }

        public void Draw(Graphics gfx)
        {
            AssignPoints();
            gfx.FillRectangle(new SolidBrush(BackgroundColor), 0,0,Form1.Panel_Width,Form1.Panel_Height);
            gfx.DrawEllipse(new Pen(new SolidBrush(ForegroundColor)), new RectangleF(0, 0, Form1.Panel_Width,Form1.Panel_Height));

            for (int i = 0; i < PointsAmount; i++)
            {
                int too = i * Times;

                while (too > PointsAmount-1)
                {
                    too -= PointsAmount;
                }

                gfx.DrawLine(new Pen(ForegroundColor), points[i], points[too]);
            }
        }
    }
}
