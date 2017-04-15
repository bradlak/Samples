using AutoMapper;
using CustomersCrud.Data.Entities;
using CustomersCrud.Dto;

namespace CustomersCrud.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
