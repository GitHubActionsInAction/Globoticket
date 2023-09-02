using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Playwright
{
    [TestClass]
    public class Demo01
    {
        public TestContext? TestContext;
        public string StartPage = "https://globoticket.azurewebsites.net";
        [TestInitialize]
        public void Initialize()
        {
        }


        [TestMethod]
        public async Task BuyOneProduct()
        {
            // Arange
            var homepageUrl = "http://localhost:5266/";

            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });

            // Act
            var page = await browser.NewPageAsync();
            await page.GotoAsync(homepageUrl);

            var element = page.GetByRole(AriaRole.Row)
                .Filter(new() { HasText = "John Egbert" });
            await element.GetByRole(AriaRole.Cell, new() { Name = "PURCHASE DETAILS" }).ClickAsync();

            element = page.GetByRole(AriaRole.Button, new() { Name = "PLACE ORDER" });
            await element.ClickAsync();

            element = page.GetByRole(AriaRole.Link, new() { Name = "CHECKOUT" });
            await element.ClickAsync();

            await page.Locator("id=Name").FillAsync("Marcel de Vries");
            await page.Locator("id=Address").FillAsync("Kerkhofweg 12");
            await page.Locator("id=Town").FillAsync("Warnsveld");
            await page.Locator("id=PostalCode").FillAsync("7231RJ");
            await page.Locator("id=CreditCardDate").FillAsync("05/28");
            await page.Locator("id=Email").FillAsync("vriesmarcel@hotmail.com");
            await page.Locator("id=CreditCard").FillAsync("1111222233334444");

            var button = page.GetByRole(AriaRole.Button, new() { Name = "SUBMIT ORDER" });
            await button.ClickAsync();

            // Assert
            var header = page.GetByRole(AriaRole.Heading, new() { Name = "Thank you for your order!" });
            Assert.IsTrue(await header.IsVisibleAsync());

        }

  

    }
}
