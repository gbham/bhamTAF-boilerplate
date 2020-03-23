using OpenQA.Selenium;

namespace PageObjects
{
    public class ContactUsPage : WebPage
    {
        private const string SELECTOR_ID_SUBJECT_HEADING = "id_contact";
        private const string SELECTOR_NAME_ORDER_REFERENCE = "id_order";
        private const string SELECTOR_XPATH_MESSAGE_BOX = "//*[@id='message']";
        private const string SELECTOR_CSS_CONFIRMATION_MSG = "#center_column > p";
        private const string SELECTOR_ID_FILE_UPLOAD = "fileUpload";
        private const string SELECTOR_ID_SEND_BTN = "submitMessage";

        protected override string PAGE_TITLE { get { return "Contact us - My Store"; } set { } }

        public ContactUsPage(IWebDriver Driver) : base(Driver)
        {
        }

        public ContactUsPage SelectSubjectHeading(string option)
        {            
            var selectElement = GetSelectWebElement(By.Id(SELECTOR_ID_SUBJECT_HEADING));
            selectElement.SelectByText(option);

            return this;
        }

        public ContactUsPage SelectOrderRefernce()
        {
            var selectElement = GetSelectWebElement(By.Name(SELECTOR_NAME_ORDER_REFERENCE));
            selectElement.SelectByIndex(1);

            return this;
        }

        public ContactUsPage EnterMessage(string message)
        {
            var element = GetWebElement(By.XPath(SELECTOR_XPATH_MESSAGE_BOX));
            EnterText(element, message);

            return this;
        }

        public ContactUsPage AttachFile(string path)
        {
            var uploadElement = GetWebElement(By.Id(SELECTOR_ID_FILE_UPLOAD));
            EnterText(uploadElement, path);

            return this;
        }

        public ContactUsPage Send()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_SEND_BTN));
            ClickElement(element);

            return this;
        }

        public string GetActualMessage()
        {
            var element = GetWebElement(By.CssSelector(SELECTOR_CSS_CONFIRMATION_MSG));
            return element.Text;

        }
    }
}
