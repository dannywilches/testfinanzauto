namespace TFA.Backend.Infrastructure.Persistence.Models
{
    public class CategoryModel
    {
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();

    }
}
