using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.DomainModel.ValueObjects;
using CondominiumNetwork.Infrastructure.AzureStorage;
using CondominiumNetwork.Infrastructure.DataAcess.Context;
using CondominiumNetwork.Infrastructure.DataAcess.Context.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.Infrastructure.DataAcess.Repository
{
    public class CategoryRepository : Repository<DbCategory>
    {
        public CategoryRepository(CondominiumNetworkContext context) : base(context) { }

        public override async Task Create(DbCategory entity)
        {
            Db.Categories.Add(entity);
            await SaveChanges();
        }

        //public Task Update(Category entity)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Category> ICategoryRepository.Read(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public override async Task<IEnumerable<DbCategory>> ReadAll()
        {
            return await Db.Categories.ToListAsync();
        }
    }
}
