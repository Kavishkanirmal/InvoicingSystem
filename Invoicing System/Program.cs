using Invoicing_System.Controllers;
using Invoicing_System.Models;

namespace Invoicing_System
{
    internal static class Program
    {
        static void Main(string[] args)
        {

           /* //Add a new product to the database
            var productController = new ProductController();
            var product = new Product()
            {
                ProductId = "TestID11",
                ProductName = "TestName",
                ProductDescription = "TestDesc",
                PurchasePrice = 50,
                SellingPrice = 100,
                Quantity = 10
            };

            productController.AddProduct(product);*/

            
          /*  //List all product details
            var products = productController.GetProducts();

            foreach (var p in products)
            {
                Console.WriteLine($"Product ID: {p.ProductId}");
                Console.WriteLine($"Product Name: {p.ProductName}");
                Console.WriteLine($"Description: {p.ProductDescription}");
                Console.WriteLine($"Buying Price: {p.PurchasePrice}");
                Console.WriteLine($"Selling Price: {p.SellingPrice}");
                Console.WriteLine($"Quantity: {p.Quantity}");
                Console.WriteLine();
            }*/

            
            /*//List single product details
            var products = productController.GetProduct("TestID3");

            if (products != null)
            {
                Console.WriteLine($"Product ID: {products.ProductId}");
                Console.WriteLine($"Product Name: {products.ProductName}");
                Console.WriteLine($"Product Description: {products.ProductDescription}");
                Console.WriteLine($"Purchase Price: {products.PurchasePrice}");
                Console.WriteLine($"Selling Price: {products.SellingPrice}");
                Console.WriteLine($"Quantity: {products.Quantity}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }*/

       /*     //Remove product
            productController.RemoveProduct("TestID10");*/


            /*//Update a product
            var updateProduct = new Product()
            {
                ProductId = "TestID",
                ProductName = "TestUpdate",
                ProductDescription = "TestDescUpdate",
                PurchasePrice = 25,
                SellingPrice = 50,
                Quantity = 5
            };

            productController.UpdateProduct(updateProduct);*/


          /*  //Add a new customer to the database
            var customerController = new CustomerController();
            var customer = new Customer()
            {
                CustomerId = "TestID2",
                CustomerName = "TestName",
                Email = "TestMail",
                Address = "TestAddr",
                ContactNo = "0771177117",
                DateOfBirth = "05-10-1999",
                Gender = "Male"
            };

            customerController.AddCustomer(customer);*/
            

          /* //List all customer details
           var customers = customerController.GetCustomers();

           foreach (var c in customers)
           {
               Console.WriteLine($"Customer ID: {c.CustomerId}");
               Console.WriteLine($"Customer Name: {c.CustomerName}");
               Console.WriteLine($"Email: {c.Email}");
               Console.WriteLine($"Address: {c.Address}");
               Console.WriteLine($"Contact NO: {c.ContactNo}");
               Console.WriteLine($"DateOfBirth: {c.DateOfBirth}");
               Console.WriteLine($"Gender: {c.Gender}");
               Console.WriteLine();
           }*/


        /*  //List single customer details
          var customer = customerController.GetCustomer("TestID");

          if (customer != null)
          {
               Console.WriteLine($"Customer ID: {customer.CustomerId}");
               Console.WriteLine($"Customer Name: {customer.CustomerName}");
               Console.WriteLine($"Email: {customer.Email}");
               Console.WriteLine($"Address: {customer.Address}");
               Console.WriteLine($"Contact NO: {customer.ContactNo}");
               Console.WriteLine($"DateOfBirth: {customer.DateOfBirth}");
               Console.WriteLine($"Gender: {customer.Gender}");
               Console.WriteLine();
          }
          else
          {
               Console.WriteLine("Product not found.");
          }*/
            
   /*       //Remove customer
          customerController.RemoveCustomer("TestID2");

          //Update a customer
          var updateCustomer = new Customer()
          {  
              CustomerId = "TestID",
              CustomerName = "TestUpdate",
              Email = "TestDescUpdate",
              Address = "UpdateAddr",
              ContactNo = "0123456789",
              DateOfBirth = "01-12-2000",
              Gender = "female"
          };

          customerController.UpdateCustomer(updateCustomer);*/


        }
    }
}