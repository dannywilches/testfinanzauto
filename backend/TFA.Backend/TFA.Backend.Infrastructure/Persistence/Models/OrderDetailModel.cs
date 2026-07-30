namespace TFA.Backend.Infrastructure.Persistence.Models
{
    public class OrderDetailModel
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }

        public OrderModel Order { get; set; }
        public ProductModel Product { get; set; }
    }
}
