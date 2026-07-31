namespace TFA.Backend.Application.Commands.ProductCommand.UpdateProduct
{
    public class UpdateProductRequestDto
    {
        public string ProductName { get; set; }
        public Guid SupplierID { get; set; }
        public Guid CategoryID { get; set; }
        public decimal QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitsInStock { get; set; }
        public decimal UnitsOnOrder { get; set; }
        public decimal ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
