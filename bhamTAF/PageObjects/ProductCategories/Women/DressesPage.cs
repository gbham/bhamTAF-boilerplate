using OpenQA.Selenium;
using System.Linq;

namespace PageObjects
{
    public class DressesPage : WebPage
    { 
        //Migrate most of this to a more general class dedicated to the product page grid view of all the products, not to be mistaken with the general kinda 
        //template productPage that is for individual products
        
        private const string SELECTOR_CSS_ITEM_GRID = "#center_column > ul";
        private const string SELECTOR_CSS_PROCEED_TO_CHECKOUT_BTN = "#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a";

        public override string PAGE_TITLE { get { return "Dresses - My Store"; } set { }}
        

        public DressesPage(IWebDriver Driver) : base(Driver)
        {
        }

        public DressesPage AddItemToShoppingCart(string desiredItem)
        {
            var itemList = GetWebElement(By.CssSelector(SELECTOR_CSS_ITEM_GRID)).FindElements(By.TagName("li"));   
            ScrollPageToElement(itemList.First());
         
            foreach(var element in itemList)
            {
                var currentItem = GetItemName(element);
                if (currentItem.Equals(desiredItem))
                {
                    ClickAddToCartBtn(element);
                    break;
                }
            }

            return this;
        }

        public ProductPage ViewItem(string desiredItem)
        {
            var itemList = GetWebElement(By.CssSelector(SELECTOR_CSS_ITEM_GRID)).FindElements(By.TagName("li"));            
            ScrollPageToElement(itemList.First());

            foreach (var element in itemList)
            {
                var currentItem = GetItemName(element);
                if (currentItem.Equals(desiredItem))
                {
                    ScrollPageToElement(element);
                    ClickMoreBtn(element);

                    break;
                }
            }

            return new ProductPage(Driver);
        }

        public ShoppingCartPage ProceedToCheckout()
        {
            var element = GetWebElement(By.CssSelector(SELECTOR_CSS_PROCEED_TO_CHECKOUT_BTN));            
            ClickElement(element);

            return new ShoppingCartPage(Driver);
        }

        private string GetItemName(IWebElement element)
        {
            var listOfATags = element.FindElements(By.TagName("a"));
            foreach (var subElement in listOfATags)
            {
                if (subElement.GetAttribute("class").Equals("product-name"))
                {
                    return subElement.Text;
                }
            }

            return " ";
        }

        private void ClickAddToCartBtn(IWebElement element)
        {
            var listOfATags = element.FindElements(By.TagName("a"));
            foreach (var subElement in listOfATags)
            {
                if(subElement.Text.Equals("Add to cart"))
                {
                    subElement.Click();
                    break;
                }
            }
        }

        private void ClickMoreBtn(IWebElement element)
        {
            var listOfATags = element.FindElements(By.TagName("a"));
            foreach (var subElement in listOfATags)
            {               
                if (subElement.Text.Equals("More"))
                {
                    subElement.Click();
                    break;
                }
            }
        }
    }
}
