using CustomerAPI.Data.Interfaces;
using CustomerAPI.Data.Models;
using CustomerAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _userRepository;

        public CustomerService(ICustomerRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _userRepository.GetCustomerAsync(id);
        }
    }
}
