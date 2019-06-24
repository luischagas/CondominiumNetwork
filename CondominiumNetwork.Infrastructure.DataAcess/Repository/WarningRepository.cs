using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.Infrastructure.DataAcess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumNetwork.Infrastructure.DataAcess.Repository
{
    public class WarningRepository : Repository<Warning>, IWarningRepository
    {
        public WarningRepository(CondominiumNetworkContext context) : base(context) { }

        public async Task<Warning> GetDetailsWarning(Guid id)
        {
            var warning = await Db.Warnings.AsNoTracking()
                 .Include(p => p.Profile)
                 .Where(o => o.Id == id)
                 .FirstOrDefaultAsync();

            return warning;
        }
    }
}
