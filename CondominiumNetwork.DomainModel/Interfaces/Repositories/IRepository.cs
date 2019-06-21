using CondominiumNetwork.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Repositories
{
    public interface IRepository<T, EntityId> : IDisposable where T : EntityBase<EntityId>
    {
        Task Create(T entity);
        Task<T> Read(EntityId id);
        Task<IEnumerable<T>> ReadAll();
        Task Update(T entity);
        Task Delete(EntityId id);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();
    }
}
