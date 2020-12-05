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
        public string desc, brand, type, cost;
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


        void TypeCompleted(object sender, EventArgs e)
        {
            type = ((Entry)sender).Text;
        }


        void CostCompleted(object sender, EventArgs e)
        {
            cost = ((Entry)sender).Text;
        }

        async void OnSubmitClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewListingPage()); //need to add Listing creation here
        }

    }
}