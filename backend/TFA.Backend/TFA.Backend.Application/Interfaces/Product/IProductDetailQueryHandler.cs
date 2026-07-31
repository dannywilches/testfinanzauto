using TFA.Backend.Application.Queries.ProductDetailQuery;

namespace TFA.Backend.Application.Interfaces.Product
{
    public interface IProductDetailQueryHandler
    {
        Task<ProductDetailResponseDto> Handle(ProductDetailQuery request, CancellationToken cancellationToken);
    }
}
