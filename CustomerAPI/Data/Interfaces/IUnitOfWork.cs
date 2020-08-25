using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
