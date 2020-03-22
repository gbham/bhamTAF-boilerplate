using OpenQA.Selenium;

namespace PageObjects
{
    public class RegisterPage : WebPage
    {
        private const string SELECTOR_ID_RADIO_BTN_MR = "id_gender1";
        private const string SELECTOR_ID_RADIO_BTN_MRS = "id_gender2";
        private const string SELECTOR_ID_FIRSTNAME = "customer_firstname";
        private const string SELECTOR_ID_SURNAME = "customer_lastname";
        private const string SELECTOR_ID_PASSWORD = "passwd";
        private const string SELECTOR_ID_DAYS_DDL = "days";
        private const string SELECTOR_ID_MONTHS_DDL = "months";
        private const string SELECTOR_ID_YEARS_DDL = "years";
        private const string SELECTOR_ID_SIGNUP_NEWSLETTER_CHECKBOX= "newsletter";
        private const string SELECTOR_ID_ADDRESS_1 = "address1";
        private const string SELECTOR_ID_CITY = "city";
        private const string SELECTOR_ID_STATE= "id_state";
        private const string SELECTOR_ID_POSTCODE = "postcode"; 
        private const string SELECTOR_ID_MOBILE = "phone_mobile";
        private const string SELECTOR_ID_REGISTER_BTN = "submitAccount";

        protected override string PAGE_TITLE { get { return "Login - My Store"; } set { } }

        public RegisterPage(IWebDriver Driver) : base(Driver)
        {
        }

        public RegisterPage ClickRadioBtnForMr()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_RADIO_BTN_MR));
            ClickElement(element);            

            return this;
        }

        public RegisterPage ClickRadioBtnForMrs()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_RADIO_BTN_MRS));
            ClickElement(element);            

            return this;
        }

        public RegisterPage EnterFirstname(string firstname)
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_FIRSTNAME));
            EnterText(element, firstname);

            return this;
        }

        public RegisterPage EnterSurname(string surname)
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_SURNAME));
            EnterText(element, surname);

            return this;
        }

        public RegisterPage EnterPassword(string password)
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_PASSWORD));
            EnterText(element, password);

            return this;
        }

        public RegisterPage EnterRandomDOB()
        { 
            var Days = GetSelectWebElement(By.Id(SELECTOR_ID_DAYS_DDL));
            var Months = GetSelectWebElement(By.Id(SELECTOR_ID_MONTHS_DDL));
            var Years = GetSelectWebElement(By.Id(SELECTOR_ID_YEARS_DDL));

            Days.SelectByValue("4");
            Months.SelectByValue("8");
            Years.SelectByValue("1900");

            return this;
        }

        public RegisterPage ClickSignUpForNewsletterCheckbox()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_SIGNUP_NEWSLETTER_CHECKBOX));
            ClickElement(element);

            return this;
        }

        public RegisterPage EnterAddress(string address)
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_ADDRESS_1));
            EnterText(element, address);
            
            return this;
        }

        public RegisterPage EnterCity(string city)
        {            
            var element = GetWebElement(By.Id(SELECTOR_ID_CITY));
            EnterText(element, city);

            return this;
        }

        public RegisterPage EnterState(string state)
        {
            var selectElement = GetSelectWebElement(By.Id(SELECTOR_ID_STATE));            
            selectElement.SelectByText(state);

            return this;
        }

        public RegisterPage EnterPostcode(string postcode)
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_POSTCODE));
            EnterText(element, postcode);            

            return this;
        }

        public RegisterPage EnterMobile(string mobile)
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_MOBILE));
            EnterText(element, mobile);

            return this;
        } 

        public string GetActualErrors()
        {
            var elementText = GetWebElement(By.TagName("ol")).Text;
            elementText = elementText.Replace("\r\n", " ").Replace("00000", "");
            
            return elementText;
        }
        
        public MyAccountPage ClickRegister()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_REGISTER_BTN));
            ClickElement(element);

            var MyAccountPage = new MyAccountPage(Driver);
            MyAccountPage.WaitUntilPageHasLoaded();

            return MyAccountPage;
        }

        //Duplicate function except this one has no WaitUntilPageLoaded() function for MyAccountPage
        public MyAccountPage ClickRegisterExpectingError()
        {
            var element = GetWebElement(By.Id(SELECTOR_ID_REGISTER_BTN));
            ClickElement(element);

            return new MyAccountPage(Driver);
        }
    }
}
