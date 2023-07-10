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
    public class CustomerController
    {

        private readonly SqlConnection _connection;

        public CustomerController()
        {
            _connection = DBConnector.DBConnector.GetConnection();
        }

        //Add a new customer to the database
        public bool AddCustomer(Customer customer)
        {
            var query = "INSERT INTO customer (customerId, customerName, email, address, contactNo, dateOfBirth, gender) VALUES (@customerId, @customerName, @email, @address, @contactNo, @dateOfBirth, @gender)";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("CustomerId", customer.CustomerId);
            cmd.Parameters.AddWithValue("customerName", customer.CustomerName);
            cmd.Parameters.AddWithValue("email", customer.Email);
            cmd.Parameters.AddWithValue("address", customer.Address);
            cmd.Parameters.AddWithValue("contactNo", customer.ContactNo);
            cmd.Parameters.AddWithValue("dateOfBirth", customer.DateOfBirth);
            cmd.Parameters.AddWithValue("gender", customer.Gender);

            var result = cmd.ExecuteNonQuery() > 0;
            _connection.Close();
            return result;
        }

        //List all customer details
        public List<Customer> GetCustomers()
        {
            var query = "SELECT * FROM customer";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);


            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            var customers = new List<Customer>();
            foreach (DataRow row in dt.Rows)
            {
                customers.Add(new Customer()
                {
                    CustomerId = Convert.ToString(row["customerId"]),
                    CustomerName = Convert.ToString(row["customerName"]),
                    Email = Convert.ToString(row["Email"]),
                    Address = Convert.ToString(row["Address"]),
                    ContactNo = Convert.ToString(row["ContactNo"]),
                    DateOfBirth = Convert.ToString(row["DateOfBirth"]),
                    Gender = Convert.ToString(row["Gender"])
                });
            }
            _connection.Close();
            return customers;
        }

        //List a specific customer's details
        public Customer GetCustomer(string id)
        {
            var query = "SELECT * FROM customer WHERE customerId = @id";
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
            var customer = new Customer()
            {
                CustomerId = Convert.ToString(row["customerId"]),
                CustomerName = Convert.ToString(row["customerName"]),
                Email = Convert.ToString(row["email"]),
                Address = Convert.ToString(row["address"]),
                ContactNo = Convert.ToString(row["contactNo"]),
                DateOfBirth = Convert.ToString(row["dateOfBirth"]),
                Gender = Convert.ToString(row["gender"])
            };

            _connection.Close();
            return customer;
        }

        //Remove customers
        public bool RemoveCustomer(string customerId)
        {
            var query = "DELETE FROM customer WHERE customerId = @customerId";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@customerId", customerId);

            var result = cmd.ExecuteNonQuery() > 0;
            _connection.Close();
            return result;
        }

        // Update a customer
        public bool UpdateCustomer(Customer customer)
        {
            var query = "UPDATE customer SET customerName = @customerName, email = @email, address = @address, contactNo = @contactNo, dateOfBirth = @dateOfBirth, gender = @gender WHERE customerId = @customerId";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@customerName", customer.CustomerName);
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@address", customer.Address);
            cmd.Parameters.AddWithValue("@contactNo", customer.ContactNo);
            cmd.Parameters.AddWithValue("@dateOfBirth", customer.DateOfBirth);
            cmd.Parameters.AddWithValue("@gender", customer.Gender);
            cmd.Parameters.AddWithValue("@customerId", customer.CustomerId);

            var result = cmd.ExecuteNonQuery() > 0;
            _connection.Close();
            return result;
        }

    }
}
