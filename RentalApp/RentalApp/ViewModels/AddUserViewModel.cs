using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
namespace RentalApp.ViewModels
{
    class AddUserViewModel : INotifyPropertyChanged
    {


        public string username;
        public string gender;
        public string phoneNumber;
        public string stateId;
        public string ssn;
        public DateTime dateOfBirth;
        public string firstName;
        public string middleInitial;
        public string lastName;


        public string Username
        { get { return username; }
           set
            {
                username = value;
            }
        }

        public string Gender
        {
            get { return gender; }

            set
            {
                gender = value;
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }

            set
            {
                phoneNumber = value;
            }
        }

        public string StateID
        {
            get { return stateId; }

            set
            {
                stateId = value;
            }
        }


        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }

            set
            {
                dateOfBirth = value;
            }
        }


        public string FirstName
        {
            get { return firstName; }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }

            set
            {
               lastName = value;
            }
        }

        public string MiddleInitial
        {
            get { return middleInitial; }

            set
            {
                middleInitial= value;
            }
        }


        public string SSN
        {
            get { return ssn; }

            set
            {
                ssn = value;
            }
        }



        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }


        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }


        public ICommand SubmitCommand { protected set; get; }
        public AddUserViewModel()
        {
            SubmitCommand = new Command(OnSubmit);

            AddUserCommand = new Command(execute: () =>

            {
                AddUser(username, gender, phoneNumber, stateId, ssn, dateOfBirth, firstName, middleInitial, lastName);
            });
        } 

        public Command AddUserCommand { get; }

       public  void AddUser(string Username, string Gender, string PhoneNumber, string StateId, string SSN, DateTime DOB, string FirstName, string MiddleInitial, string LastName)
        {
           // DBObject.User.User(Username, Gender, PhoneNumber, StateId, SSN, DOB, FirstName, MiddleInitial, LastName);
        }

        public void OnSubmit()
        {
            if (email != "macoratti@yahoo.com" || password != "secret")
            {
                
            }
        }

    }
}
