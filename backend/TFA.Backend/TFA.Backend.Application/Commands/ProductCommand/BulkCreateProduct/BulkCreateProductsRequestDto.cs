namespace TFA.Backend.Application.Commands.ProductCommand.BulkCreateProduct
{
    public class BulkCreateProductsRequestDto
    {
        public int Quantity { get; set; }
        public Guid CategoryID { get; set; }
        public Guid SupplierID { get; set; }
    }
}
