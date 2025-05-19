using Microsoft.Playwright;

namespace EcommerceApp.Tests.Models;
public class HomePage
{
    private readonly IPage _page;

    public HomePage(IPage page)
    {
        _page = page;
    }

    public async Task NavigateAsync()
    {
        await _page.GotoAsync("https://playwright.dev");
    }

    public async Task<string> GetTitleAsync()
    {
        return await _page.TitleAsync();
    }

    public async Task ClickGetStartedAsync()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();
    }

    public async Task<bool> IsInstallationHeadingVisibleAsync()
    {
        return await _page.GetByRole(AriaRole.Heading, new() { Name = "Installation" }).IsVisibleAsync();
    }
}
