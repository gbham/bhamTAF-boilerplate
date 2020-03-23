using OpenQA.Selenium;

namespace PageObjects
{
    public class WriteReviewDialog : ProductPage
    {        
        private const string SELECTOR_ID_COMMENT_BOX = "content";
        private const string SELECTOR_ID_TITLE_BOX = "comment_title";
        private const string SELECTOR_ID_SEND_BT = "submitNewMessage";
        private const string SELECTOR_CLASS_STAR_RATING = "star_content";
        private const string SELECTOR_CSS_CONFIRMATION_MSG = "#product > div.fancybox-wrap.fancybox-desktop.fancybox-type-html.fancybox-opened > div > div > div > p:nth-child(2)";

        public WriteReviewDialog(IWebDriver Driver) : base(Driver)
        {

        }

        public WriteReviewDialog EnterReviewTitle()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_TITLE_BOX));
            EnterText(element, "test");

            return this;
        }

        public WriteReviewDialog SelectStarRating(string rating)
        {
            var element = GetWebElement(By.ClassName(SELECTOR_CLASS_STAR_RATING));
            var ListOfStars = element.FindElements(By.TagName("a"));

            foreach (var star in ListOfStars)
            {
                if(star.GetAttribute("title").Equals(rating))
                {
                    star.Click();
                    break;
                }
            }

            return this;
        }

        public WriteReviewDialog EnterReviewComment()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_COMMENT_BOX));
            EnterText(element, "test");

            return this;
        }

        public WriteReviewDialog ClickSend()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_SEND_BT));
            ClickElement(element);

            return this;
        }

        public string GetActualMessage()
        {
            var elementText = GetWebElement(By.CssSelector(SELECTOR_CSS_CONFIRMATION_MSG)).Text;

            return elementText;
        }
    }
}
