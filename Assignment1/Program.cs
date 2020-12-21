using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
         

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu1();
            }

        }
     
        public static bool Menu1()
        {
            Console.Clear();
            Console.WriteLine("Welcome! please choose a command:");
            Console.WriteLine("Press 1 to modify vehicles");
            Console.WriteLine("Press 2 to modify inventory");
            Console.WriteLine("Press 3 to modify repair");
            Console.WriteLine("Press 4 to exit program");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    getVehicles();
                    return true;
                case "2":
                    getInventory();
                    return true;
                case "3":
                    getRepair();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }

        }

        public static void getVehicles()
        {
            Console.Clear();
            Vehicle.getVehicles();

        }

        public static void getInventory()
        {
            Console.Clear();
            Inventory.getInventorys();
        }

        public static void getRepair()
        {
            Console.Clear();
            Repair.getRepairs();
        }

        
    }
}
