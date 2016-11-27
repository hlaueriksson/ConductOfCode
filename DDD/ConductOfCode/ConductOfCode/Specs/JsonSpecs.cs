using System;
using ConductOfCode.Domain;
using Machine.Specifications;
using Newtonsoft.Json;

namespace ConductOfCode.Specs
{
    public class JsonSpecs
    {
        It JsonConvert_can_serialize_the_entity = () =>
        {
            var entity = new Customer(Guid.NewGuid(), new Name("Sherlock", "Holmes"), "sherlock@holmes.co.uk");
            var result = JsonConvert.SerializeObject(entity);

            result.ShouldNotBeEmpty();
        };

        It JsonConvert_can_deserialize_the_entity = () =>
        {
            var json = JsonConvert.SerializeObject(new Customer(Guid.NewGuid(), new Name("Sherlock", "Holmes"), "sherlock@holmes.co.uk"));
            var result = JsonConvert.DeserializeObject<Customer>(json);

            result.ShouldNotBeNull();
        };

        It JsonConvert_can_not_deserialize_the_entity_if_validation_fails = () =>
        {
            var json = JsonConvert.SerializeObject(new Customer(Guid.NewGuid(), new Name("Sherlock", "Holmes"), "sherlock@holmes.co.uk"));
            json = json.Replace("sherlock@holmes.co.uk", "invalid");
            var exception = Catch.Exception(() =>
                JsonConvert.DeserializeObject<Customer>(json)
            );

            exception.ShouldContainErrorMessage("Email is invalid");
        };
    }
}