using TFA.Backend.Domain.Entities;

namespace TFA.Backend.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> CreateCategory(Category category, CancellationToken ct = default);
        Task<bool> DeleteCategory(Guid categoryId, CancellationToken ct = default);
        Task<Category?> GetCategoryById(Guid categoryId, CancellationToken ct = default);
        Task<List<Category>> GetCategories(CancellationToken ct = default);
    }
}
