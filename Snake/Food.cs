using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        public static List<Food> foods = new List<Food>(); 

        private Point coordinate;
        public Point Coordinate { get { return coordinate; } }


        public Food(Point coordinate)
        {
            this.coordinate = coordinate;
            foods.Add(this);
        }

    }
}
