using CondominiumNetwork.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Repositories
{
    public interface ICategoryRepository : IDisposable
    {
        Task Create(Category entity);
        Task<Category> Read(Guid id);
        Task<IEnumerable<Category>> ReadAll();
        Task Update(Category entity);
        Task Delete(Guid id);
        Task<int> SaveChanges();
    }
}
