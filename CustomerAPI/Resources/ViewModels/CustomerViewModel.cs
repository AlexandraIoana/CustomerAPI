using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Resources.ViewModels
{
    public class CustomerViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<AccountViewModel> Accounts { get; set; }
    }
}
