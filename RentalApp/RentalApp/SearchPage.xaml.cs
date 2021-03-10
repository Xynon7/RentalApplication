using RentalsApp;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
        public string username, itemName,brand,type =null;
        StackLayout parent;
		public SearchPage ()
		{
            InitializeComponent();
        }



        void OnUserNameCompleted(object sender, EventArgs e)
        {
            username = ((Entry)sender).Text;
        }

        void OnItemNameCompleted(object sender, EventArgs e)
        {
            itemName = ((Entry)sender).Text;
        }



        void OnBrandCompleted(object sender, EventArgs e)
        {
            brand = ((Entry)sender).Text;
        }

        void OnTypeCompleted(object sender, EventArgs e)
        {
            type = ((Entry)sender).Text;
        }


        void OnSearchClicked(object sender, EventArgs e) //was async void
        {
            List<RentalsApp.DBObjects.ItemListing> listy=new List<RentalsApp.DBObjects.ItemListing>();
            List<RentalsApp.DBObjects.Item> itemList;
            RentalsApp.DBObjects.SearchResult SearchResults;
            
            if(username==null || username == "")
            {
                username ="%";
            }
            if (itemName == null || itemName == "")
            {
                itemName = "%";
            }
            if (brand == null || brand == "")
            {
                brand = "%";
            }
            if (type == null || type == "")
            {
                type = "%";
            }

            SearchResults = RASQLManager.sqlManagerInstance.SearchForItems(); //change to search function
            itemList = SearchResults.items;
            foreach(RentalsApp.DBObjects.Item item in itemList)
            {
                listy.Add(item.listingInfo);
            }
            foreach (RentalsApp.DBObjects.ItemListing item in listy)
            {
                //  string buttonTxt = item.itemNum + " " + item.brand + " " + item.description;
                string buttonTxt = item.description + " Brand: " + item.brand;
                Button button = new Button
                {

                    Text = buttonTxt,
                    TextColor = Color.FromHex("#E29F10"),
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 23

                };
                button.Clicked += async (sender2, args) => await Navigation.PushAsync(new ConfirmationPage(item));

                parent = layout;
                parent.Children.Add(button);
            }

        }
    }
}