using OpenQA.Selenium;
using System;

namespace PageObjects
{
    public class AccountPage : WebPage
    {
        public AccountPage(IWebDriver Driver) : base(Driver)
        {            
        }

        public string GetAccountPageTitle()
        {
            return Driver.Title;
        }
    }
}
