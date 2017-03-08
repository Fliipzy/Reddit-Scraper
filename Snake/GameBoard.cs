using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Snake
{

    class GameBoard
    {

        Timer foodTimer;
        public List<Food> foods = new List<Food>();
        private byte[,] tiles;
        public byte[,] Tiles { get { return tiles; } }
        private int map_size;
        public int Map_Size { get { return map_size; } }

        public GameBoard(int map_size, int food_interval)
        {
            InitializeTimer(food_interval);
            this.map_size = map_size;
            InitializeBoard();
        }

        public void OnFoodTimer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();

            List<Point> legalPoints = new List<Point>();

            for (int x = 0; x < map_size; x++)
            {
                for (int y = 0; y < map_size; y++)
                {
                    if (tiles[x,y] == 0)
                    {
                        legalPoints.Add(new Point(x, y));
                    }
                }
            }

            foods.Add(new Food(legalPoints[rnd.Next(legalPoints.Count)]));

        }

        public void InitializeTimer(int interval)
        {
            foodTimer = new Timer();
            foodTimer.Interval = interval;
            foodTimer.Tick += OnFoodTimer_Tick;
            foodTimer.Start();
        }

        public void InitializeBoard()
        {
            tiles = GenerateByteArray(map_size);
        }

        public void UpdateMap(Snake snake)
        {
            for (int x = 0; x < map_size; x++)
            {
                for (int y = 0; y < map_size; y++)
                {
                    tiles[x, y] = 0;
                }
            }

            foreach (Point part in snake.parts)
            {
                int x = part.X;
                int y = part.Y;

                tiles[x, y] = 1;
            }
        }

        private byte[,] GenerateByteArray(int map_size)
        {
            var bytes = new byte[map_size, map_size];

            for (int x = 0; x < map_size; x++)
            {
                for (int y = 0; y < map_size; y++)
                {
                    bytes[x, y] = 0;
                }
            }
            return bytes;
        }
    }
}
