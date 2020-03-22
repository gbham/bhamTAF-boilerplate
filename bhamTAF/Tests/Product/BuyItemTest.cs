using NUnit.Framework;
using PageObjects;
using System;
using System.Threading;

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

            var expectedOrderReference = ShoppingCartPage.ClickProceedToCheckout_SummarySection()
                                                 .EnterRandomCommentAboutOrder()
                                                 .ClickProceedToCheckout_AddressSection()
                                                 .ClickTermsOfServiceCheckbox()
                                                 .ClickProceedToCheckout_ShippingSection()
                                                 .ClickPayByBankWire()
                                                 .ClickConfirmOrder()
                                                 .GetOrderReference();

            var actualOrderReference = Menu.GoToMyAccountPage()
                                               .ClickOrderHistory()
                                               .GetMostRecentOrderReference();

            Assert.AreEqual(expectedOrderReference, actualOrderReference);   

        }
    }
}