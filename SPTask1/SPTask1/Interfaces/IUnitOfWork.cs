using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTask1.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
