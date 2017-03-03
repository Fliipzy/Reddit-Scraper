using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    class MapDrawer
    {
        private Map map;

        public static Color startColor = Color.LightBlue;
        public static Color goalColor = Color.Red;
        public static Color accessibleColor = Color.DimGray;
        public static Color inaccessibleColor = Color.DarkSlateGray;

        public static Color visitedColor = Color.Yellow;
        public static Color pathColor = Color.GreenYellow;

        public MapDrawer(Map map)
        {
            this.map = map;
        }


        public Color GetColor(Tile tile)
        {
            Color color = new Color();

            switch (tile.Type)
            {
                case Type.Accessible:
                    color = accessibleColor;
                    break;
                case Type.Inaccessible:
                    color = inaccessibleColor;
                    break;
                case Type.Start:
                    color = startColor;
                    break;
                case Type.Goal:
                    color = goalColor;
                    break;
                case Type.Path:
                    color = pathColor;
                    break;
            }
            return color;
        }

        public void DrawMap(Graphics gfx, bool debug)
        {

            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    RectangleF tileRect = new RectangleF(x * map.TileWidth, y * map.TileHeight, map.TileWidth, map.TileHeight);

                    Brush brush = new SolidBrush(GetColor(map.Tiles[x,y]));

                    gfx.FillRectangle(brush, tileRect);
                    //gfx.DrawRectangle(Pens.Black, x * map.TileWidth, y * map.TileHeight, map.TileWidth, map.TileHeight);

                    if (debug)
                    {
                        if (map.Tiles[x, y].Visited && map.Tiles[x, y].Type == Type.Accessible)
                        {
                            brush = new SolidBrush(visitedColor);
                            gfx.FillRectangle(brush, tileRect);
                        }

                        if (map.IsStartAndGoalPlaced && map.Tiles[x,y].Type == Type.Accessible)
                        {
                            gfx.DrawString(map.Tiles[x, y].HeuristicCost.ToString(), SystemFonts.DefaultFont, Brushes.Black, x * map.TileWidth, y * map.TileHeight);
                            gfx.DrawString(map.Tiles[x, y].TravelCost.ToString(), SystemFonts.DefaultFont, Brushes.Black, x * map.TileWidth, y * map.TileHeight + map.TileHeight - 15);
                            gfx.DrawString(map.Tiles[x, y].TotalCost.ToString(), SystemFonts.DefaultFont, Brushes.Black, x * map.TileWidth + (map.TileWidth / 2)-4, y * map.TileHeight + (map.TileHeight / 2)-4);
                        }
                    }
                    gfx.DrawRectangle(Pens.Black, x * map.TileWidth, y * map.TileHeight, map.TileWidth, map.TileHeight);
                }
            }
        }
    }
}
