using OpenQA.Selenium;

namespace PageObjects
{
    public class OrderHistoryPage : WebPage
    {
        private const string SELECTOR_CSS_ROW_ONE_ORDER_REFERENCE = "#order-list > tbody > tr.first_item > td.history_link.bold.footable-first-column > a";

        protected override string PAGE_TITLE { get { return "Order history - My Store"; } set { } }

        public OrderHistoryPage(IWebDriver Driver) : base(Driver)
        {            
        }        

        public string GetMostRecentOrderReference()
        {
            var OrderReferenceText = GetWebElement(By.CssSelector(SELECTOR_CSS_ROW_ONE_ORDER_REFERENCE)).Text;

            return OrderReferenceText;
        }
    }
}
