using Invoicing_System.Controllers;
using Invoicing_System.Models;

namespace Invoicing_System
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            bool exitFalg = false;

            while (!exitFalg)
            {

                /*----- Starting Menu -----*/
                Console.WriteLine(" 1. Manage Products");
                Console.WriteLine(" 2. Manage Customers");
                Console.WriteLine(" 3. Invoice Generation");
                Console.WriteLine(" 4. Admin Tasks");
                Console.WriteLine(" 5. Exit");
                Console.Write(" Enter the service you want: ");
                string? serviceInput = Console.ReadLine();
                int.TryParse(serviceInput, out int service);
                Console.WriteLine();

                if (service == 1)
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


                    if (pService == 1)
                    {

                        //Add a new product to the database
                        var productController = new ProductController();
                        var product = new Product();

                        Console.WriteLine("Enter the Product ID: ");
                        product.ProductId = Console.ReadLine();

                        Console.WriteLine("Enter the Product Name: ");
                        product.ProductName = Console.ReadLine();

                        Console.WriteLine("Enter the Product Description: ");
                        product.ProductDescription = Console.ReadLine();

                        Console.WriteLine("Enter the Purchase Price: ");
                        product.PurchasePrice = (float)Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Enter the Selling Price: ");
                        product.SellingPrice = (float)Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Enter the Quantity: ");
                        product.Quantity = Convert.ToInt32(Console.ReadLine());

                        productController.AddProduct(product);

                    }
                    else if (pService == 2)
                    {

                        //List a specific product's details
                        var productController = new ProductController();
                        Console.WriteLine("Enter the product ID: ");
                        string? productId = Console.ReadLine();

                        if (!string.IsNullOrEmpty(productId))
                        {
                            var products = productController.GetProduct(productId);

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
                                Console.WriteLine("Product not found!");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Enter a valid product ID");
                        }

                    }
                    else if (pService == 3)
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

                        Console.WriteLine("Enter the product ID: ");
                        string? productId = Console.ReadLine();
                        if (!string.IsNullOrEmpty(productId))
                        {
                            productController.RemoveProduct(productId);
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid product ID");
                        }

                    }
                    else if (pService == 5)
                    {

                        //Update a product
                        var productController = new ProductController();
                        var updateProduct = new Product();

                        Console.WriteLine("Enter the product ID: ");
                        updateProduct.ProductId = Console.ReadLine();

                        Console.WriteLine("Enter the product name: ");
                        updateProduct.ProductName = Console.ReadLine();

                        Console.WriteLine("Enter the product description: ");
                        updateProduct.ProductDescription = Console.ReadLine();

                        Console.WriteLine("Enter the purchase price: ");
                        updateProduct.PurchasePrice = (float)Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Enter the selling price: ");
                        updateProduct.SellingPrice = (float)Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Enter the quantity: ");
                        updateProduct.Quantity = Convert.ToInt32(Console.ReadLine());

                        productController.UpdateProduct(updateProduct);

                    }

                }//Main menu if condition (Products)
                else if (service == 2)
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

                    if (cService == 1)
                    {

                        //Add a new customer to the database
                        var customerController = new CustomerController();
                        var customer = new Customer();

                        Console.WriteLine("Enter Customer ID: ");
                        customer.CustomerId = Console.ReadLine();

                        Console.WriteLine("Enter Customer Name: ");
                        customer.CustomerName = Console.ReadLine();

                        Console.WriteLine("Enter Email: ");
                        customer.Email = Console.ReadLine();

                        Console.WriteLine("Enter Address: ");
                        customer.Address = Console.ReadLine();

                        Console.WriteLine("Enter Contact No: ");
                        customer.ContactNo = Console.ReadLine();

                        Console.WriteLine("Enter Date of Birth (MM-DD-YYYY): ");
                        customer.DateOfBirth = Console.ReadLine();

                        Console.WriteLine("Enter Gender: ");
                        customer.Gender = Console.ReadLine();

                        customerController.AddCustomer(customer);

                    }
                    else if (cService == 2)
                    {

                        //List specific customer's details
                        var customerController = new CustomerController();
                        Console.WriteLine("Enter the customer ID ");
                        string? customerId = Console.ReadLine();

                        if (!string.IsNullOrEmpty(customerId))
                        {
                            var customer = customerController.GetCustomer(customerId);

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
                                Console.WriteLine("Customer not found!");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Enter a valid customer ID");
                        }

                    }
                    else if (cService == 3)
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
                    else if (cService == 4)
                    {

                        //Remove customer
                        var customerController = new CustomerController();
                        Console.WriteLine("Enter the customer ID ");
                        string? customerId = Console.ReadLine();

                        if (!string.IsNullOrEmpty(customerId))
                        {
                            customerController.RemoveCustomer(customerId);
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid customer ID");
                        }

                    }
                    else if (cService == 5)
                    {

                        //Update a customer
                        var customerController = new CustomerController();
                        var updateCustomer = new Customer();

                        Console.WriteLine("Enter Customer ID: ");
                        updateCustomer.CustomerId = Console.ReadLine();

                        Console.WriteLine("Enter Customer Name: ");
                        updateCustomer.CustomerName = Console.ReadLine();

                        Console.WriteLine("Enter Email: ");
                        updateCustomer.Email = Console.ReadLine();

                        Console.WriteLine("Enter Address: ");
                        updateCustomer.Address = Console.ReadLine();

                        Console.WriteLine("Enter Contact No: ");
                        updateCustomer.ContactNo = Console.ReadLine();

                        Console.WriteLine("Enter Date of Birth: ");
                        updateCustomer.DateOfBirth = Console.ReadLine();

                        Console.WriteLine("Enter Gender: ");
                        updateCustomer.Gender = Console.ReadLine();

                        customerController.UpdateCustomer(updateCustomer);

                    }

                }//Main menu if condition (Customers)
                else if (service == 3)
                {
                    /*----- Menu for the Invoices ------*/
                    Console.WriteLine(" 1. Generate an invoice");
                    Console.WriteLine(" 2. Search for invoices by date & customer");
                    string? iServiceInput = Console.ReadLine();
                    int.TryParse(iServiceInput, out int iService);
                    Console.WriteLine();

                    if (iService == 1)
                    {

                        var productController = new ProductController();
                        Console.WriteLine("Enter the corresponding product ID: ");
                        string? productId = Console.ReadLine();

                        if (!string.IsNullOrEmpty(productId))
                        {

                            var product = productController.GetProduct(productId);

                            if (product != null)
                            {
                                Console.WriteLine("Enter the required quantity: ");
                                string? qtyInput = Console.ReadLine();
                                int.TryParse(qtyInput, out int qty);

                                if (product.Quantity > qty)
                                {

                                    //Add a new invoice to the database
                                    var invoiceController = new InvoiceController();
                                    var invoice = new Invoice();

                                    Console.WriteLine("Enter the invoice number: ");
                                    invoice.InvoiceNumber = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Enter the invoice date (YYYY-MM-DD): ");
                                    string? invoiceDateInput = Console.ReadLine();

                                    if (DateTime.TryParse(invoiceDateInput, out DateTime invoiceDate))
                                    {
                                        invoice.InvoiceDate = new DateOnly(invoiceDate.Year, invoiceDate.Month, invoiceDate.Day);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid invoice date format!");
                                    }

                                    Console.WriteLine("Enter the customer name: ");
                                    invoice.CustomerName = Console.ReadLine();

                                    Console.WriteLine("Enter the product names: ");
                                    invoice.ProductNames = Console.ReadLine();

                                    Console.WriteLine("Enter the units per product: ");
                                    invoice.UnitsPerProduct = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Enter the unit price per product: ");
                                    invoice.UnitPricePerProduct = decimal.Parse(Console.ReadLine());

                                    Console.WriteLine("Enter the total price per product: ");
                                    invoice.TotalPricePerProduct = decimal.Parse(Console.ReadLine());

                                    Console.WriteLine("Enter the discount per product: ");
                                    invoice.DiscountPerProduct = decimal.Parse(Console.ReadLine());

                                    invoiceController.AddInvoice(invoice);

                                    /*----- Update the product quantity -----*/
                                    var updateProduct = new Product();


                                    updateProduct.ProductId = product.ProductId;
                                    updateProduct.ProductName = product.ProductName;
                                    updateProduct.ProductDescription = product.ProductDescription;
                                    updateProduct.PurchasePrice = product.PurchasePrice;
                                    updateProduct.SellingPrice = product.SellingPrice;

                                    int existingQty = product.Quantity;
                                    updateProduct.Quantity = existingQty - qty;
                                    productController.UpdateProduct(updateProduct);

                                    //List a specific invoice's details
                                    var listInvoice = invoiceController.GetInvoice(invoice.InvoiceNumber);

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

                        }
                        else
                        {
                            Console.WriteLine("Enter a valid product ID");
                        }

                    }
                    else if (iService == 2)
                    {
                        var invoiceController = new InvoiceController();
                        DateOnly startDate = DateOnly.FromDateTime(DateTime.Parse("2001-01-01"));
                        DateOnly endDate = DateOnly.FromDateTime(DateTime.Parse("2002-12-31"));

                        string customerName = "testname";

                        List<Invoice> invoices = invoiceController.GetInvoicesByDateAndCustomer(startDate, endDate, customerName);

                        foreach (var invoice in invoices)
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


                    }



                }//Main menu if condition (Invoice)
              //  elseif(){

               // }//Main menu if condition (Admin Tasks)
                else if (service == 5)
                {
                    exitFalg = true;
                }

            }//While loop
            
            




        }
    }
}