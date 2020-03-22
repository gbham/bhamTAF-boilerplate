using NUnit.Framework;
using PageObjects;


namespace bhamTAF
{
    [TestFixture]
    public class SendMessageToCustomerServiceTest : IntegrationTest
    {
        [Test]  
        public void SendMessageToCustomerService()
        {
            var Menu = LoadSite();
            var LoginPage = Menu.GoToLoginPage();

            LoginPage.EnterEmailAddress()
                     .EnterPassword()
                     .ClickLogin();

            var ContactUsPage = Menu.GoToContactUsPage();

            ContactUsPage.SelectSubjectHeading("Webmaster")
                         .SelectOrderRefernce()
                         .EnterMessage("test message")
                         .AttachFile("C:\\test.txt")
                         .Send();            

            var ExpectedMessage = "Your message has been successfully sent to our team.";
            var ActualMessage = ContactUsPage.GetActualMessage();

            Assert.AreEqual(ExpectedMessage, ActualMessage);            

        }
    }
}