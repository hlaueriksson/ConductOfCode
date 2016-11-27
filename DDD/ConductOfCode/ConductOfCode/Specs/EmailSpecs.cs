using ConductOfCode.Domain;
using Machine.Specifications;

namespace ConductOfCode.Specs
{
    [Subject(typeof(Email))]
    public class EmailSpecs
    {
        public class Ctor
        {
            It should_create_an_instance_with_valid_state_via_ctor_parameter = () => new Email("a@b.c").ShouldNotBeNull();

            It should_validate_the_email = () => Catch.Exception(() => new Email("invalid")).ShouldContainErrorMessage("Email is invalid");
        }

        public class Conversion
        {
            It should_convert_Email_to_string = () =>
            {
                string result = new Email("a@b.c");
                result.ShouldEqual("a@b.c");
            };

            It should_convert_string_to_Email = () =>
            {
                Email result = "a@b.c";
                result.Value.ShouldEqual("a@b.c");
            };
        }

        public class Equality
        {
            It should_be_equatable_with_another_Email = () =>
            {
                new Email("a@b.c").Equals(new Email("a@b.c")).ShouldBeTrue();
                new Email("a@b.c").Equals((object)new Email("a@b.c")).ShouldBeTrue();
                new Email("a@b.c").Equals(new Email("c@b.a")).ShouldBeFalse();
                new Email("a@b.c").Equals((Email)null).ShouldBeFalse();
            };

            It should_be_equatable_with_string = () =>
            {
                new Email("a@b.c").Equals("a@b.c").ShouldBeTrue();
                new Email("a@b.c").Equals((object)"a@b.c").ShouldBeTrue();
                new Email("a@b.c").Equals("c@b.a").ShouldBeFalse();
                new Email("a@b.c").Equals((string)null).ShouldBeFalse();
            };

            It should_support_equality_operator = () =>
            {
                (new Email("a@b.c") == new Email("a@b.c")).ShouldBeTrue();
                (new Email("a@b.c") == "a@b.c").ShouldBeTrue();
                (new Email("a@b.c") == new Email("c@b.a")).ShouldBeFalse();
                (new Email("a@b.c") == "c@b.a").ShouldBeFalse();
            };

            It should_support_inequality_operator = () =>
            {
                (new Email("a@b.c") != new Email("a@b.c")).ShouldBeFalse();
                (new Email("a@b.c") != "a@b.c").ShouldBeFalse();
                (new Email("a@b.c") != new Email("c@b.a")).ShouldBeTrue();
                (new Email("a@b.c") != "c@b.a").ShouldBeTrue();
            };
        }
    }
}