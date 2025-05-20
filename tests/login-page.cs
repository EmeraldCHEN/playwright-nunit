using NUnit.Framework;
using PlaywrightDemo.Pages;
using PlaywrightDemo.Utils;
using System.Threading.Tasks;

namespace PlaywrightDemo.Tests
{
    public class LoginTests : BaseTest
    {
        [Test]
        public async Task ValidLogin_ShouldDisplaySuccessMessage()
        {
            var loginPage = new LoginPage(page);
            await loginPage.NavigateAsync();
            await loginPage.LoginAsync("tomsmith", "SuperSecretPassword!");
            Assert.IsTrue(await loginPage.IsLoginSuccessfulAsync(), "Loginsuccess message not found.");
        }
        
        [Test]
        public async Task InvalidLogin_ShouldDisplayErrorMessage()
        {
            var loginPage = new LoginPage(page); await loginPage.NavigateAsync(); await loginPage.LoginAsync("invalid", "wrong"); var flashMessage = await loginPage.GetFlashMessageAsync();
            Assert.IsTrue(flashMessage.Contains("Your username isinvalid!"), "Expected error message not found.");
        }
    }
}