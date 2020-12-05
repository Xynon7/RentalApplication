
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
                toReturn = toReturn + " " + kvp.Value.ToString() + '\n';
            }
            toReturn = toReturn + "Total cost is: " + myCart.totalCost;

                return toReturn;
        }
	}
}