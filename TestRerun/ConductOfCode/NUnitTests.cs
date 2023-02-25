using NUnit.Framework;

namespace ConductOfCode
{
    public class NUnitTests
    {
        private Random _random = null!;

        [SetUp]
        public void Init() => _random = new Random();

        private int RollD6() => _random.Next(1, 7);

        [Test]
        public void Should_pass()
        {
            Assert.AreEqual(2, 1 + 1);
        }

        [Test]
        public void Should_probably_pass()
        {
            Assert.True(RollD6() > 2);
        }

        [Test, Category("Flaky")]
        public void Should_probably_fail()
        {
            if (TestContext.Parameters.Exists("Retry")) Console.WriteLine("Retry #" + TestContext.Parameters["Retry"]);

            Assert.True(RollD6() > 4);
        }

        [Test, Category("Failing")]
        public void Should_fail()
        {
            Assert.Fail("Intentionally");
        }
    }
}
