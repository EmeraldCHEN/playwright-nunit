using NUnit.Framework;
using PlaywrightDemo.Pages;
using PlaywrightDemo.Utils;
using System.Threading.Tasks;
using PlaywrightTests.Utilitis;

namespace PlaywrightDemo.Tests
{
    public class LoginTests : BaseTest
    {
        private Credentials _credentials;

        [SetUp]
        public void SetUp()
        {
            // Load credentials once before each test
            _credentials = ConfigLoader.LoadCredentials();
        }

        [Test]
        public async Task ValidLogin_ShouldDisplaySuccessMessage()
        {
            // Arrange
            var loginPage = new LoginPage(page);

            // Act
            await loginPage.NavigateAsync();
            await loginPage.LoginAsync(_credentials.Username, _credentials.Password);

            // Assert
            // Use Assert.That with the expected condition
            Assert.That(await loginPage.IsLoginSuccessfulAsync(), Is.True, "Login success message not found.");
        }

        [Test]
        public async Task InvalidLogin_ShouldDisplayErrorMessage()
        {
            // Arrange
            var loginPage = new LoginPage(page);

            // Act
            await loginPage.NavigateAsync();
            await loginPage.LoginAsync("invalid", "wrong");

            // Assert
            var flashMessage = await loginPage.GetFlashMessageAsync();
            // Use Assert.That with Does.Contain for a more readable assertion
            Assert.That(flashMessage, Does.Contain("Your username is invalid!"), "Expected error message not found.");
        }
    }
}
