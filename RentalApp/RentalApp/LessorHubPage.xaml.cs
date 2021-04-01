
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LessorHubPage : ContentPage
	{
		public LessorHubPage ()
		{
			InitializeComponent ();
		}

		async void OnNewItemClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewListingPage());
		}

		async void OnListingsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ListingsPage());
		}

		async void OnRatingsClicked(object sender, EventArgs e)
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

		async void OnLAgreementsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new LessorAgreementPage()); //need a L Agreement page
		}
		async void OnHomeClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new HomePage());
		}
		async void OnHelpClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new LessorHubHelp());
		}


	}
}