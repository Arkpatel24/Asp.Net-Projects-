using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Inventory
    {

        public static List<Inventory> InventoryList = new List<Inventory>()
            {
            new Inventory { inventoryId=101,vehicleId = 1,numberOnHand=9,price=220,cost=130 },
            new Inventory { inventoryId=102,vehicleId = 2,numberOnHand=19,price=230,cost=230 },
            new Inventory { inventoryId=103,vehicleId = 3,numberOnHand=5,price=200,cost=150 },
            new Inventory { inventoryId=104,vehicleId = 4,numberOnHand=6,price=270,cost=170 },
            new Inventory { inventoryId=105,vehicleId = 5,numberOnHand=7,price=420,cost=140 }
            };

        public int inventoryId { get; set; }
        public int vehicleId { get; set; }
        public int numberOnHand { get; set; }
        public int price { get; set; }
        public int cost { get; set; }

        public static void getInventorys()
        {
            Console.WriteLine("Press 1 to list all inventory");
            Console.WriteLine("Press 2 to add new inventory");
            Console.WriteLine("Press 3 to update a inventory");
            Console.WriteLine("Press 4 to delete a inventory");
            Console.WriteLine("Press 5 to return to main menu");
            switch (Console.ReadLine())
            {
                case "1":
                    ListInventorys();
                    break;

                case "2":
                    addInventorys();
                    break;

                case "3":
                    updateInventorys();
                    break;

                case "4":
                    deleteInventorys();
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

        public static void ListInventorys()
        {

            Console.WriteLine("List of Inventorys");
            var display = from veh in InventoryList
                          select new { inventoryId = veh.inventoryId,vehicleId = veh.vehicleId,numberOnhand = veh.numberOnHand,price = veh.price,cost = veh.cost};

            foreach (var i in display)
                Console.WriteLine(i);

        }

        public static List<Inventory> addInventorys()
        {
            try
            {
                Console.WriteLine("Insert Inventory Information");
                Console.WriteLine("Enter Inventory Id");
                string inId = Console.ReadLine();
                Console.WriteLine("Enter vehicle Id");
                string vehicleId = Console.ReadLine();
                Console.WriteLine("Enter number on hand");
                string nOnH = Console.ReadLine();
                Console.WriteLine("Enter price");
                string price = Console.ReadLine();
                Console.WriteLine("Enter cost");
                string cost = Console.ReadLine();

                InventoryList.Add(new Inventory()
                {
                    inventoryId = int.Parse(inId),
                    vehicleId = int.Parse(vehicleId),
                    numberOnHand = int.Parse(nOnH),
                    price = int.Parse(price),
                    cost = int.Parse(cost),
                });


                Console.WriteLine("Insert Completed");
                ListInventorys();

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
            return InventoryList;
        }

        public static List<Inventory> updateInventorys()
        {
            try
            {
                Console.WriteLine("Update Vehicle Information");
                ListInventorys();


                Console.WriteLine("Enter Inventory Id that you want to update");
                int inId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new Inventory Id");
                int newInId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new vehicle Id");
                int newId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number on hand");
                int newNOnH = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new price");
                int newPrice = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new cost");
                int newCost = int.Parse(Console.ReadLine());


                var update = from i in InventoryList
                             where i.inventoryId == inId
                             select new { inventoryId = i.inventoryId = newInId, vehicleId = i.vehicleId = newId, numberOnHand = i.numberOnHand = newNOnH, price = i.price = newPrice, cost = i.cost = newCost };
                foreach (var v in update)
                    Console.WriteLine(v);
                Console.WriteLine("List Updated");

                ListInventorys();
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
            return InventoryList;
        }

        public static List<Inventory> deleteInventorys()
        {
            try
            {
                ListInventorys();

                Console.WriteLine("Delete information  using inventory ID");
                Console.WriteLine("Enter Inventroy Id");
                int inId = int.Parse(Console.ReadLine());


                var remove = from i in InventoryList
                             where i.inventoryId != inId
                             select new { i.inventoryId, i.vehicleId, i.numberOnHand, i.price, i.cost };
                foreach (var i in remove)
                    Console.WriteLine(i);
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

            return InventoryList;
        }
    }
}
