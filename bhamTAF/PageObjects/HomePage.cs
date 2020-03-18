using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace PageObjects
{
    public class HomePage : WebPage
    {
        protected const string HOME_URL = "http://www.automationpractice.com";
        protected const string SELECTOR_ID_HOMEPAGE_LOGO = "header_logo";
        public override string PAGE_TITLE { get { return "My Store"; } set { } }

        public HomePage(IWebDriver Driver): base(Driver)
        {           
        }        

        public void LoadSite()
        {
            Driver.Navigate().GoToUrl(HOME_URL);
            Driver.Manage().Window.Maximize();

            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_HOMEPAGE_LOGO));
        }     
    }
}
