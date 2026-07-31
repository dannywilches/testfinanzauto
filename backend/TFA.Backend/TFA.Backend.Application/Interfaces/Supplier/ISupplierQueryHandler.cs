using TFA.Backend.Application.Queries.SupplierQuery;

namespace TFA.Backend.Application.Interfaces.Supplier
{
    public interface ISupplierQueryHandler
    {
        Task<List<SupplierQueryResponseDto>> Handle(CancellationToken cancellationToken);
    }
}
