using NUnit.Framework;
using PageObjects;
using System.Threading;

namespace bhamTAF
{
    [TestFixture]
    public class Tests : IntegrationTest
    {        
        [Test]
        public void Test1()
        {
            var HomePage = new HomePage(Driver);
            HomePage.LoadSite();

            HomePage.GoToLoginPage();

            HomePage.GoToHomePage();

            HomePage.GoToLoginPage();
        }

        [Test]
        public void ValidateAccountCreation()
        {
            var HomePage = new HomePage(Driver);
            HomePage.LoadSite();

            var LoginPage = HomePage.GoToLoginPage();

            var RegisterPage = LoginPage.TypeEmailAddress()
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

            var ExpectedAccountPageTitle = "My account - My Store";
            var AccountPageTitle = AccountPage.GetAccountPageTitle();

            Assert.AreEqual(ExpectedAccountPageTitle, AccountPageTitle);

        }

        [Test]
        public void ValidateAccountCreationError_ScenarioOne()
        {
            var HomePage = new HomePage(Driver);
            HomePage.LoadSite();

            var LoginPage = HomePage.GoToLoginPage();

            var RegisterPage = LoginPage.TypeEmailAddress()
                                        .ClickCreateAccount();

            RegisterPage.ClickRadioBtnForMr()
                        .EnterFirstname(firstname)
                        .EnterSurname(surname)
                        .EnterRandomDOB()
                        .ClickRegister();

            var ExpectedErrors = "You must register at least one phone number. passwd is required. address1 is required. " +
                                 "city is required. The Zip/Postal code you've entered is invalid. It must follow this format" +
                                 ":  This country requires you to choose a State.";

            var ActualErrors = RegisterPage.GetActualErrors();

            Assert.AreEqual(ExpectedErrors, ActualErrors);

        }
    }
}