using System;
using System.Collections.Generic;

namespace RentalsApp.DBObjects
{
    public class Cart
    {
        //Dictionary of Items as keys with the days 
        public Dictionary<Item, int> itemList;
        public double totalCost;
        public DateTime creationTime;
        public bool active;
    }
}