using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PageObjects
{
    public class MenuPage : WebPage
    {
        protected const string SELECTOR_CLASS_LOGIN_BTN = "login";
        protected const string SELECTOR_CLASS_MY_ACCOUNT_BTN = "account";        
        protected const string SELECTOR_ID_EMAIL_ADDRESS_FIELD_SIGN_IN = "email";
        protected const string SELECTOR_ID_HOMEPAGE_LOGO = "header_logo";
        protected const string SELECTOR_CLASS_CATEGORY_NAME = "category-name";
        protected const string SELECTOR_CLASS_PAGE_NAME = "navigation_page";
        protected const string SELECTOR_ID_PRODUCT_MENU = "block_top_menu";

        public override string PAGE_TITLE { get { return "Dont want one in this class, assess options"; } set { } }

        public MenuPage(IWebDriver Driver) : base(Driver)
        {
        }

        //ensure that this logo is visible from all pages
        public HomePage GoToHomePage()
        {
            var homePageLogo = GetWebElement(By.Id(SELECTOR_ID_HOMEPAGE_LOGO));
            ClickElement(homePageLogo);

            var HomePage = new HomePage(Driver);
            HomePage.WaitUntilPageHasLoaded();

            return HomePage;
        }

        public LoginPage GoToLoginPage()
        {
            var loginPageBtn = GetWebElement(By.ClassName(SELECTOR_CLASS_LOGIN_BTN));
            ClickElement(loginPageBtn);

            var LoginPage = new LoginPage(Driver);
            LoginPage.WaitUntilPageHasLoaded();

            return LoginPage;
        }

        public DressesPage GoToDressesPage()
        {
            var menu = GetWebElement(By.Id(SELECTOR_ID_PRODUCT_MENU));

            var menuList = menu.FindElements(By.TagName("li"));

            foreach(var element in menuList)
            {
                if (element.Text.Equals("DRESSES"))
                {
                    ClickElement(element);
                    break;
                }
            }

            var DressesPage = new DressesPage(Driver);
            DressesPage.WaitUntilPageHasLoaded();

            return DressesPage;
        }

        public MyAccountPage GoToMyAccountPage()
        {
            var myAccountBtn = GetWebElement(By.ClassName(SELECTOR_CLASS_MY_ACCOUNT_BTN));
            ClickElement(myAccountBtn);

            var MyAccountPage = new MyAccountPage(Driver);
            MyAccountPage.WaitUntilPageHasLoaded();

            return MyAccountPage;
        }          
    }
}
