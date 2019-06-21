using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainService
{
    public class ProfileService
    {
        private IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task CreateProfile(Profile profile)
        {
            await _profileRepository.Create(profile);
        }

        public async Task UpdateProfile(Profile profile)
        {
           await _profileRepository.Update(profile);
        }

        public async Task DeleteProfile(Guid profileId)
        {
           await _profileRepository.Delete(profileId);
        }

        public async Task<Profile> GetProfile(Guid profileId)
        {
            return await _profileRepository.Read(profileId);
        }

        public async Task<IEnumerable<Profile>> GetAllProfiles()
        {
            return await _profileRepository.ReadAll();
        }


    }
}
