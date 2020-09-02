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
    public class AccountRepository: BaseRepository, IAccountRepository
    {
        ITransactionRepository _transactionRepository;
        public AccountRepository(AppDbContext context, ITransactionRepository transactionRepository) : base(context)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<List<AccountDto>> GetAccountsForCustomerAsync(int customerId)
        {
            var accounts = await (from a in _context.Accounts
                            where a.CustomerID == customerId
                            select new AccountDto
                            {
                                ID = a.ID,
                                Balance = (from t in _context.Transactions
                                            where t.AccountID == a.ID
                                            select t.Amount).Sum()
                            }).ToListAsync();

            foreach (var a in accounts)
            {
                a.Transactions = await _transactionRepository.GetTransactionsForAccountAsync(a.ID);
            }

            return accounts;
            
        }

        public async Task<AccountDto> GetAccount(int id)
        {
            var account = await (from a in _context.Accounts
                                  where a.ID == id
                                  select new AccountDto
                                  {
                                      ID = a.ID,
                                      Balance = (from t in _context.Transactions
                                                 where t.AccountID == a.ID
                                                 select t.Amount).Sum()
                                  }).FirstOrDefaultAsync();

            account.Transactions = await _transactionRepository.GetTransactionsForAccountAsync(id);
            
            return account;
        }

        public async Task<int> PostAccountAsync(int customerId)
        {
            Account account = new Account
            {
                CustomerID = customerId
            };

            await _context.Accounts.AddAsync(account);

            return account.ID;
        }
    }
}
