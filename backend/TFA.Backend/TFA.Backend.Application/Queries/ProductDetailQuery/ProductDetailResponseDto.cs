namespace TFA.Backend.Application.Queries.ProductDetailQuery
{
    public class ProductDetailResponseDto
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string Supplier { get; set; }
        public string Category { get; set; }
        public decimal QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitsInStock { get; set; }
        public decimal UnitsOnOrder { get; set; }
        public decimal ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
