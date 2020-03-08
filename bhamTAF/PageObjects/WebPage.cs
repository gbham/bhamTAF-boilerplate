using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace PageObjects
{
    public class WebPage
    {
        public IWebDriver driver;
        public WebDriverWait wait;       

        public WebPage( )
        {            
        }
        public WebPage(IWebDriver Driver)
        {
            driver = Driver;           
        }

        public void WaitUntilElementisDisplayedAndEnabled(By selector)
        {
            GetWaitForFiveSeconds().Until(d =>
            {
                try
                {
                    var element = GetWebElement(selector);
                    return driver.FindElement(selector).Displayed && driver.FindElement(selector).Enabled;                    
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine($"CATCH ERROR: {e.Message}");
                    return false;
                }
                //catch ()
                //{
                //}  
                //catch ()
                //{
                //}    
            });            
        }

        public IWebElement GetWebElement(By selector)
        {            
            IWebElement element = null;
            
            GetWaitForFiveSeconds().Until(d =>
            {
                try
                {
                    element = driver.FindElement(selector);
                    return true;
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine($"CATCH ERROR: {e.Message}");
                    return false;
                }
                //catch ()
                //{
                //}
                //catch ()
                //{
                //}    
            });
                
            return element;
        }

        public void EnterText(IWebElement element, string firstname)
        {  
            GetWaitForFiveSeconds().Until(d =>
            {
                try
                {
                    element.SendKeys(firstname);
                    return true;
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine($"CATCH ERROR: {e.Message}");
                    return false;
                }
                //catch ()
                //{
                //}
                //catch ()
                //{
                //}    
            });
        }

        public void ClickElement(IWebElement element)
        {
            GetWaitForFiveSeconds().Until(d =>
            {
                try
                {
                    element.Click();
                    return true;
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine($"CATCH ERROR: {e.Message}");
                    return false;
                }
                //catch ()
                //{
                //}
                //catch ()
                //{
                //}    
            });
        }

        public WebDriverWait GetWaitForFiveSeconds()
        {
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            return wait;
        }

    }
}
