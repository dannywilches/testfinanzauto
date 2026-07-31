using TFA.Backend.Application.Commands.ProductCommand.BulkCreateProduct;

namespace TFA.Backend.Application.Interfaces.Product
{
    public interface IBulkCreateProductsHandler
    {
        Task<BulkCreateProductsResponseDto> Handle(BulkCreateProductsCommand command, CancellationToken cancellationToken = default);
    }
}
