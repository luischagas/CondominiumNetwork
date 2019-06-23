using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.DomainModel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainService
{
    public class AnswerService : IAnswerService
    {
        private IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task Create(Answer answer)
        {
            await _answerRepository.Create(answer);
        }

        public async Task Update(Answer answer)
        {
            await _answerRepository.Update(answer);
        }

        public async Task Delete(Guid answerId)
        {
            await _answerRepository.Delete(answerId);
        }

        public async Task<Answer> Get(Guid answerId)
        {
            return await _answerRepository.Read(answerId);
        }

        public async Task<IEnumerable<Answer>> GetAll()
        {
            return await _answerRepository.ReadAll();
        }

        public async Task<IEnumerable<Answer>> GetAnswersOcurrence(Guid profileId)
        {
            return await _answerRepository.GetAnswersOcurrence(profileId);
        }

        public void Dispose()
        {
            _answerRepository?.Dispose();
        }
    }
}
