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
    public class AdminController
    {

        private readonly SqlConnection _connection;

        public AdminController()
        {
            _connection = DBConnector.DBConnector.GetConnection();
        }


        //Get a specific admin's details
        public Admin? GetAdmin(string username, string password)
        {
            var query = "SELECT * FROM Admin WHERE Username = @username AND Password = @password";
            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                _connection.Close();
                return null; // No customer found
            }

            var row = dt.Rows[0];
            var admin = new Admin()
            {
                Username = Convert.ToString(row["Username"]),
                Password = Convert.ToString(row["Password"])
            };

            _connection.Close();
            return admin;
        }

    }
}
