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
    public partial class ErrorPage : ContentPage
    {
        public ErrorPage(int ErrorNum)
        {
            InitializeComponent();
         ErrorDisplay.Text =   findErr(ErrorNum);
        }

        string findErr(int num)
        {
            switch (num)
            {
                case 1:
                    return "There was an error with creating this message";

                case 2:
                    return "If you do not agree to the Terms, Standards, and Privacy Policies then you will be unable to sign up for this app";
                case 4:
                    return "There was a problem with this item listing";

            }

            return "";
        }
    }
}