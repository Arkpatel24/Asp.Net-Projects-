using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DatabaseDisconnectedModel
{
    class CrudOperationsInDataSet
    {
        // private fields
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;
        private SqlCommandBuilder _cmdBuilder;
        private DataSet _ds;
        private DataTable _tblProducts;

        //constructor
        internal CrudOperationsInDataSet()
        {
            string cs = GetConnectionString("NorthwindSqlServer");
            string query = "Select ProductID, ProductName, UnitPrice, UnitsInStock from Products";

            _conn = new SqlConnection(cs);
            _adapter = new SqlDataAdapter(query, _conn);
            _cmdBuilder = new SqlCommandBuilder(_adapter);

            FillDataSet();
        }

        // method to read the connection string from the JSON file
        private string GetConnectionString(string connectionStringName)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            IConfiguration config = builder.Build();

            return config["ConnectionStrings:" + connectionStringName];
        }

        // method to refresh the dataset
        internal void FillDataSet()
        {
            // reset the dataset
            _ds = new DataSet();

            _adapter.Fill(_ds, "Products");
            _tblProducts = _ds.Tables["Products"];

            // define primary key
            DataColumn[] pk = new DataColumn[1];
            pk[0] = _tblProducts.Columns["ProductID"];
            _tblProducts.PrimaryKey = pk;
        }

        // method to print all the products
        internal void GetAllProducts()
        {
            // display products
            Console.WriteLine("\n\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\n");

            foreach (DataRow row in _tblProducts.Rows)
            {
                Console.WriteLine($"{row["ProductID"],5} {row["ProductName"],-40} {row["UnitPrice"],10} {row["UnitsInStock"],10}");
            }
        }

        // method to print a single product based on its ID
        internal void GetProductById(int id)
        {
            // find a row based on its primary key
            DataRow row = _tblProducts.Rows.Find(id);

            if (row != null)
            {
                Console.WriteLine("\n\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\n");
                Console.WriteLine($"{row["ProductID"],5} {row["ProductName"],-40} {row["UnitPrice"],10} {row["UnitsInStock"],10}");
            }
            else
                Console.WriteLine("\nInvalid Product ID, Please try again.\n");
        }

        internal void InsertProduct(string name, decimal price, short quantity)
        {
            DataRow newRow = _tblProducts.NewRow(); // create a new row
            newRow["ProductID"] = 0;                // add a dummy value to ProductID, 
                                                    // since it'll be overwritten by the SQL Server 
                                                    // because ProductID is set as 
                                                    // Identity (Auto-increment) in the database
            newRow["ProductName"] = name;
            newRow["UnitPrice"] = price;
            newRow["UnitsInStock"] = quantity;

            _tblProducts.Rows.Add(newRow);          // add the new row to the Rows collection

            // read the INSERT query from the SqlCommandBuilder object
            _adapter.InsertCommand = _cmdBuilder.GetInsertCommand();
            _adapter.Update(_tblProducts);          // save the changes to database

            FillDataSet();                          // refresh dataset
        }

        // method to update a product
        internal void UpdateProduct(int id, string name, decimal price, short quantity)
        {
            DataRow row = _tblProducts.Rows.Find(id);

            if (row != null)
            {
                row["ProductName"] = name;
                row["UnitPrice"] = price;
                row["UnitsInStock"] = quantity;

                _adapter.UpdateCommand = _cmdBuilder.GetUpdateCommand();
                _adapter.Update(_tblProducts);

                FillDataSet();
            }
            else
                Console.WriteLine("\nInvalid Product ID. Please try again.");
        }

        // method to delete a product
        internal void DeleteProduct(int id)
        {
            DataRow row = _tblProducts.Rows.Find(id);

            if (row != null)
            {
                row.Delete();

                _adapter.DeleteCommand = _cmdBuilder.GetDeleteCommand();
                _adapter.Update(_tblProducts);

                FillDataSet();
            }
            else
                Console.WriteLine("\nInvalid Product ID. Please try again.");
        }
    }
}
