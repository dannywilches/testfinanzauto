using TFA.Backend.Application.Interfaces.Product;
using TFA.Backend.Domain.Repositories;

namespace TFA.Backend.Application.Queries.ProductDetailQuery
{
    public class ProductDetailQueryHandler : IProductDetailQueryHandler
    {
        private readonly IProductRepository _productRepository;
        public ProductDetailQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDetailResponseDto> Handle(ProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.ProductID, cancellationToken);
            if(product == null)
                throw new KeyNotFoundException($"Product with ID {request.ProductID} not found.");

            var response = new ProductDetailResponseDto
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                SupplierID = product.SupplierID,
                CategoryID = product.CategoryID,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued,
                PictureCategory = product.Category.Picture
            };
            return response;
        }
    }
}
