using Microsoft.Playwright;

namespace Tests.Playwright.PageObjects
{
    internal class ShopingBasket
    {
        private IPage page;

        public ShopingBasket(IPage playwright)
        {
            page = playwright;
        }

        public CheckOutPage Checkout(CustomerNico customer)
        {
            page.Locator("id=Name").FillAsync(customer.name).Wait();
            page.Locator("id=Address").FillAsync(customer.street).Wait();
            page.Locator("id=Town").FillAsync(customer.town).Wait();
            page.Locator("id=PostalCode").FillAsync(customer.postalcode).Wait();
            page.Locator("id=CreditCardDate").FillAsync(customer.expdate).Wait();
            page.Locator("id=Email").FillAsync(customer.email).Wait();
            page.Locator("id=CreditCard").FillAsync(customer.cc).Wait();

            var button = page.GetByRole(AriaRole.Button, new() { Name = "SUBMIT ORDER" });
            button.ClickAsync().Wait();
            return new CheckOutPage(page);
        }
    }
}