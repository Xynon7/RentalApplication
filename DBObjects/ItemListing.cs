using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

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