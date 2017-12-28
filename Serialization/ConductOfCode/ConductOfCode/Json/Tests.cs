using System;
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
        public void Deserialize()
        {
            var json = Subject.ToJson();
            var result = json.FromJson<Subject>();
            Assert.AreEqual(json, result.ToJson());
        }

        [Test]
        public void Problem_()
        {
            Console.WriteLine(Problem.ToJson());
            Assert.AreEqual(Problem.ToJson(), Problem.ToJson().FromJson<Problem>().ToJson());
        }

        [Test]
        public void CircularReference()
        {
            Console.WriteLine(a.ToJson());
        }

        [Test]
        public void Polymorphism()
        {
            Console.WriteLine(c.ToJson());
            Assert.AreEqual(c.ToJson(), c.ToJson().FromJson<C>().ToJson());
        }
    }
}