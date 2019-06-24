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

        //public async Task Create(Category entity)
        //{
        //    Db.Categories.Add(entity);
        //    await SaveChanges();
        //}

        //public Task Update(Category entity)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Category> ICategoryRepository.Read(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<Category>> ICategoryRepository.ReadAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
