using CustomerAPI.Data.Interfaces;
using CustomerAPI.Data.Models;
using CustomerAPI.Interfaces;
using CustomerAPI.Resources.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionService _transactionService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, ITransactionService transactionService, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _transactionService = transactionService;
            _unitOfWork = unitOfWork;
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

        public async Task<SaveAccountResponse> PostAccountAsync(Account account)
        {
            try
            {
                await _accountRepository.PostAccountAsync(account);

                Transaction transaction = new Transaction()
                {
                    AccountID = account.ID,
                    Amount = account.Balance
                };

                await _transactionService.PostTransactionAsync(transaction);

                await _unitOfWork.CompleteAsync();

                return new SaveAccountResponse(account);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveAccountResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}
