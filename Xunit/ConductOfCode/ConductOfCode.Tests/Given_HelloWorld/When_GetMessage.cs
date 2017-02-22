using ConductOfCode.Core;
using ConductOfCode.Tests.Fakes;
using Moq;
using Should;
using Xunit;

namespace ConductOfCode.Tests.Given_HelloWorld
{
    public class When_GetMessage : WithFakes
    {
        private HelloWorld Subject => Subject<HelloWorld>();

        public When_GetMessage()
        {
            The<IFoo>().Setup(x => x.GetFoo()).Returns("Hello");
            With<IBar>(x => x.GetBar() == ", World!");
        }

        [Fact]
        public void Should_invoke_IFoo_GetMessage()
        {
            Subject.GetMessage();

            The<IFoo>().Verify(x => x.GetFoo());
        }

        [Fact]
        public void Should_invoke_IBar_GetMessage()
        {
            Subject.GetMessage();

            The<IBar>().Verify(x => x.GetBar(), Times.Once);
        }

        [Fact]
        public void Should_return_a_concatenated_string_with_messages_from_IFoo_and_IBar()
        {
            Subject.GetMessage().ShouldEqual("Hello, World!");
        }
    }
}