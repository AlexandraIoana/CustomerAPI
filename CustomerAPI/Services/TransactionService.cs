using CustomerAPI.Data.Interfaces;
using CustomerAPI.Data.Models;
using CustomerAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class TransactionService : ITransactionService
    {
        ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsForAccountAsync(int id)
        {
            return await _transactionRepository.GetTransactionsForAccountAsync(id);
        }

        public async Task PostTransactionAsync(Transaction transaction)
        {
            await _transactionRepository.PostTransactionAsync(transaction);
        }
    }
}
