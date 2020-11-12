using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{

            InitializeComponent();
		}

        async void OnSignUpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
        async void  OnLogInClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignInPage());
        }
    }
}