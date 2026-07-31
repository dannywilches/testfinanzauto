namespace TFA.Backend.Application.Commands.ProductCommand.UpdateProduct
{
    public class UpdateProductResponseDto
    {
        public string Message { get; set; }
        public Guid ProductID { get; set; }
        public bool StatusUpdated { get; set; }
    }
}
