using Invoicing_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System.Controllers
{
    public class InvoiceController
    {

        private readonly SqlConnection _connection;

        public InvoiceController()
        {
            _connection = DBConnector.DBConnector.GetConnection();
        }

        //Add a new invoice to the database
        public bool AddInvoice(Invoice invoice)
        {
            var query = "INSERT INTO Invoices (InvoiceNumber, InvoiceDate, CustomerName, ProductNames, UnitsPerProduct, UnitPricePerProduct, TotalPricePerProduct, DiscountPerProduct) VALUES (@InvoiceNumber, @InvoiceDate, @CustomerName, @ProductNames, @UnitsPerProduct, @UnitPricePerProduct, @TotalPricePerProduct, @DiscountPerProduct)";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("InvoiceNumber", invoice.InvoiceNumber);
            cmd.Parameters.AddWithValue("InvoiceDate", invoice.InvoiceDate);
            cmd.Parameters.AddWithValue("CustomerName", invoice.CustomerName);
            cmd.Parameters.AddWithValue("ProductNames", invoice.ProductNames);
            cmd.Parameters.AddWithValue("UnitsPerProduct", invoice.UnitsPerProduct);
            cmd.Parameters.AddWithValue("UnitPricePerProduct", invoice.UnitPricePerProduct);
            cmd.Parameters.AddWithValue("TotalPricePerProduct", invoice.TotalPricePerProduct);
            cmd.Parameters.AddWithValue("DiscountPerProduct", invoice.DiscountPerProduct);

            var result = cmd.ExecuteNonQuery() > 0;
            _connection.Close();
            return result;
        }

        //List a specific Invoice's details
        public Invoice GetInvoice(int id)
        {
            var query = "SELECT * FROM Invoices WHERE InvoiceNumber = @id";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@id", id);

            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                _connection.Close();
                return null; // No customer found
            }

            var row = dt.Rows[0];
            var invoice = new Invoice()
            {
                InvoiceNumber = Convert.ToInt32(row["InvoiceNumber"]),
                InvoiceDate = Convert.ToString(row["InvoiceDate"]),
                CustomerName = Convert.ToString(row["CustomerName"]),
                ProductNames = Convert.ToString(row["ProductNames"]),
                UnitsPerProduct = Convert.ToInt32(row["UnitsPerProduct"]),
                UnitPricePerProduct = Convert.ToDecimal(row["TotalPricePerProduct"]),
                TotalPricePerProduct = Convert.ToDecimal(row["TotalPricePerProduct"]),
                DiscountPerProduct = Convert.ToDecimal(row["DiscountPerProduct"])
            };

            _connection.Close();
            return invoice;
        }
    }
}
