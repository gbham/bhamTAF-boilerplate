using NUnit.Framework;
using PageObjects;

namespace bhamTAF
{
    [TestFixture]
    public class BuyItemTest : IntegrationTest
    {
        [Test]
        public void BuyItemAndVerifyOrder()
        {
            var Menu = LoadSite();
            var LoginPage = Menu.GoToLoginPage();

            LoginPage.EnterEmailAddress()
                     .EnterPassword()
                     .ClickLogin();

            var ShoppingCartPage = Menu.GoToDressesPage()
                                       .AddItemToShoppingCart("Printed Dress")
                                       .ProceedToCheckout();

            var ExpectedOrderReference = ShoppingCartPage.ClickProceedToCheckout_SummarySection()
                                                         .EnterRandomCommentAboutOrder()
                                                         .ClickProceedToCheckout_AddressSection()
                                                         .ClickTermsOfServiceCheckbox()
                                                         .ClickProceedToCheckout_ShippingSection()
                                                         .ClickPayByBankWire()
                                                         .ClickConfirmOrder()
                                                         .GetOrderReference();

            var ActualOrderReference = Menu.GoToMyAccountPage()
                                            .ClickOrderHistory()
                                            .GetMostRecentOrderReference();

            Assert.AreEqual(ExpectedOrderReference, ActualOrderReference);   

        }
    }
}