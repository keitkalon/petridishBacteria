using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetriDish
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X
        {
            get ;
            set ;
        }

        public int Y
        {
            get ;
            set ;           
            
        }
        public override string ToString()
        {
            return $"({this.X},{this.Y})";
        }
    }
}