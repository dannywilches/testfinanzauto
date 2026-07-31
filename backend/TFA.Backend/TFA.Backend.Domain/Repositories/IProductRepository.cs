using TFA.Backend.Domain.Common;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Filters;

namespace TFA.Backend.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> CreateProduct(Product product, CancellationToken ct = default);
        Task<bool> DeleteProduct(Guid productId, CancellationToken ct = default);
        Task<Product?> GetProductById(Guid productId, CancellationToken ct = default);
        Task<PagedResult<Product>> GetAllProductsPaged(ProductFilter filter, CancellationToken ct = default);
        Task<bool> UpdateProduct(Product product, CancellationToken ct = default);
        Task BulkCreateProducts(IEnumerable<Product> products, CancellationToken ct = default);
    }
}
