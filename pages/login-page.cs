using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightDemo.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;         // Selectors for HerokuApplogin page        
        private readonly string usernameField = "#username";
        private readonly string passwordField = "#password";
        private readonly string loginButton = "button[type='submit']";
        private readonly string flashMessage = "#flash";

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://the-internet.herokuapp.com/login");
        }

        public async Task LoginAsync(string username, string password)
        {
            await _page.FillAsync(usernameField, username);
            await _page.FillAsync(passwordField, password);
            await _page.ClickAsync(loginButton);
        }

        public async Task<string> GetFlashMessageAsync()
        {
            return await _page.InnerTextAsync(flashMessage);
        }

        public async Task<bool> IsLoginSuccessfulAsync()
        {
            var message = await GetFlashMessageAsync();
            return message.Contains("You logged into a secure area!");
        }
    }
}