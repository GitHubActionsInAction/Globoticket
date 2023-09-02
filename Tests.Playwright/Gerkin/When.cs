using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Playwright.PageObjects;

namespace Tests.Playwright.Gerkin
{

    internal class When
    {
        internal GloboticketDriver driver;

        internal When(GloboticketDriver driver)
        {
            this.driver = driver;
        }

        internal When IAddTheProductToTheShoppingCart(string productName)
        {
            driver.GotoHomepage();
            var homePAge = new HomePage(driver);
            homePAge.SelectTicket(productName);
               
            var element = driver.CurrentPage.GetByRole(AriaRole.Row)
                .Filter(new() { HasText = productName });
            element.GetByRole(AriaRole.Cell, new() { Name = "PURCHASE DETAILS" }).ClickAsync().Wait();

            element = driver.CurrentPage.GetByRole(AriaRole.Button, new() { Name = "PLACE ORDER" });
            element.ClickAsync().Wait();

            return this;
        }

        internal When And() { return this; }
    }
}
