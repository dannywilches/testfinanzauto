namespace TFA.Backend.Application.Commands.Auth
{
    public class LoginResponseDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }
        public int Expire { get; set; }
    }
}
