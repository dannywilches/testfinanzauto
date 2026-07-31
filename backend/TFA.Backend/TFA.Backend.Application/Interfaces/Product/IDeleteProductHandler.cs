using TFA.Backend.Application.Commands.ProductCommand.DeleteProduct;

namespace TFA.Backend.Application.Interfaces.Product
{
    public interface IDeleteProductHandler
    {
        Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken);
    }
}
