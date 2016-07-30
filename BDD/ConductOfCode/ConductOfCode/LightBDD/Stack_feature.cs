using LightBDD;
using NUnit.Framework;

namespace ConductOfCode.LightBDD
{
    [TestFixture]
    [FeatureDescription(
@"In order to support last-in-first-out (LIFO) operations
As an developer
I want to use a stack")]
    [Label("LIFO")]
    public partial class Stack_feature
    {
        [Test]
        [Label("Empty")]
        public void Empty_stack()
        {
            Runner.RunScenario(

                given => an_empty_stack(),
                then => it_has_no_elements(),
                and => it_throws_an_exception_when_calling_pop(),
                and => it_throws_an_exception_when_calling_peek());
        }

        [Test]
        [Label("Not empty")]
        public void Non_empty_stack()
        {
            Runner.RunScenario(

                given => a_non_empty_stack(),
                when => calling_peek(),
                then => it_returns_the_top_element(),
                but => it_does_not_remove_the_top_element(),
                when => calling_pop(),
                then => it_returns_the_top_element(),
                and => it_removes_the_top_element());
        }
    }
}