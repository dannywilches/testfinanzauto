namespace TFA.Backend.Infrastructure.Persistence.Models
{
    public class OrderModel
    {
        public Guid OrderID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public Guid ShipVia { get; set; }
        public string Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public CustomerModel Customer { get; set; }
        public EmployeeModel Employee { get; set; }
        public ShipperModel Shipper { get; set; }
        public ICollection<OrderDetailModel> OrderDetails { get; set; } = new List<OrderDetailModel>();
    }
}
