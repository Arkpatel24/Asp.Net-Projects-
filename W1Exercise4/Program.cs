using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W1Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int randomNum = rnd.Next(10);
            int guess;

            do
            {
                Console.WriteLine("Guess the random number between 0 to 9 : ");
                guess = int.Parse(Console.ReadLine());

                if (guess == randomNum)
                {
                    Console.WriteLine("Congrats you guess it");
                }
                else if (guess < randomNum)
                {
                    Console.WriteLine("Too low try again");
                }
                else 
                {
                    Console.WriteLine("Too high try again");
                }
            } while (guess!= randomNum);
            Console.ReadKey();
        }
    }
}
