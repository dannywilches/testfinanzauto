using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TFA.Backend.Application.Interfaces.Supplier;

namespace TFA.Backend.Api.Controllers
{
    [Authorize]
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly ISupplierQueryHandler _supplierQueryHandler;
        public SupplierController(ILogger<SupplierController> logger, ISupplierQueryHandler supplierQueryHandler)
        {
            _logger = logger;
            _supplierQueryHandler = supplierQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GeAllSuppliers(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Start GetAllSupplier");
            try
            {
                _logger.LogInformation("Fetching supplier");

                var result = await _supplierQueryHandler.Handle(cancellationToken);
                if (result == null)
                {
                    return NotFound("No suppliers found");
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching suppliers");
                return StatusCode(500, "An error occurred while fetching suppliers");
            }
        }
    }
}
