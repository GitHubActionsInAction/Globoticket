using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace End2EndTests
{
    [TestClass]
    public class GloboticketUITests
    {
        [TestMethod]
        public void BuyOneProduct()
        {
            using (IWebDriver driver = new EdgeDriver())
            {
                StartDriver(driver);
                driver.FindElement(By.Name("TicketAmount")).Click();
                {
                    var dropdown = driver.FindElement(By.Name("TicketAmount"));
                    dropdown.FindElement(By.XPath("//option[. = '3']")).Click();
                }
                driver.FindElement(By.CssSelector(".btn")).Click();
                driver.FindElement(By.LinkText("CHECKOUT")).Click();
                driver.FindElement(By.Id("Name")).Click();
                driver.FindElement(By.Id("Name")).SendKeys("MArcel");
                driver.FindElement(By.Id("Email")).SendKeys("m@m.com");
                driver.FindElement(By.Id("Address")).SendKeys("some");
                driver.FindElement(By.Id("Town")).SendKeys("town");
                driver.FindElement(By.Id("PostalCode")).SendKeys("1212VB");
                driver.FindElement(By.Id("CreditCard")).SendKeys("1111222233334444");
                driver.FindElement(By.Id("CreditCardDate")).Click();
                driver.FindElement(By.Id("CreditCardDate")).SendKeys("12/12/28");
                driver.FindElement(By.CssSelector(".btn")).Click();
            }
        }

        [TestMethod]
        public void BuyOneProductAfterAddingAndRemovingAnotherProduct()
        {
            using (IWebDriver driver = new EdgeDriver())
            {
                StartDriver(driver);
                driver.FindElement(By.LinkText("PURCHASE DETAILS")).Click();
                driver.FindElement(By.CssSelector(".btn")).Click();
                driver.FindElement(By.LinkText("Back to event catalog")).Click();
                driver.FindElement(By.CssSelector("tr:nth-child(2) .btn-primary")).Click();
                driver.FindElement(By.Name("TicketAmount")).Click();
                {
                    var dropdown = driver.FindElement(By.Name("TicketAmount"));
                    dropdown.FindElement(By.XPath("//option[. = '3']")).Click();
                }
                driver.FindElement(By.CssSelector(".btn")).Click();
                driver.FindElement(By.CssSelector("tr:nth-child(2) .cancelIcon")).Click();
                driver.FindElement(By.CssSelector(".navbar-brand > img")).Click();
                var element = driver.FindElement(By.XPath("/html/body/header/div/div/div[2]/div/div/div[2]/span[1]"));
                Assert.IsTrue(element != null);
                Assert.IsTrue(element.Text == "1");

                driver.Close();
            }
        }

        private static void StartDriver(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:5266/");
            driver.Manage().Window.Size = new System.Drawing.Size(1616, 1034);
        }
    }
}