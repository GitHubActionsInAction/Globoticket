using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Playwright.Gerkin
{
    internal class Given
    {
        private GloboticketDriver driver;

        internal Given(GloboticketDriver diver)
        {
            this.driver = diver;
        }

        internal Given And()
        {
            return this;
        }

        internal Given GloboticketWebsiteIsAvailable()
        {
            driver.Initialize(); ;
            return this;
        }

        internal Given IHaveACleanUserDatabase()
        {
            return this;
        }

        internal Given IHaveACleanDatabaseWithProducts()
        {
            return this;
        }
    }
}
