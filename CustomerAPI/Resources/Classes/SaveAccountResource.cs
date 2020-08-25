using System.ComponentModel.DataAnnotations;


namespace CustomerAPI.Resources.Classes
{
    public class SaveAccountResource
    {
        [Range(1, 6)]
        public int CustomerID { get; set; }

        [Range(0.0, double.MaxValue)]
        public decimal InitialCredit { get; set; }
    }
}
