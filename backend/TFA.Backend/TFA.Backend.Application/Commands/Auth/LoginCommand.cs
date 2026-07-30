namespace TFA.Backend.Application.Commands.Auth
{
    public record LoginCommand(
        string Username, 
        string Password
    );
}
