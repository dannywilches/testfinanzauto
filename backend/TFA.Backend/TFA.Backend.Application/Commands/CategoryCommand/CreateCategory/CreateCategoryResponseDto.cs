namespace TFA.Backend.Application.Commands.CategoryCommand.CreateCategory
{
    public class CreateCategoryResponseDto
    {
        public string Message { get; set; }
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}
