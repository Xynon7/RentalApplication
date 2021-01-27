using RentalsApp;
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
    public partial class ListingsPage : ContentPage
    {
        public string listings;
        public ListingsPage()
        {
            InitializeComponent();
            listings = getListings();
            ListingsDisplay.Text = listings;
        }

        string getListings()
        {
            string user = RASQLManager.currentUser.username;
            List<RentalsApp.DBObjects.ItemListing> listy;
            listy = RASQLManager.sqlManagerInstance.GetItemListings(user);
            string toReturn = "";
            foreach (RentalsApp.DBObjects.ItemListing listing in listy)
            {
                toReturn= toReturn + " " + listing.itemNum + " " + listing.brand +" " + listing.type + "\n";
            }
            
            return toReturn;
        }

        async void OnReturnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        async void OnHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}