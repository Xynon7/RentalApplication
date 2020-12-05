using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RentalsApp;
namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StandardsPage : ContentPage
	{
		public StandardsPage ()
		{
			InitializeComponent ();
		}

		async void OnAgreeClicked(object sender, EventArgs e)
		{
			bool decision = true;
			bool sucess = RASQLManager.sqlManagerInstance.ChangeAcceptedSP(decision);
			if (sucess)
			{
				await Navigation.PopAsync(); //???profit?
			}
			else
				await Navigation.PushAsync(new StartPage());
		}

		async void OnDisagreeClicked(object sender, EventArgs e)
		{
			bool decision = false;
			RASQLManager.sqlManagerInstance.ChangeAcceptedSP(decision);
			await Navigation.PopAsync();//need to display error message 
		}
	}
}