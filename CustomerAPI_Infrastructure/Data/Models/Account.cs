using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CustomerAPI_Infrastucture.Data.Models
{
    public class Account
    {
        public int ID { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        [JsonIgnore]
        [IgnoreDataMember]
        public int CustomerID { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Customer Customer { get; set; }
    }
}
