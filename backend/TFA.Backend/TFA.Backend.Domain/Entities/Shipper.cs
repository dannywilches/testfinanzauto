namespace TFA.Backend.Domain.Entities
{
    public class Shipper
    {
        public Guid ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
