using Invoicing_System.Controllers;
using Invoicing_System.Models;

namespace Invoicing_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productController = new ProductController();
            var product = new Product("TestID2", "TestName", "TestDesc", 50, 100, 10);
            
            productController.AddProduct(product);

        }
    }
}