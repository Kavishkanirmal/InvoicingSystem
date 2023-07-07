using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace Invoicing_System.DBConnector
{
    internal class DBConnector
    {
        public static SqlConnection GetConnection()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false, reloadOnChange: true).Build();

            return new SqlConnection(configuration.GetConnectionString("InvoicingSystem"));
        }

    }
}
