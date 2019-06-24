using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.DomainModel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainService
{
    public class WarningService : IWarningService
    {
        private IWarningRepository _warningRepository;

        public WarningService(IWarningRepository warningRepository)
        {
            _warningRepository = warningRepository;
        }

        public async Task Create(Warning warning)
        {
            await _warningRepository.Create(warning);
        }

        public async Task Update(Warning warning)
        {
            await _warningRepository.Update(warning);
        }

        public async Task Delete(Guid warningId)
        {
            await _warningRepository.Delete(warningId);
        }

        public async Task<Warning> Get(Guid warningId)
        {
            return await _warningRepository.Read(warningId);
        }

        public async Task<IEnumerable<Warning>> GetAll()
        {
            return await _warningRepository.ReadAll();
        }

        public async Task<Warning> GetDetailsWarning(Guid id)
        {
            return await _warningRepository.GetDetailsWarning(id);
        }

        public void Dispose()
        {
            _warningRepository?.Dispose();
        }
    }
}
