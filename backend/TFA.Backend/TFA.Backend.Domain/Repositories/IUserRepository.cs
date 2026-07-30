using TFA.Backend.Domain.Entities;

namespace TFA.Backend.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> ValidateLogin(string username, CancellationToken ct = default);
    }
}
