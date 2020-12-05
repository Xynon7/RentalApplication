using RentalsApp;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocationPage : ContentPage
	{
		public string name, address, city, state, zip;
		public LocationPage ()
		{
			InitializeComponent ();

			//	List<RentalsApp.DBObjects.Location> lis;
			//	lis = locationList();
			string result = locationList();
         //   LocList.ItemsSource = lis;
			LocationDisplay.Text = result;
		}

		void NameCompleted(object sender, EventArgs e)
        {
			name = ((Entry)sender).Text;
        }

		void AddressCompleted(object sender, EventArgs e)
		{
			address = ((Entry)sender).Text;
		}

		void StateCompleted(object sender, EventArgs e)
		{
			state = ((Entry)sender).Text;
		}

		void ZipCompleted(object sender, EventArgs e)
		{
			zip = ((Entry)sender).Text;
		}

		void CityCompleted(object sender, EventArgs e)
		{
			city = ((Entry)sender).Text;
		}
		string locationList()
		{
			string user = RASQLManager.currentUser.username;
			List<RentalsApp.DBObjects.Location> listy;

			listy = RASQLManager.sqlManagerInstance.GetLocations(user);// need to fix this 
			string toReturn = "";
			
			foreach (RentalsApp.DBObjects.Location location in listy)
			{

				toReturn = toReturn + " " + location.name + " " + location.city + " " + location.state + " " + location.zipCode + "\n";
			}
			return toReturn;
		}

		async void OnAddLocationClicked(object sender, EventArgs e)
		{
			bool success = RASQLManager.sqlManagerInstance.CreateLocation(name, address, city, state, zip);
			if (success)
			{
				await Navigation.PushAsync(new LocationPage());
			}
			else
				await Navigation.PushAsync(new ErrorPage(3));
		}
		async void OnReturnClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		async void OnHomeClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new HomePage());
		}
	}
}