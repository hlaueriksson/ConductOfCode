using System;
using TechTalk.SpecFlow;

namespace ConductOfCode.Specs
{
    [Binding]
    public class StackSteps
    {
        [Given(@"an empty stack")]
        public void GivenAnEmptyStack()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"a non empty stack")]
        public void GivenANonEmptyStack()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"calling peek")]
        public void WhenCallingPeek()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"calling pop")]
        public void WhenCallingPop()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it has no elements")]
        public void ThenItHasNoElements()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it throws an exception when calling pop")]
        public void ThenItThrowsAnExceptionWhenCallingPop()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it throws an exception when calling peek")]
        public void ThenItThrowsAnExceptionWhenCallingPeek()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it returns the top element")]
        public void ThenItReturnsTheTopElement()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it does not remove the top element")]
        public void ThenItDoesNotRemoveTheTopElement()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it removes the top element")]
        public void ThenItRemovesTheTopElement()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
