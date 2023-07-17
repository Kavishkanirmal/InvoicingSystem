using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System.Models
{
    public class InvoiceAddAndUpdateData
    {
        public int Id { get; set; }
        public DateOnly Date {get; set;}
        public string? Operation { get; set;}
        public int InvoiceNumber { get; set;}

    }
}
