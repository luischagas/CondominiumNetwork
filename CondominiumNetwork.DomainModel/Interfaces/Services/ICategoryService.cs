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
        Task<Category> Get(Guid id);
        Task<IEnumerable<Category>> GetAll();
        Task Create(Category ocurrence);
        Task Update(Category ocurrence);
        Task Delete(Guid id);
    }
}
