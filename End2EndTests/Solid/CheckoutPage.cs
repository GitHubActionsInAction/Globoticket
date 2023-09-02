using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End2EndTests.Solid
{
    internal class CheckoutPage
    {
        private IWebDriver driver;

        internal CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SubmitOrder(CustomerInfo customer)
        {
            driver.FindElement(By.Id("Name")).Click();
            driver.FindElement(By.Id("Name")).SendKeys(customer.name);
            driver.FindElement(By.Id("Email")).SendKeys(customer.email);
            driver.FindElement(By.Id("Address")).SendKeys(customer.street);
            driver.FindElement(By.Id("Town")).SendKeys(customer.town);
            driver.FindElement(By.Id("PostalCode")).SendKeys(customer.postalcode);
            driver.FindElement(By.Id("CreditCard")).SendKeys(customer.cc);
            driver.FindElement(By.Id("CreditCardDate")).SendKeys(customer.expdate);
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

    }
}
