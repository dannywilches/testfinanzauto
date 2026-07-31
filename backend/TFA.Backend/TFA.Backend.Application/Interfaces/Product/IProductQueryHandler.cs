using TFA.Backend.Application.Queries.ProductQuery;

namespace TFA.Backend.Application.Interfaces.Product
{
    public interface IProductQueryHandler
    {
        Task<PagedResult<ProductResponseDto>> Handle(ProductsQuery query, CancellationToken ct = default);
    }
}
