using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetriDish
{
    public abstract class LifeForm
    {
        public abstract int LifeSpan { get; set; }
        public abstract int NearbyCircleRadius { get; set; }
        public abstract string Specia { get; set; }
        public Status Status { get; set; }
        public Position Position
        {
            get ;
            set ;
            
        }

        protected LifeForm(Position position)
        {
            Position = position;
            Status = Status.Young;
        }

        public abstract List<LifeForm> Divide();

        /// <summary>
        /// when  one Coccus is in Nearby
        /// Cocci need all least 2 bacteria inNearby
        /// Spirillum die if a bacillum Nearby
        /// </summary>
        public abstract void ActOnStatus();

        public bool IsInRadius(Position other)
        {
            return Math.Pow(this.Position.X - other.X, 2) + Math.Pow(this.Position.Y - other.Y, 2) <= Math.Pow(this.NearbyCircleRadius, 2);
        }

        public override string ToString()
        {
            return $"{Specia} {Status.ToString()} at position: {this.Position.ToString()}";
        }

    }
}