using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2P1Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            double height;
            double weight;
            double bmi;

            Console.WriteLine("Enter your weight in kg:");
            weight = double.Parse(Console.ReadLine());


            Console.WriteLine("Enter your height in M:");
            height = double.Parse(Console.ReadLine());

            bmi = weight / Math.Pow(height,2.0);

            Console.WriteLine("Your bmi is: " + bmi);

            if (bmi < 18.5)
                Console.WriteLine("Underweight");

            else if ((bmi >= 18.5) && (bmi <= 24.5))
                Console.WriteLine("Normalweight");

            else if ((bmi >= 24.5) && (bmi <= 34.5))
                Console.WriteLine("Normalweight");

            else
                Console.WriteLine("Obese ClaSS");

            Console.ReadKey();
        }
    }
}
