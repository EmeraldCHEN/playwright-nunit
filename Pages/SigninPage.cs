using Microsoft.Playwright;
using System.Threading.Tasks;

namespace playwright_nunit.pages
{
    public class SignInPage
    {
        private readonly IPage _page;

        public SignInPage(IPage page)
        {
            _page = page;
        }

        private ILocator UsernameInput => _page.Locator("#user-name");
        private ILocator PasswordInput => _page.Locator("#password");
        private ILocator LoginButton => _page.Locator("#login-button");
        private ILocator ErrorMessage => _page.Locator("[data-test='error']");

        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task LoginAsync(string username, string password)
        {
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }

        public async Task<bool> IsErrorVisibleAsync()
        {
            return await ErrorMessage.IsVisibleAsync();
        }
    }
}
