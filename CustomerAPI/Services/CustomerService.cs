﻿using CustomerAPI.Data.Interfaces;
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
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountService _accountService;

        public CustomerService(ICustomerRepository userRepository, IAccountService accountService)
        {
            _customerRepository = userRepository;
            _accountService = accountService;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);
            customer.Accounts = _accountService.GetAccountsForCustomerAsync(id).Result.ToList();
            return customer;
        }
    }
}
