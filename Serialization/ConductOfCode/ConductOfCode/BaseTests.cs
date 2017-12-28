using NUnit.Framework;
using Ploeh.AutoFixture;

namespace ConductOfCode
{
    public abstract class BaseTests
    {
        protected Subject Subject;
        protected Problem Problem;
        protected A a;
        protected C c;

        [SetUp]
        public void SetUp()
        {
            var fixture = new Fixture();
            Subject = fixture.Create<Subject>();
            Problem = fixture.Create<Problem>();

            a = new A
            {
                Id = 1,
                B = new B { Ref = "2" }
            };
            a.B.A = a;

            c = new C
            {
                D = new D1
                {
                    Id = 1
                }
            };
        }
    }
}