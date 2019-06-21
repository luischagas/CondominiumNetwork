using CondominiumNetwork.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainModel.Interfaces.Repositories
{
   public interface IProfileRepository : IRepository<Profile, Guid>
    {
    }
}
