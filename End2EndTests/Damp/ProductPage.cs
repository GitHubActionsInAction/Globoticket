using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End2EndTests.Damp
{
    internal class ProductPage
    {
        private IWebDriver driver;

        internal ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ProductPage SetQuantity(int quantity)
        {
            driver.FindElement(By.Name("TicketAmount")).Click();
            {
                var dropdown = driver.FindElement(By.Name("TicketAmount"));
                dropdown.FindElement(By.XPath($"//option[. = '{quantity}']")).Click();
            }
            return this;
        }

        public ShoppingBasket PlaceOrder()
        {
            driver.FindElement(By.CssSelector(".btn")).Click(); //Place Order
            return new ShoppingBasket(driver);
        }


    }
}
