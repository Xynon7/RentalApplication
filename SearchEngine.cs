using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentalsApp.DBObjects;

namespace RentalsApp
{
    public static class SearchEngine
    {
        public static List<Item> SearchForItem(string username, string itemNum, string brand, string type, string costPerDay, bool isAvailable, DateTime availabilityDate)
        {
            SearchResult result = RASQLManager.sqlManagerInstance.SearchForItems(username, itemNum, brand, type, costPerDay, isAvailable, availabilityDate);
            return result.items;
        }
    }
}