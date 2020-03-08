using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace PageObjects
{
    public class HomePage : WebPage
    {
        private const string SELECTOR_ID_HOMEPAGE_LOGO = "header_logo";
        private const string SELECTOR_CLASS_LOGIN_BTN = "login";
        private const string SELECTOR_ID_EMAIL_ADDRESS_FIELD_SIGN_IN = "email";    

        const string HOME_URL = "http://www.automationpractice.com";

        public HomePage(IWebDriver Driver): base(Driver)
        {           
        }        

        public void LoadSite()
        {
            Driver.Navigate().GoToUrl(HOME_URL);

            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_HOMEPAGE_LOGO));
        }        

        public HomePage GoToHomePage()
        {
            var homePageLogo = GetWebElement(By.Id(SELECTOR_ID_HOMEPAGE_LOGO));
            ClickElement(homePageLogo);            

            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_HOMEPAGE_LOGO));

            return new HomePage(Driver);
        }

        public LoginPage GoToLoginPage()
        {
            var LoginPageBtn = GetWebElement(By.ClassName(SELECTOR_CLASS_LOGIN_BTN));
            ClickElement(LoginPageBtn);            

            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_EMAIL_ADDRESS_FIELD_SIGN_IN));

            return new LoginPage(Driver);
        }
    }
}
