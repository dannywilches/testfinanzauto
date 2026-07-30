namespace TFA.Backend.Infrastructure.Persistence.Models
{
    public class ProductModel
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

        public CategoryModel Category { get; set; }
        public SupplierModel Supplier { get; set; }
        public ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}
