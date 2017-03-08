using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Snake
{

    public enum Movement { Right, Left, Up, Down };

    public partial class GameForm : Form
    {
        
        Movement movement;
        static GameBoard gameBoard;
        static Snake snake;
        public static Rectangle clientRectangle = ActiveForm.ClientRectangle;
        Movement lastMovement;

        public static int Resolution
        {
            get { return gameBoard.Map_Size; }
        }

        public GameForm()
        {
            InitializeComponent();
            base.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            gameBoard = new GameBoard(17, 5000);
            snake = new Snake(2, gameBoard);
            clientRectangle = ClientRectangle;

            timer.Start();
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (GameState.State == States.State.Playing)
            {
                Invalidate();
            }
            if (GameState.State == States.State.GameOver)
            {
                timer.Stop();
            }
        }



        private void GameForm_Paint(object sender, PaintEventArgs e)
        {

            snake.Move(movement, out lastMovement);
            gameBoard.UpdateMap(snake);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            Draw.DrawColors(e.Graphics, gameBoard.Map_Size, ClientRectangle.Width, ClientRectangle.Height, 127);
            Draw.DrawSnake(e.Graphics, snake, gameBoard, this);
            Draw.DrawFoods(e.Graphics, gameBoard.foods);
            
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && lastMovement != Movement.Left)
            {
                movement = Movement.Right;
            }
            if (e.KeyCode == Keys.Left && lastMovement != Movement.Right)
            {
                movement = Movement.Left;
            }
            if (e.KeyCode == Keys.Up && lastMovement != Movement.Down)
            {
                movement = Movement.Up;
            }
            if (e.KeyCode == Keys.Down && lastMovement != Movement.Up)
            {
                movement = Movement.Down;
            }

        }
    }
}
