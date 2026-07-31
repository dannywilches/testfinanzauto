using TFA.Backend.Application.Queries.CategoryQuery;

namespace TFA.Backend.Application.Interfaces.Category
{
    public interface ICategoryQueryHandler
    {
        Task<List<CategoryQueryResponseDto>> Handle(CancellationToken cancellationToken);
    }
}
