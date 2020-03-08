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
            var HomePage = new HomePage(driver);
            HomePage.LoadSite();

            HomePage.GoToLoginPage();

            HomePage.GoToHomePage();

            HomePage.GoToLoginPage();
        }

        [Test]
        public void ValidateAccountCreationError_ScenarioOne()
        {
            var HomePage = new HomePage(driver);
            HomePage.LoadSite();

            var LoginPage = HomePage.GoToLoginPage();

            var RegisterPage = LoginPage.TypeEmailAddress()
                                        .ClickCreateAccount();

            RegisterPage.ClickRadioBtnForMr()
                        .TypeFirstName(firstname)
                        .TypeSurnameName(surname)
                        //TODO
                        .EnterRandomDOB()
                        .ClickRegister();

            var expectedErrors = "You must register at least one phone number. passwd is required. address1 is required. " +
                                 "city is required. The Zip/Postal code you've entered is invalid. It must follow this format" +
                                 ":  This country requires you to choose a State.";

            var actualErrors = RegisterPage.GetActualErrors();        

            Assert.AreEqual(expectedErrors, actualErrors);

            Thread.Sleep(2500);

        }
    }
}