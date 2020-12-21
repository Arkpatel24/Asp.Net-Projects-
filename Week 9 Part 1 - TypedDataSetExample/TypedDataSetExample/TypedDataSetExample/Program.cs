using System;

namespace TypedDataSetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            CrudOperationsInTypedDataSet crud = new CrudOperationsInTypedDataSet();

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

                    case 3: // Get Product by Name
                        Console.Write("\nEnter Product Name: ");
                        string name = Console.ReadLine();

                        crud.GetProductByName(name);
                        break;

                    case 4: // Insert Product
                        Console.Write("\nEnter Product Name: ");
                        name = Console.ReadLine();

                        Console.Write("Enter Product Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Product Quantity: ");
                        short quantity = short.Parse(Console.ReadLine());

                        crud.InsertProduct(name, price, quantity);
                        break;

                    case 5: // Update Product
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

                    case 6: // Delete Product
                        Console.Write("\nEnter Product Id: ");
                        id = int.Parse(Console.ReadLine());

                        crud.DeleteProduct(id);
                        break;

                    case 7: // Exit
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }

        static int DisplayMenu()
        {
            Console.WriteLine("\n\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\n");
            Console.WriteLine("\t1 - Get all Products");
            Console.WriteLine("\t2 - Get Product by ID");
            Console.WriteLine("\t3 - Get Product by Name");
            Console.WriteLine("\t4 - Insert Product");
            Console.WriteLine("\t5 - Update Product");
            Console.WriteLine("\t6 - Delete Product");
            Console.WriteLine("\t7 - Exit");

            Console.Write("\nEnter your choice: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
