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
    public class OcurrenceRepository : Repository<Ocurrence>, IOcurrenceRepository
    {
        public OcurrenceRepository(CondominiumNetworkContext context) : base(context) { }
        public async Task<Ocurrence> GetOcurrenceAnswers(Guid id)
        {
            var ocurrence = await Db.Ocurrences.AsNoTracking()
                 .Include(p => p.Profile)
                 .Include(a => a.Answers)
                    .ThenInclude(p => p.Profile)
                 .Where(o => o.Id == id)
                 .FirstOrDefaultAsync();

            return ocurrence;
        }

        public async Task<IEnumerable<Ocurrence>> GetAllOcurrenceAnswers()
        {
            var ocurrences = await Db.Ocurrences.AsNoTracking()
                 .Include(a => a.Answers)
                 .ToListAsync();

            return ocurrences;

        }
    }
}
