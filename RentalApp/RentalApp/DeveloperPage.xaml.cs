using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using RentalsApp;


namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeveloperPage : ContentPage
    {
        public DeveloperPage()
        {
            InitializeComponent();
			string result = locationList();
			//   LocList.ItemsSource = lis;
			//LocationDisplay.Text = result;
			//ItemDisplay.Text = GetItems();
		}

		async void OnClick(Object sender, EventArgs e)
        {
			var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
			{
				Title = "Please pick a photo"
			});
			var stream = await result.OpenReadAsync();

			resultImage.Source = ImageSource.FromStream(() => stream);

        }

		string locationList()
		{
			string user = "Den1S80";
			List<RentalsApp.DBObjects.Location> listy;

			listy = RASQLManager.sqlManagerInstance.GetLocations(user);// need to fix this 
			string toReturn = "";

			foreach (RentalsApp.DBObjects.Location location in listy)
			{

				toReturn = toReturn + " " + location.name + " " + location.city + " " + location.state + " " + location.zipCode + "\n";
			}
			return toReturn;
		}

		string GetItems()
		{
			List<RentalsApp.DBObjects.ItemListing> listy;
			listy = RASQLManager.sqlManagerInstance.GetAllItems();
			string toReturn = "";
			foreach (RentalsApp.DBObjects.ItemListing item in listy)
			{
				//RentalsApp.DBObjects.ItemListing info = item.listingInfo;

				toReturn = toReturn + " " + item.itemNum + " " + item.brand + " " + item.description + "\n";
			}
			return toReturn;
		}
	}
}
