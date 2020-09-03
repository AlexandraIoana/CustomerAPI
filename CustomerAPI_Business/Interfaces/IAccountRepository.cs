using CustomerAPI_Business.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI_Business.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<AccountDto>> GetAccountsForCustomerAsync(int id);

        Task<AccountDto> GetAccount(int id);

        Task<int> PostAccountAsync(int customerId, decimal initialCredit);

    }
}
