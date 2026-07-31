namespace TFA.Backend.Domain.Entities
{
    public class OrderDetail
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
