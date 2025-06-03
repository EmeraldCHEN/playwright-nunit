using System.Text.RegularExpressions;
using Microsoft.Playwright.NUnit;
using EcommerceApp.Tests.Models;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ExampleTest : PageTest
{
    private HomePage homePage;

    [SetUp]
    public void Setup()
    {
        homePage = new HomePage(Page);
    }

    [Test]
    public async Task HasTitle()
    {
        await homePage.NavigateAsync();
        Assert.That(await homePage.GetTitleAsync(), Does.Match(new Regex("Playwright")));
    }

    [Test]
    public async Task GetStartedLink()
    {
        await homePage.NavigateAsync();
        await homePage.ClickGetStartedAsync();
        Assert.That(await homePage.IsInstallationHeadingVisibleAsync(), Is.True);

    }
}
