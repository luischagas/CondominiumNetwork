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
    public class ProfileRepository : IProfileRepository
    {
        private readonly CondominiumNetworkContext _db;

        public ProfileRepository(CondominiumNetworkContext db)
        {
            _db = db;
        }

        public virtual async Task Create(Profile entity)
        {
            _db.Profiles.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            _db.Remove(Read(id));
            await SaveChanges();
        }

        public async virtual Task<IEnumerable<Profile>> GetProfileAnswers(Guid id)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<IEnumerable<Profile>> GetProfileOcurrences(Guid id)
        {
            return await _db.Profiles.AsNoTracking()
                 .Include(o => o.Ocurrences)
                 .ToListAsync();
        }

        public async virtual Task<IEnumerable<Profile>> GetProfileWarnings(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Profile> Read(Guid id)
        {
            return await _db.Profiles.FindAsync(id);
        }

        public virtual async Task<IEnumerable<Profile>> ReadAll()
        {
            return await _db.Profiles.ToListAsync();
        }

        public async Task<IEnumerable<Profile>> Search(Expression<Func<Profile, bool>> predicate)
        {
            return await _db.Profiles.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Update(Profile entity)
        {
            _db.Profiles.Update(entity);
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
    }
}
