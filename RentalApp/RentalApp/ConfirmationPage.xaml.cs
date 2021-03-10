using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RentalsApp;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmationPage : ContentPage
    {
        public ConfirmationPage(RentalsApp.DBObjects.ItemListing item)
        {
            InitializeComponent();
            ItemConfirm.Text = "Would you like to rent the: " + item.description;
        }


       

            async void OnConfirmClicked(object sender, EventArgs e)
        {
            //add functionality to exchange
            await Navigation.PushAsync(new HomePage());
        }
    }
}