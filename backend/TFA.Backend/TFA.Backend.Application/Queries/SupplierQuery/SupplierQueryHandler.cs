using TFA.Backend.Application.Interfaces.Supplier;
using TFA.Backend.Application.Queries.CategoryQuery;
using TFA.Backend.Domain.Repositories;

namespace TFA.Backend.Application.Queries.SupplierQuery
{
    public class SupplierQueryHandler : ISupplierQueryHandler
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierQueryHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<List<SupplierQueryResponseDto>> Handle(CancellationToken cancellationToken)
        {
            var listSuppliers = await _supplierRepository.GetSuppliers(cancellationToken);
            var response = listSuppliers.Select(p => new SupplierQueryResponseDto
            {
                SupplierID = p.SupplierID,
                CompanyName = p.CompanyName
            }).ToList();

            return response;
        }
    }
}
