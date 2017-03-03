using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinding
{
    public enum Type
    {
        Accessible,
        Inaccessible,
        Start,
        Goal,
        Path
    }

    public class Tile
    {
        public Tile Parent;

        public List<Tile> Neighbours = new List<Tile>();

        public int HeuristicCost { get; set; }
        public int TravelCost { get; set; }
        public int TotalCost { get { return HeuristicCost + TravelCost; } }

        public Type Type { get; set; }

        public Point Coordinate { get { return new Point(X, Y); } }

        public int X { get; set; }
        public int Y { get; set; }

        //Debug Variables
        public bool Visited = false;
        public int VisitedNumber = 0;

        public Tile(int x, int y, Type type)
        {
            this.X = x;
            this.Y = y;

            this.Type = type;
        }
    }


    class Map
    {
        private Tile[,] tiles;
        public Tile[,] Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        private int[,] tileDistances;
        public int[,] TileDistances { get { return tileDistances; } }

        private Panel drawPanel;

        private Point startPoint;

        public Point StartPoint
        {
            get
            {
                return startPoint;
            }
        }

        private Point goalPoint;

        public Point GoalPoint
        {
            get { return goalPoint; }
        }


        public bool IsStartAndGoalPlaced
        {
            get
            {
                bool startPlaced = false;
                bool goalPlaced = false;

                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        if (tiles[x,y].Type == Type.Start)
                        {
                            startPoint = new Point(x, y);
                            startPlaced = true;
                        }
                        if (tiles[x,y].Type == Type.Goal)
                        {
                            goalPoint = new Point(x, y);
                            goalPlaced = true;
                        }
                    }
                }
                if (startPlaced && goalPlaced)
                {
                    InitializeTileDistances();
                    return true;
                }
                else
                {
                    return false;
                }
            }    
        }

        private int width;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public float TileWidth { get { return (float)drawPanel.Width / width; } }

        public float TileHeight { get { return (float)drawPanel.Height / height; } }

        public Map(int width, int height, Panel drawPanel)
        {
            this.width = width;
            this.height = height;

            this.drawPanel = drawPanel;

            InitializeTiles();
        }

        private void InitializeTiles()
        {
            tiles = new Tile[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tiles[x, y] = new Tile(x, y, Type.Accessible);
                }
            }
        }

        public void ClearMap()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tiles[x, y] = new Tile(x, y, Type.Accessible);
                }
            }
        }

        public void InitializeTileDistances()
        {
            tileDistances = new int[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int xDistance = Math.Abs(goalPoint.X - x);
                    int yDistance = Math.Abs(goalPoint.Y - y);

                    //Manhattan Heuristics
                    tiles[x, y].HeuristicCost = xDistance + yDistance;
                }
            }
        }

    }
}
