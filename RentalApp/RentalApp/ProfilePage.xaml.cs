using System;
using RentalsApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
		public string UserInfo;
		public ProfilePage ()
		{
			InitializeComponent ();

			UserInfo = GetUserInfo();

			BindingContext = this;
			InfoDisplay.Text = UserInfo;
		}

		string GetUserInfo()
		{
			string user = RASQLManager.currentUser.username;

			string INFO = user;
			return INFO;

		}

		async void OnLocationsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new LocationPage());
		}

		async void OnResultsClicked(object sender, EventArgs e)
		{
			//await Navigation.PushAsync(new ResultsPage());
		}

		async void OnCartsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CartPage());
		}

		async void OnPaymentsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ProfilePage());//need to make payments page
		}

		async void OnHomeClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new HomePage());
		}

		
	}
}