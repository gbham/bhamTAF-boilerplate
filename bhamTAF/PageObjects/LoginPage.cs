using OpenQA.Selenium;
using System;

namespace PageObjects
{
    public class LoginPage : WebPage
    {
        private const string SELECTOR_ID_EMAIL_ADDRESS_FIELD_REGISTER = "email_create";
        private const string SELECTOR_ID_CREATE_ACCOUNT_BTN = "SubmitCreate";
        private const string SELECTOR_ID_EMAIL_ADDRESS_FIELD_LOGIN = "email";
        private const string SELECTOR_ID_PASSWORD_FIELD = "passwd";
        private const string SELECTOR_ID_LOGIN_BTN = "SubmitLogin";        
        private const string EMAIL_ADDRESS = "tester@random.com";
        private const string PASSWORD = "password";
        private string RANDOM_EMAIL_ADDRESS = $"{Guid.NewGuid()}@test.com";

        public override string PAGE_TITLE { get { return "Login - My Store"; } set { } }

        public LoginPage(IWebDriver Driver) : base(Driver)
        {
        }

        public LoginPage EnterNewEmailAddress()
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

        public LoginPage EnterEmailAddress()
        {            
            var element = GetWebElement(By.Id(SELECTOR_ID_EMAIL_ADDRESS_FIELD_LOGIN));
            EnterText(element, EMAIL_ADDRESS);

            return this;
        }

        public LoginPage EnterPassword()
        {
            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_PASSWORD_FIELD));

            var element = GetWebElement(By.Id(SELECTOR_ID_PASSWORD_FIELD));
            EnterText(element, PASSWORD);

            return this;
        }

        public LoginPage ClickLogin()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_LOGIN_BTN));
            ClickElement(element);

            return this;
        }
    }
}
