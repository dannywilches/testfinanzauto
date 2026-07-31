namespace TFA.Backend.Application.Commands.ProductCommand.BulkCreateProduct
{
    public class BulkCreateProductsResponseDto
    {
        public int Requested { get; set; }
        public int Processed { get; set; }
        public Guid CategoryID { get; set; }
        public Guid SupplierID { get; set; }
    }
}
