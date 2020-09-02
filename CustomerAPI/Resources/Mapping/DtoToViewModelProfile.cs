using AutoMapper;
using CustomerAPI.Resources.ViewModels;
using CustomerAPI_Business.Entities;

namespace CustomerAPI.Resources.Mapping
{
    public class DtoToViewModelProfile : Profile
    {
        public DtoToViewModelProfile()
        {
            CreateMap<TransactionDto, TransactionViewModel>();
            CreateMap<AccountDto, AccountViewModel>();
            CreateMap<CustomerDto, CustomerViewModel>();

        }

    }
}
