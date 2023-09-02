using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Playwright.Gerkin
{
    internal class Then
    {
        internal GloboticketDriver driver;
        public Then(GloboticketDriver diver) 
        {
            this.driver = driver;
        }   

        internal bool TheShoppingCartContainsNumberOfItems(int numberOfItems)
        {
            // var element = driver.CurrentPage.GetByRole(AriaRole.Row)
            //      .Filter(new() { HasText = productName });
            // await element.GetByRole(AriaRole.Cell, new() { Name = "PURCHASE DETAILS" }).ClickAsync();

            // element = driver.CurrentPage.GetByRole(AriaRole.Button, new() { Name = "PLACE ORDER" });
            //element.ScreenshotAsync
            // await element.ClickAsync();

            //locate shoping basket page
            // count number of items in basket

            return true;
        }
        internal bool AThankYouMessageIsShown()
        {
            var header = driver.currentPage.GetByRole(AriaRole.Heading, new() { Name = "Thank you for your order!" });
            var task = header.IsVisibleAsync();
            return task.Result;
        }

        internal bool theShoppingBasketContainsNumberOfItems(int numberOfItems)
        {
            var headerwidget = driver.currentPage.GetByTestId("ticketAmount");
            var ticketAmount = headerwidget.TextContentAsync().Result;
            return (numberOfItems == int.Parse(ticketAmount)) ;
        }
    }
}
