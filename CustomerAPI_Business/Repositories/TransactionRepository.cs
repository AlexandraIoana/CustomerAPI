using CustomerAPI_Business.Entities;
using CustomerAPI_Business.Interfaces;
using CustomerAPI_Infrastucture.Data;
using CustomerAPI_Infrastucture.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI_Business.Repositories
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<TransactionDto>> GetTransactionsForAccountAsync(int accountId)
        {
            return await (from t in _context.Transactions
                            where t.AccountID == accountId
                            select new TransactionDto 
                            { 
                                ID = t.ID,
                                Amount = t.Amount
                            }).ToListAsync();
        }


        public async Task<int> PostTransactionAsync(int accountId, decimal amount)
        {
            Transaction transaction = new Transaction
            {
                AccountID = accountId,
                Amount = amount
            };

            await _context.Transactions.AddAsync(transaction);

            return transaction.ID;
                
        }
    }
}
