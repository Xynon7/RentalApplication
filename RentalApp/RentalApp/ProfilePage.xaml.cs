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
			string first = RASQLManager.currentUser.firstName;
			string middle = RASQLManager.currentUser.middleInitial;
			string last = RASQLManager.currentUser.lastName;
			string gender = RASQLManager.currentUser.gender;
			string date = RASQLManager.currentUser.dateOfBirth.ToString("yyyy-MM-dd HH:mm:ss");
			string ID = RASQLManager.currentUser.stateId;
			string ssn = RASQLManager.currentUser.ssn;
			string INFO = user + '\n' + first + ' ' + middle + ' ' + last + '\n' + gender + date + '\n' + ID + ssn;
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