using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace End2EndTests
{
    [TestClass]
    public class GloboticketUITestsDry
    {
        private EdgeDriver? driver;

        [TestInitialize]
        public void Init()
        {
            driver = new EdgeDriver();
            driver.Navigate().GoToUrl("http://localhost:5266/");
            driver.Manage().Window.Maximize();
        }
        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            driver.Dispose();
        }
        [TestMethod]
        public void BuyOneProduct()
        {
            BuyFirstProduct(2);
            GotoShoppingBasket();
            CheckOut();
            ConfirmPurchase();
        }
        [TestMethod]
        public void AddingAndRemovingAnotherProduct()
        {
            BuyFirstProduct(1);
            BuySecondProduct(2);
            GotoShoppingBasket();
            RemoveItemFromBasketAndGoHome(1);
            AssertNumberOfItemsInBasket(1);
        }








        private void ConfirmPurchase()
        {
            driver.FindElement(By.Id("Name")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("marcel");
            driver.FindElement(By.Id("Email")).SendKeys("m@m.com");
            driver.FindElement(By.Id("Address")).SendKeys("kerkhofweg 12");
            driver.FindElement(By.Id("Town")).SendKeys("warnsveld");
            driver.FindElement(By.Id("PostalCode")).SendKeys("7231RJ");
            driver.FindElement(By.Id("CreditCard")).SendKeys("1111222233334444");
            driver.FindElement(By.Id("CreditCardDate")).SendKeys("12/12/2024");
            driver.FindElement(By.CssSelector(".btn")).Click();
        }
        private void CheckOut()
        {
            driver.FindElement(By.CssSelector(".filterButton")).Click();
            driver.FindElement(By.LinkText("CHECKOUT")).Click();
        }
        private void BuyFirstProduct(int quantity)
        {
            driver.FindElement(By.CssSelector("tr:nth-child(2) .btn-primary")).Click(); //Purchase details
            BuyTheSelectedProduct(quantity);

        }
        private void BuySecondProduct(int quantity)
        {
            driver.FindElement(By.CssSelector("tr:nth-child(3) .btn-primary")).Click(); //Purchase details
            BuyTheSelectedProduct(quantity);

        }
        private void BuyTheSelectedProduct(int quantity)
        {
            driver.FindElement(By.Name("TicketAmount")).Click();
            {
                var dropdown = driver.FindElement(By.Name("TicketAmount"));
                dropdown.FindElement(By.XPath($"//option[. = '{quantity}']")).Click();
            }
            driver.FindElement(By.CssSelector(".btn")).Click(); //Place Order
            driver.FindElement(By.LinkText("Back to event catalog")).Click();
        }
        private void AssertNumberOfItemsInBasket(int numOfItems)
        {
            var element = driver.FindElement(By.XPath("/html/body/header/div/div/div[2]/div/div/div[2]/span[1]"));
            Assert.IsTrue(element != null);
            Assert.IsTrue(element.Text == $"{numOfItems}");
        }
        private void RemoveItemFromBasketAndGoHome(int itemNumber)
        {
            driver.FindElement(By.CssSelector($"tr:nth-child({itemNumber+1}) .cancelIcon")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[2]/td[1]/a")).Click();

        }
        private void GotoShoppingBasket()
        {
            driver.FindElement(By.CssSelector(".shoppingCartIcon")).Click();
        }
    }
}