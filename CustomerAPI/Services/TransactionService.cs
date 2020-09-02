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
    public class TransactionService : ITransactionService
    {
        ITransactionRepository _transactionRepository;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TransactionViewModel>> GetTransactionsForAccountAsync(int id)
        {
            var transactions = await _transactionRepository.GetTransactionsForAccountAsync(id);

            return _mapper.Map<List<TransactionDto>, List<TransactionViewModel>>(transactions);
        }

        public async Task<SaveTransactionResponse> PostTransactionAsync(int accountId, decimal amount)
        {
            try
            {
                int transactionId = await _transactionRepository.PostTransactionAsync(accountId, amount);
                await _unitOfWork.CompleteAsync();

                TransactionDto transactionDto = await _transactionRepository.GetTransaction(transactionId);
                TransactionViewModel transactionViewModel = _mapper.Map<TransactionDto, TransactionViewModel>(transactionDto);

                return new SaveTransactionResponse(transactionViewModel);
            }
            catch (Exception ex)
            {
                return new SaveTransactionResponse($"An error occurred when saving the transaction: {ex.Message}");
            }
        }
    }
}
