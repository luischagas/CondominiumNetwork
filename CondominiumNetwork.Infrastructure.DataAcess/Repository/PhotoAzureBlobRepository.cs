using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.Infrastructure.AzureStorage;
using CondominiumNetwork.Infrastructure.DataAcess.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.Infrastructure.DataAcess.Repository
{
    public class PhotoAzureBlobRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoAzureBlobRepository(CondominiumNetworkContext context) : base(context) { }

        public async Task<string> UploadPhotoAsync(Photo photo)
        {
            var blobService = new AzureBlobService();

            return await blobService.UploadFileAsync(photo.FileName,
                photo.BinaryContent, photo.ContainerName,
                photo.ContentType);
        }
    }
}
