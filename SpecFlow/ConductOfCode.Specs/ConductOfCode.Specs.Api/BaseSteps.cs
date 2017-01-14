using SpecResults;
using SpecResults.WebApp;
using TechTalk.SpecFlow;

namespace ConductOfCode.Specs
{
    [Binding]
    public class BaseSteps : ReportingStepDefinitions
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var webApp = new WebAppReporter();
            webApp.Settings.Title = "ConductOfCode.Specs.Api";

            Reporters.Add(webApp);

            Reporters.FinishedReport += (sender, args) =>
            {
                var reporter = args.Reporter as WebAppReporter;
                reporter?.WriteToFolder("ConductOfCode.Specs.Api", true);
            };
        }
    }
}