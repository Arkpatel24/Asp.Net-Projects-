using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Repair
    {
        public static List<Repair> ListRepair = new List<Repair>()
            {
            new Repair { repairId=1, inventoryId=101, whatToRepair="tiers"},
            new Repair { repairId=2, inventoryId=102, whatToRepair="sunroof"},
            new Repair { repairId=3, inventoryId=103, whatToRepair="moonroof"},
            new Repair { repairId=4, inventoryId=104, whatToRepair="exhaust"},
            new Repair { repairId=5, inventoryId=105, whatToRepair="bumper"},
        };

        public int repairId { get; set; }
        public int inventoryId { get; set; }
        public string whatToRepair { get; set; }
        public static void getRepairs()
        {
            
            Console.WriteLine("Press 1 to view all repairs");
            Console.WriteLine("Press 2 to enter repair info");
            Console.WriteLine("Press 3 to update repair info");
            Console.WriteLine("Press 4 to delete info");
            Console.WriteLine("Press 5 to return to main menu");
            switch (Console.ReadLine())
            {
                case "1":
                    ListRepairs();
                    break;

                case "2":
                    addRepairs();
                    break;

                case "3":
                    updateRepairs();
                    break;

                case "4":
                    deleteRepairs();
                    break;

                case "5":
                    Program.Menu1();
                    break;

                default:
                    Console.WriteLine("Please enter number between 1 to 5");
                    break;
            }
            Console.ReadKey();
        }

        public static void ListRepairs()
        {
            Console.WriteLine("List of Repairs");
            var display = from r in ListRepair
                          select new { repairId = r.repairId, inventoryId = r.inventoryId, whatToRepair = r.whatToRepair };

            foreach (var r in display)
                Console.WriteLine(r);
        }

        public static List<Repair> addRepairs()
        {
            try
            {
                string whatToRepair;
                Console.WriteLine("Insert Repair Information");
                Console.WriteLine("Enter Repair Id");
                string repId = Console.ReadLine();
                Console.WriteLine("Enter inventory Id");
                string inId = Console.ReadLine();
                Console.WriteLine("Enter What to repair");
                do 
                { 
                whatToRepair = Console.ReadLine();
                    if (String.IsNullOrEmpty(whatToRepair))
                    {
                        Console.WriteLine("Invalid input,You must enter value");
                        Console.WriteLine("Enter what to repair ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                ListRepair.Add(new Repair()
                {
                    repairId = int.Parse(repId),
                    inventoryId = int.Parse(inId),
                    whatToRepair = whatToRepair
                }); ;


                Console.WriteLine("Insert Completed");
                ListRepairs();
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    $"Unexpected error:  { exception.Message }");

            }
            finally
            {
                Console.WriteLine("goodbye");
            }
            return ListRepair;
        }

        public static List<Repair> updateRepairs()
        {
            try
            {
                ListRepairs();
                string newRepair;
                Console.WriteLine("Enter Id, you want to update");
                int repId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new repair Id");
                int newRepId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new inventory Id");
                int newInId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter What to repair");
                do 
                { 
                newRepair = Console.ReadLine();
                    if (String.IsNullOrEmpty(newRepair))
                    {
                        Console.WriteLine("Invalid input,You must enter value");
                        Console.WriteLine("Enter what to repair ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                var update = from r in ListRepair
                             where r.repairId == repId
                             select new { repairId = r.repairId = newRepId, inventoryId = r.inventoryId = newInId, whatToRepair = r.whatToRepair = newRepair };
                foreach (var r in update)
                    Console.WriteLine(r);
                Console.WriteLine("List Updated");

                ListRepairs();
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    $"Unexpected error:  { exception.Message }");

            }
            finally
            {
                Console.WriteLine("goodbye");
            }
            return ListRepair;
        }
        public static List<Repair> deleteRepairs()
        {
            try
            {
                ListRepairs();

                Console.WriteLine("Delete repair Information using ID");
                Console.WriteLine("Enter repair Id");
                int repId = int.Parse(Console.ReadLine());



                var remove = from r in ListRepair
                             where r.repairId != repId
                             select new { r.repairId, r.inventoryId, r.whatToRepair };
                foreach (var r in remove)
                    Console.WriteLine(r);
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    $"Unexpected error:  { exception.Message }");

            }
            finally
            {
                Console.WriteLine("goodbye");
            }
            return ListRepair;
        }
    }
}
