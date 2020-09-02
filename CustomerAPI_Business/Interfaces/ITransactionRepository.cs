using CustomerAPI_Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI_Business.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<TransactionDto>> GetTransactionsForAccountAsync(int id);

        Task<TransactionDto> GetTransaction(int id);

        Task<int> PostTransactionAsync(int accountId, decimal amount);
    }
}
