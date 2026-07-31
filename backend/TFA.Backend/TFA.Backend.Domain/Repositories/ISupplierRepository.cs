using TFA.Backend.Domain.Entities;

namespace TFA.Backend.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetSuppliers(CancellationToken ct = default);
    }
}
