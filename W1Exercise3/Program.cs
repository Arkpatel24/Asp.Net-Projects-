using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W1Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int random1, random2;
            char ch = 'y';

            while (ch == 'y')
            {
                random1 = rnd.Next(1, 10);
                random2 = rnd.Next(1, 10);

                int correctans = random1 + random2;
                int userans;

                do
                {
                    Console.Write("What is " + random1 + "+" + random2 + "?");
                    userans = int.Parse(Console.ReadLine());

                    if (userans == correctans)
                    {
                        Console.WriteLine("Correct Answer");
                    }
                    else
                    {
                        Console.WriteLine("Wrong Answer");
                    }
                } while (userans != correctans);

                Console.Write("Would you like another question (y/n):");
                ch = Console.ReadLine()[0];
            }
        }
    }
}
