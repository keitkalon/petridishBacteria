using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetriDish
{
    public class Bacillus : LifeForm
    {

        public override int LifeSpan { get; set; }
        public override int NearbyCircleRadius { get; set; }
        public override string Specia { get; set; }

        public Bacillus(Position position) : base(position)
        {
            LifeSpan = 0;
            NearbyCircleRadius = 3;
            Specia = "Bacillus";
        }

        public override void ActOnStatus()
        {
            if (LifeSpan > 10)
            {
                Status = Status.Dead;
            }
            else if (LifeSpan > 7 && LifeSpan < 10)
            {
                Status = Status.Old;
            }
            else if (LifeSpan > 3 && LifeSpan < 7)
            {
                Status = Status.Matur;
            }
        }


        /// <summary>
        /// it split in two when timePulse == LifeSpan
        /// 2 new life with random position on PetriDish NearByCircle Radius
        /// </summary>
        public override List<LifeForm> Divide()
        {

            return new List<LifeForm>()
            {
                new Bacillus(new Position(new Random().Next(this.Position.X, this.Position.X + NearbyCircleRadius), new Random().Next(this.Position.Y, this.Position.Y + NearbyCircleRadius))),
                new Bacillus(new Position(new Random().Next(this.Position.X, this.Position.X + NearbyCircleRadius), new Random().Next(this.Position.Y, this.Position.Y + NearbyCircleRadius))),
                new Bacillus(new Position(new Random().Next(this.Position.X, this.Position.X + NearbyCircleRadius), new Random().Next(this.Position.Y, this.Position.Y + NearbyCircleRadius))),
                new Bacillus(new Position(new Random().Next(this.Position.X, this.Position.X + NearbyCircleRadius), new Random().Next(this.Position.Y, this.Position.Y + NearbyCircleRadius)))
            };
        }
    }
}