using CustomerAPI_Business.Entities;
using CustomerAPI_Business.Interfaces;
using CustomerAPI_Infrastucture.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI_Business.Repositories
{
    public class CustomerRepository: BaseRepository, ICustomerRepository
    {
        IAccountRepository _accountRepository;
        public CustomerRepository(AppDbContext context, IAccountRepository accountRepository) : base(context)
        {
            _accountRepository = accountRepository;
        }

        public async Task<CustomerDto> GetCustomerAsync(int id)
        {
            var customer =  await (from c in _context.Customers
                                where c.ID == id
                                select new CustomerDto
                                {
                                    ID = c.ID,
                                    Name = c.Name,
                                    Surname = c.Surname
                                }).FirstOrDefaultAsync();

            customer.Accounts = await _accountRepository.GetAccountsForCustomerAsync(id);

            return customer;
        }
    }
}
