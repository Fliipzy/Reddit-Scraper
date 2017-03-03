using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinding
{
    public partial class UIForm : Form
    {
        Map map;
        MapDrawer mapDrawer;
        AStarPathFinding aStarPathFinding;

        bool isPlacingStart;
        bool isPlacingGoal;

        public UIForm()
        {
            InitializeComponent();

            map = new Map(16, 16, dbPanel);
            mapDrawer = new MapDrawer(map);
            aStarPathFinding = new AStarPathFinding(map);

            MapDrawer.accessibleColor = Color.White;
            MapDrawer.inaccessibleColor = Color.Black;
            MapDrawer.startColor = Color.Blue;

            aStarPathFinding.PathFound += OnPathSearchingFinished;

        }

        private void OnPathSearchingFinished(object sender, EventArgs e)
        {
            RefreshPanel();
        }

        private void RefreshPanel()
        {
            dbPanel.Refresh();
        }

        private void doubleBufferPanel1_Paint(object sender, PaintEventArgs e)
        {
            mapDrawer.DrawMap(e.Graphics, cBoxDebugMode.Checked);
        }
        

        private void doubleBufferPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            int mouse_pos_x = (int)Math.Floor(e.X / map.TileWidth);
            int mouse_pos_y = (int)Math.Floor(e.Y / map.TileHeight);

            if (isPlacingStart || isPlacingGoal)
            {
                if (isPlacingStart)
                {
                    isPlacingStart = false;
                    map.Tiles[mouse_pos_x, mouse_pos_y].Type = Type.Start;
                }
                if (isPlacingGoal)
                {
                    isPlacingGoal = false;
                    map.Tiles[mouse_pos_x, mouse_pos_y].Type = Type.Goal;
                }
            }
            else
            {
                switch (map.Tiles[mouse_pos_x, mouse_pos_y].Type)
                {
                    case Type.Accessible:
                        map.Tiles[mouse_pos_x, mouse_pos_y].Type = Type.Inaccessible;
                        break;
                    case Type.Inaccessible:
                        map.Tiles[mouse_pos_x, mouse_pos_y].Type = Type.Accessible;
                        break;
                    case Type.Start:
                        map.Tiles[mouse_pos_x, mouse_pos_y].Type = Type.Accessible;
                        break;
                    case Type.Goal:
                        map.Tiles[mouse_pos_x, mouse_pos_y].Type = Type.Accessible;
                        break;
                    default:
                        break;
                }
            }
            

            dbPanel.Refresh();
            CheckToEnableBegin();
        }

        public void CheckToEnableBegin()
        {
            if (map.IsStartAndGoalPlaced)
            {
                btnBegin.Enabled = true;
            }
            else
            {
                btnBegin.Enabled = false;
            }
        }

        private void btnPlaceStart_Click(object sender, EventArgs e)
        {
            isPlacingStart = true;
        }

        private void btnPlaceGoal_Click(object sender, EventArgs e)
        {
            isPlacingGoal = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            map.ClearMap();
            aStarPathFinding.Clear();
            dbPanel.Refresh();
            btnBegin.Enabled = false;
        }

        private void cBoxDebugMode_CheckedChanged(object sender, EventArgs e)
        {
            dbPanel.Refresh();
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            aStarPathFinding.FindPath();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            aStarPathFinding.Clear();
            dbPanel.Refresh();
        }
    }
}
