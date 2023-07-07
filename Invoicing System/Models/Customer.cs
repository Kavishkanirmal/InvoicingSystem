using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_System.Models
{
    internal class Customer
    {
        /* Member Variables */
        private string customerID = "";
        private string customerName = "";                                
        private string email = "";
        private string address = "";
        private string contactNO = "";
        private string dateOfBirth = "";
        private string gender = "";


        /* Setters */
        public void SetCustomerID(string customerID)
        {
            this.customerID = customerID;
        }

        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public void SetContactNO(string contactNO)
        {
            this.contactNO = contactNO; 
        }

        public void SetDateOfBirth(string dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
        }

        public void SetGender(string gender)
        {
            this.gender = gender;
        }


        /* Getters */
        public string GetCustomerID()
        {
            return this.customerID;
        } 

        public string GetCustomerName()
        {
            return this.customerName;
        }

        public string GetEmail()
        {
            return this.email;
        }

        public string GetAddress()
        {
            return this.address;
        }

        public string GetContactNO()
        {
            return this.contactNO;
        }

        public string GetDateOfBirth()
        {
            return this.dateOfBirth;
        }

        public string GetGender()
        {
            return this.gender;
        }


    }
}
