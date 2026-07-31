using TFA.Backend.Application.Interfaces.Services;
using TFA.Backend.Domain.Entities;

namespace TFA.Backend.Application.Services
{
    public class ProductGeneratorService : IProductGeneratorService
    {
        public IEnumerable<Product> GenerateProducts(Guid categoryId, Guid supplierId, int quantity)
        {
            var random = new Random();

            for (int i = 0; i < quantity; i++)
            {
                yield return new Product
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = $"Product {random.Next(1, 1000)}",
                    SupplierID = supplierId,
                    CategoryID = categoryId,
                    QuantityPerUnit = random.Next(1, 100),
                    UnitPrice = (decimal)(random.NextDouble() * 100),
                    UnitsInStock = random.Next(0, 100),
                    UnitsOnOrder = random.Next(0, 50),
                    ReorderLevel = random.Next(0, 20),
                    Discontinued = random.Next(0, 2) == 1
                };
            }
        }
    }
}
