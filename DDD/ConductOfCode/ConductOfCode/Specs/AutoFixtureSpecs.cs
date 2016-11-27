using ConductOfCode.Domain;
using Machine.Specifications;
using Ploeh.AutoFixture;

namespace ConductOfCode.Specs
{
    public class AutoFixtureSpecs
    {
        It AutoFixture_can_not_create_an_instance_if_validation_fails = () =>
        {
            var fixture = new Fixture();
            var exception = Catch.Exception(() =>
                fixture.Create<Customer>()
            );

            exception.ShouldContainErrorMessage("Exception has been thrown by the target of an invocation.");
            exception.InnerException.ShouldContainErrorMessage("Email is invalid");
        };

        It AutoFixture_can_not_create_an_instance_using__With__if_the_property_is_read_only = () =>
        {
            var fixture = new Fixture();
            var exception = Catch.Exception(() =>
                fixture.Build<Customer>().With(x => x.Email, new Email("a@b.c")).Create()
            );

            exception.ShouldContainErrorMessage("The property \"Email\" is read-only.");
        };

        It AutoFixture_can_create_an_instance_using__Register__and_a_creation_function = () =>
        {
            var fixture = new Fixture();
            fixture.Register(() => new Email("a@b.c"));
            var subject = fixture.Create<Customer>();

            subject.ShouldNotBeNull();
        };
    }
}