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
        public void CheckConnectionThroughInvalidLogin()
        {
            bool isValidLogin = RASQLManager.sqlManagerInstance.ValidateLogin("", "");
            Assert.IsFalse(isValidLogin, "Login should not have been valid");
        }

        [Test]
        public void CheckMessagesReceivedRetrieval()
        {
            List<Communication> messages = RASQLManager.sqlManagerInstance.GetMessagesReceived("Den1S80");
            Assert.IsTrue(messages.Count > 0, "Messages should not have been empty");
        }

        [Test]
        public void CheckMessagesSentRetrieval()
        {
            List<Communication> messages = RASQLManager.sqlManagerInstance.GetMessagesSent("Jnnife016");
            Assert.IsTrue(messages.Count > 0, "Messages should not have been empty");
        }
    }
}
