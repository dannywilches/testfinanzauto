using TFA.Backend.Application.DTOs.Auth;
using TFA.Backend.Domain.Entities;

namespace TFA.Backend.Application.Interfaces.Auth
{
    public interface ITokenService
    {
        TokenDto GenerateToken(User user);
    }
}
