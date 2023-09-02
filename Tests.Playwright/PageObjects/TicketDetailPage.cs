using Microsoft.Playwright;

namespace Tests.Playwright.PageObjects
{
    internal class TicketDetailPage
    {
        IPage page;
        internal TicketDetailPage(IPage page)
        {
            this.page = page;
        }

        public ShopingBasket BuyTicket()
        {
            var element = page.GetByRole(AriaRole.Button, new() { Name = "PLACE ORDER" });
            element.ClickAsync().Wait();

            element = page.GetByRole(AriaRole.Link, new() { Name = "CHECKOUT" });
             element.ClickAsync().Wait();
            return new ShopingBasket(page);
        }
    }
}