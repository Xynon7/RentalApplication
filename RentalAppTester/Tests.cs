using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using RentalApp;
using RentalsApp;

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
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void CheckConnectionThroughInvalidLogin()
        {
            bool isValidLogin = RASQLManager.sqlManagerInstance.ValidateLogin("", "");
            Assert.IsFalse(isValidLogin, "Login should not have been valid");
        }
    }
}
