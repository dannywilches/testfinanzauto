namespace TFA.Backend.Application.Queries.ProductQuery
{
    public record ProductsQuery(
        int Page,
        int PageSize,
        string? Search
    );
}
