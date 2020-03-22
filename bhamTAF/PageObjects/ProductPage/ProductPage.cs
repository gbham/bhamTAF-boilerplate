using OpenQA.Selenium;

namespace PageObjects
{
    public class ProductPage : WebPage
    {
        private const string SELECTOR_CLASS_WRITE_REVIEW = "open-comment-form";
        
        public ProductPage(IWebDriver Driver) : base(Driver)
        {
        }

        public WriteReviewDialog ClickWriteReviewbtn()
        {
            var element = GetWebElement(By.ClassName(SELECTOR_CLASS_WRITE_REVIEW));
            ClickElement(element);

            return new WriteReviewDialog(Driver);
        }
    }
}
