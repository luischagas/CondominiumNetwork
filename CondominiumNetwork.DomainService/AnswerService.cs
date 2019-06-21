using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainService
{
    public class AnswerService
    {
        private IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task CreateAnswer(Answer answer)
        {
            await _answerRepository.Create(answer);
        }

        public async Task UpdatAnswer(Answer answer)
        {
            await _answerRepository.Update(answer);
        }

        public async Task DeleteAnswer(Guid answerId)
        {
            await _answerRepository.Delete(answerId);
        }

        public async Task<Answer> GetAnswer(Guid answerId)
        {
            return await _answerRepository.Read(answerId);
        }

        public async Task<IEnumerable<Answer>> GetAllAnswer()
        {
            return await _answerRepository.ReadAll();
        }

    }
}
