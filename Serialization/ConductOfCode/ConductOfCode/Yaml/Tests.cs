using System;
using NUnit.Framework;

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
        public void Problem_()
        {
            Console.WriteLine(Problem.ToYaml());
            Assert.Throws(
                Is.TypeOf<YamlDotNet.Core.YamlException>().And.Message.EndsWith("Exception during deserialization"),
                () => Problem.ToYaml().FromYaml<Problem>());
        }

        [Test]
        public void CircularReference()
        {
            Console.WriteLine(a.ToYaml());
        }

        [Test]
        public void Polymorphism()
        {
            Console.WriteLine(c.ToYaml());
            Assert.AreEqual(c.ToYaml(), c.ToYaml().FromYaml<C>().ToYaml());
        }
    }
}