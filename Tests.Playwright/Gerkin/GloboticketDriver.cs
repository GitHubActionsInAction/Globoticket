using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Playwright.Gerkin
{
    internal class GloboticketDriver
    {
        internal string homepageUrl = "http://localhost:5266/";
        internal IPage? currentPage;
        internal bool isInitialized = false;
        public void GotoHomepage()
        {
            if(!isInitialized)
            {
                Initialize();
            }
            var result = currentPage.GotoAsync(homepageUrl).Result;

        }

        public void Initialize()
        {
            var playwright = Microsoft.Playwright.Playwright.CreateAsync().Result;
            
            var browser = playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            }).Result;
            currentPage = browser.NewPageAsync().Result;
        }

        public IPage CurrentPage
        {
            get
            {
                return currentPage;
            }
        }
    }
}
