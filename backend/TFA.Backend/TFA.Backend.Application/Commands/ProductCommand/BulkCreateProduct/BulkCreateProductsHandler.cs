using System.ComponentModel.DataAnnotations;
using TFA.Backend.Application.Interfaces.Product;
using TFA.Backend.Application.Interfaces.Services;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Repositories;

namespace TFA.Backend.Application.Commands.ProductCommand.BulkCreateProduct
{
    public class BulkCreateProductsHandler : IBulkCreateProductsHandler
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductGeneratorService _productGeneratorService;
        private const int BatchSize = 1000; 
        public BulkCreateProductsHandler(ICategoryRepository categoryRepository, IProductRepository productRepository, IProductGeneratorService productGeneratorService)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productGeneratorService = productGeneratorService;
        }
        public async Task<BulkCreateProductsResponseDto> Handle(BulkCreateProductsCommand request, CancellationToken cancellationToken = default)
        {
            var category = await _categoryRepository.GetCategoryById(request.CategoryID);
            if (category == null)
                throw new Exception($"Category not found.");

            if (request.Quantity <= 0)
                throw new ValidationException($"Quantity must be greater than zero.");

            if (request.Quantity > 1000000)
                throw new ValidationException($"Maximum quantity exceeded.");

            var processed = 0;

            for (int i = 0; 
                i < request.Quantity; 
                i += BatchSize)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var quantity = Math.Min(BatchSize, request.Quantity - i);

                var products = _productGeneratorService.GenerateProducts(request.CategoryID, request.SupplierID, quantity).ToList();

                await _productRepository.BulkCreateProducts(products, cancellationToken);

                processed += quantity;
            }

            return new BulkCreateProductsResponseDto
            {
                Requested = request.Quantity,
                Processed = processed,
                CategoryID = request.CategoryID,
                SupplierID = request.SupplierID
            };
        }
    }
}
