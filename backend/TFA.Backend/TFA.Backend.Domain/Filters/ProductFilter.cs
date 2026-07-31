namespace TFA.Backend.Domain.Filters
{
    public class ProductFilter
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public string? Category { get; set; }
    }
}
