using TFA.Backend.Application.Interfaces.Category;
using TFA.Backend.Domain.Repositories;
using TFA.Backend.Domain.Entities;

namespace TFA.Backend.Application.Commands.CategoryCommand.CreateCategory
{
    public class CreateCategoryHandler : ICreateCategoryHandler
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CreateCategoryResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                CategoryID = Guid.NewGuid(),
                CategoryName = request.CategoryName,
                Description = request.Description,
                Picture = request.Picture
            };

            var result = await _categoryRepository.CreateCategory(category, cancellationToken);

            var response = new CreateCategoryResponseDto
            {
                Message = result != null ? "Category created successfully" : "Failed to create category",
                CategoryID = result?.CategoryID ?? Guid.Empty,
                CategoryName = result?.CategoryName ?? string.Empty,
                Description = result?.Description ?? string.Empty,
                Picture = result?.Picture ?? string.Empty
            };

            return response;
        }
    }
}
