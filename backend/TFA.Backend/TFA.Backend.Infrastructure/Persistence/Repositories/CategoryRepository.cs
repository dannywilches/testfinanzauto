using Microsoft.EntityFrameworkCore;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Repositories;
using TFA.Backend.Infrastructure.Persistence.Context;
using TFA.Backend.Infrastructure.Persistence.Mappers;

namespace TFA.Backend.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogDbContext _dbContext;

        public CategoryRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category?> CreateCategory(Category category, CancellationToken ct = default)
        {
            var newCategory = CategoryMapper.ToModel(category);
            await _dbContext.Categories.AddAsync(newCategory, ct);
            await _dbContext.SaveChangesAsync(ct);
            return CategoryMapper.ToEntity(newCategory);
        }

        public async Task<bool> DeleteCategory(Guid categoryId, CancellationToken ct = default)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryID == categoryId, ct);
            if (category == null) 
                return false;
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync(ct);
            return true;
        }

        public async Task<Category?> GetCategoryById(Guid categoryId, CancellationToken ct = default)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryID == categoryId, ct);
            return CategoryMapper.ToEntity(category);
        }
    }
}
