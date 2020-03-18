using OpenQA.Selenium;
using System;
using System.Threading;

namespace PageObjects
{
    public class OrderHistoryPage : WebPage
    {
        const string SELECTOR_CSS_ROW_ONE_ORDER_REFERENCE = "#order-list > tbody > tr.first_item > td.history_link.bold.footable-first-column > a";

        public OrderHistoryPage(IWebDriver Driver) : base(Driver)
        {            
        }

        public override string PAGE_TITLE { get { return "My account - My Store"; } set { } }

        public string GetMostRecentOrderReference()
        {
            var orderReference = GetWebElement(By.CssSelector(SELECTOR_CSS_ROW_ONE_ORDER_REFERENCE)).Text;

            return orderReference;
        }
    }
}
