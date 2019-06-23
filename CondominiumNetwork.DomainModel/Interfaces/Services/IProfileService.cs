using CondominiumNetwork.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Services
{
    public interface IProfileService : IDisposable
    {
        Task<Profile> Get(Guid id);
        Task<IEnumerable<Profile>> GetAll();
        Task Create(Profile profile);
        Task Update(Profile profile);
        Task Delete(Guid id);
    }
}
