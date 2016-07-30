using System;
using System.Collections.Generic;
using Xbehave;
using Xunit;

namespace ConductOfCode.Xbehave
{
    public class StackFeature
    {
        [Scenario]
        public void Empty(Stack<int> stack)
        {
            "Given an empty stack"
                .x(() => stack = new Stack<int>());

            "Then it has no elements"
                .x(() => Assert.Empty(stack));

            "And it throws an exception when calling pop"
                .x(() => Assert.Throws<InvalidOperationException>(() => stack.Pop()));

            "And it throws an exception when calling peek"
                .x(() => Assert.Throws<InvalidOperationException>(() => stack.Peek()));
        }

        [Scenario]
        public void NotEmpty(Stack<int> stack, int result)
        {
            "Given a non empty stack"
                .x(() => stack = new Stack<int>(new[] { 1, 2, 3 }));

            "When calling peek"
                .x(() => result = stack.Peek());

            "Then it returns the top element"
                .x(() => Assert.Equal(3, result));

            "But it does not remove the top element"
                .x(() => Assert.Contains(3, stack));

            "When calling pop"
                .x(() => result = stack.Pop());

            "The it returns the top element"
                .x(() => Assert.Equal(3, result));

            "And it removes the top element"
                .x(() => Assert.DoesNotContain(3, stack));
        }
    }
}