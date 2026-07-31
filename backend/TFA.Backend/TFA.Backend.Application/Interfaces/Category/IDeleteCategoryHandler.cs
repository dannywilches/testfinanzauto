using TFA.Backend.Application.Commands.CategoryCommand.DeleteCategory;

namespace TFA.Backend.Application.Interfaces.Category
{
    public interface IDeleteCategoryHandler
    {
        Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken);
    }
}
