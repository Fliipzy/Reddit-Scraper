using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collatz_Conjecture
{
    public partial class Form1 : Form
    {
        public const int NUMBER = 3;
        public int number = NUMBER;
        public int scrollValueX;
        public int scrollValueY;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            int x = 20 - scrollValueX;
            int y = 20 - scrollValueY;

            e.Graphics.DrawString($"{number}", DefaultFont, Brushes.Black, x, y);

            int steps = 0;

            while (number != 1)
            {
                if (number.IsEven())
                {
                    x += 35;
                    number = number / 2;

                    if (number.IsEven())
                    {
                        e.Graphics.DrawString($"{number}", DefaultFont, Brushes.Green, x, y);
                    }
                    else
                    {
                        e.Graphics.DrawString($"{number}", DefaultFont, Brushes.Red, x, y);
                    }
                    
                }
                else
                {
                    y += 30;
                    number = number * 3 + 1;

                    if (number.IsEven())
                    {
                        e.Graphics.DrawString($"{number}", DefaultFont, Brushes.Green, x, y);
                    }
                    else
                    {
                        e.Graphics.DrawString($"{number}", DefaultFont, Brushes.Red, x, y);
                    }
                }
                steps++;
            }
            number = NUMBER;
        }

        private void Form1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                scrollValueX = e.NewValue;
            }
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                scrollValueY = e.NewValue;
            }
            
            Invalidate();
        }
    }
}
