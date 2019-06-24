using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.Infrastructure.DataAcess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumNetwork.Infrastructure.DataAcess.Repository
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(CondominiumNetworkContext context) : base(context) { }

        public async virtual Task<Profile> GetProfileOcurrences(Guid id)
        {
            return await Db.Profiles.AsNoTracking()
                 .Include(o => o.Ocurrences)
                 .Where(p => p.Id == id)
                 .FirstOrDefaultAsync();
        }
    }
}
