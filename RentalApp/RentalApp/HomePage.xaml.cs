using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

        async void OnViewProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        async void OnViewWishListClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WishListPage());
        }

        async void OnSearchClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        async void OnViewRenterHubClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RenterHubPage());
        }

        async void OnViewLessorHubClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LessorHubPage());
        }

        async void OnReportClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportUserPage());
        }

        async void OnHelpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomeHelp());
        }
        async void OnLocationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocationPage());
        }
    }
}
