using System;
using System.Collections.Generic;
using AutoFixture;
using NUnit.Framework;

namespace ConductOfCode.Toml
{
    public class Tests : BaseTests
    {
        [Test]
        public void Serialize()
        {
            var toml = Subject.ToToml();
            Console.WriteLine(toml);
        }

        [Test]
        public void Deserialize()
        {
            var toml = Subject.ToToml();
            var result = toml.FromToml<Subject>();
            Assert.AreEqual(toml, result.ToToml());
        }

        [Test]
        public void Serialize_and_Deserialize_IDictionary()
        {
            var subject = Fixture.Create<Dictionary<string, Foo>>();

            Assert.AreEqual(subject.ToToml(), subject.ToToml().FromToml<Dictionary<string, Foo>>().ToToml());
        }

        [Test]
        public void Deserialize_IDictionary_with_non_string_key()
        {
            var subject = Fixture.Create<Dictionary<int, Foo>>();

            Assert.Throws(
                Is.TypeOf<InvalidCastException>().And.Message.EqualTo("Unable to cast object of type 'System.Int32' to type 'System.String'."),
                () => subject.ToToml().FromToml<Dictionary<int, Foo>>());
        }

        [Test]
        public void Deserialize_parameterless_constructor_fails()
        {
            var subject = Fixture.Create<Tuple<Foo, Bar>>();
            var toml = subject.ToToml();

            Assert.Throws(
                Is.TypeOf<InvalidOperationException>().And.Message.Contains("Only types with a parameterless constructor or an specialized creator can be created."),
                () => toml.FromToml<Tuple<Foo, Bar>>());
        }

        [Test, Ignore("Stack overflow exception occurred in test.Test run is aborted.")]
        public void Serialize_circular_reference_fails()
        {
            Parent.ToToml();
        }

        [Test]
        public void Serialize_polymorphism_fails()
        {
            Assert.Throws(
                Is.TypeOf<InvalidOperationException>().And.Message.Contains("Only types with a parameterless constructor or an specialized creator can be created."),
                () => Geometry.ToToml().FromToml<Geometry>());
        }
    }
}