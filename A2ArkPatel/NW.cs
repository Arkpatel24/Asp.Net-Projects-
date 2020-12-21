using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace A2ArkPatel
{
    class NW
    {
        static string GetConnectionString()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("connect_config.json");
            IConfiguration config = configurationBuilder.Build();
            return config["ConnectionStrings:NorthWindLocalDB"];
        }

        public static void ViewProduct()
        {
            string cs = GetConnectionString();
            SqlConnection conn = new SqlConnection(cs);
            string query = "select ProductID,ProductName,CategoryName,CompanyName  from Products  inner join" +
                " Categories  on Categories.CategoryID = Products.CategoryID inner join Suppliers  on Suppliers.SupplierID = Products.SupplierID";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine($"{"Product ID",9} {"Product Name",-33} {"Category Name",-28} {"Company Name",-18}");
            
            while (reader.Read())
            {
                int pro_ID = (int)reader["ProductID"];
                string pro_Name = (string)reader["ProductName"];
                string cat_Name = (string)reader["CategoryName"];
                string comp_Name = (string)reader["CompanyName"];
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine($"{pro_ID,9} {pro_Name,-33} {cat_Name,-28} {comp_Name,-18}");
            }
            Console.ReadKey();
        }
        public static void ViewCategory()
        {
            string cs = GetConnectionString();
            SqlConnection conn = new SqlConnection(cs);
            string query = "select CategoryID, CategoryName from Categories";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine($"{"Category ID",6} {"Category Name",22}");
            
            while (reader.Read())
            {
                int cat_ID = (int)reader["CategoryID"];
                string cat_Name = (string)reader["CategoryName"];
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine($"{cat_ID,-22} {cat_Name,-10}");
            }
            Console.ReadKey();
        }
        public static void ViewSuppliers()
        {
            string cs = GetConnectionString();
            SqlConnection conn = new SqlConnection(cs);
            string query = "select SupplierID, CompanyName from Suppliers";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine($"{"Supplier ID",6} {"Supplier Name",22}");
          
            while (reader.Read())
            {
                int sup_ID = (int)reader["SupplierID"];
                string comp_Name = (string)reader["CompanyName"];
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"{sup_ID,-20} {comp_Name,-10}");
            }
            Console.ReadKey();
        }
        public static void ViewProdByCatID()
        {
            Console.WriteLine("Enter Category ID:");
            string cat_ID = Console.ReadLine();
            string cs = GetConnectionString();
            SqlConnection conn = new SqlConnection(cs);
            string query = "select ProductID,ProductName,CategoryName," + "CompanyName from Products inner join Categories " +
                "on Categories.CategoryID=Products.CategoryID inner join Suppliers  on " + "Suppliers.SupplierID=Products.SupplierID where Categories.CategoryID=@CategoryID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("CategoryID", cat_ID);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int pro_ID = (int)reader["ProductID"];
                string pro_Name = (string)reader["ProductName"];
                string cat_Name = (string)reader["CategoryName"];
                string comp_Name = (string)reader["CompanyName"];
                Console.WriteLine("------------------------------------------------------------------------------------------");
                Console.WriteLine($"{pro_ID,10} {pro_Name,-35} {cat_Name,-20} {comp_Name,-15}");
            }
            Console.ReadKey();
        }
        public static void ViewProdBySupID()
        {

            Console.WriteLine("Enter Supplier ID:");
            string sup_ID = Console.ReadLine();
            string cs = GetConnectionString();
            SqlConnection conn = new SqlConnection(cs);
            string query = "select ProductID,ProductName,CategoryName," + "CompanyName from Products inner join Categories " +
                "on Categories.CategoryID=Products.CategoryID inner join Suppliers on " + "Suppliers.SupplierID=Products.SupplierID where Suppliers.SupplierID=@SupplierID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("SupplierID", sup_ID);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int pro_ID = (int)reader["ProductID"];
                string pro_Name = (string)reader["ProductName"];
                string cat_Name = (string)reader["CategoryName"];
                string comp_Name = (string)reader["CompanyName"];
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine($"{pro_ID,10} {pro_Name,-35} {cat_Name,-20} {comp_Name,-15}");
            }
            Console.ReadKey();
        }
    }
}
