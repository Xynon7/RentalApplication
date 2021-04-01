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
    public partial class NewListingPage : ContentPage
    {
        public string itemName, desc, brand, type, city, state, zip;
        public double cost, replacementCost, deposit;
        public NewListingPage()
        {
            InitializeComponent();
        }

        void DescriptionCompleted(object sender, EventArgs e)
        {
            desc = ((Entry)sender).Text;
        }

        void BrandCompleted(object sender, EventArgs e)
        {
            brand = ((Entry)sender).Text;
        }

        void ItemNameCompleted(object sender, EventArgs e)
        {
            itemName = ((Entry)sender).Text;
        }


        void TypeCompleted(object sender, EventArgs e)
        {
            type = ((Entry)sender).Text;
        }

        


        void CostCompleted(object sender, EventArgs e)
        {
            cost =  Convert.ToDouble(((Entry)sender).Text);
        }

        void ReplacementCompleted(object sender, EventArgs e)
        {
            replacementCost = Convert.ToDouble(((Entry)sender).Text);
        }

        void DepositCompleted(object sender, EventArgs e)
        {
            deposit = Convert.ToDouble(((Entry)sender).Text);
        }

        void CityCompleted(object sender, EventArgs e)
        {
            city = ((Entry)sender).Text;
        }

        void StateCompleted(object sender, EventArgs e)
        {
            state = ((Entry)sender).Text;
        }
        void ZipCompleted(object sender, EventArgs e)
        {
           zip = ((Entry)sender).Text;
        }

        async void OnSubmitClicked(object sender, EventArgs e)
        {

            bool success;
           success= RASQLManager.sqlManagerInstance.CreateItemListing(itemName, desc, brand, type, cost, replacementCost, deposit);
            if (success)
            {
                await Navigation.PushAsync(new NewListingPage()); //need to add Listing creation here
            }
            else
                await Navigation.PushAsync(new ErrorPage(4));  
        }

    }
}