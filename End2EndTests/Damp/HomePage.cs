using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End2EndTests.Damp
{
    internal class HomePage
    {
        private IWebDriver driver;

        internal HomePage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public HomePage NavigateToHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost:5266/");
            driver.Manage().Window.Maximize();
            return this;
        }
        public ProductPage PutProductWithNameInBasket(string name)
        {
            var tableRows = driver.FindElements(By.XPath("/html/body/div/main/div/table/tbody/tr"));
            foreach ( var row in tableRows )
            {
                if(row.Text.Contains(name))
                {
                    var purcaseButton = row.FindElement(By.ClassName("btn-primary"));
                    purcaseButton.Click();
                    break;
                }
            }
            return new ProductPage(driver);
        }
    }
}
