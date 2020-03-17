using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;

namespace bhamTAF
{
    public class BaseTest
    {
        public IWebDriver Driver;

        protected MenuPage LoadSite()
        {
            var HomePage = new HomePage(Driver);
            HomePage.LoadSite();

            return new MenuPage(Driver);
        }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();   
        }

        [TearDown]
        public void Teardown()
        {
            Driver.Quit();
        }
    }
}