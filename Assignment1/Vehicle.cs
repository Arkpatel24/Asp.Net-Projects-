using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Vehicle
    {
        public static List<Vehicle> vehicleList = new List<Vehicle>()
            {
            new Vehicle { vehicleId = 1, Make = "Audi", Model = "UV", Year = "2019", newCar = "yes" },
            new Vehicle { vehicleId = 2, Make = "Audi", Model = "VX", Year = "2018", newCar = "yes" },
            new Vehicle { vehicleId = 3, Make = "Mercedes", Model = "SUV", Year = "2012", newCar = "yes" },
            new Vehicle { vehicleId = 4, Make = "Honda", Model = "ZX", Year = "2013", newCar = "no" },
            new Vehicle { vehicleId = 5, Make = "Toyota", Model = "QY", Year = "2011", newCar = "no" }
            };

        public int vehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string newCar { get; set; }

      

        public static void getVehicles()
        {        

            Console.WriteLine("Press 1 to list all vehicles");
            Console.WriteLine("Press 2 to add new vehicle");
            Console.WriteLine("Press 3 to update a vehicle");
            Console.WriteLine("Press 4 to delete a vehicle");
            Console.WriteLine("Press 5 to return to main menu");

            switch (Console.ReadLine())
            {
                case "1":
                    ListVehicles();
                    break;

                case "2":
                    addVehicles();
                    break;

                case "3":
                    updateVehicles();
                    break;

                case "4":
                    deleteVehicles();
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

        public static void ListVehicles()
        {

            Console.WriteLine("List of Vehicles");
            var display = from veh in vehicleList
                          select new { vehicleId = veh.vehicleId, Make = veh.Make, Model = veh.Model, Year = veh.Year, newCar = veh.newCar };
            
            foreach (var v in display)
                Console.WriteLine(v);

        }

        public static List<Vehicle> addVehicles()
        {
            int vehid;
            string vehmake, vehmodel, vehyear, vehusedcar;
           
            try
            {
                Console.WriteLine("Insert Vehicle Information");
                Console.WriteLine("Enter vehicle Id");
                vehid = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter vehicle make");
                do
                {
                    vehmake = Console.ReadLine();
                    if (String.IsNullOrEmpty(vehmake))
                    {
                        Console.WriteLine("Invalid input,You must enter value");
                        Console.WriteLine("Enter vehicle make: ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                Console.WriteLine("Enter vehicle model");
                do 
                {
                vehmodel = Console.ReadLine();
                    if (String.IsNullOrEmpty(vehmodel))
                    {
                        Console.WriteLine("Invalid input,You must enter value");
                        Console.WriteLine("Enter vehicle model: ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                Console.WriteLine("Enter vehicle year");
                do 
                { 
                vehyear = Console.ReadLine();
                    if (String.IsNullOrEmpty(vehyear))
                    {
                        Console.WriteLine("Invalid input,You must enter value");
                        Console.WriteLine("Enter vehicle year: ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                Console.WriteLine("Enter vehicle usedcar[yes/no]");
                do
                { 
                vehusedcar = Console.ReadLine();
                    if (String.IsNullOrEmpty(vehusedcar))
                    {
                        Console.WriteLine("Invalid input,You must enter value");
                        Console.WriteLine("Enter vehicle usedcar[yes/no]: ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                vehicleList.Add(new Vehicle()
                {
                    vehicleId = vehid,
                    Make = vehmake,
                    Model = vehmodel,
                    Year = vehyear,
                    newCar = vehusedcar
                });


                Console.WriteLine("Insert Completed");
                ListVehicles();

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
            return vehicleList;

        }
        public static List<Vehicle> updateVehicles()
        {
            int vehid, newId;
            string newMake, newModel, newYear, newusedCar;

            try
            {
                Console.WriteLine("Update Vehicle Information");
                ListVehicles();


                Console.WriteLine("Enter vehicle Id that you want to update");
                vehid = int.Parse(Console.ReadLine());


                Console.WriteLine("Enter new vehicle ID");
                newId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new vehicle make");
                do 
                { 
                newMake = Console.ReadLine();
                    if (String.IsNullOrEmpty(newMake))
                    {
                        Console.WriteLine("Invalid input,You must enter value");
                        Console.WriteLine("Enter new vehicle make: ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                Console.WriteLine("Enter new vehicle model");
                do 
                { 
                newModel = Console.ReadLine();
                    if (String.IsNullOrEmpty(newModel))
                    {
                        Console.WriteLine("Invalid input,You must enter value");
                        Console.WriteLine("Enter new vehicle Model: ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                Console.WriteLine("Enter new vehicle year");
                do 
                { 
                newYear = Console.ReadLine();
                    if (String.IsNullOrEmpty(newYear))
                    {
                        Console.WriteLine("Invalid input,You must enter value");
                        Console.WriteLine("Enter new vehicle Year: ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                Console.WriteLine("Enter new vehicle usedcar[yes/no]");
                do 
                {
                newusedCar = Console.ReadLine();
                    if (String.IsNullOrEmpty(newusedCar))
                    {
                        Console.WriteLine("Invalid input,You must enter value");
                        Console.WriteLine("Enter new vehicle usedcar[yes/no] ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                var update = from u in vehicleList
                             where u.vehicleId == vehid
                             select new { VehicleId = u.vehicleId = newId, make = u.Make = newMake, model = u.Model = newModel, year = u.Year = newYear, Newcar = u.newCar = newusedCar };
                foreach (var v in update)
                    Console.WriteLine(v);

                Console.WriteLine("List Updated");
                ListVehicles();
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
            return vehicleList;
        }
        public static List<Vehicle> deleteVehicles()
        {
            int vehid;
            try
            {
                ListVehicles();

                Console.WriteLine("Delete information using vehicle ID");
                Console.WriteLine("Enter vehicle Id");
                vehid = int.Parse(Console.ReadLine());

                var remove = from r in vehicleList
                             where r.vehicleId != vehid
                             select new { r.vehicleId, r.Make, r.Model, r.Year, r.newCar };
                foreach (var v in remove)
                    Console.WriteLine(v);
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
            return vehicleList;
        }

    }
}
