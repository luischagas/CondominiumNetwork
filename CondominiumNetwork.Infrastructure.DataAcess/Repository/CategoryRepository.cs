using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.DomainModel.ValueObjects;
using CondominiumNetwork.Infrastructure.AzureStorage;
using CondominiumNetwork.Infrastructure.DataAcess.Context;
using CondominiumNetwork.Infrastructure.DataAcess.Context.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.Infrastructure.DataAcess.Repository
{
    public class CategoryRepository : Repository<DbCategory>, ICategoryRepository
    {
        public CategoryRepository(CondominiumNetworkContext context) : base(context) { }

        public virtual async Task CreateCategory(Category entity)
        {

            DbCategory categoryDbModel = new DbCategory();

            categoryDbModel.Id = Guid.NewGuid();
            categoryDbModel.Category = entity.Description;

            Db.Categories.Add(categoryDbModel);
            await SaveChanges();
        }

        public virtual async Task<IEnumerable<Category>> ReadAllCategories()
        {
            var listDBModel = await Db.Categories.ToArrayAsync();

            IList<Category> listCategory = new List<Category>();
            foreach (DbCategory item in listDBModel.ToList())
            {
                Category list = new Category();
                list.Description = item.Category;
                listCategory.Add(list);
            }

            return listCategory.ToList().OrderBy(c => c.Description);
        }

    }
}
