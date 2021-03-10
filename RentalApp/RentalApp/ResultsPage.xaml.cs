
using RentalsApp;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;


namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultsPage : ContentPage
	{

		StackLayout parent;
		public ResultsPage (string searchFor)
		{
			InitializeComponent ();
			ResultsDisplay.Text = GetItems(searchFor);
			CreateButtons();
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

		void CreateButtons()
        {
			List<RentalsApp.DBObjects.ItemListing> listy;
			listy = RASQLManager.sqlManagerInstance.GetAllItems();

			foreach (RentalsApp.DBObjects.ItemListing item in listy)
            {
				string buttonTxt = item.itemNum + " " + item.brand + " " + item.description;
				Button button = new Button
				{

					Text = buttonTxt
				};
				button.Clicked += async (sender, args )=> await Navigation.PushAsync(new ConfirmationPage(item));

				parent = layout;
				parent.Children.Add(button);
            }
		}

		


		
	}
}