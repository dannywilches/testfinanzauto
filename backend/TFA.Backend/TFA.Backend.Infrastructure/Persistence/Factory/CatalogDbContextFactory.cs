using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TFA.Backend.Infrastructure.Persistence.Context;

namespace TFA.Backend.Infrastructure.Persistence.Factory
{
    public class CatalogDbContextFactory
        : IDesignTimeDbContextFactory<CatalogDbContext>
    {
        public CatalogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<CatalogDbContext>();

            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=CatalogDb;Username=user_postgres;Password=DannyDev2025@");

            return new CatalogDbContext(optionsBuilder.Options);
        }
    }
}