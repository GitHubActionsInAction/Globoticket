using Microsoft.Playwright;

namespace Tests.Playwright.PageObjects
{
    public class CheckOutPage
    {
        private IPage page;

        public CheckOutPage(IPage playwright)
        {
            page = playwright;
        }

        public bool IsOrderPlaced()
        {
            return  page.GetByRole(AriaRole.Heading, new() { Name = "Thank you for your order!" }).IsVisibleAsync().Result;
        }
    }
}