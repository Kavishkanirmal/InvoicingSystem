using Invoicing_System.Controllers;
using Invoicing_System.Models;

namespace Invoicing_System
{
    internal static class Program
    {
        static void Main(string[] args)
        {

            
            /*----- Starting Menu -----*/
            Console.WriteLine(" 1. Manage Products");
            Console.WriteLine(" 2. Manage Customers");
            Console.WriteLine(" 3. Invoice Generation");
            Console.WriteLine(" 4. Admin Tasks");
            Console.Write(" Enter the service you want: ");
            string? serviceInput = Console.ReadLine();
            int.TryParse(serviceInput, out int service);
            Console.WriteLine();

            if (service==1)
            {
                /*----- Menu for the products -----*/
                Console.WriteLine(" 1. Add Products");
                Console.WriteLine(" 2. Search for a specific Product");
                Console.WriteLine(" 3. List all Products");
                Console.WriteLine(" 4. Remove Products");
                Console.WriteLine(" 5. Update Products");
                Console.Write(" Enter the service you want: ");
                string? pServiceInput = Console.ReadLine();
                int.TryParse(pServiceInput, out int pService);
                Console.WriteLine();


                if(pService==1)
                {

                    //Add a new product to the database
                    var productController = new ProductController();
                    var product = new Product()
                    {
                        ProductId = "TestID10",
                        ProductName = "TestName",
                        ProductDescription = "TestDesc",
                        PurchasePrice = 50,
                        SellingPrice = 100,
                        Quantity = 10
                    };

                    productController.AddProduct(product);

                }
                else if(pService==2)
                {

                    //List a specific product's details
                    var productController = new ProductController();
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
                    }

                }
                else if(pService==3)
                {

                    //List all product details
                    var productController = new ProductController();
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
                    }

                }
                else if (pService == 4)
                {

                    //Remove product
                    var productController = new ProductController();
                    productController.RemoveProduct("TestID10");

                }
                else if (pService == 5)
                {

                    //Update a product
                    var productController = new ProductController();
                    var updateProduct = new Product()
                    {
                        ProductId = "TestID",
                        ProductName = "TestUpdate",
                        ProductDescription = "TestDescUpdate",
                        PurchasePrice = 25,
                        SellingPrice = 50,
                        Quantity = 5
                    };

                    productController.UpdateProduct(updateProduct);

                }

            }//Main menu if condition (Products)
            else if(service==2)
            {
                /*----- Menu for the customer ------*/
                Console.WriteLine(" 1. Add Customers");
                Console.WriteLine(" 2. Search for a specific Customer");
                Console.WriteLine(" 3. List all Customers");
                Console.WriteLine(" 4. Remove Customers");
                Console.WriteLine(" 5. Update Customers");
                Console.Write(" Enter the service you want: ");
                string? cServiceInput = Console.ReadLine();
                int.TryParse(cServiceInput, out int cService);
                Console.WriteLine();

                if(cService == 1)
                {

                    //Add a new customer to the database
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

                    customerController.AddCustomer(customer);

                }
                else if(cService == 2)
                {

                    //List specific customer's details
                    var customerController = new CustomerController();
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
                    }

                }
                else if(cService == 3)
                {

                    //List all customer details
                    var customerController = new CustomerController();
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
                    }

                }
                else if(cService == 4)
                {

                    //Remove customer
                    var customerController = new CustomerController();
                    customerController.RemoveCustomer("TestID2");

                }
                else if(cService == 5)
                {

                    //Update a customer
                    var customerController = new CustomerController();
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

                    customerController.UpdateCustomer(updateCustomer);

                }

            }//Main menu if condition (Customers)
            else if (service == 3)
            {

                var productController = new ProductController();
                var product = productController.GetProduct("TestID");

                if (product != null)
                {
                    int requestedQty = 2;

                    if(product.Quantity > requestedQty)
                    {

                        //Add a new invoice to the database
                        var invoiceController = new InvoiceController();
                        var invoice = new Invoice()
                        {
                            InvoiceNumber = 002,
                            InvoiceDate = "2023-07-11",
                            CustomerName = "TestName",
                            ProductNames = "TestName",
                            UnitsPerProduct = 10,
                            UnitPricePerProduct = 10,
                            TotalPricePerProduct = 100,
                            DiscountPerProduct = 10
                        };

                        invoiceController.AddInvoice(invoice);


                        //List a specific invoice's details
                        var listInvoice = invoiceController.GetInvoice(002);

                        if (listInvoice != null)
                        {
                            Console.WriteLine($"Invoice Number: {invoice.InvoiceNumber}");
                            Console.WriteLine($"Invoice Date: {invoice.InvoiceDate}");
                            Console.WriteLine($"Customer Name: {invoice.CustomerName}");
                            Console.WriteLine($"Product Names: {invoice.ProductNames}");
                            Console.WriteLine($"Units Per Product: {invoice.UnitsPerProduct}");
                            Console.WriteLine($"Unit Price Per Product: {invoice.UnitPricePerProduct}");
                            Console.WriteLine($"Total Price Per Product: {invoice.TotalPricePerProduct}");
                            Console.WriteLine($"Discount Per Product: {invoice.DiscountPerProduct}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("No Invoices found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Insufficient products!");
                    }
                }
                else
                {
                    Console.WriteLine("No products found!");
                }

            }//Main menu if condition (Invoice)




        }
    }
}