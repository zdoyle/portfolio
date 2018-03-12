using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenPomBracketPredictor
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string again;

            do
            {
                int favorite = -1;
                int underdog = -1;

                do
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("FAVORITE");
                    Console.ResetColor();
                    Console.Write("'s % probability of winning: ");
                    string favoriteString = Console.ReadLine();

                    if (!int.TryParse(favoriteString, out favorite) || favorite < 0 || favorite > 100)
                    {
                        Console.Write("\nPlease enter a valid number (1-100).  Press any key to enter another number...");
                        Console.ReadKey();
                    }
                } while (favorite < 0 || favorite > 100);


                underdog = 100 - favorite;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("UNDERDOG");
                Console.ResetColor();
                Console.WriteLine("'s % probability of winning: " + underdog);

                Console.Write("\nThe program will now generate a random number between 1-100." + 
                    "\nIf the number lands at or below the % win probability of the favorite," +
                    "\nthey shall be the winner of this matchup. If it lands above, the underdog shall be the winner." +
                    "\n\nPress any key to learn the outcome of this matchup... ");
                Console.ReadKey();


                int winner = random.Next(1, 101);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("FAVORITE");
                Console.ResetColor();
                Console.WriteLine("'s % probability of winning: " + favorite);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("UNDERDOG");
                Console.ResetColor();
                Console.WriteLine("'s % probability of winning: " + underdog);
                Console.Write("\nWith a random draw of ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(winner);
                Console.ResetColor();
                Console.Write(", it has been determined that the ");

                if (winner <= favorite)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("FAVORITE ");
                    Console.ResetColor();
                    Console.WriteLine("has won this matchup.");
                    Console.Write("\nPress enter to enter a new matchup.  Press \"Q\" to quit.... ");
                    again = Console.ReadLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("UNDERDOG ");
                    Console.ResetColor();
                    Console.WriteLine("has won this matchup.");
                    Console.Write("\nPress enter to enter a new matchup.  Press \"Q\" to quit... ");
                    again = Console.ReadLine();
                }

                again = again.ToUpper();

            } while (again != "Q");
        }
    }
}
