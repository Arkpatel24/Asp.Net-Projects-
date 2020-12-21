using System;

namespace A2ArkPatel
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                flag = MainMenu();
            }
        }
        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Get all Products");
            Console.WriteLine("2 - Get all Categories ");
            Console.WriteLine("3 - Get all Suppliers");
            Console.WriteLine("4 - Get Products by Category ID");
            Console.WriteLine("5 - Get Products by Supplier ID");
            Console.WriteLine("6 - Exit");
            Console.WriteLine("Choose your option :");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    NW.ViewProduct();
                    return true;
                case "2":
                    Console.Clear();
                    NW.ViewCategory();
                    return true;
                case "3":
                    Console.Clear();
                    NW.ViewSuppliers();
                    return true;
                case "4":
                    Console.Clear();
                    NW.ViewProdByCatID();
                    return true;
                case "5":
                    Console.Clear();
                    NW.ViewProdBySupID();
                    return true;
                case "6":
                    Environment.Exit(-1);
                    return false;
                default:

                    return true;
            }
        }
    }
}
