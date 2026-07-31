using TFA.Backend.Application.Interfaces.Product;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Repositories;

namespace TFA.Backend.Application.Commands.ProductCommand.UpdateProduct
{
    public class UpdateProductHandler : IUpdateProductHandler
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<UpdateProductResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetProductById(request.ProductID, cancellationToken);
            if (existingProduct == null)
                throw new Exception($"Product with ID {request.ProductID} not found.");

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

            var updatedProduct = await _productRepository.UpdateProduct(product, cancellationToken);
            if (!updatedProduct)
                throw new Exception($"Failed to update product with ID {request.ProductID}.");
            
            return new UpdateProductResponseDto
            {
                Message = "Product updated successfully.",
                ProductID = request.ProductID,
                StatusUpdated = updatedProduct
            };
        }
    }
}
