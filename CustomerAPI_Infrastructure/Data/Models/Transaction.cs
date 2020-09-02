using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CustomerAPI_Infrastucture.Data.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public int AccountID { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Account Account { get; set; }
    }
}
