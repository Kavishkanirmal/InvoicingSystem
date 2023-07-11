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
    public class ProductController
    {

        private readonly SqlConnection _connection;

        public ProductController() 
        {
            _connection = DBConnector.DBConnector.GetConnection();
        }

        //Add a new product to the database
        public bool AddProduct(Product product)
        {
            var query = "INSERT INTO product (productID, productName, productDescription, purchasePrice, sellingPrice, quantity) VALUES (@productID, @productName, @productDescription, @purchasePrice, @sellingPrice, @quantity)";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("ProductId", product.ProductId);
            cmd.Parameters.AddWithValue("ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("ProductDescription", product.ProductDescription);
            cmd.Parameters.AddWithValue("PurchasePrice", product.PurchasePrice);
            cmd.Parameters.AddWithValue("SellingPrice", product.SellingPrice);
            cmd.Parameters.AddWithValue("Quantity", product.Quantity);

            var result = cmd.ExecuteNonQuery() > 0;
            _connection.Close();
            return result;
        }

        //List a specific product's details
        public Product? GetProduct(string id)
        {
            var query = "SELECT * FROM product WHERE productID = @id";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@id", id);

            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                _connection.Close();
                return null; // No product found
            }

            var row = dt.Rows[0];
            var product = new Product()
            { 
                ProductId = Convert.ToString(row["productID"]),
                ProductName = Convert.ToString(row["productName"]),
                ProductDescription = Convert.ToString(row["productDescription"]),
                PurchasePrice = (float)Convert.ToDouble(row["purchasePrice"]),
                SellingPrice = (float)Convert.ToDouble(row["sellingPrice"]),
                Quantity = Convert.ToInt32(row["quantity"])
                
            };

            _connection.Close();
            return product;
        }

        //List all product details
        public List<Product> GetProducts()
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
                    ProductId = Convert.ToString(row["productID"]),
                    ProductName = Convert.ToString(row["productName"]),
                    ProductDescription = Convert.ToString(row["productDescription"]),
                    PurchasePrice = (float)Convert.ToDouble(row["purchasePrice"]),
                    SellingPrice = (float)Convert.ToDouble(row["sellingPrice"]),
                    Quantity = Convert.ToInt32(row["quantity"])
                });
            }
            _connection.Close();
            return products;
        }

        //Remove products
        public bool RemoveProduct(string productId)
        {
            var query = "DELETE FROM product WHERE productID = @productId";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@productId", productId);

            var result = cmd.ExecuteNonQuery() > 0;
            _connection.Close();
            return result;
        }

        // Update a product
        public bool UpdateProduct(Product product)
        {
            var query = "UPDATE product SET productName = @productName, productDescription = @productDescription, purchasePrice = @purchasePrice, sellingPrice = @sellingPrice, quantity = @quantity WHERE productID = @productId";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@productName", product.ProductName);
            cmd.Parameters.AddWithValue("@productDescription", product.ProductDescription);
            cmd.Parameters.AddWithValue("@purchasePrice", product.PurchasePrice);
            cmd.Parameters.AddWithValue("@sellingPrice", product.SellingPrice);
            cmd.Parameters.AddWithValue("@quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@productId", product.ProductId);

            var result = cmd.ExecuteNonQuery() > 0;
            _connection.Close();
            return result;
        }

    }
}
