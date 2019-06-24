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
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(CondominiumNetworkContext context) : base(context) { }

        public async virtual Task<IEnumerable<Answer>> GetDetailsAnswers(Guid id)
        {
            return await Db.Answers.AsNoTracking()
                 .Include(o => o.Profile)
                 .Where(o => o.ProfileId == id)
                 .ToListAsync();
        }

    }
}
