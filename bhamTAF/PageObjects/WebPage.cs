﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace PageObjects
{
    public class WebPage
    {
        protected IWebDriver Driver { get; private set; }
        protected WebDriverWait Wait { get; private set; }

        public WebPage(IWebDriver driver)
        {
            Driver = driver;            
        }
        public WebPage()
        {
        }

        public void WaitUntilElementisDisplayedAndEnabled(By selector)
        {
            GetWaitForFiveSeconds().Until(d =>
            {
                try
                {
                    var element = GetWebElement(selector);
                    return Driver.FindElement(selector).Displayed && Driver.FindElement(selector).Enabled;                    
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

        public void WaitUntilElementisDisplayed(By selector)
        {
            GetWaitForFiveSeconds().Until(d =>
            {
                try
                {
                    var element = GetWebElement(selector);
                    return Driver.FindElement(selector).Displayed;
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
                    element = Driver.FindElement(selector);
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

        public SelectElement GetSelectWebElement(By selector)
        {
            var element = GetWebElement(selector);
            var selectElement = new SelectElement(element);            

            return selectElement;
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
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
            return Wait;
        }

    }
}