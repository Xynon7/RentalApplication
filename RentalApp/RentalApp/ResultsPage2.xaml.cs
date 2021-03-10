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
    public partial class ResultsPage2 : ContentPage
    {
        StackLayout parent;
        public ResultsPage2()
        {
            InitializeComponent();
            CreateButtons();
        }



        void CreateButtons()
        {
            List<RentalsApp.DBObjects.ItemListing> listy;
            listy = RASQLManager.sqlManagerInstance.GetAllItems();

            foreach (RentalsApp.DBObjects.ItemListing item in listy)
            {
                //  string buttonTxt = item.itemNum + " " + item.brand + " " + item.description;
                string buttonTxt = item.description + " Brand: " + item.brand ;
                Button button = new Button
                {

                    Text = buttonTxt,
                    TextColor = Color.FromHex("#E29F10"),
                    FontAttributes=FontAttributes.Bold,
                    FontSize=23

                };
                button.Clicked += async (sender, args) => await Navigation.PushAsync(new ConfirmationPage(item));

                parent = layout;
                parent.Children.Add(button);
            }
        }
    }
}