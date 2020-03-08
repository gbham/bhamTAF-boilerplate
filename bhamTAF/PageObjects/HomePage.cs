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

        public HomePage(IWebDriver Driver)
        {
            driver = Driver;
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
        }        

        public void LoadSite()
        {
            driver.Navigate().GoToUrl(HOME_URL);

            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_HOMEPAGE_LOGO));
        }        

        public HomePage GoToHomePage()
        {
            var homePageLogo = GetWebElement(By.Id(SELECTOR_ID_HOMEPAGE_LOGO));
            ClickElement(homePageLogo);            

            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_HOMEPAGE_LOGO));

            return new HomePage(driver);
        }

        public LoginPage GoToLoginPage()
        {
            var LoginPageBtn = GetWebElement(By.ClassName(SELECTOR_CLASS_LOGIN_BTN));
            ClickElement(LoginPageBtn);            

            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_EMAIL_ADDRESS_FIELD_SIGN_IN));

            return new LoginPage(driver);
        }
    }
}
