using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.DOMSnapshot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End2EndTests.Damp
{
    internal class ThankYouPage
    {
        private IWebDriver driver;

        internal ThankYouPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool IsThankYouMessageShown()
        {
            return true;
        }
    }
}
