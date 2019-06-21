using CondominiumNetwork.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Repositories
{
    public interface IOcurrenceRepository : IRepository<Ocurrence, Guid>
    {
        Task<IEnumerable<Ocurrence>> GetOcurrenceAnswers(Guid id);
        Task<IEnumerable<Ocurrence>> GetOcurrencesProfile(Guid id);
    }
}
