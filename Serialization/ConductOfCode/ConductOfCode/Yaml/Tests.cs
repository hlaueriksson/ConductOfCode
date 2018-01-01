﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Ploeh.AutoFixture;
using YamlDotNet.Core;

namespace ConductOfCode.Yaml
{
    public class Tests : BaseTests
    {
        [Test]
        public void Serialize()
        {
            var yaml = Subject.ToYaml();
            Console.WriteLine(yaml);
        }

        [Test]
        public void Deserialize()
        {
            var yaml = Subject.ToYaml();
            var result = yaml.FromYaml<Subject>();
            Assert.AreEqual(yaml, result.ToYaml());
        }

        [Test]
        public void Serialize_and_Deserialize_IDictionary()
        {
            var subject = Fixture.Create<Dictionary<string, Foo>>();

            Assert.AreEqual(subject.ToYaml(), subject.ToYaml().FromYaml<Dictionary<string, Foo>>().ToYaml());
        }

        [Test]
        public void Deserialize_parameterless_constructor_fails()
        {
            var subject = Fixture.Create<Tuple<Foo, Bar>>();
            var yaml = subject.ToYaml();

            Assert.Throws(
                Is.TypeOf<YamlException>().And.InnerException.InnerException.Message.EqualTo("No parameterless constructor defined for this object."),
                () => yaml.FromYaml<Tuple<Foo, Bar>>());
        }

        [Test]
        public void Serialize_and_Deserialize_circular_reference()
        {
            var yaml = a.ToYaml();
            Console.WriteLine(yaml);

            Assert.AreEqual(yaml, yaml.FromYaml<A>().ToYaml());
        }

        [Test]
        public void Serialize_polymorphism_fails()
        {
            Assert.Throws(
                Is.TypeOf<YamlException>().And.InnerException.InnerException.Message.Contains("Cannot create an abstract class."),
                () => c.ToYaml().FromYaml<C>());
        }
    }
}