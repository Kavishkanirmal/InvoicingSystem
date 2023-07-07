using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoicing_System.Models;
using Microsoft.Extensions.Configuration;

namespace Invoicing_System.Controllers
{
    internal class ProductController
    {
        private readonly SqlConnection _connection;

        public ProductController() 
        {
         //   _connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["config.json"].ConnectionString);

            _connection = DBConnector.DBConnector.GetConnection();

           // _connection = new SqlConnection("Data Source=LAPTOP-Q41M8E8L\\SQLEXPRESS;Initial Catalog=InvoicingSystem;Integrated Security=True");
        }

        public bool AddProduct(Product product)
        {
            var query = "INSERT INTO product (productID, productName, productDescription, purchasePrice, sellingPrice, quantity) VALUES (@productID, @productName, @productDescription, @purchasePrice, @sellingPrice, @quantity)";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("productID", product.GetProductID());
            cmd.Parameters.AddWithValue("productName", product.GetProductName());
            cmd.Parameters.AddWithValue("productDescription", product.GetProductDescription());
            cmd.Parameters.AddWithValue("purchasePrice", product.GetPurchasePrice());
            cmd.Parameters.AddWithValue("sellingPrice", product.GetSellingPrice());
            cmd.Parameters.AddWithValue("quantity", product.GetQuantity());

            var result = cmd.ExecuteNonQuery() > 0;
            _connection.Close();
            return result;
        }

       /*public List<ProductController> GetProducts()
        {
            var query = "SELECT * FROM product";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            var products = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                products.Add(new Product()
                {
                    ID = Convert.ToString(row["ID"]),
                    Name = Convert.ToString(row["Name"]),
                    Description = Convert.ToString(row["Description"]),
                    PurchasePrice = Convert.ToDouble(row["PurchasePrice"]),
                    SellingPrice = Convert.ToDouble(row["SellingPrice"]),
                    Quantity = Convert.ToInt32(row["Quantity"])
                });
            }
            return products;
        }*/

    }
}
