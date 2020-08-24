using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Data.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }

        public int AccountID { get; set; }
        public Account Account { get; set; }
    }
}
