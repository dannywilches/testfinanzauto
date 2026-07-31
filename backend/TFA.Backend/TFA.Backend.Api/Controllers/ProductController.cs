using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TFA.Backend.Application.Commands.ProductCommand.BulkCreateProduct;
using TFA.Backend.Application.Commands.ProductCommand.CreateProduct;
using TFA.Backend.Application.Commands.ProductCommand.DeleteProduct;
using TFA.Backend.Application.Commands.ProductCommand.UpdateProduct;
using TFA.Backend.Application.Interfaces.Product;
using TFA.Backend.Application.Queries.ProductDetailQuery;
using TFA.Backend.Application.Queries.ProductQuery;

namespace TFA.Backend.Api.Controllers
{
    [Authorize]
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductDetailQueryHandler _productDetailQueryHandler;
        private readonly IProductQueryHandler _productQueryHandler;
        private readonly ICreateProductHandler _createProductHandler;
        private readonly IUpdateProductHandler _updateProductHandler;
        private readonly IDeleteProductHandler _deleteProductHandler;
        private readonly IBulkCreateProductsHandler _bulkCreateProductsHandler;
        public ProductController(
            ILogger<ProductController> logger,
            IProductDetailQueryHandler productDetailQueryHandler,
            IProductQueryHandler productQueryHandler,
            ICreateProductHandler createProductHandler,
            IUpdateProductHandler updateProductHandler,
            IDeleteProductHandler deleteProductHandler,
            IBulkCreateProductsHandler bulkCreateProductsHandler
            )
        {
            _logger = logger;
            _productDetailQueryHandler = productDetailQueryHandler;
            _productQueryHandler = productQueryHandler;
            _createProductHandler = createProductHandler;
            _updateProductHandler = updateProductHandler;
            _deleteProductHandler = deleteProductHandler;
            _bulkCreateProductsHandler = bulkCreateProductsHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? category = null,
            [FromQuery] string? search = null,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("GetProducts called with page: {Page}, pageSize: {PageSize}, category: {Category}, search: {Search}", page, pageSize, category, search);
            try
            {
                _logger.LogInformation("Fetching products");
                var query = new ProductsQuery(page, pageSize, category, search);

                var result = await _productQueryHandler.Handle(query, cancellationToken);
                if (result == null || result.Items == null || !result.Items.Any())
                {
                    _logger.LogInformation("No products found for the given query parameters");
                    return NotFound("No products found");
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching products");
                return StatusCode(500, "An error occurred while fetching products");
            }
        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> GetProductById(Guid productId, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Start GetProductById with ID: {ProductId}", productId);
            try
            {
                _logger.LogInformation("Fetching product with ID: {ProductId}", productId);
                var query = new ProductDetailQuery(productId);
                var result = await _productDetailQueryHandler.Handle(query, cancellationToken);
                if (result == null)
                {
                    _logger.LogInformation("Product with ID: {ProductId} not found", productId);
                    return NotFound($"Product with ID: {productId} not found");
                }
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Product with ID: {ProductId} not found", productId);
                return NotFound($"Product with ID: {productId} not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching product with ID: {ProductId}", productId);
                return StatusCode(500, "An error occurred while fetching the product");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDto request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Creating a new product");
            try
            {
                var command = new CreateProductCommand(
                    Guid.NewGuid(),
                    request.ProductName,
                    request.SupplierID,
                    request.CategoryID,
                    request.QuantityPerUnit,
                    request.UnitPrice,
                    request.UnitsInStock,
                    request.UnitsOnOrder,
                    request.ReorderLevel,
                    request.Discontinued
                );
                var result = await _createProductHandler.Handle(command, cancellationToken);
                if (result == null)
                {
                    _logger.LogWarning("Failed to create product");
                    return BadRequest("Failed to create product");
                }
                return Created($"/products/{result.ProductID}", result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a product");
                return StatusCode(500, "An error occurred while creating the product");
            }

        }

        [HttpPut("{productId:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] UpdateProductRequestDto request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Start UpdateProduct with ID: {ProductId}", productId);
            try
            {
                _logger.LogInformation("Updating product with ID: {ProductId}", productId);
                var command = new UpdateProductCommand(
                    productId,
                    request.ProductName,
                    request.SupplierID,
                    request.CategoryID,
                    request.QuantityPerUnit,
                    request.UnitPrice,
                    request.UnitsInStock,
                    request.UnitsOnOrder,
                    request.ReorderLevel,
                    request.Discontinued
                );
                var result = await _updateProductHandler.Handle(command, cancellationToken);
                if (!result.StatusUpdated)
                {
                    _logger.LogWarning("Failed to update product with ID: {ProductId}", productId);
                    return BadRequest("Failed to update product");
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating product with ID: {ProductId}", productId);
                return StatusCode(500, "An error occurred while updating the product");
            }
        }

        [HttpDelete("{productId:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid productId, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Start DeleteProduct with ID: {ProductId}", productId);
            try
            {
                _logger.LogInformation("Deleting product with ID: {ProductId}", productId);
                var command = new DeleteProductCommand(productId);
                var response = await _deleteProductHandler.Handle(command, cancellationToken);
                if (!response)
                {
                    _logger.LogWarning("Failed to delete product with ID: {ProductId}", productId);
                    return BadRequest("Failed to delete product");
                }
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting product with ID: {ProductId}", productId);
                return StatusCode(500, "An error occurred while deleting the product");
            }
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateProductsBulk([FromBody] BulkCreateProductsRequestDto request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Creating products in bulk");
            try
            {
                var command = new BulkCreateProductsCommand(request.Quantity, request.CategoryID, request.SupplierID);
                var execution = await _bulkCreateProductsHandler.Handle(command, cancellationToken);
                if (execution.Processed <= 0)
                {
                    _logger.LogWarning("Failed to create some products in bulk");
                    return BadRequest("Failed to create some products");
                }
                return Created("/products/bulk", execution);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating products in bulk");
                return StatusCode(500, "An error occurred while creating products in bulk");
            }
        }
    }
}
