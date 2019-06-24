using CondominiumNetwork.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Services
{
   public interface IPhotoService : IDisposable
    {
        Task<string> UploadPhotoAsync(Photo photo);
    }
}
