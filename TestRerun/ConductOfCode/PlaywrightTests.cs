using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace ConductOfCode
{
    public class PlaywrightTests : PageTest
    {
        [SetUp]
        public async Task SetUpAsync()
        {
            if (!TestContext.Parameters.Exists("Retry"))
            {
                return;
            }

            // Start tracing before creating / navigating a page.
            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        [TearDown]
        public async Task TearDownAsync()
        {
            if (!TestContext.Parameters.Exists("Retry"))
            {
                return;
            }

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                await Context.Tracing.StopAsync();
                return;
            }

            Console.WriteLine("Export trace for retry #" + TestContext.Parameters["Retry"]);

            // Stop tracing and export it into a zip archive.
            await Context.Tracing.StopAsync(new()
            {
                Path = $"{TestContext.CurrentContext.Test.FullName}.zip"
            });
        }

        [Test]
        public async Task Should_have_elevator_pitch_on_start_page()
        {
            await Page.GotoAsync("https://playwright.dev/dotnet/");

            await Expect(Page.GetByText("Playwright enables reliable end-to-end testing for modern web apps.")).ToBeVisibleAsync();
        }
    }
}
