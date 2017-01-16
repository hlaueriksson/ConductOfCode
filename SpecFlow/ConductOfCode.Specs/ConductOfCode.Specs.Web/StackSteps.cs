using Should;
using TechTalk.SpecFlow;

namespace ConductOfCode.Specs
{
    [Binding]
    public class StackSteps// : BaseSteps
    {
        private StackPage page;

        private string result;

        [AfterScenario]
        public void AfterScenario()
        {
            page?.Dispose();
        }

        // Empty

        [Given(@"an empty stack")]
        public void GivenAnEmptyStack()
        {
            page = new StackPage();
            page.Visit();
            page.Clear();
        }

        [Then(@"it has no elements")]
        public void ThenItHasNoElements()
        {
            page.ToArray().ShouldBeEmpty();
        }

        [Then(@"it throws an exception when calling pop")]
        public void ThenItThrowsAnExceptionWhenCallingPop()
        {
            page.Pop();
            page.Error.ShouldExist();
        }

        [Then(@"it throws an exception when calling peek")]
        public void ThenItThrowsAnExceptionWhenCallingPeek()
        {
            page.Peek();
            page.Error.ShouldExist();
        }

        // Not empty

        [Given(@"a non empty stack")]
        public void GivenANonEmptyStack()
        {
            page = new StackPage();
            page.Visit();
            page.Clear();
            page.Push("1");
            page.Push("2");
            page.Push("3");
        }

        [When(@"calling peek")]
        public void WhenCallingPeek()
        {
            result = page.Peek().Text;
        }

        [Then(@"it returns the top element")]
        public void ThenItReturnsTheTopElement()
        {
            result.ShouldEqual("3");
        }

        [Then(@"it does not remove the top element")]
        public void ThenItDoesNotRemoveTheTopElement()
        {
            page.ToArray().ShouldContain("3");
        }

        [When(@"calling pop")]
        public void WhenCallingPop()
        {
            result = page.Pop().Text;
        }

        [Then(@"it removes the top element")]
        public void ThenItRemovesTheTopElement()
        {
            page.ToArray().ShouldNotContain("3");
        }
    }
}