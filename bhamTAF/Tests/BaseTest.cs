using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace bhamTAF
{
    public class BaseTest
    {        
        public IWebDriver driver;        

        [SetUp]
        public void Setup()
        {            
            driver = new ChromeDriver();   
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}