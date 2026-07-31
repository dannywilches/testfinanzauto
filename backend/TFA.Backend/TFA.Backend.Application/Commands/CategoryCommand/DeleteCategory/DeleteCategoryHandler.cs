using TFA.Backend.Application.Interfaces.Category;
using TFA.Backend.Domain.Repositories;

namespace TFA.Backend.Application.Commands.CategoryCommand.DeleteCategory
{
    public class DeleteCategoryHandler : IDeleteCategoryHandler
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryById(request.CategoryID);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            var result = await _categoryRepository.DeleteCategory(request.CategoryID);
            return result;
        }
    }
}
