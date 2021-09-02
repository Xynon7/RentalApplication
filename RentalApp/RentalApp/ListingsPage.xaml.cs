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
        StackLayout parent;
        public ListingsPage()
        {
            InitializeComponent();
            listings = getListings();
            ListingsDisplay.Text = listings;
        }

        string getListings()
        {
            parent = layout;
            string user = RASQLManager.currentUser.username;
            List<RentalsApp.DBObjects.ItemListing> listy;
            listy = RASQLManager.sqlManagerInstance.GetItemListings(user);
            string toReturn = "";
            foreach (RentalsApp.DBObjects.ItemListing listing in listy)
            {
                // toReturn= toReturn + " " + listing.itemNum + " " + listing.brand +" " + listing.type + "\n";
                string buttonTxt = listing.itemName + "\n" + listing.description + "\nBrand: " + listing.brand;
                Button button = new Button
                {
                    Text = buttonTxt,
                    TextColor = Color.FromHex("#25B6D3"),
                    BackgroundColor = Color.White,
                    BorderWidth = 1.5,
                    BorderColor = Color.FromHex("#25B6D3"),
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 23
                };
                button.Clicked += async (sender2, args) => await Navigation.PushAsync(new AddImagePage(listing));

                parent.Children.Add(button);
            }

            Button returnButton = new Button
            {
                Text = "Return to Lessor Hub",

            };
            returnButton.Clicked += async (sender3, args) => Navigation.PushAsync(new LessorHubPage());
            parent.Children.Add(returnButton);

            Button homeButton = new Button
            {
                Text = "Home",

            };
            homeButton.Clicked += async (sender4, args) => Navigation.PushAsync(new HomePage());
            parent.Children.Add(homeButton);
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