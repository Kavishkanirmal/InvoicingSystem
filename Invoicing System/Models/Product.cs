using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System.Models
{
    internal class Product
    {

        /* Member Variables */
        private string productID = "";
        private string productName = "";
        private string productDescription = "";
        private float purchasePrice;
        private float sellingPrice;
        private int quantity;


        /* Constructor */
        public Product(string id, string name, string description, float pPrice, float sPrice, int qty) 
        {
            this.productID = id;
            this.productName = name;
            this.productDescription = description;
            this.purchasePrice = pPrice;
            this.sellingPrice = sPrice;
            this.quantity = qty;
        }


        /* Setters */
        public void SetProductID(string id)
        {
            this.productID = id;
        }

        public void SetProductName(string name) {
            this.productName = name; 
        }

        public void SetProductDescription(string description) { 
            this.productDescription = description; 
        }

        public void SetPurchasePrice(float price)
        {
            this.purchasePrice = price;
        }

        public void SetSellingPrice(float price)
        {
            this.sellingPrice = price;
        }

        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }


        /* Getters */
        public string GetProductID()
        {
            return this.productID;
        }

        public string GetProductName()
        {
            return this.productName;
        }

        public string GetProductDescription()
        {
            return this.productDescription; 
        }

        public float GetPurchasePrice()
        {
            return this.purchasePrice;                          
        }

        public float GetSellingPrice()
        {
            return this.sellingPrice;
        }

        public int GetQuantity()
        {
            return this.quantity;
        }

    }
}
