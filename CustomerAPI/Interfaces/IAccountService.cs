using CustomerAPI.Data.Models;
using CustomerAPI.Resources.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccountsForCustomerAsync(int id);
        Task<SaveAccountResponse> PostAccountAsync(Account account);
    }
}
