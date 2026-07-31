using TFA.Backend.Application.Interfaces.Product;
using TFA.Backend.Domain.Filters;
using TFA.Backend.Domain.Repositories;

namespace TFA.Backend.Application.Queries.ProductQuery
{
    public class ProductQueryHandler : IProductQueryHandler
    {
        private readonly IProductRepository _productRepository;
        public ProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<PagedResult<ProductResponseDto>> Handle(ProductsQuery query, CancellationToken ct = default)
        {
            var filter = new ProductFilter
            {
                Page = query.Page,
                PageSize = query.PageSize,
                Search = query.Search
            };
            var products = await _productRepository.GetAllProductsPaged(filter, ct);


            return new PagedResult<ProductResponseDto>
            {
                Items = products.Items.Select(p => new ProductResponseDto
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    Category = p.Category.CategoryName,
                    Supplier = p.Supplier.CompanyName,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    UnitsOnOrder = p.UnitsOnOrder,
                    ReorderLevel = p.ReorderLevel,
                    Discontinued = p.Discontinued
                }).ToList(),
                Page = products.Page,
                PageSize = products.PageSize,
                TotalItems = products.TotalItems,
            };
        }
    }
}
