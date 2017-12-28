using System;
using NUnit.Framework;

namespace ConductOfCode.Xml
{
    public class Tests : BaseTests
    {
        [Test]
        public void Serialize()
        {
            var xml = Subject.ToXml();
            Console.WriteLine(xml);
        }

        [Test]
        public void Deserialize()
        {
            var xml = Subject.ToXml();
            var result = xml.FromXml<Subject>();
            Assert.AreEqual(xml, result.ToXml());
        }

        [Test]
        public void Problem_()
        {
            Assert.Throws(
                Is.TypeOf<NotSupportedException>().And.Message.EndsWith("is not supported because it implements IDictionary."),
                () => Problem.Dictionary.ToXml());
            Assert.Throws(
                Is.TypeOf<InvalidOperationException>().And.Message.EndsWith("cannot be serialized because it does not have a parameterless constructor."),
                () => Problem.Tuple.ToXml());
            Assert.Throws(
                Is.TypeOf<InvalidOperationException>().And.Message.EndsWith("cannot be serialized because it does not have a parameterless constructor."),
                () => Problem.Uri.ToXml());
        }

        [Test]
        public void CircularReference()
        {
            Console.WriteLine(a.ToXml());
        }

        [Test]
        public void Polymorphism()
        {
            Console.WriteLine(c.ToXml());
            Assert.AreEqual(c.ToXml(), c.ToXml().FromXml<C>().ToXml());
        }
    }
}