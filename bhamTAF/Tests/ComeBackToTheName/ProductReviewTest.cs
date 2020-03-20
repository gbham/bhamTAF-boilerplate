using NUnit.Framework;
using PageObjects;
using System;
using System.Threading;

namespace bhamTAF
{
    [TestFixture]
    public class ProductReviewTest : IntegrationTest
    {
        [Test]
        public void LeaveReview()
        {
            var Menu = LoadSite();
            var LoginPage = Menu.GoToLoginPage();

            LoginPage.EnterEmailAddress()
                     .EnterPassword()
                     .ClickLogin();

            var ProductPage = Menu.GoToDressesPage()
                                  .ViewItem("Printed Summer Dress");

            var WriteReviewDialog = ProductPage.ClickWriteReviewbtn();

            WriteReviewDialog.EnterReviewTitle()
                             .EnterReviewComment()
                             .ClickSend()
                             .AcceptConfirmationDialog();

            Thread.Sleep(5000);

        }
    }
}