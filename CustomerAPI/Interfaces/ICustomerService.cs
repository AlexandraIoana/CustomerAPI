using CustomerAPI.Resources.ViewModels;
using System.Threading.Tasks;

namespace CustomerAPI.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerViewModel> GetCustomerAsync(int id);
    }
}
