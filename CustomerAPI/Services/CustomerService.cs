using AutoMapper;
using CustomerAPI.Interfaces;
using CustomerAPI.Resources.ViewModels;
using CustomerAPI_Business.Entities;
using CustomerAPI_Business.Interfaces;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerViewModel> GetCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);
            
            return _mapper.Map<CustomerDto, CustomerViewModel>(customer);
        }
    }
}
