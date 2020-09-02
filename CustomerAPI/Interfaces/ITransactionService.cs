using CustomerAPI.Resources.Communication;
using CustomerAPI.Resources.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI.Interfaces
{
    public interface ITransactionService
    {
        Task<List<TransactionViewModel>> GetTransactionsForAccountAsync(int id);

        Task<SaveTransactionResponse> PostTransactionAsync(int accountId, decimal amount);
    }
}
