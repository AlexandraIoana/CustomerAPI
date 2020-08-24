using CustomerAPI.Data.Interfaces;
using CustomerAPI.Data.Models;
using CustomerAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class AccountService : IAccountService
    {
        IAccountRepository _accountRepository;
        ITransactionService _transactionService;

        public AccountService(IAccountRepository accountRepository, ITransactionService transactionService)
        {
            _accountRepository = accountRepository;
            _transactionService = transactionService;
        }
        public async Task<IEnumerable<Account>> GetAccountsForCustomerAsync(int id)
        {
            var accounts = await _accountRepository.GetAccountsForCustomerAsync(id);

            foreach(Account a in accounts)
            {
                a.Transactions = _transactionService.GetTransactionsForAccountAsync(a.ID).Result.ToList();
            }

            return accounts;
        }
    }
}
