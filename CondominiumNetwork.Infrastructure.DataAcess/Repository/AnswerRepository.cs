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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly CondominiumNetworkContext _db;

        public AnswerRepository(CondominiumNetworkContext db)
        {
            _db = db;
        }

        public virtual async Task Create(Answer entity)
        {
            _db.Answers.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            _db.Remove(await Read(id));
            await SaveChanges();
        }


        public virtual async Task<Answer> Read(Guid id)
        {
            return await _db.Answers.FindAsync(id);
        }

        public virtual async Task<IEnumerable<Answer>> ReadAll()
        {
            return await _db.Answers.ToListAsync();
        }

        public async Task<IEnumerable<Answer>> Search(Expression<Func<Answer, bool>> predicate)
        {
            return await _db.Answers.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Update(Answer entity)
        {
            _db.Answers.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public async virtual Task<IEnumerable<Answer>> GetAnswersOcurrence(Guid id)
        {
            return await _db.Answers.AsNoTracking()
                 .Include(o => o.Profile)
                 .Where(o => o.ProfileId == id)
                 .ToListAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
