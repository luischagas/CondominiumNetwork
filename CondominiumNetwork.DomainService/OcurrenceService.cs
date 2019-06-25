using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.DomainModel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainService
{
    public class OcurrenceService : IOcurrenceService
    {
        private IOcurrenceRepository _ocurrenceRepository;

        public OcurrenceService(IOcurrenceRepository ocurrenceRepository)
        {
            _ocurrenceRepository = ocurrenceRepository;
        }

        public async Task Create(Ocurrence ocurrence)
        {
            await _ocurrenceRepository.Create(ocurrence);
        }

        public async Task Update(Ocurrence ocurrence)
        {
           await _ocurrenceRepository.Update(ocurrence);
        }

        public async Task Delete(Guid ocurrenceId)
        {
           await _ocurrenceRepository.Delete(ocurrenceId);
        }

        public async Task<Ocurrence> Get(Guid ocurrenceId)
        {
            return await _ocurrenceRepository.Read(ocurrenceId);
        }

        public async Task<IEnumerable<Ocurrence>> GetAll()
        {
            return await _ocurrenceRepository.ReadAll();
        }

        public async Task<Ocurrence> GetOcurrenceAnswers(Guid id)
        {
            return await _ocurrenceRepository.GetOcurrenceAnswers(id);
        }

        public async Task<IEnumerable<Ocurrence>> GetAllOcurrenceAnswers()
        {
            return await _ocurrenceRepository.GetAllOcurrenceAnswers();
        }
        public void Dispose()
        {
           _ocurrenceRepository?.Dispose();
        }


    }
}
