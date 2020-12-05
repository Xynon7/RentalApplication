
using RentalsApp;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExchangePage : ContentPage
	{
		public string exchangeList;
		public ExchangePage ()
		{
			InitializeComponent ();
		}

		string getExchanges()
        {
			string user = RASQLManager.currentUser.username;
			List<RentalsApp.DBObjects.Exchange> listy;

			listy = RASQLManager.sqlManagerInstance.GetRenterExchanges(user); //change to GetExchanges
			string toReturn = "";
			foreach(RentalsApp.DBObjects.Exchange exch in listy)
            {
				toReturn = toReturn + " Lessor: " + exch.lessor + " Renter:" + exch.renter + "\n";
            }
			return toReturn;
		}

		async void OnNewExchangeClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewExchangePage());
		}

		async void OnHomeClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new HomePage()); 
		}

	}
}