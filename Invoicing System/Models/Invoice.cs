using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System.Models
{
    public class Invoice
    {

        /*----- Properties -----*/
        public int InvoiceNumber{ get; set; }
        public string? InvoiceDate { get; set; } 
        public string? CustomerName { get; set; } 
        public string? ProductNames { get; set; }
        public int UnitsPerProduct { get; set; }
        public decimal UnitPricePerProduct { get; set; }
        public decimal TotalPricePerProduct { get; set; }
        public decimal DiscountPerProduct { get; set; }

    }
}
