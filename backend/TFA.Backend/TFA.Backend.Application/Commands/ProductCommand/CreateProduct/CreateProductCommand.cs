namespace TFA.Backend.Application.Commands.ProductCommand.CreateProduct
{
    public record CreateProductCommand(
        Guid ProductID,
        string ProductName,
        Guid SupplierID,
        Guid CategoryID,
        decimal QuantityPerUnit,
        decimal UnitPrice,
        decimal UnitsInStock,
        decimal UnitsOnOrder,
        decimal ReorderLevel,
        bool Discontinued
    );
}
