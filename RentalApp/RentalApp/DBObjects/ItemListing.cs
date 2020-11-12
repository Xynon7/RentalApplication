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
        public List<ItemImage> itemImages;

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