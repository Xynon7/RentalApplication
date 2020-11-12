using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RentalApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.AddUserViewModel();
        }
        async void OnWelcomeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartPage());
        }
    }
}
