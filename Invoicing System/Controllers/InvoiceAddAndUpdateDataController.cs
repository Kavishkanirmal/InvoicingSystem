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
    public class InvoiceAddAndUpdateDataController
    {

        private readonly SqlConnection _connection;

        public InvoiceAddAndUpdateDataController()
        {
            _connection = DBConnector.DBConnector.GetConnection();
        }

        //Add a new entry to the database
        public bool AddInvoiceData(InvoiceAddAndUpdateData invoice)
        {
            var query = "INSERT INTO InvoiceAddAndUpdateData (Date, Operation, InvoiceNumber) VALUES (@Date, @Operation, @InvoiceNumber)";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("Date", new DateTime(invoice.Date.Year, invoice.Date.Month, invoice.Date.Day));
            cmd.Parameters.AddWithValue("Operation", invoice.Operation);
            cmd.Parameters.AddWithValue("InvoiceNumber", invoice.InvoiceNumber);

            var result = cmd.ExecuteNonQuery() > 0;
            _connection.Close();
            return result;
        }


        //List all entries
        public List<InvoiceAddAndUpdateData> GetInvoiceAddAndUpdateData()
        {
            var query = "SELECT * FROM InvoiceAddAndUpdateData";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);


            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            var invoices = new List<InvoiceAddAndUpdateData>();
            foreach (DataRow row in dt.Rows)
            {
                invoices.Add(new InvoiceAddAndUpdateData()
                {
                    Date = DateOnly.FromDateTime(Convert.ToDateTime(row["Date"])),
                    Operation = Convert.ToString(row["Operation"]),
                    InvoiceNumber = Convert.ToInt32(row["InvoiceNumber"])
                });
            }
            _connection.Close();
            return invoices;
        }
    }
}
