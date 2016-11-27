using ConductOfCode.Domain;
using Machine.Specifications;

namespace ConductOfCode.Specs
{
    [Subject(typeof(Name))]
    public class NameSpecs
    {
        public class Ctor
        {
            It should_create_an_instance_with_valid_state_via_ctor_parameters = () => new Name("Sherlock", "Holmes").ShouldNotBeNull();

            It should_validate_the_first_name = () => Catch.Exception(() => new Name("", "Holmes")).ShouldContainErrorMessage("First name is invalid");

            It should_validate_the_last_name = () => Catch.Exception(() => new Name("Sherlock", "")).ShouldContainErrorMessage("Last name is invalid");
        }
    }
}