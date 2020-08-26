using CustomerAPI.Data.Models;
using CustomerAPI.Resources.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactionsForAccountAsync(int id);

        Task<SaveTransactionResponse> PostTransactionAsync(Transaction transaction);
    }
}
