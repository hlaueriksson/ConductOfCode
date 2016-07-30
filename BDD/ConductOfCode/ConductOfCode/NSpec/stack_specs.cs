using System;
using System.Collections.Generic;
using NSpec;

namespace ConductOfCode.NSpec
{
    class stack_specs : nspec
    {
        void empty_()
        {
            before = () => stack = new Stack<int>();

            it["has no elements"] = () => stack.Count.should_be(0);
            it["throws an exception when calling pop"] = () => expect<InvalidOperationException>(() => stack.Pop());
            it["throws an exception when calling peek"] = () => expect<InvalidOperationException>(() => stack.Peek());
        }

        void not_empty()
        {
            before = () => stack = new Stack<int>(new[] { 1, 2, 3 });

            it["returns the top element when calling peek"] = () => stack.Peek().should_be(3);
            it["does not remove the top element when calling peek"] = () =>
            {
                stack.Peek();
                stack.should_contain(3);
            };
            it["returns the top element when calling pop"] = () => stack.Pop().should_be(3);
            it["removes the top element when calling pop"] = () =>
            {
                stack.Pop();
                stack.should_not_contain(3);
            };
        }

        Stack<int> stack;
    }
}