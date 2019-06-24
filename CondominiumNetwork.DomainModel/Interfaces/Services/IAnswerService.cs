using CondominiumNetwork.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Services
{
    public interface IAnswerService : IDisposable
    {
        Task<Answer> Get(Guid id);
        Task<IEnumerable<Answer>> GetAll();
        Task Create(Answer answer);
        Task Update(Answer answer);
        Task Delete(Guid id);
        Task<IEnumerable<Answer>> GetDetailsAnswers(Guid id);
    }
}
