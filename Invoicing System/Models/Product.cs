using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System.Models
{
    public class Product
    {

        /* Properties */
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public float PurchasePrice { get; set; }
        public float SellingPrice { get; set; }
        public int Quantity { get; set; }

    }
}
