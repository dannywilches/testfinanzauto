using Microsoft.AspNetCore.Identity;
using TFA.Backend.Application.Interfaces.Auth;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Repositories;

namespace TFA.Backend.Application.Commands.Auth
{
    public class LoginCommandHandler : ILoginCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<LoginResponseDto> Handle(LoginCommand command)
        {

            var user = await _userRepository.ValidateLogin(command.Username);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            // Temporal mientras pruebas
            if (user.Password != command.Password)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            //var passwordHasher = new PasswordHasher<User>();
            //var validateUser = passwordHasher.VerifyHashedPassword(user, user.Password, command.Password);

            //if (validateUser != PasswordVerificationResult.Success)
            //{
            //    throw new UnauthorizedAccessException("Invalid username or password.");
            //}

            var token = _tokenService.GenerateToken(user);

            var loginResponse = new LoginResponseDto
            {
                Username = user.Name,
                Token = token.Token,
                Type = token.Type,
                Expire = token.Expire
            };
            return loginResponse;
        }
    }
}
