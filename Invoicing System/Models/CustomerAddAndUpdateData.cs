using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System.Models
{
    public class CustomerAddAndUpdateData
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string? Operation { get; set; }
        public string? CustomerID { get; set; }

    }
}
