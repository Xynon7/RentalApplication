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
            //need a function to get listings
            string toReturn = "";
            return toReturn;
        }
    }
}