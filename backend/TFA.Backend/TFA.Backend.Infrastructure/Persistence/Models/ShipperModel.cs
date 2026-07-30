namespace TFA.Backend.Infrastructure.Persistence.Models
{
    public class ShipperModel
    {
        public Guid ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public ICollection<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
