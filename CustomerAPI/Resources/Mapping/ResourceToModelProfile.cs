using AutoMapper;
using CustomerAPI.Data.Models;
using CustomerAPI.Resources.Classes;

namespace CustomerAPI.Resources.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAccountResource, Account>()
                .ForMember(a => a.CustomerID, r => r.MapFrom(src => src.CustomerID))
                .ForMember(a => a.Balance, r => r.MapFrom(src => src.InitialCredit));
        }

    }
}
