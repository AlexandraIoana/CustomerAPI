using CustomerAPI.Data.Contexts;
using CustomerAPI.Data.Interfaces;
using CustomerAPI.Data.Models;
using CustomerAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Data.Repositories
{
    public class CustomerRepository: BaseRepository, ICustomerRepository
    {
        IAccountService _accountService;
        public CustomerRepository(AppDbContext context, IAccountService accountService) : base(context)
        {
            _accountService = accountService;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            customer.Accounts = _accountService.GetAccountsForCustomerAsync(id).Result.ToList();
            return customer;
        }
    }
}
