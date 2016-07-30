using System;
using System.Collections.Generic;
using LightBDD;
using NUnit.Framework;

namespace ConductOfCode.LightBDD
{
    public partial class Stack_feature : FeatureFixture
    {
        private Stack<int> stack;

        private int result;

        // Empty

        private void an_empty_stack()
        {
            stack = new Stack<int>();
        }

        private void it_has_no_elements()
        {
            Assert.That(stack, Is.Empty);
        }

        private void it_throws_an_exception_when_calling_pop()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        private void it_throws_an_exception_when_calling_peek()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        // Not empty

        private void a_non_empty_stack()
        {
            stack = new Stack<int>(new[] { 1, 2, 3 });
        }

        private void calling_peek()
        {
            result = stack.Peek();
        }

        private void it_returns_the_top_element()
        {
            Assert.That(result, Is.EqualTo(3));
        }

        private void it_does_not_remove_the_top_element()
        {
            Assert.That(stack.Contains(3), Is.True);
        }

        private void calling_pop()
        {
            result = stack.Pop();
        }

        private void it_removes_the_top_element()
        {
            Assert.That(stack.Contains(result), Is.False);
        }
    }
}