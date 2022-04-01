using System;

namespace PetriDish
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PetiDish PlasticLamela = new PetiDish();
            PlasticLamela.AddBacteria(new Spirillum(new Position( new Random().Next(2,17), new Random().Next(2, 17))));
            PlasticLamela.AddBacteria(new Bacillus(new Position(new Random().Next(2, 17), new Random().Next(2, 17))));
            PlasticLamela.AddBacteria(new Coccus(new Position(new Random().Next(2, 17), new Random().Next(2, 17))));
            PlasticLamela.AddBacteria(new Spirillum(new Position(new Random().Next(2, 17), new Random().Next(2, 17))));
            PlasticLamela.AddBacteria(new Bacillus(new Position(new Random().Next(2, 17), new Random().Next(2, 17))));
            PlasticLamela.AddBacteria(new Coccus(new Position(new Random().Next(2, 17), new Random().Next(2, 17))));
            PlasticLamela.DinamicPetriDish(200);
            //PlasticLamela.ToString();
        }
    }
}
