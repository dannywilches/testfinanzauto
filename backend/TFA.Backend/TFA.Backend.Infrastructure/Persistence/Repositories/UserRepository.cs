using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Repositories;
using TFA.Backend.Infrastructure.Persistence.Context;
using TFA.Backend.Infrastructure.Persistence.Mappers;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CatalogDbContext _dbContext;

        public UserRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public async Task<User?> ValidateLogin(string username, CancellationToken ct = default)
        {
            var userModel = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username, ct);

            //if (userModel == null)
            //{
            //    return null;
            //}

            //var passwordHasher = new PasswordHasher<UserModel>();
            //var validateUser = passwordHasher.VerifyHashedPassword(userModel, userModel.Password, password);

            //if (validateUser != PasswordVerificationResult.Success)
            //{
            //    return null;
            //}
            var user = UserMapper.ToEntity(userModel);
            return user;
        }
    }
}
