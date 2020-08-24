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
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Transaction>> GetTransactionsForAccountAsync(int id)
        {
            return await _context.Transactions.Where(t => t.AccountID == id).ToListAsync();
        }
    }
}
