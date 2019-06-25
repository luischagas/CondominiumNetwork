using CondominiumNetwork.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Repositories
{
    public interface ICategoryRepository : IDisposable
    {
        Task CreateCategory(Category entity);
        Task<IEnumerable<Category>> ReadAllCategories();
        Task<int> SaveChanges();
    }
}
