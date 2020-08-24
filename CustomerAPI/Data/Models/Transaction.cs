using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerAPI.Data.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }

        [JsonIgnore]
        public int AccountID { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
    }
}
