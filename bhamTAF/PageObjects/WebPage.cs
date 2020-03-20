using NUnit.Framework;
using OpenQA.Selenium;
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
        public virtual string PAGE_TITLE { get; set; }

        const string SELECTOR_ID_CONTACT_US_BTN = "contact-link";

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
            });
        }

        public void WaitUntilPageHasLoaded()
        {
            GetWaitForFiveSeconds().Until(d =>
            {
                try
                {
                    var contactUsBtn = GetWebElement(By.Id(SELECTOR_ID_CONTACT_US_BTN));

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

        protected void VerifyElementIsInvisible(IWebElement element)
        {
            try
            {
                //Decided not to log these exceptions for the moment as they are expected but also since it may do more harm than good 
                //by causing confusion in the logs. At least it might in the current set up where it is not clear in the logs what element/function the 
                //exception has been thrown from
                GetWaitForFiveSeconds().Until(d =>
                {
                    try
                    {
                        return !element.Displayed;
                    }                    
                    catch (NoSuchElementException e)
                    {
                        return true;
                    }                                       
                    catch (StaleElementReferenceException e)
                    {
                        return true;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"TEST FAILED: Element ['{element.Text}'] is NOT meant to be visibile");
                Assert.Fail();                
            }
        }

        public WebDriverWait GetWaitForFiveSeconds()
        {
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
            return Wait;
        }
    }
}
