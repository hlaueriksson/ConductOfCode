using FluentAssertions;
using LoFuUnit.AutoNSubstitute;
using LoFuUnit.NUnit;
using NSubstitute;
using NUnit.Framework;

namespace ConductOfCode
{
    public class HelloWorldTests : LoFuTest<HelloWorld>
    {
        [SetUp]
        public void SetUp()
        {
            Use<IFoo>().GetFoo().Returns("Hello");
            Use(Substitute.For<IBar>()).GetBar().Returns(", World!");
        }

        [LoFu, Test]
        public void When_GetMessage()
        {
            Result = Subject.GetMessage();

            void should_invoke_IFoo_GetMessage() =>
                The<IFoo>().Received().GetFoo();
            void should_invoke_IBar_GetMessage() =>
                The<IBar>().Received(1).GetBar();
            void should_return_a_concatenated_string_with_messages_from_IFoo_and_IBar() =>
                Result.Should().Be("Hello, World!");
        }

        string Result { get; set; }
    }
}