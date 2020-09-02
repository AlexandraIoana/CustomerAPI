using CustomerAPI.Resources.ViewModels;

namespace CustomerAPI.Resources.Communication
{
    public class SaveTransactionResponse : BaseResponse
    {
        public TransactionViewModel Transaction { get; private set; }

        private SaveTransactionResponse(bool success, string message, TransactionViewModel transaction) : base(success, message)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="transaction">Saved transaction.</param>
        /// <returns>Response.</returns>
        public SaveTransactionResponse(TransactionViewModel transaction) : this(true, string.Empty, transaction)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveTransactionResponse(string message) : this(false, message, null)
        { }
    }
}
