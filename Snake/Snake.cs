using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        private int size;
        public int Size { get { return size; } }
        private GameBoard gameBoard;

        public List<Point> parts = new List<Point>();
        List<Point> tempParts = new List<Point>();

        private bool IsTouching()
        {

            for (int i = 0; i < parts.Count; i++)
            {
                if (i > 0 && parts[i] == parts[0])
                {
                    return true;
                }
            }
            return false;
        }

        public Point HeadPosition
        {
            get
            {
                return parts[0];
            }
        }
        Point startPoint;

        public Snake(int startParts, GameBoard gameBoard)
        {
            this.gameBoard = gameBoard;
            startPoint = new Point(gameBoard.Map_Size / 2, gameBoard.Map_Size / 2);

            for (int i = 0; i < startParts; i++)
            {
                parts.Add(new Point(startPoint.X, startPoint.Y + i));
            }

        }

        public void Grow()
        {
            size++;
            parts.Add(new Point(parts[size-1].X, parts[size-1].Y));
        }

        public void Move(Movement movement, out Movement lastMovement)
        {
            

            foreach (Point part in parts)
            {
                tempParts.Add(part);
            }


            switch (movement)
            {
                case Movement.Right:
                    parts[0] = new Point(parts[0].X + 1, parts[0].Y);
                    lastMovement = Movement.Right;
                    break;
                case Movement.Left:
                    parts[0] = new Point(parts[0].X - 1, parts[0].Y);
                    lastMovement = Movement.Left;
                    break;
                case Movement.Up:
                    parts[0] = new Point(parts[0].X, parts[0].Y - 1);
                    lastMovement = Movement.Up;
                    break;
                case Movement.Down:
                    parts[0] = new Point(parts[0].X, parts[0].Y + 1);
                    lastMovement = Movement.Down;
                    break;
                default:
                    lastMovement = Movement.Down;
                    break;
            }

            if (IsTouching())
            {
                GameState.State = States.State.GameOver;
            }

            //Is it touching food
            foreach (Food f in Food.foods)
            {
                if (parts[0] == f.Coordinate)
                {
                    Grow();
                    //Food.foods.Remove(f);
                }
            }


            if (parts[0].X > gameBoard.Map_Size-1 || parts[0].X < 0 || parts[0].Y > gameBoard.Map_Size-1 || parts[0].Y < 0)
            {
                parts[0] = GetOutOfBoundsPosition();
            }
            

            for (int i = 0; i < parts.Count; i++)
            {
                if (i > 0)
                {
                    parts[i] = tempParts[i - 1];
                }
            }

            tempParts.Clear();
        }

        private Point GetOutOfBoundsPosition()
        {
            Point outOfboundPoint = new Point();

            if (parts[0].X > gameBoard.Map_Size - 1)
            {
                outOfboundPoint = new Point(0, parts[0].Y);
            }
            if (parts[0].X < 0)
            {
                outOfboundPoint = new Point(gameBoard.Map_Size - 1, parts[0].Y);
            }
            if (parts[0].Y > gameBoard.Map_Size - 1)
            {
                outOfboundPoint = new Point(parts[0].X, 0);
            }
            if (parts[0].Y < 0)
            {
                outOfboundPoint = new Point(parts[0].X, gameBoard.Map_Size - 1);
            }

            return outOfboundPoint;
        }
    }
}
