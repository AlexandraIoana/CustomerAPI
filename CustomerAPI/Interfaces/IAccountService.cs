using CustomerAPI.Resources.Communication;
using CustomerAPI.Resources.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI.Interfaces
{
    public interface IAccountService
    {
        Task<List<AccountViewModel>> GetAccountsForCustomerAsync(int id);
        Task<SaveAccountResponse> PostAccountAsync(int customerId, decimal initialCredit);
    }
}
