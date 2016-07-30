using System;
using System.Collections.Generic;
using Concordion.NET.Integration;
using Concordion.Runners.NUnit;
using NUnit.Framework;

namespace ConductOfCode.Concordion
{
    [TestFixture]
    [ConcordionTest]
    public class StackTest : ExecutableSpecification
    {
        private Stack<int> stack;

        public int TopElement => 3;

        // Empty

        public void GivenAnEmptyStack()
        {
            stack = new Stack<int>();
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public bool ShouldThrowWhenPop()
        {
            return ShouldThrowWhen(() => stack.Pop());
        }

        public bool ShouldThrowWhenPeek()
        {
            return ShouldThrowWhen(() => stack.Peek());
        }

        private bool ShouldThrowWhen(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                return true;
            }

            return false;
        }

        // Not empty

        public void GivenANonEmptyStack()
        {
            stack = new Stack<int>(new[] { 1, 2, TopElement });
        }

        public int Pop()
        {
            return stack.Pop();
        }

        public int Peek()
        {
            return stack.Peek();
        }

        public bool Contains(int value)
        {
            return stack.Contains(value);
        }

        public bool DoesNotContain(int value)
        {
            return !stack.Contains(value);
        }
    }
}