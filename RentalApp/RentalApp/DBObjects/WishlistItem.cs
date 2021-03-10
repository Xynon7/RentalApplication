using RentalsApp;
using RentalsApp.DBObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalsApp.DBObjects
{
    public class WishlistItem
    {
        private Item item;
        public double costRangeLow;
        public double costRangeHigh;

        public WishlistItem(string itemNum, double CostRangeLow, double CostRangeHigh)
        {
            item = RASQLManager.sqlManagerInstance.GetSpecificItem(int.Parse(item.listingInfo.itemNum));
            costRangeLow = CostRangeLow;
            costRangeHigh = CostRangeHigh;
        }

        public Item GetItem()
        {
            item = RASQLManager.sqlManagerInstance.GetSpecificItem(int.Parse(item.listingInfo.itemNum));
            return item;
        }
    }
}
