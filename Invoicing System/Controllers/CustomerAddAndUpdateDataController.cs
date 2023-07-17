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
    public class CustomerAddAndUpdateDataController
    {

        private readonly SqlConnection _connection;

        public CustomerAddAndUpdateDataController()
        {
            _connection = DBConnector.DBConnector.GetConnection();
        }

        //Add a new entry to the database
        public bool AddCustomerData(CustomerAddAndUpdateData customer)
        {
            var query = "INSERT INTO CustomerAddAndUpdateData (Date, Operation, CustomerID) VALUES (@Date, @Operation, @CustomerID)";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("Date", new DateTime(customer.Date.Year, customer.Date.Month, customer.Date.Day));
            cmd.Parameters.AddWithValue("Operation", customer.Operation);
            cmd.Parameters.AddWithValue("CustomerID", customer.CustomerID);

            var result = cmd.ExecuteNonQuery() > 0;
            _connection.Close();
            return result;
        }


        //List all entries
        public List<CustomerAddAndUpdateData> GetCustomerAddAndUpdateData()
        {
            var query = "SELECT * FROM CustomerAddAndUpdateData";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);


            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            var customers = new List<CustomerAddAndUpdateData>();
            foreach (DataRow row in dt.Rows)
            {
                customers.Add(new CustomerAddAndUpdateData()
                {
                    Date = DateOnly.FromDateTime(Convert.ToDateTime(row["Date"])),
                    Operation = Convert.ToString(row["Operation"]),
                    CustomerID = Convert.ToString(row["CustomerID"])
                });
            }
            _connection.Close();
            return customers;
        }

    }
}
