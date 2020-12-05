using System.ComponentModel;
using Xamarin.Forms;

namespace RentalApp.ViewModels
{
    class AddLocationViewModel : INotifyPropertyChanged
    {

        public string name;
        public string city;
        public string state;
        public string zipCode;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddLocationViewModel()
        {
            AddLocationCommand = new Command(execute: () =>


                {
                    AddLocation(name, city, state, zipCode);
                });
        }


        public Command AddLocationCommand { get; }

        public void AddLocation(string Name, string City, string State, string ZipCode)
        {
         //   DBObject.Location.Location(Name, City, State, ZipCode);
        }


        public string Name
        {
            get { return name; }

            set
            {
                name = value;
            }
        }


        public string City
        {
            get { return city; }

            set
            {
                city = value;
            }
        }

        public string State
        {
            get { return state; }

            set
            {
                state = value;
            }
        }

        public string ZipCode
        {
            get { return zipCode; }

            set
            {
                zipCode = value;
            }
        }

    }
}
