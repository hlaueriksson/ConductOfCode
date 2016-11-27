using System;
using AutoMapper;
using ConductOfCode.Data;
using ConductOfCode.Domain;
using Machine.Specifications;

namespace ConductOfCode.Specs
{
    public class AutoMapperSpecs
    {
        Establish context = () =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, Customer>().ReverseMap();
                cfg.CreateMap<NameDto, Name>().ReverseMap();
                cfg.CreateMap<EmailDto, Email>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        };

        It AutoMapper_can_map_to_the_entity = () =>
        {
            var dto = new CustomerDto
            {
                Id = Guid.NewGuid(),
                Name = new NameDto { First = "Sherlock", Last = "Holmes" },
                Email = new EmailDto { Value = "sherlock@holmes.co.uk" }
            };
            var result = _mapper.Map<Customer>(dto);

            result.ShouldNotBeNull();
        };

        It AutoMapper_can_not_map_to_the_entity_if_validation_fails = () =>
        {
            var dto = new CustomerDto
            {
                Id = Guid.NewGuid(),
                Name = new NameDto { First = "Sherlock", Last = "Holmes" },
                Email = new EmailDto { Value = "invalid" }
            };
            var exception = Catch.Exception(() =>
                _mapper.Map<Customer>(dto)
            );

            exception.ShouldContainErrorMessage("Email is invalid");
        };

        It AutoMapper_can_map_from_the_entity = () =>
        {
            var entity = new Customer(Guid.NewGuid(), new Name("Sherlock", "Holmes"), "sherlock@holmes.co.uk");
            var result = _mapper.Map<CustomerDto>(entity);

            result.ShouldNotBeNull();
        };

        static IMapper _mapper;
    }
}