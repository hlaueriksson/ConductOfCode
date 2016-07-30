using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;

namespace ConductOfCode.SpecFlow
{
    [Binding]
    public class StackSteps
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
            Assert.Empty(stack);
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
            Assert.Equal(3, result);
        }

        [Then(@"it does not remove the top element")]
        public void ThenItDoesNotRemoveTheTopElement()
        {
            Assert.Contains(3, stack);
        }

        [When(@"calling pop")]
        public void WhenCallingPop()
        {
            result = stack.Pop();
        }

        [Then(@"it removes the top element")]
        public void ThenItRemovesTheTopElement()
        {
            Assert.DoesNotContain(3, stack);
        }
    }
}