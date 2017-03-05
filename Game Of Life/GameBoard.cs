using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameOfLife
{
    class GameBoard
    {
        public Cell[,] cellMap;
        public bool[,] map;

        private int size;
        private float tileSize;


        public GameBoard(int size)
        {
            this.size = size;
            tileSize = 500f / size;
            map = new bool[size, size];
            InitializeCells();
        }

        private void InitializeCells()
        {
            cellMap = new Cell[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    cellMap[x, y] = new Cell(x, y);
                }
            }
        }

        public void DrawBoard(object sender, PaintEventArgs e)
        {
            
            int decrementColorValue = 50;

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (cellMap[x,y].IsAlive == true)
                    {
                        e.Graphics.FillRectangle(Brushes.Black, x * tileSize, y * tileSize, tileSize, tileSize);
                        cellMap[x, y].TemporaryColor = Color.Black;
                        cellMap[x, y].HasBeenTouched = true;
                    }
                    if (cellMap[x,y].IsAlive == false && cellMap[x,y].HasBeenTouched == true)
                    {

                        int R = (cellMap[x, y].TemporaryColor.R + decrementColorValue).Between(0, 255);
                        int B = (cellMap[x, y].TemporaryColor.B + decrementColorValue).Between(0, 255);
                        int G = (cellMap[x, y].TemporaryColor.G + decrementColorValue).Between(0, 255);

                        if (R == 255 && G == 255 && B == 255)
                        {
                            cellMap[x, y].HasBeenTouched = false;
                            continue;
                        }

                        Color newColor = Color.FromArgb(R,G,B);
                        e.Graphics.FillRectangle(new SolidBrush(newColor), x * tileSize, y * tileSize, tileSize, tileSize);
                        cellMap[x, y].TemporaryColor = newColor;

                    }

                }
            }
        }

        public void Simulate()
        {
            byte[,] neighboursMap = new byte[size, size];
            bool[,] tempMap = map;
            bool[,] keptAliveCells = new bool[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (cellMap[x,y].IsAlive == true)
                    {
                        int aliveNeighboursCount = 0;

                        if (x < size-1)
                        {
                            if (cellMap[x+1, y].IsAlive == true)
                            {
                                aliveNeighboursCount += 1;
                            }
                            else
                            {
                                neighboursMap[x + 1, y] += 1;
                            }
                        }
                        if (x > 0)
                        {
                            if (cellMap[x-1, y].IsAlive == true)
                            {
                                aliveNeighboursCount += 1;
                            }
                            else
                            {
                                neighboursMap[x - 1, y] += 1;
                            }
                        }
                        if (y < size - 1)
                        {
                            if (cellMap[x, y+1].IsAlive == true)
                            {
                                aliveNeighboursCount += 1;
                            }
                            else
                            {
                                neighboursMap[x, y + 1] += 1;
                            }
                        }
                        if (y > 0)
                        {
                            if (cellMap[x, y-1].IsAlive == true)
                            {
                                aliveNeighboursCount += 1;
                            }
                            else
                            {
                                neighboursMap[x, y-1] += 1;
                            }
                        }
                        //top left
                        if (x > 0 && y > 0)
                        {
                            if (cellMap[x-1, y-1].IsAlive == true)
                            {
                                aliveNeighboursCount += 1;
                            }
                            else
                            {
                                neighboursMap[x - 1, y - 1] += 1;
                            }
                        }
                        //top right
                        if (x < size-1 && y > 0)
                        {
                            if (cellMap[x+1, y-1].IsAlive == true)
                            {
                                aliveNeighboursCount += 1;
                            }
                            else
                            {
                                neighboursMap[x + 1, y - 1] += 1;
                            }
                        }
                        //lower left
                        if (x > 0 && y < size-1)
                        {
                            if (cellMap[x-1, y+1].IsAlive == true)
                            {
                                aliveNeighboursCount += 1;
                            }
                            else
                            {
                                neighboursMap[x - 1, y + 1] += 1;
                            }
                        }
                        //lower right
                        if (x < size - 1 && y < size - 1)
                        {
                            if (cellMap[x+1, y+1].IsAlive == true)
                            {
                                aliveNeighboursCount += 1;
                            }
                            else
                            {
                                neighboursMap[x + 1, y + 1] += 1;
                            }
                        }
                        if (aliveNeighboursCount > 1 && aliveNeighboursCount < 4)
                        {
                            cellMap[x, y].IsAlive = true;
                            keptAliveCells[x, y] = true;
                        }
                    }
                }
            }

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (keptAliveCells[x,y] == false)
                    {
                        int neighboursCount = neighboursMap[x, y];

                        if (neighboursCount < 2)
                        {
                            cellMap[x, y].IsAlive = false;
                        }
                        if (neighboursCount == 2)
                        {
                            cellMap[x, y].IsAlive = cellMap[x, y].IsAlive;
                        }
                        if (neighboursCount == 3)
                        {
                            cellMap[x, y].IsAlive = true;
                        }
                        if (neighboursCount > 3)
                        {
                            cellMap[x, y].IsAlive = false;
                        }
                    }
                }
            }
        }

        public void SetCell(float x, float y, bool condition)
        {
            int cellX = (int)Math.Ceiling(x / tileSize);
            int cellY = (int)Math.Ceiling(y / tileSize);

            if (size > cellX - 1 && size > cellY - 1 && cellX > 0 && cellY > 0)
            {
                if (condition)
                {
                    cellMap[cellX - 1, cellY - 1].IsAlive = true;
                }
                else
                {
                    cellMap[cellX - 1, cellY - 1].IsAlive = false;
                }
                
            }
        }

        public void ClearBoard()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    cellMap[x, y].IsAlive = false;
                }
            }
        }
    }
}
