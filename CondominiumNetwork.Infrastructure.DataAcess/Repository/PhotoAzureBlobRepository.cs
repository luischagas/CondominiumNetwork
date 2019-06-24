using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.Infrastructure.AzureStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.Infrastructure.DataAcess.Repository
{
    public class PhotoAzureBlobRepository
    {
        public async Task<string> CreateAsync(Photo photo)
        {
            var blobService = new AzureBlobService();

            return await blobService.UploadFileAsync(photo.FileName,
                photo.BinaryContent, photo.ContainerName,
                photo.ContentType);
        }
    }
}
