using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

namespace DatabaseConnectedModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connected Model Examples

            PrintEmployees();
            //GetEmployeeByName();
            //CountTableRows();
            //InsertEmployee("John", "Smith");
        }


        // method to print all the employees
        static void PrintEmployees()
        {
            string cs = GetConnectionString("NorthwindSqlServer");
            string query = "Select EmployeeID, FirstName, LastName, BirthDate from Employees";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["EmployeeID"]; // either this
                    //int id = reader.GetInt32(0);      // or this
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];

                    // check if cell has null value
                    DateTime? birthDate = (reader.IsDBNull(3)) ? null : (DateTime?)reader["BirthDate"];

                    Console.WriteLine($"{id,5} {firstName,-15} {lastName,-15} {birthDate,10}");
                }
            }
        }


        // method to get an employee by name
        static void GetEmployeeByName()
        {
            Console.Write("Enter employee's first name: ");
            string fname = Console.ReadLine();

            string cs = GetConnectionString("NorthwindSqlServer");

            // parameterized query
            string query = "Select EmployeeID, FirstName, LastName, BirthDate from Employees " +
                "Where FirstName = @FirstName";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("FirstName", fname);    // add value for parameter

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["EmployeeID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    DateTime birthDate = (DateTime)reader["BirthDate"];

                    Console.WriteLine($"{id,5} {firstName,-15} {lastName,-15} {birthDate,10}");
                }
            }
        }


        // ExecuteScalar() example
        static void CountTableRows()
        {
            string cs = GetConnectionString("NorthwindSqlServer");
            string query = "Select Count(*) from Employees";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                int numOfRows = (int)cmd.ExecuteScalar();

                Console.WriteLine("Number of rows: " + numOfRows);
            }
        }


        // ExecuteNonQuery example
        static void InsertEmployee(string firstName, string lastName)
        {
            string cs = GetConnectionString("NorthwindSqlServer");
            string query = "Insert into Employees (FirstName, LastName) values (@FirstName, @LastName)";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("FirstName", firstName);
                cmd.Parameters.AddWithValue("LastName", lastName);
                conn.Open();

                int result = cmd.ExecuteNonQuery();

                if (result == 1)
                    Console.WriteLine("Employee inserted");
                else
                    Console.WriteLine("Employee not inserted");
            }
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
