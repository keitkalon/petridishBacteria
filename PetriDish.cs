using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetriDish
{
    public class PetiDish
    {
        public PetiDish()
        {
            Timepulse = 0;
            Bacterias = new List<LifeForm>();
        }

        public int Timepulse
        {
            get ;
            set ;
        }

        public List<LifeForm> Bacterias
        {
            get;
            set;
        }

        /// <summary>
        /// divide when timepulse = Life_Span
        /// </summary>
        public void Divide()
        {
            foreach (var bacteria in Bacterias.Reverse<LifeForm>())
            {
                if (bacteria.Status == Status.Matur)
                {
                    Bacterias.AddRange(bacteria.Divide());                   
                    Bacterias.Remove(bacteria);
                   
                    
                }
            }
        }
        public void Vecinity()
        {
            foreach (var bacteria in Bacterias)
            {
                int count = 0;
                foreach (var other in Bacterias)
                {
                    if (!bacteria.Equals(other))
                    {
                        if (bacteria is Bacillus && other is Coccus)
                        {
                            if (bacteria.IsInRadius(other.Position))
                            {
                                bacteria.LifeSpan = -1;
                            }                            
                        }
                        if (bacteria is Coccus)
                        {                           
                            if (bacteria.IsInRadius(other.Position))
                            {
                                count++;                                
                            }                           
                        }
                        if (bacteria is Spirillum && other is Bacillus)
                        {
                            if (bacteria.IsInRadius(other.Position))
                            {
                                bacteria.Status = Status.Killed;
                            }
                        }
                    }
                }
                if (bacteria is Coccus && count < 2)
                {
                    bacteria.LifeSpan += 3;
                }
            }
        }
        public void Move()
        {
            foreach (var bacteria in Bacterias)
            {
                if (bacteria.Status == Status.Matur)
                {
                    if(new Random().Next(1,2) == 2)
                    {
                        int chance1 = new Random().Next(0, 5);
                        int chance2 = new Random().Next(0, 5);
                        //bacteria.Position.X += chance1;
                        //bacteria.Position.Y += chance2;
                        if (bacteria.Position.X + chance1 < 20)
                        {
                            bacteria.Position.X += chance1;
                        }
                        else
                        {
                            bacteria.Position.X -= chance1;
                        }

                        if (bacteria.Position.Y + chance2 < 20)
                        {
                            bacteria.Position.Y += chance2;
                        }
                        else
                        {
                            bacteria.Position.Y -= chance2;
                        }
                    }
                    else
                    {
                        int chance1 = new Random().Next(0, 5);
                        int chance2 = new Random().Next(0, 5);
                        //bacteria.Position.X -= chance1;
                        //bacteria.Position.Y -= chance2;
                        if (bacteria.Position.X + chance1 < 20)
                        {
                            bacteria.Position.X += chance1;
                        }
                        else
                        {
                            bacteria.Position.X -= chance1;
                        }

                        if (bacteria.Position.Y + chance2 < 20)
                        {
                            bacteria.Position.Y += chance2;
                        }
                        else
                        {
                            bacteria.Position.Y -= chance2;
                        }
                    }
                          
                }
                else if (bacteria.Status == Status.Young)
                {
                    if (new Random().Next(1, 2) == 1)
                    {
                        int chance1 = new Random().Next(1, 3);
                        int chance2 = new Random().Next(1, 3);
                        //bacteria.Position.X += chance1;
                        //bacteria.Position.Y += chance2;
                        if (bacteria.Position.X + chance1 < 20)
                        {
                            bacteria.Position.X += chance1;
                        }
                        else
                        {
                            bacteria.Position.X -= chance1;
                        }

                        if (bacteria.Position.Y + chance2 < 20)
                        {
                            bacteria.Position.Y += chance2;
                        }
                        else
                        {
                            bacteria.Position.Y -= chance2;
                        }
                    }
                    else
                    {
                        int chance1 = new Random().Next(1, 3);
                        int chance2 = new Random().Next(1, 3);
                        //bacteria.Position.X -= chance1;
                        //bacteria.Position.Y -= chance2;
                        if (bacteria.Position.X - chance1 < 0)
                        {
                            bacteria.Position.X += chance1;
                        }
                        else
                        {
                            bacteria.Position.X -= chance1;
                        }

                        if (bacteria.Position.Y - chance2 < 0)
                        {
                            bacteria.Position.Y += chance2;
                        }
                        else
                        {
                            bacteria.Position.Y -= chance2;
                        }

                    }

                }
                else if (bacteria.Status == Status.Old)
                {
                    if (new Random().Next(1, 2) == 1)
                    {
                        int chance1 = new Random().Next(0, 1);
                        int chance2 = new Random().Next(0, 1);
                        if (bacteria.Position.X + chance1 < 20)
                        {
                            bacteria.Position.X += chance1;
                        }
                        else
                        {
                            bacteria.Position.X -= chance1;
                        }

                        if (bacteria.Position.Y + chance2 < 20)
                        {
                            bacteria.Position.Y += chance2;
                        }
                        else
                        {
                            bacteria.Position.Y -= chance2;
                        }
                        
                    }
                    else
                    {
                        int chance1 = new Random().Next(0, 1);
                        int chance2 = new Random().Next(0, 1);
                        //bacteria.Position.X -= chance1;
                        //bacteria.Position.Y -= chance2;

                        if (bacteria.Position.X - chance1 < 0)
                        {
                            bacteria.Position.X += chance1;
                        }
                        else
                        {
                            bacteria.Position.X -= chance1;
                        }

                        if (bacteria.Position.Y - chance2 < 0)
                        {
                            bacteria.Position.Y += chance2;
                        }
                        else
                        {
                            bacteria.Position.Y -= chance2;
                        }
                    }

                }
            }
        }

        public void AddBacteria(LifeForm lifeForm)
        {
            Bacterias.Add(lifeForm);
        }
        public void DinamicPetriDish(int volume)
        {
            while (Timepulse < volume)
            {
                Timepulse++;
                display();
                Console.WriteLine(this.ToString());
                Console.ReadKey();
                Console.Clear();
                Bacterias = Bacterias.Where(bacteria => Array.IndexOf(new Status[] { Status.Dead, Status.Killed }, bacteria.Status) == -1).ToList();
                Divide();                
                Move();
                Vecinity();
                Bacterias.ForEach(bacteria => bacteria.LifeSpan++);
                Bacterias.ForEach(bacteria => bacteria.ActOnStatus());
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Bacterias.ForEach(bacteria => sb.Append(bacteria.ToString()).Append("\n"));
            return sb.ToString();
        }

        public void display(int row = 20, int col= 20)
        {
            char[] alfa = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W' };
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            string[,] form = new string[row, col];


            for (int i = 0; i < form.GetLength(0); i++)
            {
                for (int j = 0; j < form.GetLength(1); j++)
                {
                    foreach (var bacteria in Bacterias)
                    {
                        form[i, j] = ".";
                    }
                }
            }

            foreach (var bacteria in Bacterias)
            {
                if (bacteria.Specia == "Spirillum")
                {
                    if (bacteria.Status == Status.Young)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "Sy";
                    }
                    else if (bacteria.Status == Status.Matur)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "Sm";
                    }
                    else if (bacteria.Status == Status.Old)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "So";
                    }
                    else if (bacteria.Status == Status.Dead)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "Sd";
                    }
                    else if (bacteria.Status == Status.Killed)
                    {
                        form[bacteria.Position.X - 1, bacteria.Position.Y - 1] = "Sk";
                    }

                }
                else if(bacteria.Specia == "Coccus")
                {
                    if (bacteria.Status == Status.Young)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "Cy";
                    }
                    else if (bacteria.Status == Status.Matur)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "Cm";
                    }
                    else if (bacteria.Status == Status.Old)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "Co";
                    }
                    else if (bacteria.Status == Status.Dead)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "Cd";
                    }
                }
                else if (bacteria.Specia == "Bacillus")
                {
                    if (bacteria.Status == Status.Young)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "By";
                    }
                    else if (bacteria.Status == Status.Matur)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "Bm";
                    }
                    else if (bacteria.Status == Status.Old)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "Bo";
                    }
                    else if (bacteria.Status == Status.Dead)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "Bd";
                    }
                }
                else
                {
                    if (bacteria.Status == Status.Young)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "0y";
                    }
                    else if (bacteria.Status == Status.Matur)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "0m";
                    }
                    else if (bacteria.Status == Status.Old)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "0o";
                    }
                    else if (bacteria.Status == Status.Dead)
                    {
                        form[bacteria.Position.X-1, bacteria.Position.Y-1] = "0d";
                    }
                    else if (bacteria.Status == Status.Killed)
                    {
                        form[bacteria.Position.X - 1, bacteria.Position.Y - 1] = "0k";
                    }
                }

            }

            Console.Write("  ");
            for (int i = 0; i < row; i++)
            {
                if (i < 10)
                {
                    Console.Write($"__{numbers[i]}___");
                }
                else
                {
                    Console.Write($"_{numbers[i]}___");
                }
            }

            Console.WriteLine("");

            for (int i = 0; i < row; i++)
            {
                Console.Write(" |");
                for (int j = 0; j < col; j++)
                {
                    Console.Write("     |");
                }
                Console.WriteLine("");
                Console.Write($"{alfa[i]}|");
                for (int j = 0; j < col; j++)
                {
                    if (form[i,j] == "Sy")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"  S");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if(form[i, j] == "Sm")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"  S");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "So")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"  S");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "Sd")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"  S");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "Cy")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"  C");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "Cm")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"  C");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "Co")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"  C");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "Cd")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"  C");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "By")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"  B");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "Bm")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"  B");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "Bo")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"  B");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "Bd")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"  B");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "0y")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"  0");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "0m")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"  0");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "0o")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"  0");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "0d")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"  0");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "Sk")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"  X");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == "0k")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"  X");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (form[i, j] == ".")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"  .");
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    
                 
                } 
                Console.Write("\n |");
                for (int j = 0; j < col; j++)
                {
                    Console.Write("_____|");
                }
                Console.WriteLine("");
            }
        }
             
    }
}