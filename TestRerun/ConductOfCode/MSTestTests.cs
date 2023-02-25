using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConductOfCode
{
    [TestClass]
    public class MSTestTests
    {
        public TestContext TestContext { get; set; } = null!;

        private Random _random = null!;

        [TestInitialize]
        public void Init() => _random = new Random();

        private int RollD6() => _random.Next(1, 7);

        [TestMethod]
        public void Should_pass()
        {
            Assert.AreEqual(2, 1 + 1);
        }

        [TestMethod]
        public void Should_probably_pass()
        {
            Assert.IsTrue(RollD6() > 2);
        }

        [TestMethod, TestCategory("Flaky")]
        public void Should_probably_fail()
        {
            if (TestContext.Properties.Contains("Retry")) Console.WriteLine("Retry #" + TestContext.Properties["Retry"]);

            Assert.IsTrue(RollD6() > 4);
        }

        [TestMethod, TestCategory("Failing")]
        public void Should_fail()
        {
            Assert.Fail("Intentionally");
        }
    }
}
