using NUnit.Framework;
using PageObjects;
using System;
using System.Threading;

namespace bhamTAF
{
    [TestFixture]
    public class AccountCreationTest : IntegrationTest
    {
        [Test]
        public void ValidateAccountCreation()
        {
            var HomePage = LoadSite();
            var LoginPage = HomePage.GoToLoginPage();

            var RegisterPage = LoginPage.EnterNewEmailAddress()
                                        .ClickCreateAccount();

            var AccountPage = RegisterPage.ClickRadioBtnForMr()
                                          .EnterFirstname(firstname)
                                          .EnterSurname(surname)
                                          .EnterPassword(password)
                                          .EnterRandomDOB()
                                          .ClickSignUpForNewsletterCheckbox()
                                          .EnterAddress(address)
                                          .EnterCity(city)
                                          .EnterState(state)
                                          .EnterPostcode(postcode)
                                          .EnterMobile(mobile)
                                          .ClickRegister();

            var ExpectedAccountPageTitle = AccountPage.GetExpectedPageTitle();
            var AccountPageTitle = AccountPage.GetPageTitle();

            Assert.AreEqual(ExpectedAccountPageTitle, AccountPageTitle);

        }

        [Test]
        public void ValidateAccountCreationError_ScenarioOne()
        {
            var HomePage = LoadSite();
            var LoginPage = HomePage.GoToLoginPage();

            var RegisterPage = LoginPage.EnterNewEmailAddress()
                                        .ClickCreateAccount();

            RegisterPage.ClickRadioBtnForMr()
                        .EnterFirstname(firstname)
                        .EnterSurname(surname)
                        .EnterRandomDOB()
                        .ClickRegisterExpectingError();

            var ExpectedErrors = "You must register at least one phone number. passwd is required. address1 is required. " +
                                 "city is required. The Zip/Postal code you've entered is invalid. It must follow this format" +
                                 ":  This country requires you to choose a State.";

            var ActualErrors = RegisterPage.GetActualErrors();

            Assert.AreEqual(ExpectedErrors, ActualErrors);

        }
    }
}