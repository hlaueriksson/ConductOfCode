using Coypu;
using Should;

namespace ConductOfCode.Specs
{
    public static class PageShouldExtensions
    {
        public static void ShouldExist(this ElementScope element)
        {
            element.Exists().ShouldBeTrue();
        }
    }
}