using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End2EndTests.Solid
{
    internal class HomePage
    {
        private IWebDriver driver;

        internal HomePage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost:5266/");
            driver.Manage().Window.Maximize();
        }
        public void PutProductWithNameInBasket(string name)
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
        }
    }
}
