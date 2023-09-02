using Microsoft.Playwright;
using System.Xml.Linq;

namespace Tests.Playwright.PageObjects
{
    internal class HomePage
    {
        IPage page;
        IPlaywright playwright;
        IBrowser browser;
        public static HomePage GetHomePage(string homepageurl, bool headless=true)
        {
            var playwright =  Microsoft.Playwright.Playwright.CreateAsync().Result;
            var browser = playwright.Chromium.LaunchAsync(new()
            {
                Headless = headless
            }).Result;

            var page =  browser.NewPageAsync().Result;
            page.GotoAsync(homepageurl).Wait();
            return new HomePage(playwright,browser, page);
        }

        protected HomePage(IPlaywright playwright,IBrowser browser,  IPage page ) {
           
            this.playwright = playwright;
            this.browser = browser;
            this.page = page;
        }
        public TicketDetailPage SelectTicket(string concertName)
        {
            var element = page.GetByRole(AriaRole.Row)
                .Filter(new() { HasText = concertName });
            element.GetByRole(AriaRole.Cell, new() { Name = "PURCHASE DETAILS" }).ClickAsync().Wait();

            return new TicketDetailPage(page);
        }
    }
}