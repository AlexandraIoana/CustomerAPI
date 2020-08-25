using CustomerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Resources.Communication
{
    public class SaveTransactionResponse : BaseResponse
    {
        public Transaction Transaction { get; private set; }

        private SaveTransactionResponse(bool success, string message, Transaction transaction) : base(success, message)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="transaction">Saved transaction.</param>
        /// <returns>Response.</returns>
        public SaveTransactionResponse(Transaction transaction) : this(true, string.Empty, transaction)
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
