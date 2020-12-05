using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using RentalApp;
using RentalsApp;
using RentalsApp.DBObjects;
using System.Collections.Generic;

namespace RentalAppTester
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        public void CheckInvalidLoginFunctionality()
        {
            bool isValidLogin = RASQLManager.sqlManagerInstance.ValidateLogin("", "");
            Assert.IsFalse(isValidLogin, "Login should not have been valid");
        }

        [Test]
        public void CheckValidLoginFunctionality()
        {
            bool isValidLogin = RASQLManager.sqlManagerInstance.ValidateLogin("Den1S80", "Belloto9021");
            Assert.IsTrue(isValidLogin, "Login should have been valid");
        }

        [Test]
        public void CheckMessagesSentFunctionality()
        {
            List<Communication> messages = RASQLManager.sqlManagerInstance.GetMessagesSent("Jnnife016");
            Assert.IsFalse(messages.Count == 0, "Message list should not be empty");
        }

        [Test]
        public void CheckMessagesReceivedFunctionality()
        {
            List<Communication> messages = RASQLManager.sqlManagerInstance.GetMessagesReceived("Den1S80");
            Assert.IsFalse(messages.Count == 0, "Message list should not be empty");
        }

        [Test]
        public void CheckAccountCreationAndDeletion()
        {
            string testUsername = "TestingPerson";
            string testPassword = "TestingPerson";
            if (RASQLManager.sqlManagerInstance.ValidateLogin(testUsername, testPassword))
            {
                RASQLManager.sqlManagerInstance.Logout();
                Assert.IsTrue(RASQLManager.sqlManagerInstance.DeleteAccount(testUsername), "Failed Account Deletion");
            }
            Assert.IsTrue(RASQLManager.sqlManagerInstance.CreateNewAccount(testUsername, testPassword, "Ma", "(111) 111-1111", "OK", "1111111111", DateTime.Now, "Name", "M", "NotName"), "Failed Account Creation");
            Assert.IsTrue(RASQLManager.sqlManagerInstance.ValidateLogin(testUsername, testPassword), "Failed Account Login");
            RASQLManager.sqlManagerInstance.Logout();
            Assert.IsTrue(RASQLManager.sqlManagerInstance.DeleteAccount(testUsername), "Failed Account Deletion");
        }

        [Test]
        public void CheckItemCreationAndDeletion()
        {
            RASQLManager.sqlManagerInstance.ValidateLogin("Den1S80", "Belloto9021");
            Assert.IsTrue(RASQLManager.sqlManagerInstance.CreateItemListing("Description", "Brand", "Type", 0.0, 0.0, 0.0, new Dictionary<string, string>(), new List<string>()), "Failed Item Creation");
            Assert.IsTrue(RASQLManager.sqlManagerInstance.DeleteAllItemsFromUser("Den1S80"), "Failed Item Deletion");
            RASQLManager.sqlManagerInstance.Logout();
        }
    }
}
