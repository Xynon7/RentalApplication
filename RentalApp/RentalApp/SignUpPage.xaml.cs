using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
            InitializeComponent();
          //  BindingContext = AddUserViewModel();
        }
        async void OnSignUpAppClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage2());
        }
    }
}