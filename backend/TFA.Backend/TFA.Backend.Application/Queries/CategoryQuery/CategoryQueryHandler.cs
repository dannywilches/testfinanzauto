using TFA.Backend.Application.Interfaces.Category;
using TFA.Backend.Application.Queries.ProductQuery;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Repositories;

namespace TFA.Backend.Application.Queries.CategoryQuery
{
    public class CategoryQueryHandler : ICategoryQueryHandler
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryQueryResponseDto>> Handle(CancellationToken cancellationToken)
        {
            var listCategories = await _categoryRepository.GetCategories(cancellationToken);
            var response = listCategories.Select(p => new CategoryQueryResponseDto
            {
                CategoryID = p.CategoryID,
                CategoryName = p.CategoryName
            }).ToList();
            return response;
        }
    }
}
