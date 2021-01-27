using RentalsApp.DBObjects;
using System;
using System.Collections.Generic;

namespace RentalsApp.DBObjects
{
    public class User
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
        public bool agreedToTC;
        public bool agreedToPP;
        public bool agreedToSP;
        private List<Location> locations;
        private List<Communication> messagesReceived;
        private List<Communication> messagesSent;
        private List<Invoice> invoices;
        private List<Exchange> exchanges;
        private List<WishlistItem> wishlistItems;
        private Cart cart;

        public User(string Username, string Gender, string PhoneNumber, string StateId, string SSN, DateTime DOB, string FirstName, string MiddleInitial, string LastName, bool AgreedTC, bool AgreedPP, bool AgreedSP)
        {
            username = Username;
            gender = Gender;
            phoneNumber = PhoneNumber;
            stateId = StateId;
            ssn = SSN;
            dateOfBirth = DOB;
            firstName = FirstName;
            middleInitial = MiddleInitial;
            lastName = LastName;
            agreedToTC = AgreedTC;
            agreedToPP = AgreedPP;
            agreedToSP = AgreedSP;
    }

        public List<Location> RetrieveLocations()
        {
            PopulateLocations();
            return locations;
        }

        public List<Communication> RetrieveMessagesReceived()
        {
            PopulateMessagesSent();
            return messagesSent;
        }

        public List<Communication> RetrieveMessagesSent()
        {
            PopulateMessagesReceived();
            return messagesReceived;
        }

        public Cart RetrieveCart()
        {
            PopulateCart();
            return cart;
        }

        public List<Invoice> RetrieveInvoices()
        {
            PopulateInvoices();
            return invoices;
        }

        public List<Exchange> RetrieveExchanges()
        {
            PopulateExchanges();
            return exchanges;
        }

        public List<WishlistItem> RetrieveWishlist()
        {
            PopulateWishlist();
            return wishlistItems;
        }

        private void PopulateLocations()
        {
            locations = RASQLManager.sqlManagerInstance.GetLocations(username);
        }

        private void PopulateMessagesReceived()
        {
            messagesReceived = RASQLManager.sqlManagerInstance.GetMessagesReceived(username);
        }

        private void PopulateMessagesSent()
        {
            messagesSent = RASQLManager.sqlManagerInstance.GetMessagesSent(username);
        }

        private void PopulateCart()
        {
            cart = RASQLManager.sqlManagerInstance.GetCart(username);
        }

        private void PopulateInvoices()
        {
            invoices = RASQLManager.sqlManagerInstance.GetInvoices(username);
        }

        private void PopulateExchanges()
        {
            exchanges = RASQLManager.sqlManagerInstance.GetExchanges(username);
        }

        private void PopulateWishlist()
        {
            wishlistItems = RASQLManager.sqlManagerInstance.GetWishlist(username);
        }
    }
}