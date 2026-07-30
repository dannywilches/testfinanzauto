using TFA.Backend.Application.Commands.Auth;

namespace TFA.Backend.Application.Interfaces.Auth
{
    public interface ILoginCommandHandler
    {
        Task<LoginResponseDto> Handle(LoginCommand command);
    }
}
