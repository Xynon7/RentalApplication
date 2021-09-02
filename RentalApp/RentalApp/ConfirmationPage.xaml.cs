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
        string ItemOwner;
        string itemNumber;
        DateTime exchangeD;
        StackLayout parent;
        RentalsApp.DBObjects.ItemListing myItem;
        RentalsApp.DBObjects.Location Loc4Exchange;
        public ConfirmationPage(RentalsApp.DBObjects.ItemListing item)
        {
            InitializeComponent();
            ItemOwner=RASQLManager.sqlManagerInstance.GetUserFromItem(item.itemNum);
            itemNumber = item.itemNum;
            ItemConfirm.Text = "Would you like to rent the: " + item.description;
            myItem = item;
            List<RentalsApp.DBObjects.ItemImage> ImageList;
            int ItemNumber = int.Parse(item.itemNum);
            //if (item.itemImages.Count > 0)
           // {
                //  ItemImage = item.itemImages[0].image;
          //      parent.Children.Add(item.itemImages[0].image);
          // }
            ImageList = RASQLManager.sqlManagerInstance.GetImagesForItem(ItemNumber);
            if (ImageList.Count > 0)
            {
                //Image myImage = new Image();
                //myImage.Source = ImageList[0].image.Source;
                ItemImage.Source= ImageList[0].image.Source;
               // parent.Children.Add(myImage);

            }
            Label itemOwner = new Label
            {
                Text = "Owned by user: " + ItemOwner
            };
            parent = layout;
            parent.Children.Add(itemOwner);
            
            CreateButtons();
        }


            

            async void OnConfirmClicked(object sender, EventArgs e)
        {
            //add functionality to exchange
            await Navigation.PushAsync(new HomePage());
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            exchangeD = ((DatePicker)sender).Date;
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
                    TextColor = Color.FromHex("#25B6D3"),
                    BackgroundColor = Color.White,
                    BorderWidth = 1.5,
                    BorderColor = Color.FromHex("#25B6D3"),
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 23
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

            confirm.Clicked += (sender, args) => RASQLManager.sqlManagerInstance.CreateExchange(RASQLManager.currentUser.username, ItemOwner, 
                                                                                                 itemNumber, Loc4Exchange.name, "PU", exchangeD);
            confirm.Clicked += async (sender, args) => await Navigation.PushAsync(new HomePage());
            parent = layout;
            parent.Children.Add(confirm);

        }
            
    }
}