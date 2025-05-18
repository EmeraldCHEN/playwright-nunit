using System.Text.Json;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaywrightTests
{
    [TestFixture]
    public class TestGitHubAPI
    {
        static string REPO = "test-repo-2";
        static string USER = Environment.GetEnvironmentVariable("GITHUB_USER");
        static string? API_TOKEN = Environment.GetEnvironmentVariable("GITHUB_API_TOKEN");

        private IAPIRequestContext Request = null!;

        [Test]
        public async Task ShouldCreateBugReport()
        {
            var data = new Dictionary<string, string>
            {
                { "title", "[Bug] report 1" },
                { "body", "Bug description" }
            };
            var newIssue = await Request.PostAsync("/repos/" + USER + "/" + REPO + "/issues", new() { DataObject = data });
            Assert.That(newIssue.Status, Is.EqualTo(201));

            var issues = await Request.GetAsync("/repos/" + USER + "/" + REPO + "/issues");
            Assert.That(issues.Status, Is.EqualTo(200));

            var issuesJsonResponse = await issues.JsonAsync();
            JsonElement? issue = null;

            foreach (JsonElement issueObj in issuesJsonResponse?.EnumerateArray() ?? new JsonElement[0])
            {
                if (issueObj.TryGetProperty("title", out var title) && title.GetString() == "[Bug] report 1")
                {
                    issue = issueObj;
                }
            }

            Assert.IsNotNull(issue);
            Assert.That(issue?.GetProperty("body").GetString(), Is.EqualTo("Bug description"));
        }

        [Test]
        public async Task ShouldCreateFeatureRequests()
        {
            var data = new Dictionary<string, string>
            {
                { "title", "[Feature] request 1" },
                { "body", "Feature description" }
            };
            var newIssue = await Request.PostAsync("/repos/" + USER + "/" + REPO + "/issues", new() { DataObject = data });
            Assert.That(newIssue.Status, Is.EqualTo(201));

            var issues = await Request.GetAsync("/repos/" + USER + "/" + REPO + "/issues");
            Assert.That(issues.Status, Is.EqualTo(200));

            var issuesJsonResponse = await issues.JsonAsync();
            JsonElement? issue = null;

            foreach (JsonElement issueObj in issuesJsonResponse?.EnumerateArray() ?? new JsonElement[0])
            {
                if (issueObj.TryGetProperty("title", out var title) && title.GetString() == "[Feature] request 1")
                {
                    issue = issueObj;
                }
            }

            Assert.IsNotNull(issue);
            Assert.That(issue?.GetProperty("body").GetString(), Is.EqualTo("Feature description"));
        }

        [SetUp]
        public async Task SetUpAPITesting()
        {
            await CreateAPIRequestContext();
            await CreateTestRepository();
        }

        private async Task CreateAPIRequestContext()
        {
            var headers = new Dictionary<string, string>
            {
                { "Accept", "application/vnd.github.v3+json" },
                { "Authorization", "token " + API_TOKEN }
            };

            var playwright = await Playwright.CreateAsync();
            Request = await playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://api.github.com",
                ExtraHTTPHeaders = headers,
            });
        }

        private async Task CreateTestRepository()
        {
            var resp = await Request.PostAsync("/user/repos", new()
            {
                DataObject = new Dictionary<string, string>()
                {
                    ["name"] = REPO,
                },
            });
            Assert.That(resp.Status, Is.EqualTo(201));
        }

        [TearDown]
        public async Task TearDownAPITesting()
        {
            await DeleteTestRepository();
            await Request.DisposeAsync();
        }

        private async Task DeleteTestRepository()
        {
            var resp = await Request.DeleteAsync("/repos/" + USER + "/" + REPO);
            Assert.That(resp.Status, Is.EqualTo(204));
        }
    }
}
