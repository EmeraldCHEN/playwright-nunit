using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
{
    Headless = false,
});
var context = await browser.NewContextAsync();

var page = await context.NewPageAsync();
await page.GotoAsync("https://login.microsoftonline.com/");
await page.GetByRole(AriaRole.Textbox, new() { Name = "Enter the password for" }).FillAsync("password");
await page.GetByRole(AriaRole.Button, new() { Name = "Sign in" }).ClickAsync();
await page.GotoAsync("https://xyznz-onmicrosoft-com.access.mcas.ms/aad_login");
await page.GetByRole(AriaRole.Button, new() { Name = "Continue in current browser" }).ClickAsync();
await page.GotoAsync("https://xyz-test.crm6.dynamics.com.mcas.ms/");
await page.GetByRole(AriaRole.Menuitem, new() { Name = "New", Exact = true }).ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "J, Lookup" }).ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "J, Lookup" }).PressAsync("Enter");
await page.GetByText("Family Court").ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "location, Lookup" }).ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "location, Lookup" }).PressAsync("Enter");
await page.GetByText("Queenstown").ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "Submitted via" }).ClickAsync();
await page.GetByRole(AriaRole.Option, new() { Name = "Counter" }).ClickAsync();
await page.Locator("[id=\"id-xxxxxxx_submittedondate\\.fieldControl-courts_submittedondate\\.fieldControl\\._datecontrol-date-container\"] svg").ClickAsync();
await page.GetByRole(AriaRole.Button, new() { Name = "15, May," }).ClickAsync();
await page.GetByRole(AriaRole.Menuitem, new() { Name = "Save (CTRL+S)" }).ClickAsync();
await page.GetByText("Draft").ClickAsync();
await page.GetByText("Status reason").ClickAsync();
await page.GetByRole(AriaRole.Menuitem, new() { Name = "New Application. Add New" }).ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "L, Lookup" }).ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "L, Lookup" }).PressAsync("Enter");
await page.GetByText("Care of Children Act").ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "Section of the Act, Lookup" }).ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "Section of the Act, Lookup" }).PressAsync("Enter");
await page.GetByRole(AriaRole.Combobox, new() { Name = "Section of the Act, Lookup" }).FillAsync("s48");
await page.Locator("[id=\"id-xxxxxxxxxxsectionid\\.fieldControl-courts_name0_0_0\"]").ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "Application type, Lookup" }).ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "Application type, Lookup" }).PressAsync("Enter");
await page.GetByText("s48 Application for parenting order", new() { Exact = true }).ClickAsync();
await page.GetByRole(AriaRole.Combobox, new() { Name = "Filing method" }).ClickAsync();
await page.GetByRole(AriaRole.Option, new() { Name = "On Notice" }).ClickAsync();
await page.GetByRole(AriaRole.Button, new() { Name = "Save and Close", Exact = true }).ClickAsync();
await page.GetByRole(AriaRole.Menuitem, new() { Name = "Save & Close" }).ClickAsync();
await page.GetByRole(AriaRole.Link, new() { Name = "FB-2025-xxxxxxx" }).ClickAsync();
await page.GetByRole(AriaRole.Button, new() { Name = "Account manager for XYZ" }).ClickAsync();
await page.GetByRole(AriaRole.Button, new() { Name = "Sign out of this account" }).ClickAsync();
await page.GetByRole(AriaRole.Heading, new() { Name = "You signed out of your account" }).ClickAsync();
