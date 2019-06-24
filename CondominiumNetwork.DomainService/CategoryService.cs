using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Interfaces.Repositories;
using CondominiumNetwork.DomainModel.Interfaces.Services;
using CondominiumNetwork.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumNetwork.DomainService
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Create(Category category)
        {
            await _categoryRepository.Create(category);
        }

        public async Task Update(Category category)
        {
            await _categoryRepository.Update(category);
        }

        public async Task Delete(Guid ocurrenceId)
        {
            await _categoryRepository.Delete(ocurrenceId);
        }

        public async Task<Category> Get(Guid ocurrenceId)
        {
            return await _categoryRepository.Read(ocurrenceId);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.ReadAll();
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}
