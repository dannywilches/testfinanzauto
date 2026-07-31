namespace TFA.Backend.Application.Interfaces.Services
{
    public interface IProductGeneratorService
    {
        IEnumerable<Domain.Entities.Product> GenerateProducts(Guid categoryId, Guid supplierId, int quantity);
    }
}
