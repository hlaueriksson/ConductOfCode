using System;
using Machine.Specifications;

namespace ConductOfCode.MSpec
{
    using System.Collections.Generic;

    public class StackSpecs
    {
        [Subject(typeof(Stack<>))]
        public class When_empty
        {
            Establish context = () =>
            {
                Subject = new Stack<int>();
            };

            It should_have_no_elements = () => Subject.ShouldBeEmpty();
            It should_throw_an_exception_when_calling_pop = () => Catch.Exception(() => Subject.Pop()).ShouldBeOfExactType<InvalidOperationException>();
            It should_throw_an_exception_when_calling_peek = () => Catch.Exception(() => Subject.Peek()).ShouldBeOfExactType<InvalidOperationException>();

            static Stack<int> Subject;
        }

        [Subject(typeof(Stack<>))]
        public class When_not_empty
        {
            Establish context = () =>
            {
                Subject = new Stack<int>(new[] { 1, 2, 3 });
            };

            It should_return_the_top_element_when_calling_peek = () => Subject.Peek().ShouldEqual(3);
            It should_not_remove_the_top_element_when_calling_peek = () =>
            {
                Subject.Peek();
                Subject.ShouldContain(3);
            };
            It should_return_the_top_element_when_calling_pop = () => Subject.Pop().ShouldEqual(3);
            It should_remove_the_top_element_when_calling_pop = () =>
            {
                Subject.Pop();
                Subject.ShouldNotContain(3);
            };

            static Stack<int> Subject;
        }
    }
}