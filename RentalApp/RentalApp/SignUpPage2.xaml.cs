using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage2 : ContentPage
	{
		public SignUpPage2 ()
		{
			InitializeComponent ();
		}
        async void OnAddLoactionClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocationPage());
        }
        async void OnTermsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermsPage());
        }
        async void OnPrivacyClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PrivacyPage());
        }
        async void OnStandardsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StandardsPage());
        }
        async void OnSubmitClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}