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
    public class AccountRepository: BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Account>> GetAccountsForCustomerAsync(int id)
        {
            return await _context.Accounts.Where(a => a.CustomerID == id).ToListAsync();
        }
    }
}
