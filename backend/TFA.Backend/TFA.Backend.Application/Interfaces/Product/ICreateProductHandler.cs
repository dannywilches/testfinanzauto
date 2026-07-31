using TFA.Backend.Application.Commands.ProductCommand.CreateProduct;

namespace TFA.Backend.Application.Interfaces.Product
{
    public interface ICreateProductHandler
    {
        Task<CreateProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken);
    }
}
