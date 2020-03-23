using OpenQA.Selenium;

namespace PageObjects
{
    public class MenuPage : WebPage
    {
        private const string SELECTOR_CLASS_LOGIN_BTN = "login";
        private const string SELECTOR_CLASS_MY_ACCOUNT_BTN = "account";
        private const string SELECTOR_ID_CONTACT_US = "contact-link";        
        private const string SELECTOR_ID_HOMEPAGE_LOGO = "header_logo";        
        private const string SELECTOR_ID_PRODUCT_MENU = "block_top_menu";

        protected override string PAGE_TITLE { get { return "Dont want one in this class, assess options"; } set { } }

        public MenuPage(IWebDriver Driver) : base(Driver)
        {
        }

        //ensure that this logo is visible from all pages
        public HomePage GoToHomePage()
        {
            var HomePageLogo = GetWebElement(By.Id(SELECTOR_ID_HOMEPAGE_LOGO));
            ClickElement(HomePageLogo);

            var HomePage = new HomePage(Driver);
            HomePage.WaitUntilPageHasLoaded();

            return HomePage;
        }

        public LoginPage GoToLoginPage()
        {
            var LoginPageBtn = GetWebElement(By.ClassName(SELECTOR_CLASS_LOGIN_BTN));
            ClickElement(LoginPageBtn);

            var LoginPage = new LoginPage(Driver);
            LoginPage.WaitUntilPageHasLoaded();

            return LoginPage;
        }

        public DressesPage GoToDressesPage()
        {
            var Menu = GetWebElement(By.Id(SELECTOR_ID_PRODUCT_MENU));
            var ProductList = Menu.FindElements(By.TagName("li"));

            foreach(var element in ProductList)
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
            var MyAccountBtn = GetWebElement(By.ClassName(SELECTOR_CLASS_MY_ACCOUNT_BTN));
            ClickElement(MyAccountBtn);

            var MyAccountPage = new MyAccountPage(Driver);
            MyAccountPage.WaitUntilPageHasLoaded();

            return MyAccountPage;
        }

        public ContactUsPage GoToContactUsPage()
        {
            var ContactUsBtn = GetWebElement(By.Id(SELECTOR_ID_CONTACT_US));
            ClickElement(ContactUsBtn);

            var ContactUsPage = new ContactUsPage(Driver);
            ContactUsPage.WaitUntilPageHasLoaded();

            return ContactUsPage;
        }
    }
}
