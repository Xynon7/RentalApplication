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
    public class Location
    {
        public string name;
        public string city;
        public string state;
        public string zipCode;

        public Location(string Name, string City, string State, string ZipCode)
        {
            name = Name;
            city = City;
            state = State;
            zipCode = ZipCode;
        }
    }
}