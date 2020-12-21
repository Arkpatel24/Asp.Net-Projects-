using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2p1Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter customer type (R or C):");
            char customerType = Console.ReadLine().ToUpper()[0];

            Console.Write("Enter subtotal:");
            double subtotal = double.Parse(Console.ReadLine());

            double discountPercent = 0.0;

            switch (customerType)
            {
                case 'R':
                    if (subtotal >= 250)
                        discountPercent = 0.25;
                    else if (subtotal >= 100 && subtotal < 250)
                        discountPercent = 0.1;
                    break;

                case 'C':
                    if (subtotal >= 250)
                        discountPercent = 0.3;
                    else if (subtotal >= 100 && subtotal < 250)
                        discountPercent = 0.2;
                    break;

                default:
                    Console.WriteLine("Invalid customer type.Try again.");
                    break;
            }
            double discountAmount = subtotal * discountPercent ;
            double total = subtotal - discountAmount;

            Console.WriteLine("Discount Percent:"+ discountPercent.ToString("P1"));
            Console.WriteLine("Discount Amount:" + discountAmount.ToString("C"));
            Console.WriteLine("Total:" + total.ToString("C"));
            Console.ReadKey();
        }
    }
}
