using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RentalsApp;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddImagePage : ContentPage
    {
        RentalsApp.DBObjects.ItemListing MyItem;
        public AddImagePage(RentalsApp.DBObjects.ItemListing listing)
        {
            InitializeComponent();
            MyItem = listing;
        }


        async void AddImageClicked(Object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });
            int itemNumber = int.Parse(MyItem.itemNum);
            bool AddedOrNah=RASQLManager.sqlManagerInstance.AddImage(itemNumber, result.FullPath, true);

            if (AddedOrNah){
                Console.WriteLine("Image added to the db");
            }
            else
            {
                Console.WriteLine("Image failed to add");
            }


            var stream = await result.OpenReadAsync();

            resultImage.Source = ImageSource.FromStream(() => stream);

        }
        async void OnHomeClicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

    }
}