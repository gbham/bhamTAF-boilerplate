﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PageObjects
{
    public abstract class WebPage 
    {
        protected IWebDriver Driver { get; private set; }
        protected WebDriverWait Wait { get; private set; }
        public abstract string PAGE_TITLE { get; set; }

        public WebPage(IWebDriver Driver)
        {
            this.Driver = Driver;
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
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
                catch (ElementNotInteractableException e)
                {
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
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
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
                catch (ElementNotInteractableException e)
                {
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
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
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
                catch (ElementNotInteractableException e)
                {
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
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
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
                catch (ElementNotInteractableException e)
                {
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
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
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
                catch (ElementNotInteractableException e)
                {
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
                //catch ()
                //{
                //}    
            });
        }

        public void WaitUntilPageHasLoaded()
        {
            GetWaitForFiveSeconds().Until(d =>
            {
                try
                {
                    var contactUsBtn = GetWebElement(By.Id("contact-link"));

                    var expectedPageTitle = GetExpectedPageTitle();
                    var actualPageTitle = GetPageTitle();

                    return contactUsBtn.Displayed && expectedPageTitle.Equals(actualPageTitle);
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
                catch (ElementNotInteractableException e)
                {
                    Console.WriteLine($"CATCH ERROR - {e.Message}");
                    return false;
                }
                //catch ()
                //{
                //} 

            });
        }

        protected void ScrollPageToElement(IWebElement element)
        {
            var actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public string GetExpectedPageTitle()
        {
            return PAGE_TITLE;
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }

        public WebDriverWait GetWaitForFiveSeconds()
        {
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
            return Wait;
        }
    }
}
