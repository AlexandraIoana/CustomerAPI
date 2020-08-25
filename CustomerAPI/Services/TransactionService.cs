using CustomerAPI.Data.Interfaces;
using CustomerAPI.Data.Models;
using CustomerAPI.Interfaces;
using CustomerAPI.Resources.Communication;
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

        public TransactionService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsForAccountAsync(int id)
        {
            return await _transactionRepository.GetTransactionsForAccountAsync(id);
        }

        public async Task<SaveTransactionResponse> PostTransactionAsync(Transaction transaction)
        {
            try
            {
                await _transactionRepository.PostTransactionAsync(transaction);
                await _unitOfWork.CompleteAsync();

                return new SaveTransactionResponse(transaction);
            }
            catch (Exception ex)
            {
                return new SaveTransactionResponse($"An error occurred when saving the transaction: {ex.Message}");
            }
        }
    }
}
