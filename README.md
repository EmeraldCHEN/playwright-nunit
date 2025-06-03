# playwright-nunit

## Summary Project Structure with Purpose

PLAYWRIGHT-NUNIT/

| ── config/                # contains sensitive config data

│    └── credentials.json   

| ── pages/         # contains Page Object Models (POMs) (encapsulate UI logic)
 
│    └── home-page.cs

│    └── login-page.cs   

| ── tests/         # Actual NUnit test classes

│    └── home-page.cs

│    └── login-page.cs  

| ── utilitis/      # contains shared test utilities: BaseTest, helpers, etc.

│    └── base-test.cs

| ── wiki/

| ── playwright-nunit.csproj


🚀 Getting Started

1. Clone the repository:

```bash
git clone [repo-url]
cd playwright-nunit
```

2. Install dependencies:

```bash
dotnet add package Microsoft.Playwright.NUnit
```

3. Build the project:

```bash
dotnet build
```

4. Install browsers:

```bash
pwsh bin/Debug/net9.0/playwright.ps1 install --with-deps

```


🧩 Utilize Page Object Models (POMs) and Benefits of This Approach

Organize the test code by implementing Page Object Models. This design pattern helps in reducing code duplication and improving test maintenance. 
Ensure that these models encapsulate all interactions with the UI elements on their respective pages.

- Reusability: The page objects in the `Pages` folder can be reused across multiple tests.

- Readability: Test methods read more like user actions.

- Maintainability: Locator changes only require updates in one place.

✅ To find more details, follow the steps from [here](https://playwright.dev/dotnet/docs/intro#introduction) to install the necessary Playwright dependencies

- Install `Newtonsoft.Json` (or any JSON library of your choice) to parse `credentials.json`

```bash
dotnet add package Newtonsoft.Json
```

- If a file listed in `.gitignore` still appears in your Git repository, it's because Git has already started tracking it. `.gitignore` prevents new files from being tracked but does not untrack existing ones. To stop Git from tracking the file without deleting it from your local system, use this command:

```bash
git rm --cached [file-path]
```


📚 Resources

- [Playwright for .NET](https://playwright.dev/dotnet/docs/intro)

- [install PowerShell as a .NET Global tool](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-windows?view=powershell-7.5#install-as-a-net-global-tool)

- [Test generator](https://playwright.dev/dotnet/docs/codegen)

- [Page object models](https://playwright.dev/dotnet/docs/pom)

- [API testing](https://playwright.dev/dotnet/docs/api-testing)

- [Best Practices](https://playwright.dev/docs/best-practices)

- [Dynamics 365 sample automation tests](https://github.com/microsoft/Dynamics-365-FastTrack-Implementation-Assets/tree/master/Customer%20Service/Testing/Automation/Playwright/Samples/automation)
