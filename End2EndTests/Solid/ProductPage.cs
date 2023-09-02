using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End2EndTests.Solid
{
    internal class ProductPage
    {
        private IWebDriver driver;

        internal ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SetQuantity(int quantity)
        {
            driver.FindElement(By.Name("TicketAmount")).Click();
            {
                var dropdown = driver.FindElement(By.Name("TicketAmount"));
                dropdown.FindElement(By.XPath($"//option[. = '{quantity}']")).Click();
            }
        }

        public void PlaceOrder()
        {
            driver.FindElement(By.CssSelector(".btn")).Click(); //Place Order
        }


    }
}
