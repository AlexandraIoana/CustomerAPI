using System.Threading.Tasks;

namespace CustomerAPI_Business.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
