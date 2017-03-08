using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Draw 
    {
        static int RESOLUTION = GameForm.Resolution;

        static float tileX = (float)Form.ActiveForm.ClientRectangle.Width / RESOLUTION;
        static float tileY = (float)Form.ActiveForm.ClientRectangle.Height / RESOLUTION;

        public static void DrawColors(Graphics gfx, int resolution, float panel_width, float panel_height, float val)
        {
            float tileWidth = (panel_width / resolution);
            float tileHeight = (panel_height / resolution);
            
            Brush brush;

            int red, green, blue;

            for (int x = 0; x < resolution; x++)
            {
                for (int y = 0; y < resolution; y++)
                {
                    red = x * (255 / resolution);
                    blue = y * (255 / resolution);
                    green = (int)val;

                    brush = new SolidBrush(Color.FromArgb(red.Clamp(0, 255), blue.Clamp(0, 255), green.Clamp(0, 255)));
                    gfx.FillRectangle(brush,new RectangleF((x*tileWidth), (y*tileHeight), tileWidth, tileHeight));
                    
                }
            }
        }

        public static void DrawRamp(Graphics gfx, int resolution ,float panel_width, float panel_height)
        {
            float tileSizeX = panel_width / resolution;
            float tileSizeY = panel_height / resolution;

            float x0 = panel_width / 2f;
            float y0 = panel_height / 2f;

            float length;
            Brush brush;

            for (int x = 0; x < resolution; x++)
            {
                for (int y = 0; y < resolution; y++)
                {
                    length = (float)Math.Sqrt(Math.Pow((x0 - (x*tileSizeX)), 2) + Math.Pow((y0 - (y*tileSizeY)), 2));
                    brush = new SolidBrush(Color.FromArgb((int)length.Clamp(0,255), 0, 0, 0));

                    gfx.FillRectangle(brush, new RectangleF(x * tileSizeX, y * tileSizeY, tileSizeX, tileSizeY));
                }
            }
        }

        public static void DrawSnakeText(Graphics gfx, float fontSize, PointF position)
        {
            gfx.DrawString("SNAKE", new Font(FontFamily.Families[3],fontSize, FontStyle.Bold), Brushes.Black, position);
        }

        public static void DrawSnake(Graphics gfx, Snake snake, GameBoard gameBoard, Control client)
        {
            float partSizeX = (float)client.ClientRectangle.Width / gameBoard.Map_Size;
            float partSizeY = (float)client.ClientRectangle.Height / gameBoard.Map_Size;

            foreach (Point part in snake.parts)
            {
                gfx.FillRectangle(Brushes.Black, new RectangleF(part.X * partSizeX, part.Y * partSizeY, partSizeX, partSizeY));
            }
        }

        public static void DrawGameBoardBytes(Graphics gfx, GameBoard gameBoard, Control client)
        {
            float partSizeX = (float)client.ClientRectangle.Width / gameBoard.Map_Size;
            float partSizeY = (float)client.ClientRectangle.Height / gameBoard.Map_Size;

            for (int x = 0; x < gameBoard.Map_Size; x++)
            {
                for (int y = 0; y < gameBoard.Map_Size; y++)
                {
                    gfx.DrawString($"{gameBoard.Tiles[x,y]}", new Font(FontFamily.Families[0], 10f, FontStyle.Bold), Brushes.White, new PointF(x * partSizeX, y * partSizeY));
                }
            }
        }

       public static void DrawFoods(Graphics gfx, List<Food> foods)
        {
            foreach (Food f in foods)
            {
                gfx.FillRectangle(Brushes.Red, new RectangleF(f.Coordinate.X * tileX, f.Coordinate.Y * tileY, tileX, tileY));
            }
        }

    }
}
