using CustomerAPI.Data.Models;

namespace CustomerAPI.Resources.Communication
{
    public class SaveAccountResponse : BaseResponse
    {
        public Account Account { get; private set; }

        private SaveAccountResponse(bool success, string message, Account account) : base(success, message)
        {
            Account = account;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="account">Saved account.</param>
        /// <returns>Response.</returns>
        public SaveAccountResponse(Account account) : this(true, string.Empty, account)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveAccountResponse(string message) : this(false, message, null)
        { }
    }
}
