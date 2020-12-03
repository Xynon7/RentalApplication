namespace RentalsApp.DBObjects
{
    public class Location
    {
        public string name;
        public string city;
        public string state;
        public string zipCode;

        public Location(string Name, string City, string State, string ZipCode)
        {
            name = Name;
            city = City;
            state = State;
            zipCode = ZipCode;
        }
    }
}