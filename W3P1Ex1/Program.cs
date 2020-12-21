using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3P1Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = {55,222,88,66,11};
            printArray(x);
            printArraySpacs(x);

            Array.Sort(x);
            printArray(x);

            Console.ReadKey();
        }

        private static void printArraySpacs(int[] myArray)
        {
            Console.WriteLine("My array sceps are:");
            Console.WriteLine("Lenght is: {0}",myArray.Length);
            Console.WriteLine("Rank is : {0}",myArray.Rank);
            Console.WriteLine("Lenght of dimension zero is:{0}",myArray.GetLength(0));
        }

        private static void printArray(int[] myArray)
        {
            int i = 0;

            foreach (int num in myArray)
                Console.WriteLine("x[{0}]={1}",i++,num);
        }
    }
}
