using System;
using System.Collections.Generic;

namespace RentalsApp.DBObjects
{
    public class ItemListing
    {
        public string itemNum;
        public string brand;
        public string type;
        public string description;
        public double costPerDay;
        public DateTime datePosted;
        public double replacementCost;
        public double deposit;
        public List<ItemImage> itemImages;
        public Dictionary<string, string> leasingCityStatePairs;
        public List<string> leasingZipCodes;

        public ItemListing(string ItemNum, string Brand, string Type, string Description, double CostPerDay, DateTime DatePosted)
        {
            itemNum = ItemNum;
            brand = Brand;
            type = Type;
            description = Description;
            costPerDay = CostPerDay;
            datePosted = DatePosted;
        }
    }
}