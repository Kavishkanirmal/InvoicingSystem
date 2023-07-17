using Invoicing_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System.Controllers
{
    public class ProductAddAndUpdateDataController
    {

        private readonly SqlConnection _connection;

        public ProductAddAndUpdateDataController()
        {
            _connection = DBConnector.DBConnector.GetConnection();
        }

        //Add a new entry to the database
        public bool AddProductData(ProductAddAndUpdateData product)
        {
            var query = "INSERT INTO ProductAddAndUpdateData (Date, Operation, ProductID) VALUES (@Date, @Operation, @ProductID)";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("Date", new DateTime(product.Date.Year, product.Date.Month, product.Date.Day));
            cmd.Parameters.AddWithValue("Operation", product.Operation);
            cmd.Parameters.AddWithValue("ProductID", product.ProductID);

            var result = cmd.ExecuteNonQuery() > 0;
            _connection.Close();
            return result;
        }


        //List all entries
        public List<ProductAddAndUpdateData> GetProductAddAndUpdateData()
        {
            var query = "SELECT * FROM ProductAddAndUpdateData";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);


            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            var products = new List<ProductAddAndUpdateData>();
            foreach (DataRow row in dt.Rows)
            {
                products.Add(new ProductAddAndUpdateData()
                {
                    Date = DateOnly.FromDateTime(Convert.ToDateTime(row["Date"])),
                    Operation = Convert.ToString(row["Operation"]),
                    ProductID = Convert.ToString(row["ProductID"])
                });
            }
            _connection.Close();
            return products;
        }

    }
}
