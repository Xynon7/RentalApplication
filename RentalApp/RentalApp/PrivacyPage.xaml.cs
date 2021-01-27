
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RentalsApp;
namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrivacyPage : ContentPage
	{
		public PrivacyPage ()
		{
			InitializeComponent ();
		}

		async void OnAgreeClicked(object sender, EventArgs e)
		{
			bool decision = true;
			bool sucess=  RASQLManager.sqlManagerInstance.ChangeAcceptedPP(decision);
			if (sucess)
			{
				await Navigation.PushAsync(new SignUpPage2()); //???profit?
			}
			else
				await Navigation.PushAsync(new StartPage());
		}

		async void OnDisagreeClicked(object sender, EventArgs e)
		{
			bool decision = false;
			RASQLManager.sqlManagerInstance.ChangeAcceptedPP(decision);
			await Navigation.PopAsync();//need to display error message 
		}
	}
}