using CondominiumNetwork.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task Create(TEntity entity);
        Task<TEntity> Read(Guid id);
        Task<IEnumerable<TEntity>> ReadAll();
        Task Update(TEntity entity);
        Task Delete(Guid id);
        Task<int> SaveChanges();
    }
}
