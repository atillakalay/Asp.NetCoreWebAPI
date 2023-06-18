using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _repositoryManager.Category.GetAllCategoriesAsync(trackChanges);
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = await _repositoryManager.Category.GetOneCategoryByIdAsync(id, trackChanges);

            if (category == null)
            {
                throw new CategoryNotFoundException(id);
            }
            return category;
        }
    }
}
