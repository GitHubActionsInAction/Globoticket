using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace End2EndTests.Solid
{
    [TestClass]
    public class GloboticketUITestsSolid
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
            homepage.PutProductWithNameInBasket(productName);

            var productPage = new ProductPage(driver);
            productPage.SetQuantity(2);
            productPage.PlaceOrder();

            var shopingBasket = new ShoppingBasket(driver);
            shopingBasket.SetQuantity(productName, 3);
            shopingBasket.GotoCheckout();

            var checkoutPage = new CheckoutPage(driver);
            checkoutPage.SubmitOrder(new CustomerMarcel());

        }
    }
}