using OpenQA.Selenium;
using System;

namespace PageObjects
{
    public class MyAccountPage : WebPage
    {
        private const string SELECTOR_CSS_ORDER_HISTORY = "#center_column > div > div:nth-child(1) > ul > li:nth-child(1) > a";

        public override string PAGE_TITLE { get { return "My account - My Store"; } set { } }

        public MyAccountPage(IWebDriver Driver) : base(Driver)
        {            
        }
        
        public OrderHistoryPage ClickOrderHistory()
        {
            var element = GetWebElement(By.CssSelector(SELECTOR_CSS_ORDER_HISTORY));
            ClickElement(element);

            return new OrderHistoryPage(Driver);
        }        
    }
}
