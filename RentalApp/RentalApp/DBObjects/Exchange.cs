using System;

namespace RentalsApp.DBObjects
{
    public class Exchange
    {
        public string renter;
        public string lessor;
        public string location;
        public string method;
        public DateTime time;
        public Invoice invoiceForExchange;
        public bool paymentComplete;
    }
}