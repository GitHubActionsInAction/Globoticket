using Microsoft.Playwright;
using Tests.Playwright.PageObjects;
using static System.Net.WebRequestMethods;

namespace Tests.Playwright
{
    [TestClass]
    public class SimpleTests
    {
        public TestContext? TestContext;
        public string StartPage = "http://4.175.1.56";
        [TestInitialize]
        public void Initialize()
        {
            var homepage = System.Environment.GetEnvironmentVariable("homepage");
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
        public void SimpleTest()
        {
            var BuyticketResult = HomePage.GetHomePage(StartPage)
                .SelectTicket("John Egbert")
                .BuyTicket()
                .Checkout(new CustomerNico())
                .IsOrderPlaced();
            Assert.IsTrue(BuyticketResult);
        }
    }
}