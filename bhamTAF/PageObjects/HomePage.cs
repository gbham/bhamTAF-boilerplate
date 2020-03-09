using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace PageObjects
{
    public class HomePage : WebPage
    { 
        const string HOME_URL = "http://www.automationpractice.com";

        public HomePage(IWebDriver Driver): base(Driver)
        {           
        }        

        public void LoadSite()
        {
            Driver.Navigate().GoToUrl(HOME_URL);

            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_HOMEPAGE_LOGO));
        }     
    }
}
