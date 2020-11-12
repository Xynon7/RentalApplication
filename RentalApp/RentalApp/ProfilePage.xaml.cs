using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
		}

		async void OnLocationsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new LocationPage());
		}

		async void OnResultsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ResultsPage());
		}

		async void OnCartsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CartPage());
		}

		async void OnPaymentsClicked(object sender, EventArgs e)
		{
			//await Navigation.PushAsync(new PaymentPage());
		}

		async void OnHomeClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new HomePage());
		}
	}
}