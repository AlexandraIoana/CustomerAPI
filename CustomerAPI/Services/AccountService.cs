using AutoMapper;
using CustomerAPI.Interfaces;
using CustomerAPI.Resources.Communication;
using CustomerAPI.Resources.ViewModels;
using CustomerAPI_Business.Entities;
using CustomerAPI_Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionService _transactionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, ITransactionService transactionService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _transactionService = transactionService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<AccountViewModel>> GetAccountsForCustomerAsync(int id)
        {
            var accountsDto = await _accountRepository.GetAccountsForCustomerAsync(id);

            return _mapper.Map<List<AccountDto>, List<AccountViewModel>>(accountsDto);
                        
        }

        public async Task<SaveAccountResponse> PostAccountAsync(int customerId, decimal initialCredit)
        {
            try
            {
                int accountId = await _accountRepository.PostAccountAsync(customerId);

                if (initialCredit > 0)
                {                    

                    await _transactionService.PostTransactionAsync(accountId, initialCredit);
                }      
                                

                await _unitOfWork.CompleteAsync();

                AccountDto accountDto = await _accountRepository.GetAccount(accountId);
                AccountViewModel accountViewModel = _mapper.Map<AccountDto, AccountViewModel>(accountDto);
                return new SaveAccountResponse(accountViewModel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveAccountResponse($"An error occurred when saving the account: {ex.Message}");
            }
        }
    }
}
