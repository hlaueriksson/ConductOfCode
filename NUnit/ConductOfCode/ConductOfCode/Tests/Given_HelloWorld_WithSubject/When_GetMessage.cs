using ConductOfCode.Fakes;
using Moq;
using NUnit.Framework;
using Should;

namespace ConductOfCode.Tests.Given_HelloWorld_WithSubject
{
    public class When_GetMessage : WithSubject<HelloWorld>
    {
        [SetUp]
        public void SetUp()
        {
            The<IFoo>().Setup(x => x.GetFoo()).Returns("Hello");
            With<IBar>(x => x.GetBar() == ", World!");
        }

        [Test]
        public void Should_invoke_IFoo_GetMessage()
        {
            Subject.GetMessage();

            The<IFoo>().Verify(x => x.GetFoo());
        }

        [Test]
        public void Should_invoke_IBar_GetMessage()
        {
            Subject.GetMessage();

            The<IBar>().Verify(x => x.GetBar(), Times.Once);
        }

        [Test]
        public void Should_return_a_concatenated_string_with_messages_from_IFoo_and_IBar()
        {
            Subject.GetMessage().ShouldEqual("Hello, World!");
        }
    }
}