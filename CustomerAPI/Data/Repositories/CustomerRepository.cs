using CustomerAPI.Data.Contexts;
using CustomerAPI.Data.Interfaces;
using CustomerAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Data.Repositories
{
    public class CustomerRepository: BaseRepository, ICustomerRepository
    {
        IAccountRepository _accountRepository;
        public CustomerRepository(AppDbContext context, IAccountRepository accountRepository) : base(context)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            customer.Accounts = _accountRepository.GetAccountsForCustomerAsync(id).Result.ToList();
            return customer;
        }
    }
}
