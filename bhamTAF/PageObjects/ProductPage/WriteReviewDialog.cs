using OpenQA.Selenium;

namespace PageObjects
{
    public class WriteReviewDialog : ProductPage
    {        
        const string SELECTOR_CSS_OK_BTN = "#product > div.fancybox-wrap.fancybox-desktop.fancybox-type-html.fancybox-opened > div > div > div > p.submit > button";
        const string SELECTOR_ID_COMMENT_BOX = "content";
        const string SELECTOR_ID_TITLE_BOX = "comment_title";
        const string SELECTOR_ID_SEND_BT = "submitNewMessage";

        public WriteReviewDialog(IWebDriver Driver) : base(Driver)
        {
        }

        public WriteReviewDialog EnterReviewTitle()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_TITLE_BOX));
            EnterText(element, "test");

            return this;
        }

        public WriteReviewDialog EnterReviewComment()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_COMMENT_BOX));
            EnterText(element, "test");

            return this;
        }

        public WriteReviewDialog AcceptConfirmationDialog()
        {
            var element = GetWebElement(By.CssSelector(SELECTOR_CSS_OK_BTN));
            ClickElement(element);

            VerifyElementIsInvisible(element);
            return this;

        }

        public WriteReviewDialog ClickSend()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_SEND_BT));
            ClickElement(element);

            return this;
        }
    }
}
