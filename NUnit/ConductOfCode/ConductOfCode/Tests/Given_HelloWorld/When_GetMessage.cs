using Moq;
using NUnit.Framework;
using Should;

namespace ConductOfCode.Tests.Given_HelloWorld
{
    public class When_GetMessage
    {
        private HelloWorld _subject;
        private Mock<IFoo> _foo;
        private Mock<IBar> _bar;

        [SetUp]
        public void SetUp()
        {
            _foo = new Mock<IFoo>();
            _bar = new Mock<IBar>();
            _subject = new HelloWorld(_foo.Object, _bar.Object);
        }

        [Test]
        public void Should_invoke_IFoo_GetMessage()
        {
            _subject.GetMessage();

            _foo.Verify(x => x.GetFoo());
        }

        [Test]
        public void Should_invoke_IBar_GetMessage()
        {
            _subject.GetMessage();

            _bar.Verify(x => x.GetBar(), Times.Once);
        }

        [Test]
        public void Should_return_a_concatenated_string_with_messages_from_IFoo_and_IBar()
        {
            _foo.Setup(x => x.GetFoo()).Returns("Hello");
            _bar.Setup(x => x.GetBar()).Returns(", World!");

            _subject.GetMessage().ShouldEqual("Hello, World!");
        }
    }
}