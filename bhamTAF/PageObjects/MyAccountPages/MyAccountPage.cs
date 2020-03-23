using OpenQA.Selenium;

namespace PageObjects
{
    public class MyAccountPage : WebPage
    {
        private const string SELECTOR_CSS_ORDER_HISTORY = "#center_column > div > div:nth-child(1) > ul > li:nth-child(1) > a";

        protected override string PAGE_TITLE { get { return "My account - My Store"; } set { } }

        public MyAccountPage(IWebDriver Driver) : base(Driver)
        {            
        }
        
        public OrderHistoryPage ClickOrderHistory()
        {
            var element = GetWebElement(By.CssSelector(SELECTOR_CSS_ORDER_HISTORY));
            ClickElement(element);

            var OrderHistoryPage = new OrderHistoryPage(Driver);
            OrderHistoryPage.WaitUntilPageHasLoaded();

            return OrderHistoryPage;
        }        
    }
}
