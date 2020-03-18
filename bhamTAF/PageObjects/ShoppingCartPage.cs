using OpenQA.Selenium;
using System;
using System.Threading;

namespace PageObjects
{
    public class ShoppingCartPage : WebPage
    {  
        private const string SELECTOR_CSS_PROCEED_TO_CHECKOUT_BTN_SUMMARY_SECTION = "#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium";
        private const string SELECTOR_CSS_PROCEED_TO_CHECKOUT_BTN_ADDRESS_SECTION = "#center_column > form > p > button";
        private const string SELECTOR_CSS_PROCEED_TO_CHECKOUT_BTN_SHIPPING_SECTION = "#form > p > button";

        private const string SELECTOR_ID_TERMS_OF_SERVICE_CHECKBOX = "cgv";
        private const string SELECTOR_CSS_PAY_BY_BANK_WIRE_BTN = "#HOOK_PAYMENT > div:nth-child(1) > div > p > a";
        private const string SELECTOR_CSS_CONFRIM_ORDER_BTN = "#cart_navigation > button";

        public override string PAGE_TITLE { get { return "ShoppingCartPage"; } set { } }

        public ShoppingCartPage(IWebDriver Driver) : base(Driver)
        {
        }

        internal ShoppingCartPage ClickProceedToCheckout_SummarySection()
        {
            var element = GetWebElement(By.CssSelector(SELECTOR_CSS_PROCEED_TO_CHECKOUT_BTN_SUMMARY_SECTION));
            ClickElement(element);

            return this;
        }        

        //will need a function for "ClickProceedToCheckout_SIGN_IN()" eventually but that stage is skipped in the test since we are signed in already

        internal ShoppingCartPage ClickProceedToCheckout_AddressSection()
        {
            var element = GetWebElement(By.CssSelector(SELECTOR_CSS_PROCEED_TO_CHECKOUT_BTN_ADDRESS_SECTION));
            ClickElement(element);

            return this;
        }

        public ShoppingCartPage ClickProceedToCheckout_ShippingSection()
        {
            var element = GetWebElement(By.CssSelector(SELECTOR_CSS_PROCEED_TO_CHECKOUT_BTN_SHIPPING_SECTION));
            ClickElement(element);

            return this;
        }

        public ShoppingCartPage EnterRandomCommentAboutOrder()
        {
            var element = GetWebElement(By.ClassName("form-control"));
            EnterText(element, "test");

            Thread.Sleep(4000);

            return this;
        }

        public ShoppingCartPage ClickTermsOfServiceCheckbox()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_TERMS_OF_SERVICE_CHECKBOX));
            ClickElement(element);

            return this;
        }

        public ShoppingCartPage ClickPayByBankWire()
        {
            var element = GetWebElement(By.CssSelector(SELECTOR_CSS_PAY_BY_BANK_WIRE_BTN));
            ClickElement(element);

            return this;
        }

        public ShoppingCartPage ClickConfirmOrder()
        {
            var element = GetWebElement(By.CssSelector(SELECTOR_CSS_CONFRIM_ORDER_BTN));
            ClickElement(element);

            return this;
        }

        public string GetOrderReference()
        {
            var infoBox = GetWebElement(By.ClassName("box")).Text;
            var index = infoBox.IndexOf("reference");            
            var orderReference = infoBox.Substring(index + 10, 9);

            return orderReference;
        }
    }
}
