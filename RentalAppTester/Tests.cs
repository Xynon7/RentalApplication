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
    }
}
