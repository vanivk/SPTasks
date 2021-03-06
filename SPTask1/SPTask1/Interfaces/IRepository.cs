using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTask1.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj);
        void Remove(string id);
    }
}
