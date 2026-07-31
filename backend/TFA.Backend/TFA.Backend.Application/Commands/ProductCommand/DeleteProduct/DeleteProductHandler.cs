using TFA.Backend.Application.Interfaces.Product;
using TFA.Backend.Domain.Repositories;

namespace TFA.Backend.Application.Commands.ProductCommand.DeleteProduct
{
    public class DeleteProductHandler : IDeleteProductHandler
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.ProductID);
            if (product == null)
                throw new Exception("Product not found");

            var result = await _productRepository.DeleteProduct(request.ProductID);
            return result;
        }
    }
}
