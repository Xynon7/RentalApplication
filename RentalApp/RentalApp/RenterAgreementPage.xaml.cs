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
    public partial class RenterAgreementPage : ContentPage
    {
        public RenterAgreementPage()
        {
            InitializeComponent();
        }

        async void OnAgreeClicked(object sender, EventArgs e)
        {
            bool success = RASQLManager.sqlManagerInstance.ChangeAcceptedRA(true);
            if (success)
            {
                await Navigation.PushAsync(new RenterHubPage());
            }
            else 
            {
                //await Navigation.PushAsync(new ErrorPage(3));
                await Navigation.PushAsync(new RenterHubPage());
            }


        }

        async void OnDisagreeClicked(object sender, EventArgs e)
        {
            bool success = RASQLManager.sqlManagerInstance.ChangeAcceptedRA(false);
            if (success)
            {
                await Navigation.PushAsync(new LessorHubPage());
            }
            else await Navigation.PushAsync(new ErrorPage(3));
        }
    }
}