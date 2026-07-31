namespace TFA.Backend.Application.Commands.CategoryCommand.CreateCategory
{
    public record CreateCategoryCommand(
        Guid CategoryID,
        string CategoryName,
        string Description,
        string Picture  
    );
}
