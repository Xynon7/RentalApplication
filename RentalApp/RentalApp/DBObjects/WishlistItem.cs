using RentalsApp;
using RentalsApp.DBObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalApp.DBObjects
{
    public class WishlistItem
    {
        private Item item;
        public decimal costRangeLow;
        public decimal costRangeHigh;

        public WishlistItem(string itemNum, decimal CostRangeLow, decimal CostRangeHigh)
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
