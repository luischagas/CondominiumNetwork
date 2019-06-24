using CondominiumNetwork.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Repositories
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        Task<string> UploadPhotoAsync(Photo photo);
    }
}
