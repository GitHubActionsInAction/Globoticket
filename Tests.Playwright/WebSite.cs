using Microsoft.Playwright;

namespace Tests.Playwright
{
    internal class WebSite
    {
        private IBrowser browser;
        private string homepageUrl;
        private IPage? currentPage;

        public WebSite(IBrowser browser, string homepageUrl)
        {
            this.browser = browser;
            this.homepageUrl = homepageUrl;
            currentPage = null;
        }

        public async Task NavigateToHomepage()
        {
            currentPage = await this.browser.NewPageAsync();
            await currentPage.GotoAsync(homepageUrl);
        }

        public async Task AddItemToBasket(string ticketName)
        {
            var element = currentPage.GetByRole(AriaRole.Row)
                           .Filter(new() { HasText = ticketName });
            await element.GetByRole(AriaRole.Cell, new() { Name = "PURCHASE DETAILS" }).ClickAsync();

            element = currentPage.GetByRole(AriaRole.Button, new() { Name = "PLACE ORDER" });
            await element.ClickAsync();
        }
        public async Task CheckOut() {
            var element = currentPage.GetByRole(AriaRole.Link, new() { Name = "CHECKOUT" });
            await element.ClickAsync();
        }

        public async Task ConfirmPurchase() { 

            await currentPage.Locator("id=Name").FillAsync("Marcel de Vries");
            await currentPage.Locator("id=Address").FillAsync("Kerkhofweg 12");
            await currentPage.Locator("id=Town").FillAsync("Warnsveld");
            await currentPage.Locator("id=PostalCode").FillAsync("7231RJ");
            await currentPage.Locator("id=CreditCardDate").FillAsync("05/28");
            await currentPage.Locator("id=Email").FillAsync("vriesmarcel@hotmail.com");
            await currentPage.Locator("id=CreditCard").FillAsync("1111222233334444");

            var button = currentPage.GetByRole(AriaRole.Button, new() { Name = "SUBMIT ORDER" });
            await button.ClickAsync();

        }
        public async Task<bool> IsPurchaseConfirmed()
        {
            var header = currentPage.GetByRole(AriaRole.Heading, new() { Name = "Thank you for your order!" });
            return await header.IsVisibleAsync();
        }
    }
}