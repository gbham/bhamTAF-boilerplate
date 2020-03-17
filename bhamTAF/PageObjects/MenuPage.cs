using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PageObjects
{
    public class MenuPage : WebPage
    {
        protected const string SELECTOR_CLASS_LOGIN_BTN = "login";
        protected const string SELECTOR_ID_EMAIL_ADDRESS_FIELD_SIGN_IN = "email";
        protected const string SELECTOR_ID_HOMEPAGE_LOGO = "header_logo";
        protected const string SELECTOR_CLASS_CATEGORY_NAME = "category-name";

        public MenuPage(IWebDriver Driver) : base(Driver)
        {
        }

        //ensure that this logo is visible from all pages
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

        public DressesPage GoToDressesPage()
        {
            var menu = GetWebElement(By.Id("block_top_menu"));

            var menuList = menu.FindElements(By.TagName("li"));

            foreach(var element in menuList)
            {
                if (element.Text.Equals("DRESSES"))
                {
                    ClickElement(element);
                    break;
                }
            }

            WaitUntilDressesPageHasLoaded();

            return new DressesPage(Driver);
        }

        //Make more of these for each page, what is serving the purpose above wont work long term since the selectors arent unique
        //may need to extract this somewhere more specific
        public void WaitUntilDressesPageHasLoaded()
        {
            GetWaitForFiveSeconds().Until(d =>
            {                
                var pageTitle = GetWebElement(By.ClassName(SELECTOR_CLASS_CATEGORY_NAME)).Text;
                                      
                if(pageTitle.Equals("Dresses"))
                {
                    return true;
                }                

                return false;
            });
        }
    }
}
