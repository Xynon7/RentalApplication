
using RentalsApp;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WishListPage : ContentPage
	{
		public WishListPage()
		{
			InitializeComponent();
			string result = getWishList();
		}

		string getWishList()
		{
			string user = RASQLManager.currentUser.username;
			List<RentalsApp.DBObjects.WishlistItem> wList = RASQLManager.sqlManagerInstance.GetWishlist(user);
			
			string toReturn = "";

			foreach (RentalsApp.DBObjects.WishlistItem wishL in wList)
            {
				RentalsApp.DBObjects.Item wishItem=wishL.GetItem();
				RentalsApp.DBObjects.ItemListing wishListing = wishItem.listingInfo;
				string number = wishListing.itemNum;
				string avaliability = wishItem.isAvailable.ToString();
				toReturn = toReturn + " " + number + " " + avaliability + "\n";
            }

				return toReturn;
		}

	}
}