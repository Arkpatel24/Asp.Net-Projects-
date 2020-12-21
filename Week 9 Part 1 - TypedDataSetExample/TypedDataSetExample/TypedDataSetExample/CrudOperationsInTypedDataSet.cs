using System;
using System.Collections.Generic;
using System.Text;

namespace TypedDataSetExample
{
    public class CrudOperationsInTypedDataSet
    {
        // private fields
        private NorthwindDataSetTableAdapters.ProductsTableAdapter _adpProducts;
        private NorthwindDataSet.ProductsDataTable _tblProducts;

        // constructor
        public CrudOperationsInTypedDataSet()
        {
            _adpProducts = new NorthwindDataSetTableAdapters.ProductsTableAdapter();
            _tblProducts = new NorthwindDataSet.ProductsDataTable();
        }

        // method to print all the products
        public void GetAllProducts()
        {
            // using Fill() method
            //_adpProducts.FillProducts(_tblProducts);

            // using Get() method
            _tblProducts = _adpProducts.GetProducts();

            // display products
            Console.WriteLine("\n\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\n");
            foreach (var row in _tblProducts)
            {
                Console.WriteLine($"{row.ProductID,5} {row.ProductName,-40} {row.UnitPrice,10} {row.UnitsInStock,10}");
            }
        }

        // method to print a single product based on its ID
        public void GetProductById(int id)
        {
            _tblProducts = _adpProducts.GetProducts();

            // find a row based on its primary key
            var row = _tblProducts.FindByProductID(id);

            if (row != null)
            {
                Console.WriteLine("\n\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\n");
                Console.WriteLine($"{row.ProductID,5} {row.ProductName,-40} {row.UnitPrice,10} {row.UnitsInStock,10}");
            }
            else
                Console.WriteLine("Invalid Product ID. Please try again.");
        }

        // method to get a product by name
        public void GetProductByName(string name)
        {
            _tblProducts = _adpProducts.GetProductByName(name);

            if (_tblProducts.Count > 0)
            {
                var row = _tblProducts[0];  // read the fetched row

                Console.WriteLine("\n\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\n");
                Console.WriteLine($"{row.ProductID,5} {row.ProductName,-40} {row.UnitPrice,10} {row.UnitsInStock,10}");
            }
            else
                Console.WriteLine("Invalid Product Name. Please try again.");
        }

        // method to insert a new product
        public void InsertProduct(string name, decimal price, short quantity)
        {
            _adpProducts.Insert(name, price, quantity);
        }

        // method to update a product
        public void UpdateProduct(int id, string name, decimal price, short quantity)
        {
            _adpProducts.Update(name, price, quantity, id);
        }

        // method to delete a product
        public void DeleteProduct(int id)
        {
            _adpProducts.Delete(id);
        }
    }
}
