using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        GameBoard board;
        bool startSimulation = false;
        bool mouseDown = false;

        public Form1()
        {
            InitializeComponent();
            board = new GameBoard(64);

            panel1.Paint += board.DrawBoard;
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            board.Simulate();
            panel1.Invalidate();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startSimulation = !startSimulation;
            if (startSimulation)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
            
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (e.Button == MouseButtons.Right)
                {
                    board.SetCell(e.X, e.Y, false);
                }
                if (e.Button == MouseButtons.Left)
                {
                    board.SetCell(e.X, e.Y, true);
                }
                
                panel1.Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startSimulation = false;
            timer.Stop();
            board.ClearBoard();
            panel1.Invalidate();
        }
    }
}
