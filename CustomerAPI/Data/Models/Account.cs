using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerAPI.Data.Models
{
    public class Account
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        [JsonIgnore]
        [IgnoreDataMember]
        public int CustomerID { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Customer Customer { get; set; }
    }
}
