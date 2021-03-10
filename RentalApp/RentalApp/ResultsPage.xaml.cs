
using RentalsApp;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultsPage : ContentPage
	{
		public ResultsPage (string searchFor)
		{
			InitializeComponent ();
			ResultsDisplay.Text = GetItems(searchFor);
		}
		string GetItems(string type)
        {
			List<RentalsApp.DBObjects.ItemListing> listy;
			 listy=RASQLManager.sqlManagerInstance.GetAllItems();
			string toReturn = "";
			foreach(RentalsApp.DBObjects.ItemListing item in listy)
            {
				//RentalsApp.DBObjects.ItemListing info = item.listingInfo;

				toReturn = toReturn + " " +item.itemNum + " " + item.brand +" " + item.description +  "\n";
            }
			return toReturn;
        }
	}
}