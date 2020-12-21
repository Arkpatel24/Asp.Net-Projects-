using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number\t Square \t Cube");

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i + "\t" + (i*i) +"\t" +(i*i*i));
                Console.ReadLine();
            }
        }
    }
}
