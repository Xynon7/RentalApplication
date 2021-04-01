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
        public string userName, itemName,brand,type =null;
        StackLayout parent;
		public SearchPage ()
		{
            InitializeComponent();
        }



        void OnUserNameCompleted(object sender, EventArgs e)
        {
            userName = ((Entry)sender).Text;
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
            parent = layout;
            while(parent.Children.Count > 6)
            {
                parent.Children.RemoveAt(6);
            }

            List<RentalsApp.DBObjects.ItemListing> listy=new List<RentalsApp.DBObjects.ItemListing>();
            List<RentalsApp.DBObjects.Item> itemList;
            RentalsApp.DBObjects.SearchResult SearchResults;
            
            if(userName==null || userName == "")
            {
                userName ="%";
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

            SearchResults = RASQLManager.sqlManagerInstance.SearchForItems(username:userName, name:itemName, brand:brand, type:type); //change to search function
            
            itemList = SearchResults.items;
            if (itemList != null)
            {
                foreach (RentalsApp.DBObjects.Item item in itemList)
                {
                    listy.Add(item.listingInfo);
                }
                foreach (RentalsApp.DBObjects.ItemListing item in listy)
                {
                    //  string buttonTxt = item.itemNum + " " + item.brand + " " + item.description;
                    string buttonTxt = item.itemName + "\n" + item.description + "\nBrand: " + item.brand;
                    Button button = new Button
                    {

                        Text = buttonTxt,
                        TextColor = Color.FromHex("#25B6D3"),
                        BackgroundColor = Color.White,
                        BorderWidth=1.5,
                        BorderColor=Color.FromHex("#25B6D3"),
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 23

                    };
                    button.Clicked += async (sender2, args) => await Navigation.PushAsync(new ConfirmationPage(item));

                    //parent = layout;
                    parent.Children.Add(button);
                    
                }
            }

        }
    }
}