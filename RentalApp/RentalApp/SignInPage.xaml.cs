using RentalsApp;
using System;
using RentalApp;
using System.Linq;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInPage : ContentPage
	{
        public string user, pass;

		public SignInPage ()
		{
			InitializeComponent ();
		}

        void EmailCompleted(object sender, EventArgs e)
        {
            user = ((Entry)sender).Text;
        }

        void PasswordCompleted(object sender, EventArgs e)
        {
            pass = ((Entry)sender).Text;
        }
        async void OnEnterClicked(object sender, EventArgs e)
            
        {

            bool validate = RASQLManager.sqlManagerInstance.ValidateLogin(user, pass);
            if (validate)
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await Navigation.PushAsync(new SignInPage());
            }
            
        }
    }
}