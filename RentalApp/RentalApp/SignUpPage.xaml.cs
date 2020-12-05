using RentalsApp;
using System;
using RentalApp;
using System.Linq;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
        public string username, password, gender, phoneNumber, stateId, sSN, FirstName, middleInitial, LastName;
        DateTime DOB;


        public SignUpPage()
        {
            InitializeComponent();
            //  BindingContext = AddUserViewModel();
        }

        void FirstName_Completed(object sender, EventArgs e)
        {
            FirstName = ((Entry)sender).Text;
        }

        void LastName_Completed(object sender, EventArgs e)
        {
            LastName = ((Entry)sender).Text;
        }

        private void Email_Completed(object sender, EventArgs e)
        {

        }

        void MiddleInitial_Completed(object sender, EventArgs e)
        {
            middleInitial = ((Entry)sender).Text;
        }

        void Username_Completed(object sender, EventArgs e)
        {
            username = ((Entry)sender).Text;
        }

        void Password_Completed(object sender, EventArgs e)
        {
            password = ((Entry)sender).Text;
        }

        void Gender_Completed(object sender, EventArgs e)
        {
            gender = ((Entry)sender).Text;
        }

        void PhoneNumber_Completed(object sender, EventArgs e)
        {
            phoneNumber = ((Entry)sender).Text;
        }

        void StateID_Completed(object sender, EventArgs e)
        {
            stateId = ((Entry)sender).Text;
        }

        void OnDateSelected(object sender, EventArgs e)
        {
            DOB = ((DatePicker)sender).Date; //this aint rite
        }


        void SSN_Completed(object sender, EventArgs e)
        {
            sSN = ((Entry)sender).Text;
        }
        async void OnSignUpAppClicked(object sender, EventArgs e)
        {




            bool success = RASQLManager.sqlManagerInstance.CreateNewAccount(username, password, gender, phoneNumber, stateId, sSN, DOB, FirstName, middleInitial, LastName);
            
            if (success)
            {
                await Navigation.PushAsync(new SignUpPage2());
            }
            else
            {
                await Navigation.PushAsync(new SignUpPage());
            }
            //should prob do error stuff too 
        }
    }
}