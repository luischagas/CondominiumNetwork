using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainService
{
    public class WarningService
    {
        private IWarningRepository _warningRepository;

        public WarningService(IWarningRepository warningRepository)
        {
            _warningRepository = warningRepository;
        }

        public async Task CreateWarning(Warning warning)
        {
            await _warningRepository.Create(warning);
        }

        public async Task UpdateWarning(Warning warning)
        {
            await _warningRepository.Update(warning);
        }

        public async Task DeleteWarning(Guid warningId)
        {
            await _warningRepository.Delete(warningId);
        }

        public async Task<Warning> GetWarning(Guid warningId)
        {
            return await _warningRepository.Read(warningId);
        }

        public async Task<IEnumerable<Warning>> GetAllWarning()
        {
            return await _warningRepository.ReadAll();
        }

    }
}
