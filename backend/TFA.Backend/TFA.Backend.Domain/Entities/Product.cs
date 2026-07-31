namespace TFA.Backend.Domain.Entities
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public Guid SupplierID { get; set; }
        public Guid CategoryID { get; set; }
        public decimal QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitsInStock { get; set; }
        public decimal UnitsOnOrder { get; set; }
        public decimal ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
