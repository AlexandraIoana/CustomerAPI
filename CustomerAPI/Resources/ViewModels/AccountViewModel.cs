using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Resources.ViewModels
{
    public class AccountViewModel
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public List<TransactionViewModel> Transactions { get; set; }
    }
}
