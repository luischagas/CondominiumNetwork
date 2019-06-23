using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.Infrastructure.DataAcess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominiumNetwork.Infrastructure.DataAcess.Repository
{
    public class OcurrenceRepository : IOcurrenceRepository
    {
        private readonly CondominiumNetworkContext _db;

        public OcurrenceRepository(CondominiumNetworkContext db)
        {
            _db = db;
        }

        public virtual async Task Create(Ocurrence entity)
        {
            _db.Ocurrences.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            _db.Remove(await Read(id));
            await SaveChanges();
        }

        public async virtual Task<IEnumerable<Ocurrence>> GetOcurrencesProfile(Guid id)
        {
            return await _db.Ocurrences.AsNoTracking()
                 .Include(o => o.Profile)
                 .Where(o => o.ProfileId == id)
                 .ToListAsync();
        }

        public virtual async Task<Ocurrence> Read(Guid id)
        {
            return await _db.Ocurrences.FindAsync(id);
        }

        public virtual async Task<IEnumerable<Ocurrence>> ReadAll()
        {
            return await _db.Ocurrences.ToListAsync();
        }

        public async Task<IEnumerable<Ocurrence>> Search(Expression<Func<Ocurrence, bool>> predicate)
        {
            return await _db.Ocurrences.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Update(Ocurrence entity)
        {
            _db.Ocurrences.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<Ocurrence> GetOcurrenceAnswers(Guid id)
        {
            var ocurrences = await _db.Ocurrences.AsNoTracking()
                 .Include(p => p.Profile)
                 .Include(a => a.Answers)
                    .ThenInclude(p => p.Profile)
                 .FirstOrDefaultAsync();

            return ocurrences;
        }
    }
}
