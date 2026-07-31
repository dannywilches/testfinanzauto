using TFA.Backend.Application.Commands.CategoryCommand.CreateCategory;

namespace TFA.Backend.Application.Interfaces.Category
{
    public interface ICreateCategoryHandler
    {
        Task<CreateCategoryResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken);
    }
}
