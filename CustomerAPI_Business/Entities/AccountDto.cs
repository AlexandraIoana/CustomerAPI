using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI_Business.Entities
{
    public class AccountDto
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
