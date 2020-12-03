using System;

namespace RentalsApp.DBObjects
{
    public class Payment
    {
        public Invoice invoicePayedFor;
        public string paymentType;
        public DateTime paymentTime;
    }
}