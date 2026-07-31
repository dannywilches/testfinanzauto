using TFA.Backend.Application.Commands.ProductCommand.UpdateProduct;

namespace TFA.Backend.Application.Interfaces.Product
{
    public interface IUpdateProductHandler
    {
        Task<UpdateProductResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken);
    }
}
