using CondominiumNetwork.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Services
{
   public interface IWarningService : IDisposable
    {
        Task<Warning> Get(Guid id);
        Task<IEnumerable<Warning>> GetAll();
        Task Create(Warning warning);
        Task Update(Warning warning);
        Task Delete(Guid id);
        Task<Warning> GetDetailsWarning(Guid id);
    }
}
