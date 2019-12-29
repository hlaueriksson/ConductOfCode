using System;
using System.Collections.Generic;
using FluentAssertions;
using LoFuUnit.NUnit;
using NUnit.Framework;

namespace ConductOfCode
{
    public class StackTests
    {
        [LoFu, Test]
        public void When_empty()
        {
            Subject = new Stack<int>();

            void should_have_no_elements() =>
                Subject.Should().BeEmpty();
            void should_throw_an_exception_when_calling__Pop__() =>
                Subject.Invoking(y => y.Pop()).Should().Throw<InvalidOperationException>();
            void should_throw_an_exception_when_calling__Peek__() =>
                Subject.Invoking(y => y.Peek()).Should().Throw<InvalidOperationException>();
        }

        [LoFu, Test]
        public void When_not_empty()
        {
            Subject = new Stack<int>(new[] { 1, 2, 3 });

            void should_return_the_top_element_when_calling__Peek__() =>
                Subject.Peek().Should().Be(3);
            void should_not_remove_the_top_element_when_calling__Peek__()
            {
                var result = Subject.Peek();
                Subject.Should().Contain(result);
            }
            void should_return_the_top_element_when_calling__Pop__() =>
                Subject.Pop().Should().Be(3);
            void should_remove_the_top_element_when_calling__Pop__()
            {
                var result = Subject.Pop();
                Subject.Should().NotContain(result);
            }
        }

        Stack<int> Subject { get; set; }
    }
}