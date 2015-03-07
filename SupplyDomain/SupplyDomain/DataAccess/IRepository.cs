using System;
using System.Linq;
using SupplyDomain.Entities;

namespace SupplyDomain.DataAccess
{
    public interface IRepository<T> where T : Entity
    {
        T Get(Guid id);
        void Add(T entity);
        void Remove(T entity);

        IQueryable<T> AsQueryable();
    }
}
