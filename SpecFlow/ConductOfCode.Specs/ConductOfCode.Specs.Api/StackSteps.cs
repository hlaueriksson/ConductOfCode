using TechTalk.SpecFlow;

namespace ConductOfCode.Specs
{
    [Binding]
    public class StackSteps : BaseSteps
    {
        [Given(@"an empty stack")]
        public void GivenAnEmptyStack()
        {
        }
        
        [Given(@"a non empty stack")]
        public void GivenANonEmptyStack()
        {
        }
        
        [When(@"calling peek")]
        public void WhenCallingPeek()
        {
        }
        
        [When(@"calling pop")]
        public void WhenCallingPop()
        {
        }
        
        [Then(@"it has no elements")]
        public void ThenItHasNoElements()
        {
        }
        
        [Then(@"it throws an exception when calling pop")]
        public void ThenItThrowsAnExceptionWhenCallingPop()
        {
        }
        
        [Then(@"it throws an exception when calling peek")]
        public void ThenItThrowsAnExceptionWhenCallingPeek()
        {
        }
        
        [Then(@"it returns the top element")]
        public void ThenItReturnsTheTopElement()
        {
        }
        
        [Then(@"it does not remove the top element")]
        public void ThenItDoesNotRemoveTheTopElement()
        {
        }
        
        [Then(@"it removes the top element")]
        public void ThenItRemovesTheTopElement()
        {
        }
    }
}
