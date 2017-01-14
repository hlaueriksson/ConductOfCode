using System;
using System.Collections.Generic;
using Should;
using TechTalk.SpecFlow;
using Xunit;

namespace ConductOfCode.Specs
{
    [Binding]
    public class StackSteps : BaseSteps
    {
        private Stack<int> stack;

        private int result;

        // Empty

        [Given(@"an empty stack")]
        public void GivenAnEmptyStack()
        {
            stack = new Stack<int>();
        }

        [Then(@"it has no elements")]
        public void ThenItHasNoElements()
        {
            stack.ShouldBeEmpty();
        }

        [Then(@"it throws an exception when calling pop")]
        public void ThenItThrowsAnExceptionWhenCallingPop()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Then(@"it throws an exception when calling peek")]
        public void ThenItThrowsAnExceptionWhenCallingPeek()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        // Not empty

        [Given(@"a non empty stack")]
        public void GivenANonEmptyStack()
        {
            stack = new Stack<int>(new[] { 1, 2, 3 });
        }

        [When(@"calling peek")]
        public void WhenCallingPeek()
        {
            result = stack.Peek();
        }

        [Then(@"it returns the top element")]
        public void ThenItReturnsTheTopElement()
        {
            result.ShouldEqual(3);
        }

        [Then(@"it does not remove the top element")]
        public void ThenItDoesNotRemoveTheTopElement()
        {
            stack.ShouldContain(3);
        }

        [When(@"calling pop")]
        public void WhenCallingPop()
        {
            result = stack.Pop();
        }

        [Then(@"it removes the top element")]
        public void ThenItRemovesTheTopElement()
        {
            stack.ShouldNotContain(3);
        }
    }
}