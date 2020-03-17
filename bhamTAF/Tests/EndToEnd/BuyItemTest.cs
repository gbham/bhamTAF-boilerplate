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

            ShoppingCartPage.ClickProceedToCheckout_SummarySection()
                            //Enter text into comment box
                            .ClickProceedToCheckout_AddressSection()
                            .ClickTermsOfServiceCheckbox()
                            .ClickProceedToCheckout_ShippingSection()
                            .ClickPayByBankWire()
                            .ClickConfirmOrder();
                            //Go to account
                            //Go to Order history
                            //Open most recent entry
                            //Verify product name equals the one that was bought, maybe verify other info in the confirmation notice


            Thread.Sleep(5000);
        }
    }
}