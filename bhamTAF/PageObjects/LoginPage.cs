using OpenQA.Selenium;
using System;

namespace PageObjects
{
    public class LoginPage : WebPage
    {
        private const string SELECTOR_ID_EMAIL_ADDRESS_FIELD_REGISTER = "email_create";
        private const string SELECTOR_ID_CREATE_ACCOUNT_BTN = "SubmitCreate";

        private string RANDOM_EMAIL_ADDRESS = $"{Guid.NewGuid()}@test.com";

        public LoginPage(IWebDriver Driver) : base(Driver)
        {            
        }

        public LoginPage TypeEmailAddress()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_EMAIL_ADDRESS_FIELD_REGISTER));
            EnterText(element, RANDOM_EMAIL_ADDRESS);            

            return this;
        }

        public RegisterPage ClickCreateAccount()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_CREATE_ACCOUNT_BTN));
            ClickElement(element);            

            return new RegisterPage(Driver);
        }
    }
}
