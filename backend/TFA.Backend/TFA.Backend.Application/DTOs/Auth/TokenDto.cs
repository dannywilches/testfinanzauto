namespace TFA.Backend.Application.DTOs.Auth
{
    public class TokenDto
    {
        public string Token { get; set; }
        public string Type { get; set; }
        public int Expire { get; set; }
    }
}
