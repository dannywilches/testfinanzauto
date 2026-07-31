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
                Name = "Administrador",
                Username = "admin",
                Password = "123456",
            });
            context.Users.Add(new UserModel
            {
                Id = Guid.NewGuid(),
                Name = "Usuario",
                Username = "userdefault",
                Password = "123456",
            });

            context.Categories.Add(new CategoryModel
            {
                CategoryID = Guid.NewGuid(),
                CategoryName = "SERVIDORES",
                Description = "On Premise",
                Picture = "https://media.istockphoto.com/id/2148113350/es/foto/racks-de-servidores-para-centros-de-datos-sala-de-servidores-de-hardware-moderno-de-ti-centro.jpg?s=612x612&w=0&k=20&c=2ft9N0pxqkVXgI8Ok_QeDXzwYfQL7ZQK64WsTcagWho="
            });

            context.Categories.Add(new CategoryModel
            {
                CategoryID = Guid.NewGuid(),
                CategoryName = "CLOUD",
                Description = "En la nube",
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQjN_XPzv5e91-G2sZbGyY4MqqxH0tcvy7Q7it-9uz4981aPm6Al2w43wQ&s=10"
            });

            context.Suppliers.Add(new SupplierModel
            {
                SupplierID = Guid.NewGuid(),
                CompanyName = "Proveedor El Lago",
                ContactName = "Pedro Perez",
                ContactTitle = "Asistente",
                Address = "Calle 100",
                City = "Bogota",
                Region = "Cundinamarca",
                PostalCode = "11001",
                Country = "CO",
                Phone = "32154560056",
                Fax = "6017565495",
                HomePage = "https://test-proveedor.com"
            });

            await context.SaveChangesAsync();
        }
    }
}
