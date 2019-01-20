using NUnit.Framework;
using Ploeh.AutoFixture;

namespace ConductOfCode
{
    public abstract class BaseTests
    {
        protected Fixture Fixture;
        protected Subject Subject;
        protected Parent Parent;
        protected Geometry Geometry;

        [SetUp]
        public void SetUp()
        {
            Fixture = new Fixture();
            Subject = Fixture.Create<Subject>();

            Parent = new Parent();
            Parent.Child = new Child { Parent = Parent };

            Geometry = new Geometry
            {
                Shapes = new Shape[] {
                    new Circle { Radius = 2 },
                    new Square { Side = 3 }
                }
            };
        }
    }
}