using NUnit.Framework;
using PageObjects;

namespace bhamTAF
{
    [TestFixture]
    public class ProductReviewTest : IntegrationTest
    {
        [Test]
        public void ProductReview()
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
                             .SelectStarRating("1")
                             .ClickSend();                                         

            var expectedMessage = "Your comment has been added and will be available once approved by a moderator";
            var actualMessage = WriteReviewDialog.GetActualMessage();

            Assert.AreEqual(expectedMessage, actualMessage);

        }        
    }
}