
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RenterHubPage : ContentPage
	{
		public RenterHubPage ()
		{
			InitializeComponent ();
		}
		async void OnInvoicesClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new InvoicePage());
		}
		async void OnRateClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RatingsPage());
			
		}
		async void OnMessagesClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MessagesPage());
		}
		async void OnExchangesClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ExchangePage());
		}
		async void OnRAggrementClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RenterAgreementPage());
			
		}
		async void OnHomeClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new HomePage());
		}
	}
}