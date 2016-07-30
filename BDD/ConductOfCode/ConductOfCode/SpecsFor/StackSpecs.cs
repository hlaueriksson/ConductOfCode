using System;
using System.Collections.Generic;
using NUnit.Framework;
using Should;
using SpecsFor;

namespace ConductOfCode.SpecsFor
{
    public class StackSpecs
    {
        public class given_an_empty_stack : SpecsFor<Stack<int>>
        {
            [Test]
            public void then_it_has_no_elements()
            {
                SUT.Count.ShouldEqual(0);
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void then_it_throws_an_exception_when_calling_pop()
            {
                SUT.Pop();
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void then_it_throws_an_exception_when_calling_peek()
            {
                SUT.Peek();
            }
        }

        public class given_a_non_empty_stack : SpecsFor<Stack<int>>
        {
            protected override void BeforeEachTest()
            {
                SUT = new Stack<int>(new[] { 1, 2, 3 });
            }

            [Test]
            public void then_it_returns_the_top_element_when_calling_peek()
            {
                SUT.Peek().ShouldEqual(3);
            }

            [Test]
            public void then_it_does_not_remove_the_top_element_when_calling_peek()
            {
                SUT.Peek();
                SUT.ShouldContain(3);
            }

            [Test]
            public void then_it_returns_the_top_element_when_calling_pop()
            {
                SUT.Pop().ShouldEqual(3);
            }

            [Test]
            public void then_it_removes_the_top_element_when_calling_pop()
            {
                SUT.Pop();
                SUT.ShouldNotContain(3);
            }
        }
    }
}