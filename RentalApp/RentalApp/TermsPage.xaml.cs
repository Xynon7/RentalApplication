using System;
using RentalsApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TermsPage : ContentPage
	{
		public TermsPage ()
		{
			InitializeComponent ();
		}

		async void OnAgreeClicked(object sender, EventArgs e)
		{
			bool decision = true;
			bool success= RASQLManager.sqlManagerInstance.ChangeAcceptedTC(decision);
			if (success)
			{
				await Navigation.PopAsync(); //???profit?
			}
			else
				await Navigation.PushAsync(new StartPage());
		}

		async void OnDisagreeClicked(object sender, EventArgs e)
		{
			bool decision = false;
			RASQLManager.sqlManagerInstance.ChangeAcceptedTC(decision);
			await Navigation.PushAsync(new ErrorPage(2));//need to display error message 
		}
	}
}