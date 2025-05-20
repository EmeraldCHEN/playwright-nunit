using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightDemo.Utils
{
    public class BaseTest
    {
        protected IPlaywright playwright;
        protected IBrowser browser;
        protected IBrowserContext context;
        protected IPage page;

        [SetUp]

        public async Task Setup()
        {

            playwright = await Playwright.CreateAsync();

            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });

            context = await browser.NewContextAsync();

            page = await context.NewPageAsync();
        }

        [TearDown]

        public async Task Teardown()
        {

            await page.CloseAsync();

            await context.CloseAsync();

            await browser.CloseAsync();

            playwright.Dispose();
        }
    }
}