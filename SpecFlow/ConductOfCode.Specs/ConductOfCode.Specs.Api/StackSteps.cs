using System;
using ConductOfCode.Specs.Clients;
using Should;
using Should.Core.Assertions;
using TechTalk.SpecFlow;

namespace ConductOfCode.Specs
{
    [Binding]
    public class StackSteps : BaseSteps
    {
        private StackFacade facade;

        private string result;

        // Empty

        [Given(@"an empty stack")]
        public void GivenAnEmptyStack()
        {
            facade = new StackFacade();
            facade.Clear();
        }

        [Then(@"it has no elements")]
        public void ThenItHasNoElements()
        {
            facade.ToArray().ShouldBeEmpty();
        }

        [Then(@"it throws an exception when calling pop")]
        public void ThenItThrowsAnExceptionWhenCallingPop()
        {
            var exception = Assert.Throws<AggregateException>(() => facade.Pop());
            exception.InnerException.ShouldBeType<SwaggerException<Error>>();
        }

        [Then(@"it throws an exception when calling peek")]
        public void ThenItThrowsAnExceptionWhenCallingPeek()
        {
            var exception = Assert.Throws<AggregateException>(() => facade.Peek());
            exception.InnerException.ShouldBeType<SwaggerException<Error>>();
        }

        // Not empty

        [Given(@"a non empty stack")]
        public void GivenANonEmptyStack()
        {
            facade = new StackFacade();
            facade.Clear();
            facade.Push("1");
            facade.Push("2");
            facade.Push("3");
        }

        [When(@"calling peek")]
        public void WhenCallingPeek()
        {
            result = facade.Peek();
        }

        [Then(@"it returns the top element")]
        public void ThenItReturnsTheTopElement()
        {
            result.ShouldEqual("3");
        }

        [Then(@"it does not remove the top element")]
        public void ThenItDoesNotRemoveTheTopElement()
        {
            facade.ToArray().ShouldContain("3");
        }

        [When(@"calling pop")]
        public void WhenCallingPop()
        {
            result = facade.Pop();
        }

        [Then(@"it removes the top element")]
        public void ThenItRemovesTheTopElement()
        {
            facade.ToArray().ShouldNotContain("3");
        }
    }
}