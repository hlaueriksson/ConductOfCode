using Xunit;

namespace ConductOfCode
{
    public class XUnitTests
    {
        private readonly Random _random;

        public XUnitTests() => _random = new Random();

        private int RollD6() => _random.Next(1, 7);

        [Fact]
        public void Should_pass()
        {
            Assert.Equal(2, 1 + 1);
        }

        [Fact]
        public void Should_probably_pass()
        {
            Assert.True(RollD6() > 2);
        }

        [Fact, Trait("TestCategory", "Flaky")]
        public void Should_probably_fail()
        {
            Assert.True(RollD6() > 4);
        }

        [Fact, Trait("TestCategory", "Failing")]
        public void Should_fail()
        {
            Assert.Fail("Intentionally");
        }
    }
}
