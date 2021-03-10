
using RentalsApp;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CartPage : ContentPage
	{
        string cartList;
		public CartPage ()
		{
			InitializeComponent ();
            cartList = getCart();
            CartDisplay.Text = cartList;
		}

        string getCart()
        {
            string user = RASQLManager.currentUser.username;
            RentalsApp.DBObjects.Cart myCart;
            myCart = RASQLManager.sqlManagerInstance.GetCart(user);
            string toReturn = "";
            Dictionary<RentalsApp.DBObjects.Item, int> listy;
            listy = myCart.itemList;
            foreach(KeyValuePair<RentalsApp.DBObjects.Item, int> kvp in listy)
            {
                toReturn = toReturn + "Item num: " + kvp.Key.listingInfo.itemNum + " Brand: " + kvp.Key.listingInfo.brand + " Type: " + kvp.Key.listingInfo.type + " Cost: " 
                    + kvp.Key.listingInfo.costPerDay + " Avaliable?: " + kvp.Key.isAvailable.ToString() + " Deposit: " + kvp.Key.listingInfo.deposit.ToString() + " Description: "
                  + kvp.Key.listingInfo.description + " " + kvp.Value.ToString() + '\n';
            }
            toReturn = toReturn + "Total cost is: " + myCart.totalCost;

                return toReturn;
        }
	}
}