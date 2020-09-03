using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI_Business.Entities
{
    public class CustomerDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<AccountDto> Accounts { get; set; }
    }
}
