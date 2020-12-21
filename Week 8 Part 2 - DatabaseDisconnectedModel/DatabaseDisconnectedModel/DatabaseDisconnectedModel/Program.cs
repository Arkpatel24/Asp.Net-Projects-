using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DatabaseDisconnectedModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Disconnected Model Examples

            //PrintProducts();
            //DataSetWithMultipleTables();



            // CRUD operations example

            CrudOperationsInDataSet crud = new CrudOperationsInDataSet();

            do
            {
                int choice = DisplayMenu();

                switch (choice)
                {
                    case 1: // Get All Products
                        crud.GetAllProducts();
                        break;

                    case 2: // Get Product by ID
                        Console.Write("\nEnter Product ID: ");
                        int id = int.Parse(Console.ReadLine());
                        crud.GetProductById(id);
                        break;

                    case 3: // Insert Product
                        Console.Write("\nEnter Product Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Product Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Product Quantity: ");
                        short quantity = short.Parse(Console.ReadLine());

                        crud.InsertProduct(name, price, quantity);
                        break;

                    case 4: // Update Product
                        Console.Write("\nEnter Product Id: ");
                        id = int.Parse(Console.ReadLine());
                        crud.GetProductById(id);

                        Console.Write("\nEnter Product Name: ");
                        name = Console.ReadLine();

                        Console.Write("Enter Product Price: ");
                        price = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Product Quantity: ");
                        quantity = short.Parse(Console.ReadLine());

                        crud.UpdateProduct(id, name, price, quantity);
                        break;

                    case 5: // Delete Product
                        Console.Write("\nEnter Product Id: ");
                        id = int.Parse(Console.ReadLine());

                        crud.DeleteProduct(id);
                        break;

                    case 6: // Exit
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }


        // method to print all the products
        static void PrintProducts()
        {
            string cs = GetConnectionString("NorthwindSqlServer");
            string query = "Select ProductID, ProductName, UnitPrice, UnitsInStock from Products";

            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Products");
            DataTable tblProducts = ds.Tables["Products"];

            foreach (DataRow row in tblProducts.Rows)
            {
                Console.WriteLine($"{row["ProductID"],5} {row["ProductName"],-40} {row["UnitPrice"],10} {row["UnitsInStock"],10}");
            }
        }


        // method to demonstrate dataset having multiple tables
        static void DataSetWithMultipleTables()
        {
            string cs = GetConnectionString("NorthwindSqlServer");

            // two select queries
            string query = "Select * from Categories; Select * from Products";

            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            // give meaningful names to tables inside dataset
            ds.Tables[0].TableName = "Categories";
            ds.Tables[1].TableName = "Products";

            DataTable tblCategories = ds.Tables[0];
            DataTable tblProducts = ds.Tables[1];

            Console.WriteLine("Categories Table:\n");
            foreach (DataRow row in tblCategories.Rows)
            {
                Console.WriteLine($"{row["CategoryID"],5} {row["CategoryName"],-40}");
            }

            Console.WriteLine("\n\nProducts Table:\n");
            foreach (DataRow row in tblProducts.Rows)
            {
                Console.WriteLine($"{row["ProductID"],5} {row["ProductName"],-40}");
            }
        }


        // method to display the menu for CRUD operations example
        static int DisplayMenu()
        {
            Console.WriteLine("\n\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\n");
            Console.WriteLine("\t1 - Get all Products");
            Console.WriteLine("\t2 - Get Product by ID");
            Console.WriteLine("\t3 - Insert Product");
            Console.WriteLine("\t4 - Update Product");
            Console.WriteLine("\t5 - Delete Product");
            Console.WriteLine("\t6 - Exit");

            Console.Write("\nEnter your choice: ");
            return int.Parse(Console.ReadLine());
        }


        // method to read the connection string from the JSON file
        static string GetConnectionString(string connectionStringName)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            IConfiguration config = builder.Build();

            return config["ConnectionStrings:" + connectionStringName];
        }
    }
}
