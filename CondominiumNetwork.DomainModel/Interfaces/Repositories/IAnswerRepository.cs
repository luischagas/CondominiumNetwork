using CondominiumNetwork.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Repositories
{
    public interface IAnswerRepository : IRepository<Answer, Guid>
    {
        Task<IEnumerable<Answer>> GetAnswersOcurrence(Guid id);
    }
}
