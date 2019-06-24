using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.DomainModel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainService
{
    public class PhotoService : IPhotoService
    {
        private IPhotoRepository _photoRepository;

        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<string> UploadPhotoAsync(Photo photo)
        {
            return await _photoRepository.UploadPhotoAsync(photo);
        }

        public void Dispose()
        {
            _photoRepository?.Dispose();
        }
    }
}
