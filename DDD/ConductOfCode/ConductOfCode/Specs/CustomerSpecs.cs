using System;
using ConductOfCode.Domain;
using Machine.Specifications;

namespace ConductOfCode.Specs
{
    [Subject(typeof(Customer))]
    public class CustomerSpecs
    {
        public class Ctor
        {
            It should_create_an_instance_with_valid_state_via_ctor_parameters = () =>
            {
                var subject = new Customer(Guid.NewGuid(), new Name("Sherlock", "Holmes"), new Email("sherlock@holmes.co.uk"));

                subject.ShouldNotBeNull();
            };

            It should_be_able_to_use_conversion_operators = () =>
            {
                var subject = new Customer(Guid.NewGuid(), new Name("Sherlock", "Holmes"), "sherlock@holmes.co.uk");

                subject.ShouldNotBeNull();
            };

            It should_validate__Id__ = () => Catch.Exception(() => new Customer(Guid.Empty, new Name("Sherlock", "Holmes"), "sherlock@holmes.co.uk")).ShouldContainErrorMessage("Id is invalid");

            It should_validate__Name__ = () => Catch.Exception(() => new Customer(Guid.NewGuid(), null, "sherlock@holmes.co.uk")).ShouldContainErrorMessage("Name is required");

            It should_validate__Email__ = () => Catch.Exception(() => new Customer(Guid.NewGuid(), new Name("Sherlock", "Holmes"), null)).ShouldContainErrorMessage("Email is required");
        }
    }
}