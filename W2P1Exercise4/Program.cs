using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace W2P1Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N\t10N\t100N\t1000N");

            for (int i = 1; i <= 5; i++)
            {
                int ten = 10 * i;
                int hundred = 100 * i;
                int thousand = 1000 * 1;

                Console.WriteLine(i +"\t" + ten +"\t"+ hundred +"\t"+ thousand);
            }

            Console.ReadKey();
        }
    }
}
