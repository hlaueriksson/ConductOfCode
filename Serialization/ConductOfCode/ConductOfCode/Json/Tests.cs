using System;
using System.Collections.Generic;
using AutoFixture;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ConductOfCode.Json
{
    public class Tests : BaseTests
    {
        [Test]
        public void Serialize()
        {
            var json = Subject.ToJson();
            Console.WriteLine(json);
        }

        [Test]
        public void Serialize_with_no_indentation()
        {
            Console.WriteLine(Subject.ToJson(Formatting.None));
        }

        [Test]
        public void Deserialize()
        {
            var json = Subject.ToJson();
            var result = json.FromJson<Subject>();
            Assert.AreEqual(json, result.ToJson());
        }

        [Test]
        public void Serialize_and_Deserialize_IDictionary()
        {
            var subject = Fixture.Create<Dictionary<string, Foo>>();

            Assert.AreEqual(subject.ToJson(), subject.ToJson().FromJson<Dictionary<string, Foo>>().ToJson());
        }

        [Test]
        public void Serialize_and_Deserialize_parameterless_constructor()
        {
            var subject = Fixture.Create<Tuple<Foo, Bar>>();

            Assert.AreEqual(subject.ToJson(), subject.ToJson().FromJson<Tuple<Foo, Bar>>().ToJson());
        }

        [Test]
        public void Serialize_circular_reference_fails()
        {
            Assert.Throws(
                Is.TypeOf<JsonSerializationException>().And.Message.StartsWith("Self referencing loop detected"),
                () => Parent.ToJson());
        }

        [Test]
        public void Serialize_polymorphism_fails()
        {
            Assert.Throws(
                Is.TypeOf<JsonSerializationException>().And.Message.Contains("Type is an interface or abstract class and cannot be instantiated."),
                () => Geometry.ToJson().FromJson<Geometry>());
        }
    }
}