namespace TFA.Backend.Application.Commands.ProductCommand.UpdateProduct
{
    public record UpdateProductCommand(
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