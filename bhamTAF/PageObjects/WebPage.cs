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
        protected virtual string PAGE_TITLE { get; set; }

        private const string SELECTOR_ID_CONTACT_US_BTN = "contact-link";

        public WebPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
        public WebPage()
        {
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }

        public string GetExpectedPageTitle()
        {
            return PAGE_TITLE;
        }

        //Not needed at the moment since each page uses WaitUntilPageHasLoaded(), and GetWebElement() essentially fills the purpose of this function in many cases.
        public void WaitUntilElementisDisplayedAndEnabled(By selector)
        {
            GetWaitForXSeconds().Until(d =>
            {
                try
                {
                    var element = GetWebElement(selector);
                    return element.Displayed && element.Enabled;
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

        //Not needed at the moment since each page uses WaitUntilPageHasLoaded(), and GetWebElement() essentially fills the purpose of this function in many cases.
        public void WaitUntilElementisDisplayed(By selector)
        {
            GetWaitForXSeconds().Until(d =>
            {
                try
                {
                    var element = GetWebElement(selector);
                    return element.Displayed;
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
            GetWaitForXSeconds().Until(d =>
            {
                try
                {
                    element = d.FindElement(selector);
                    return true;
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine($"CATCH ERROR in GetWebElement() - {e.Message}");
                    return false;
                }
                catch (ElementNotInteractableException e)
                {
                    Console.WriteLine($"CATCH ERROR in GetWebElement() - {e.Message}");
                    return false;
                }
                catch(StaleElementReferenceException e)
                {
                    Console.WriteLine($"CATCH ERROR in GetWebElement() - {e.Message}");
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
            GetWaitForXSeconds().Until(d =>
            {
                try
                {
                    element.SendKeys(firstname);
                    return true;
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine($"CATCH ERROR in EnterText() - {e.Message}");
                    return false;
                }
                catch (ElementNotInteractableException e)
                {
                    Console.WriteLine($"CATCH ERROR in EnterText() - {e.Message}");
                    return false;
                }
                catch (StaleElementReferenceException e)
                {
                    Console.WriteLine($"CATCH ERROR in EnterText() - {e.Message}");
                    return false;
                }
            });
        }

        public void ClickElement(IWebElement element)
        {
            GetWaitForXSeconds().Until(d =>
            {
                try
                {
                    element.Click();
                    return true;
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine($"CATCH ERROR in ClickElement() - {e.Message}");
                    return false;
                }
                catch (ElementNotInteractableException e)
                {
                    Console.WriteLine($"CATCH ERROR in ClickElement() - {e.Message}");
                    return false;
                }
                catch (StaleElementReferenceException e)
                {
                    Console.WriteLine($"CATCH ERROR in ClickElement() - {e.Message}");
                    return false;
                }
            });
        }

        public void WaitUntilPageHasLoaded()
        {
            GetWaitForXSeconds().Until(d =>
            {
                try
                {
                    var ContactUsBtn = GetWebElement(By.Id(SELECTOR_ID_CONTACT_US_BTN));

                    var ExpectedPageTitle = GetExpectedPageTitle();
                    var ActualPageTitle = GetPageTitle();

                    return ContactUsBtn.Displayed && ExpectedPageTitle.Equals(ActualPageTitle);
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine($"CATCH ERROR in WaitUntilPageHasLoaded() - {e.Message}");
                    return false;
                }
                catch (ElementNotInteractableException e)
                {
                    Console.WriteLine($"CATCH ERROR in WaitUntilPageHasLoaded() - {e.Message}");
                    return false;
                }
                catch (StaleElementReferenceException e)
                {
                    Console.WriteLine($"CATCH ERROR in WaitUntilPageHasLoaded() - {e.Message}");
                    return false;
                }
            });
        }

        protected void ScrollPageToElement(IWebElement element)
        {
            var Actions = new Actions(Driver);
            Actions.MoveToElement(element);
            Actions.Perform();
        }

        //Decided to go a different route. Will likely need this function at a later point though.
        protected void VerifyElementIsInvisible(IWebElement element)
        {
            //This is to ensure any animations are finished
            Thread.Sleep(1000);

            try
            {
                //Decided not to log these exceptions for the moment as they are expected but also since it may do more harm than good 
                //by causing confusion in the logs. At least it might in the current set up where it is not clear in the logs what element/function the 
                //exception has been thrown from
                GetWaitForXSeconds().Until(d =>
                {
                    try
                    {
                        return !element.Displayed;
                    }                    
                    catch (NoSuchElementException)
                    {
                        return true;
                    }                                       
                    catch (StaleElementReferenceException)
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

        public WebDriverWait GetWaitForXSeconds(int timeout = 10)
        {
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, timeout));
            return Wait;
        }
    }
}
