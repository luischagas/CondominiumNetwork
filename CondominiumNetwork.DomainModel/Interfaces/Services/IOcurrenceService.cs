using CondominiumNetwork.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Services
{
    public interface IOcurrenceService : IDisposable
    {
        Task<Ocurrence> Get(Guid id);
        Task<IEnumerable<Ocurrence>> GetAll();
        Task Create(Ocurrence ocurrence);
        Task Update(Ocurrence ocurrence);
        Task Delete(Guid id);
        Task<IEnumerable<Ocurrence>> GetOcurrencesProfile(Guid id);
        Task<Ocurrence> GetOcurrenceAnswers(Guid id);
    }
}
