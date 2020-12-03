using System;

namespace RentalsApp.DBObjects
{
    public class Invoice
    {
        public string invoiceNum;
        public DateTime invoiceTime;
        public Cart cart;
    }
}