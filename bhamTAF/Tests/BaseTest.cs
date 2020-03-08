using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace bhamTAF
{
    public class BaseTest
    {        
        public IWebDriver Driver;        

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