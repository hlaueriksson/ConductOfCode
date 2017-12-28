using System;
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
        public void Problem_()
        {
            Console.WriteLine(Problem.ToToml());
            Assert.Throws(
                Is.TypeOf<InvalidOperationException>().And.Message.EndsWith("Only types with a parameterless constructor or an specialized creator can be created. Make sure the type has a parameterless constructor or a configuration with an corresponding creator is provided."),
                () => Problem.ToToml().FromToml<Problem>());
        }

        [Test, Ignore("Stack overflow exception occurred in test.Test run is aborted.")]
        public void CircularReference()
        {
            Console.WriteLine(a.ToToml());
        }

        [Test]
        public void Polymorphism()
        {
            Console.WriteLine(c.ToToml());
            Assert.AreEqual(c.ToToml(), c.ToToml().FromToml<C>().ToToml());
        }
    }
}