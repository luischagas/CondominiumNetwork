using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Services
{
    public interface ICategoryService : IDisposable
    {
        Task<IEnumerable<Category>> ReadAllCategories();
        Task CreateCategory(Category ocurrence);
    }
}
