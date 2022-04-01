using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetriDish
{
    public class Spirillum : LifeForm
    {
        public override int LifeSpan { get; set; }
        public override int NearbyCircleRadius { get; set; }
        public override string Specia { get; set; }

        public Spirillum(Position position) : base(position)
        {
            LifeSpan = 0;
            NearbyCircleRadius = 2;
            Specia = "Spirillum";
        }


        public override void ActOnStatus()
        {
            if (LifeSpan > 40)
            {
                Status = Status.Dead;
            }
            else if (LifeSpan > 30 && LifeSpan < 40)
            {
                Status = Status.Old;
            }
            else if (LifeSpan > 10 && LifeSpan < 30)
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
            this.Status = Status.Dead;
            return new List<LifeForm>()
            {
                new Spirillum(new Position(new Random().Next(this.Position.X, this.Position.X + NearbyCircleRadius), new Random().Next(this.Position.Y, this.Position.Y + NearbyCircleRadius))),
                new Spirillum(new Position(new Random().Next(this.Position.X, this.Position.X + NearbyCircleRadius), new Random().Next(this.Position.Y, this.Position.Y + NearbyCircleRadius)))
            }; ;
        }
    }
}