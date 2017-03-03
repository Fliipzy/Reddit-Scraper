using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinding
{


    class AStarPathFinding
    {
        private bool diagonalMovementAllowed = false;
        public bool DiagonallyMovement
        {
            get { return diagonalMovementAllowed; }
            set { diagonalMovementAllowed = value; }
        }

        private Map map;

        private List<Tile> OpenList = new List<Tile>();
        private List<Tile> ClosedList = new List<Tile>();
        public static LinkedList<Tile> Path { get { return path; } }
        private static LinkedList<Tile> path = new LinkedList<Tile>();

        private bool IsOpenListEmpty
        {
            get
            {
                return OpenList.Count == 0 ? true : false;
            }
        }

        private int steps = 0;
        private bool goalFound = false;

        public AStarPathFinding(Map map)
        {
            this.map = map;
        }

        public void Clear()
        {
            OpenList.Clear();
            ClosedList.Clear();
            steps = 0;
            goalFound = false;
            path.Clear();
        }

        public void FindPath()
        {
            InitializeTileNeighbours();

            AddNeighboursToOpenList(map.Tiles[map.StartPoint.X, map.StartPoint.Y]);

            while (!IsOpenListEmpty && !goalFound)
            {
                Tile q = GetCheapestTile();
                AddNeighboursToOpenList(q);
                OpenList.Remove(q);
                ClosedList.Add(q);
                map.Tiles[q.X, q.Y].Visited = true;
            }

            while (!(path.First.Value.Coordinate == map.Tiles[map.StartPoint.X,map.StartPoint.Y].Coordinate))
            {
                Tile tile = path.First.Value.Parent;
                path.AddFirst(tile);
                map.Tiles[tile.X, tile.Y].Type = Type.Path;
            }
            map.Tiles[map.StartPoint.X, map.StartPoint.Y].Type = Type.Start;
            path.RemoveFirst();

            OnPathFound();

        }
        private Tile GetCheapestTile()
        {
            int lowestIndex = 0;

            if (OpenList.Count == 1)
            {
                return OpenList[0];
            }

            for (int i = 0; i < OpenList.Count; i++)
            {

                foreach (var neighbour in OpenList[i].Neighbours)
                {
                    if (neighbour.X == map.GoalPoint.X && neighbour.Y == map.GoalPoint.Y)
                    {
                        return OpenList[i];
                    }
                }

                if (OpenList[lowestIndex].TotalCost >= OpenList[i].TotalCost)
                {
                    if (OpenList[lowestIndex].TotalCost == OpenList[i].TotalCost)
                    {
                        lowestIndex = OpenList[lowestIndex].HeuristicCost <= OpenList[i].HeuristicCost ? lowestIndex : i;
                        continue;
                    }
                    lowestIndex = i;
                }
            }
            return OpenList[lowestIndex];
        }

        private void AddNeighboursToOpenList(Tile tile)
        {
            foreach (var neighbour in tile.Neighbours)
            {
                if (neighbour.Type == Type.Goal)
                {
                    Path.AddFirst(tile);
                    tile.Type = Type.Path;
                    map.Tiles[tile.X, tile.Y].Visited = true;
                    goalFound = true;
                    break;
                }

                if (!OpenList.Contains(neighbour) && !ClosedList.Contains(neighbour) && neighbour.Type == Type.Accessible)
                {
                    OpenList.Add(neighbour);
                    neighbour.TravelCost = tile.TravelCost + 1;
                    neighbour.Parent = tile;
                }
            }
        }

        private void InitializeTileNeighbours()
        {

            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    map.Tiles[x, y].Neighbours.Clear();

                    if (x > 0)
                    {
                        map.Tiles[x, y].Neighbours.Add(map.Tiles[x - 1, y]);
                    }
                    if (x < map.Width-1)
                    {
                        map.Tiles[x, y].Neighbours.Add(map.Tiles[x + 1, y]);
                    }
                    if (y > 0)
                    {
                        map.Tiles[x, y].Neighbours.Add(map.Tiles[x, y - 1]);
                    }
                    if (y < map.Height-1)
                    {
                        map.Tiles[x, y].Neighbours.Add(map.Tiles[x, y + 1]);
                    }

                    //TODO: Add diagonal neighbours
                }
            }
        }

        public EventHandler PathFound;
        protected virtual void OnPathFound()
        {
            if (PathFound != null)
            {
                PathFound(this, new EventArgs());
            }
        }
    }
}
