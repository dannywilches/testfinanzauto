using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TFA.Backend.Application.Commands.CategoryCommand.CreateCategory;
using TFA.Backend.Application.Commands.CategoryCommand.DeleteCategory;
using TFA.Backend.Application.Interfaces.Category;

namespace TFA.Backend.Api.Controllers
{
    [Authorize]
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICreateCategoryHandler _createCategoryHandler;
        private readonly IDeleteCategoryHandler _deleteCategoryHandler;
        public CategoryController(ILogger<CategoryController> logger, ICreateCategoryHandler createCategoryHandler, IDeleteCategoryHandler deleteCategoryHandler)
        {
            _logger = logger;
            _createCategoryHandler = createCategoryHandler;
            _deleteCategoryHandler = deleteCategoryHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Start Request Create Category");
            try
            {
                var response = await _createCategoryHandler.Handle(new CreateCategoryCommand
                (
                    Guid.NewGuid(),
                    request.CategoryName,
                    request.Description,
                    request.Picture
                ), cancellationToken);
                if (response == null)
                {
                    _logger.LogWarning("The request for Create Catergory cann't be processed");
                    return BadRequest("Failed to create category");
                }
                return Created($"/categories/{response.CategoryID}", response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request for Create Catergory");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpDelete("{categoryId:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Start Request Delete Category with ID: {CategoryId}", categoryId);
            try
            {
                var result = await _deleteCategoryHandler.Handle(new DeleteCategoryCommand(categoryId), cancellationToken);
                if (!result)
                {
                    _logger.LogWarning("The request for Delete Category with ID: {CategoryId} can't be processed", categoryId);
                    return BadRequest("Failed to delete category");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request for Delete Category with ID: {CategoryId}", categoryId);
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}