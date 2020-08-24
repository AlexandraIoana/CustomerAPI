using CustomerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccountsForCustomerAsync(int id);
    }
}
