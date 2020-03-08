using OpenQA.Selenium;

namespace PageObjects
{
    public class RegisterPage : WebPage
    {

        private const string SELECTOR_ID_RADIO_BTN_MR = "id_gender1";
        private const string SELECTOR_ID_RADIO_BTN_MRS = "id_gender2";
        private const string SELECTOR_ID_FIRST_NAME_FIELD = "customer_firstname";
        private const string SELECTOR_ID_SURNAME_FIELD = "customer_lastname";

        const string SELECTOR_ID_REGISTER_BTN = "submitAccount";        

        public RegisterPage(IWebDriver Driver)
        {
            driver = Driver;
        }        

        public RegisterPage ClickRadioBtnForMr()
        {
            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_RADIO_BTN_MR));

            var element = GetWebElement(By.Id(SELECTOR_ID_RADIO_BTN_MR));
            ClickElement(element);            

            return this;
        }

        public RegisterPage ClickRadioBtnForMrs()
        {
            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_RADIO_BTN_MRS));

            var element = GetWebElement(By.Id(SELECTOR_ID_RADIO_BTN_MRS));
            ClickElement(element);            

            return this;
        }

        //TODO
        public RegisterPage EnterRandomDOB()
        {
            
            return this;
        }

        public string GetActualErrors()
        {
            var element = GetWebElement(By.TagName("ol")).Text.Replace("\r\n", " ").Replace("00000", "");
            
            return element;

        }

        public RegisterPage TypeFirstName(string firstname)
        {
            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_FIRST_NAME_FIELD));

            var element = GetWebElement(By.Id(SELECTOR_ID_FIRST_NAME_FIELD));
            EnterText(element, firstname);

            return this;
        }

        public RegisterPage TypeSurnameName(string surname)
        {
            WaitUntilElementisDisplayedAndEnabled(By.Id(SELECTOR_ID_SURNAME_FIELD));

            var element = GetWebElement(By.Id(SELECTOR_ID_SURNAME_FIELD));
            EnterText(element, surname);

            return this;
        }

        public void ClickRegister()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_REGISTER_BTN));
            ClickElement(element);
        }
    }
}
