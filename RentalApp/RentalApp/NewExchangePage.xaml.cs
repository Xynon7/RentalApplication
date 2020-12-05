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
    public partial class NewExchangePage : ContentPage
    {
        public string Ruser, Luser, itemnum, exchangeLoc, exchangeTime, pickOrDrop, Ragree, Lagree;
        public NewExchangePage()
        {
            InitializeComponent();
        }

        void RuserCompleted(object sender, EventArgs e)
        {
            Ruser = ((Entry)sender).Text;
        }

        void LuserCompleted(object sender, EventArgs e)
        {
            Luser = ((Entry)sender).Text;
        }
        void NumCompleted(object sender, EventArgs e)
        {
            itemnum = ((Entry)sender).Text;
        }


        void exchangeLocCompleted(object sender, EventArgs e)
        {
            exchangeLoc = ((Entry)sender).Text;
        }

        void exchangeTimeCompleted(object sender, EventArgs e)
        {
            exchangeTime = ((Entry)sender).Text;
        }

        void PickOrDropCompleted(object sender, EventArgs e)
        {
            pickOrDrop = ((Entry)sender).Text;
        }

        void RAgreeCompleted(object sender, EventArgs e)
        {
            Ragree = ((Entry)sender).Text;
        }
        void LAgreeCompleted(object sender, EventArgs e)
        {
            Lagree= ((Entry)sender).Text;
        }

       async void OnSubmitClicked(object sender, EventArgs e)
        {
            //need to create a new exchange
            await Navigation.PushAsync(new NewExchangePage());
        }
    }
}