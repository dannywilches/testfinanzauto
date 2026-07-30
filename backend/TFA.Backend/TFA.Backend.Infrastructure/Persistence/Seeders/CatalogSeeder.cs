using TFA.Backend.Infrastructure.Persistence.Context;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Seeders
{
    public static class CatalogSeeder
    {
        public static async Task SeedAsync(CatalogDbContext context)
        {
            if (context.Users.Any())
            {
                return; // DB has been seeded
            }

            context.Users.Add(new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "Daniel Wilches",
                Username = "daniel",
                Password = "123456",
            });

            await context.SaveChangesAsync();
        }
    }
}
