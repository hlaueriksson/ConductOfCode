using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace ConductOfCode.Steps
{
    [Binding]
    public class StackSteps
    {
        private Stack<string> stack;
        private string result;
        private int count;
        private bool contains;
        private Exception exception;

        [Given(@"an empty stack")]
        public void GivenAnEmptyStack()
        {
            stack = new Stack<string>();
        }

        [Given(@"a stack with the elements:")]
        public void GivenAStackWithTheElements(Table table)
        {
            var elements = table.Rows.Select(x => x.Values.First()).ToList();

            stack = new Stack<string>(elements);
        }

        [When(@"the pushing the elements:")]
        public void WhenThePushingTheElements(Table table)
        {
            var elements = table.Rows.Select(x => x.Values.First()).ToList();

            foreach (var element in elements)
            {
                stack.Push(element);
            }
        }

        [When(@"counting the elements")]
        public void WhenCountingTheElements()
        {
            count = stack.Count;
        }

        [When(@"pushing the element ""(.*)""")]
        public void WhenPushingTheElement(string element)
        {
            stack.Push(element);
        }

        [When(@"popping the element on top")]
        public void WhenPoppingTheElementOnTop()
        {
            try
            {
                result = stack.Pop();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        [When(@"peeking at the element on top")]
        public void WhenPeekingAtTheElementOnTop()
        {
            try
            {
                result = stack.Peek();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        [When(@"determining if the stack contains the element ""(.*)""")]
        public void WhenDeterminingIfTheStackContainsTheElement(string element)
        {
            contains = stack.Contains(element);
        }

        [Then(@"the elements should be popped in the order:")]
        public void ThenTheElementsShouldBePoppedInTheOrder(Table table)
        {
            var elements = table.Rows.Select(x => x.Values.First()).ToList();

            foreach (var element in elements)
            {
                element.ShouldEqual(stack.Pop());
            }
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            count.ShouldEqual(expected);
        }

        [Then(@"the element ""(.*)"" should be on top")]
        public void ThenTheElementShouldBeOnTop(string element)
        {
            element.ShouldEqual(stack.Peek());
        }

        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string expected)
        {
            result.ShouldEqual(expected);
        }

        [Then(@"the result should be true")]
        public void ThenTheResultShouldBeTrue()
        {
            contains.ShouldBeTrue();
        }

        [Then(@"the result should be false")]
        public void ThenTheResultShouldBeFalse()
        {
            contains.ShouldBeFalse();
        }

        [Then(@"InvalidOperationException should be thrown")]
        public void ThenInvalidOperationExceptionShouldBeThrown()
        {
            exception.ShouldBeType<InvalidOperationException>();
        }

        [Then(@"the stack should contain the elements:")]
        public void ThenTheStackShouldContainTheElements(Table table)
        {
            var elements = table.Rows.Select(x => x.Values.First()).ToList();

            foreach (var element in elements)
            {
                stack.Contains(element).ShouldBeTrue();
            }
        }
    }
}