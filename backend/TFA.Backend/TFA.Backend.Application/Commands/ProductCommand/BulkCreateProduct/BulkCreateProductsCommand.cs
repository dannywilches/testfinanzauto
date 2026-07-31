namespace TFA.Backend.Application.Commands.ProductCommand.BulkCreateProduct
{
    public record BulkCreateProductsCommand(
        int Quantity,
        Guid CategoryID,
        Guid SupplierID
    );
}
