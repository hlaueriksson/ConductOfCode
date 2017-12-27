using System;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace ConductOfCode
{
    public class Tests
    {
        private Subject _subject;
        private Problem _problem;

        [SetUp]
        public void SetUp()
        {
            var fixture = new Fixture();
            _subject = fixture.Create<Subject>();
            _problem = fixture.Create<Problem>();
        }

        [Test]
        public void Xml()
        {
            var xml = _subject.ToXml();
            Console.WriteLine(xml);

            var result = xml.FromXml<Subject>();
            Assert.AreEqual(xml, result.ToXml());

            Assert.Throws(
                Is.TypeOf<NotSupportedException>().And.Message.EndsWith("is not supported because it implements IDictionary."),
                () => _problem.Dictionary.ToXml());
            Assert.Throws(
                Is.TypeOf<InvalidOperationException>().And.Message.EndsWith("cannot be serialized because it does not have a parameterless constructor."),
                () => _problem.Tuple.ToXml());
            Assert.Throws(
                Is.TypeOf<InvalidOperationException>().And.Message.EndsWith("cannot be serialized because it does not have a parameterless constructor."),
                () => _problem.Uri.ToXml());
        }

        [Test]
        public void Json()
        {
            var json = _subject.ToJson();
            Console.WriteLine(json);

            var result = json.FromJson<Subject>();
            Assert.AreEqual(json, result.ToJson());

            Console.WriteLine(_problem.ToJson());
        }

        [Test]
        public void Yaml()
        {
            var yaml = _subject.ToYaml();
            Console.WriteLine(yaml);

            var result = yaml.FromYaml<Subject>();
            Assert.AreEqual(yaml, result.ToYaml());

            Console.WriteLine(_problem.ToYaml());
        }

        [Test]
        public void Toml()
        {
            var toml = _subject.ToToml();
            Console.WriteLine(toml);

            var result = toml.FromToml<Subject>();
            Assert.AreEqual(toml, result.ToToml());

            Assert.Throws(
                Is.TypeOf<InvalidCastException>().And.Message.EqualTo("Unable to cast object of type 'ConductOfCode.Foo' to type 'System.String'."),
                () => _problem.Dictionary.ToToml());

            Console.WriteLine(_problem.Tuple.ToYaml());
            Console.WriteLine(_problem.Uri.ToYaml());
        }
    }
}