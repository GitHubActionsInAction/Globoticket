using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace End2EndTests.Damp
{
    [TestClass]
    public class GloboticketUITestsDamp
    {
        private EdgeDriver driver;

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
            string productName = "John Egbert";
            var homepage = new HomePage(driver);

            Assert.IsTrue(homepage.PutProductWithNameInBasket(productName)
                    .PlaceOrder()
                    .SetQuantity(productName, 3)
                    .GotoCheckout()
                    .SubmitOrder(new CustomerMarcel())
                    .IsThankYouMessageShown());

        }
    }
}