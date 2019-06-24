using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.DomainModel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainService
{
    public class ProfileService : IProfileService
    {
        private IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task Create(Profile profile)
        {
            await _profileRepository.Create(profile);
        }

        public async Task Update(Profile profile)
        {
           await _profileRepository.Update(profile);
        }

        public async Task Delete(Guid profileId)
        {
           await _profileRepository.Delete(profileId);
        }

        public async Task<Profile> Get(Guid profileId)
        {
            return await _profileRepository.Read(profileId);
        }

        public async Task<IEnumerable<Profile>> GetAll()
        {
            return await _profileRepository.ReadAll();
        }

        public async Task<Profile> GetProfileOcurrences(Guid id)
        {
            return await _profileRepository.GetProfileOcurrences(id);
        }

        public void Dispose()
        {
            _profileRepository?.Dispose();
        }
    }
}
