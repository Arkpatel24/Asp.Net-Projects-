using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2P1Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter monthly investment:");
            double monthlyInvest = double.Parse(Console.ReadLine());

            Console.Write("Enter yearly investment:");
            double yearlyInvest = double.Parse(Console.ReadLine());

            Console.Write("Enter number of year:");
            int numberOfYears = int.Parse(Console.ReadLine());

            double monthlyInterest = yearlyInvest / 12 / 100;
            int numberOfMonths = numberOfYears * 12;

            double futureValue = 0.0;

            for (int i = 0; i < numberOfMonths; i++)
            {
                futureValue = (futureValue + monthlyInvest) * (1+monthlyInterest);
            }

            Console.WriteLine("FutureValue:"+futureValue.ToString("C"));
            Console.ReadKey();
        }
    }
}
