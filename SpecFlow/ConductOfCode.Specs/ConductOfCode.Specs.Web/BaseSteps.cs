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
            webApp.Settings.Title = "ConductOfCode.Specs.Web";

            Reporters.Add(webApp);

            Reporters.FinishedReport += (sender, args) =>
            {
                var reporter = args.Reporter as WebAppReporter;
                reporter?.WriteToFolder("ConductOfCode.Specs.Web", true);
            };
        }
    }
}