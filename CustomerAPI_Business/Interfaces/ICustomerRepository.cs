using CustomerAPI_Business.Entities;
using System.Threading.Tasks;

namespace CustomerAPI_Business.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> GetCustomerAsync(int id);
    }
}
