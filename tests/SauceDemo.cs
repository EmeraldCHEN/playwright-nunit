using Microsoft.Playwright;
using NUnit.Framework;
using SaucedemoTests.Pages;
using System.Threading.Tasks;

namespace SaucedemoTests
{
    public class SignInTests
    {
        private IPage _page;
        private IBrowser _browser;
        private IPlaywright _playwright;

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            _page = await _browser.NewPageAsync();
        }

        [Test]
        public async Task Login_With_Valid_Credentials_Should_Succeed()
        {
            var loginPage = new SignInPage(_page);
            var inventoryPage = new InventoryPage(_page);

            await loginPage.NavigateAsync();
            await loginPage.LoginAsync("standard_user", "secret_sauce");

            Assert.That(await inventoryPage.IsLoadedAsync());
        }

        [Test]
        public async Task Login_With_Invalid_Credentials_Should_Fail()
        {
            var loginPage = new SignInPage(_page);

            await loginPage.NavigateAsync();
            await loginPage.LoginAsync("invalid_user", "wrong_password");

            Assert.That(await loginPage.IsErrorVisibleAsync());
        }

        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
