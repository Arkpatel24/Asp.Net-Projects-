using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEFArkPatel
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
            Console.WriteLine("1 - View all Authors");
            Console.WriteLine("2 - Add Author Detail ");
            Console.WriteLine("3 - Update Author Detail");
            Console.WriteLine("4 - Exit");
            Console.WriteLine("Choose your option :");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Program.ViewAuthor();
                    return true;
                case "2":
                    Console.Clear();
                    Program.AddAuthor();
                    return true;
                case "3":
                    Console.Clear();
                    Program.UpdateAuthor();
                    return true;
                case "4":
                    Environment.Exit(-1);
                    return false;
                default:
                    return true;
            }
        }

        static void ViewAuthor()
        {
            using (var context = new BookDatabaseEntities())
            {
                var query = (from au in context.Authors
                             select au);
                Console.WriteLine($"{"AuthorID",-10} {"FirstName",-16} {"LastName",-18} {"PhoneNo",-13}  {"Address ",-20} {"City",-12} {"State",8}");

                foreach (var au in query)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{au.AuthorID,-12}{au.FirstName,-17}{au.LastName,-17 }{au.Phone,-15}{au.Address,-22}{au.City,-17 }{au.State,-3}");
                }
                Console.ReadKey();
            }
        }

        static void AddAuthor()
        {
            string firstName, lastName, phoneNo,address, city, state;
            try
            {
                using (var context = new BookDatabaseEntities())
                {
                    Console.WriteLine("Enter author first name:");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Enter author last name:");
                    lastName = Console.ReadLine();
                    Console.WriteLine("Enter author phone number:");
                    phoneNo = Console.ReadLine();
                    Console.WriteLine("Enter author address:");
                    address = Console.ReadLine();
                    Console.WriteLine("Enter author city");
                    city = Console.ReadLine();
                    Console.WriteLine("Enter auhtor state");
                    state = Console.ReadLine();

                    var au = new Author();
                    au.FirstName = firstName;
                    au.LastName = lastName;
                    au.Phone = phoneNo;
                    au.Address = address;
                    au.City = city;
                    au.State = state;

                    context.Authors.Add(au);
                    context.SaveChanges();
                    Console.WriteLine("Author Detial Successfully Added");
                    Console.WriteLine("");
                    ViewAuthor();
                    Console.ReadKey();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    $"Unexpected error:  { exception.Message }");
                Console.ReadKey();
            }
            finally
            {
                Console.WriteLine("goodbye");
            }
        } 

        static void UpdateAuthor()
        {
            int authorID;
            string newfirstName, newlastName, newphoneNo, newAddress, newCity, newState;
            try
            {
                using (var context = new BookDatabaseEntities())
                {
                    Console.WriteLine("Enter author id to change auhtor detail:");
                    authorID = Int32.Parse(Console.ReadLine());
                    var au = context.Authors.Find(authorID);
                    Console.WriteLine("Enter new author first name:");
                    newfirstName = Console.ReadLine();
                    Console.WriteLine("Enter new author last name:");
                    newlastName = Console.ReadLine();
                    Console.WriteLine("Enter new author phone number:");
                    newphoneNo = Console.ReadLine();
                    Console.WriteLine("Enter new author address:");
                    newAddress = Console.ReadLine();
                    Console.WriteLine("Enter new author city:");
                    newCity = Console.ReadLine();
                    Console.WriteLine("Enter new author state:");
                    newState = Console.ReadLine();

                    au.FirstName = newfirstName;
                    au.LastName = newlastName;
                    au.Phone = newphoneNo;
                    au.Address = newAddress;
                    au.City = newCity;
                    au.State = newState;

                    context.SaveChanges();
                    Console.WriteLine("Author detail Successfully updated");
                    Console.WriteLine("");
                    ViewAuthor();
                    Console.ReadKey();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    $"Unexpected error:  { exception.Message }");
                Console.ReadKey();
            }
            finally
            {
                Console.WriteLine("goodbye");
            }
        }

    }
}
