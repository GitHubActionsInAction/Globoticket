using Microsoft.Playwright;
using Tests.Playwright.Gerkin;
using Tests.Playwright.PageObjects;
using static System.Net.WebRequestMethods;

namespace Tests.Playwright
{
    [TestClass]
    public class SimpleTests
    {
        public TestContext? TestContext;
        public string StartPage = "https://globoticket.azurewebsites.net";
        [TestInitialize]
        public void Initialize()
        {
            var homepage = System.Environment.GetEnvironmentVariable("HomePage");
            if(!string.IsNullOrWhiteSpace(homepage))
                StartPage = homepage.Trim();

            var exitCode = Microsoft.Playwright.Program.Main(new[] { "install" });
            if (exitCode != 0)
            {
                Console.WriteLine("Failed to install browsers");
                Environment.Exit(exitCode);
            }
        }




        [TestMethod]
        public async Task SimpleTest_demo02()
        {
            var homepageUrl = "http://localhost:5266/";

            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });
            // Act

            var webSite = new WebSite(browser, homepageUrl);
            await webSite.NavigateToHomepage();
            await webSite.AddItemToBasket("John Egbert");
            await webSite.CheckOut();
            await webSite.ConfirmPurchase();
            // Assert 
            Assert.IsTrue(await webSite.IsPurchaseConfirmed());



        }


        [TestMethod]
        public void SimpleTest_demo03()
        {
            var Given = new Given(new GloboticketDriver());
            var When = new When(new GloboticketDriver());
            var Then = new Then(new GloboticketDriver());

            Given.IHaveACleanDatabaseWithProducts()
                 .And()
                 .GloboticketWebsiteIsAvailable();

            When.IAddTheProductToTheShoppingCart("John Egbert")
                .And()
                .IAddTheProductToTheShoppingCart("John Egbert");

            Then.TheShoppingCartContainsNumberOfItems(2);
        }

        [TestMethod]
        public async Task SimpleTest()
        {
            var BuyticketResult = HomePage.GetHomePage(StartPage,false)
                .SelectTicket("John Egbert")
                .BuyTicket()
                .Checkout(new CustomerNico())
                .IsOrderPlaced();
            Assert.IsTrue(BuyticketResult);
        }
    }
}