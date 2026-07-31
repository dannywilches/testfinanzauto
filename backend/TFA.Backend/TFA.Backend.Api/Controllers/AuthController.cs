using Microsoft.AspNetCore.Mvc;
using TFA.Backend.Application.Commands.Auth;
using TFA.Backend.Application.Interfaces.Auth;

namespace TFA.Backend.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ILoginCommandHandler _loginCommandHandler;
        public AuthController(ILogger<AuthController> logger, ILoginCommandHandler loginCommandHandler)
        {
            _logger = logger;
            _loginCommandHandler = loginCommandHandler;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            _logger.LogInformation("Start Login with Username: {Username}", request.Username);
            try
            {
                var credentials = new LoginCommand(request.Username, request.Password);
                var login = await _loginCommandHandler.Handle(credentials);
                if (login == null) 
                    return Unauthorized("Invalid username or password.");
                return Ok(login);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized login attempt for Username: {Username}", request.Username);
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the login request for Username: {Username}", request.Username);
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
