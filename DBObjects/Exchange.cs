using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

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