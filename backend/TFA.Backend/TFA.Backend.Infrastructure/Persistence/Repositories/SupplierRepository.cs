using Microsoft.EntityFrameworkCore;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Repositories;
using TFA.Backend.Infrastructure.Persistence.Context;
using TFA.Backend.Infrastructure.Persistence.Mappers;

namespace TFA.Backend.Infrastructure.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly CatalogDbContext _dbContext;

        public SupplierRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Supplier>> GetSuppliers(CancellationToken ct = default)
        {
            var suppliers = await _dbContext.Suppliers.AsNoTracking().ToListAsync(ct);
            return suppliers.Select(SupplierMapper.ToEntity).ToList();
        }
    }
}
