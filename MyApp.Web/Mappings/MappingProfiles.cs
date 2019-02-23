using AutoMapper;
using MyApp.Contracts;
using MyApp.Data.Models;

namespace MyApp.Web.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
