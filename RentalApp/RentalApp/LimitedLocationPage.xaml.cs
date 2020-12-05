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
    public partial class LimitedLocationPage : ContentPage
    {
		public string name, address, city, state, zip;
		public LimitedLocationPage()
        {
            InitializeComponent();
        }

		void NameCompleted(object sender, EventArgs e)
		{
			name = ((Entry)sender).Text;
		}

		void AddressCompleted(object sender, EventArgs e)
		{
			address = ((Entry)sender).Text;
		}

		void StateCompleted(object sender, EventArgs e)
		{
			state = ((Entry)sender).Text;
		}

		void ZipCompleted(object sender, EventArgs e)
		{
			zip = ((Entry)sender).Text;
		}

		void CityCompleted(object sender, EventArgs e)
		{
			city = ((Entry)sender).Text;
		}

		async void OnAddLocationClicked(object sender, EventArgs e)
		{
			bool success = RASQLManager.sqlManagerInstance.CreateLocation(name, address, city, state, zip);
			if (success)
			{
				await Navigation.PopAsync();
			}
			else
				await Navigation.PushAsync(new ErrorPage(3));
		}
	}
}