using TFA.Backend.Application.Interfaces.Product;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Repositories;

namespace TFA.Backend.Application.Commands.ProductCommand.CreateProduct
{
    public class CreateProductHandler : ICreateProductHandler
    {
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<CreateProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductID = request.ProductID,
                ProductName = request.ProductName,
                SupplierID = request.SupplierID,
                CategoryID = request.CategoryID,
                QuantityPerUnit = request.QuantityPerUnit,
                UnitPrice = request.UnitPrice,
                UnitsInStock = request.UnitsInStock,
                UnitsOnOrder = request.UnitsOnOrder,
                ReorderLevel = request.ReorderLevel,
                Discontinued = request.Discontinued
            };

            var result = await _productRepository.CreateProduct(product, cancellationToken);
            var response = new CreateProductResponseDto
            {
                ProductID = result.ProductID,
                ProductName = result.ProductName,
                SupplierID = result.SupplierID,
                CategoryID = result.CategoryID,
                QuantityPerUnit = result.QuantityPerUnit,
                UnitPrice = result.UnitPrice,
                UnitsInStock = result.UnitsInStock,
                UnitsOnOrder = result.UnitsOnOrder,
                ReorderLevel = result.ReorderLevel,
                Discontinued = result.Discontinued
            };
            return response;
        }
    }
}
