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

        StackLayout parent;
        RentalsApp.DBObjects.Location Loc4Exchange;
        public ConfirmationPage(RentalsApp.DBObjects.ItemListing item)
        {
            InitializeComponent();
            ItemConfirm.Text = "Would you like to rent the: " + item.description;
            CreateButtons();
        }


       

            async void OnConfirmClicked(object sender, EventArgs e)
        {
            //add functionality to exchange
            await Navigation.PushAsync(new HomePage());
        }

        void CreateButtons()
        {
            List<RentalsApp.DBObjects.Location> listy;
            listy = RASQLManager.sqlManagerInstance.GetLocations(RASQLManager.currentUser.username);
            foreach (RentalsApp.DBObjects.Location loc in listy)
            {
                string buttonTxt = loc.name + '\n' + loc.city + ", " +loc.state +", "+loc.zipCode;
                Button button = new Button
                {
                    Text = buttonTxt,
                    TextColor = Color.FromHex("#E29F10"),
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 18
                };
                button.Clicked += (sender, args) => Loc4Exchange = loc;

                parent = layout;
                parent.Children.Add(button);
            }


            Button confirm = new Button
            {
                Text = "Confirm",
                FontSize = 23
            };
            confirm.Clicked += async (sender, args) => await Navigation.PushAsync(new HomePage());
            parent = layout;
            parent.Children.Add(confirm);

        }
            
    }
}