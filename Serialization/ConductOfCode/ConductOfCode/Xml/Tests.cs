using System;
using System.Collections.Generic;
using NUnit.Framework;
using Ploeh.AutoFixture;

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
        public void Serialize_with_no_indentation()
        {
            var xml = Subject.ToXml(false);
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
        public void Serialize_IDictionary_fails()
        {
            var subject = Fixture.Create<Dictionary<string, Foo>>();

            Assert.Throws(
                Is.TypeOf<NotSupportedException>().And.Message.EndsWith("is not supported because it implements IDictionary."),
                () => subject.ToXml());
        }

        [Test]
        public void Serialize_parameterless_constructor_fails()
        {
            var subject = Fixture.Create<Tuple<Foo, Bar>>();

            Assert.Throws(
                Is.TypeOf<InvalidOperationException>().And.Message.EndsWith("cannot be serialized because it does not have a parameterless constructor."),
                () => subject.ToXml());
        }

        [Test]
        public void Serialize_circular_reference_fails()
        {
            Assert.Throws(
                Is.TypeOf<InvalidOperationException>().And.InnerException.Message.StartsWith("A circular reference was detected while serializing an object"),
                () => Parent.ToXml());
        }

        [Test]
        public void Serialize_polymorphism_fails()
        {
            Assert.Throws(
                Is.TypeOf<InvalidOperationException>().And.InnerException.Message.EndsWith("Use the XmlInclude or SoapInclude attribute to specify types that are not known statically."),
                () => Geometry.ToXml().FromXml<Geometry>());
        }
    }
}