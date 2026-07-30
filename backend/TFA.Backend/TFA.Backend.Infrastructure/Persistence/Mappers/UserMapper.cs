using TFA.Backend.Domain.Entities;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Mappers
{
    public static class UserMapper
    {
        public static UserModel ToModel(this User user)
        {
            if (user == null) return null;
            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password
            };
        }

        public static User ToEntity(this UserModel userModel)
        {
            if (userModel == null) return null;
            return new User
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Username = userModel.Username,
                Password = userModel.Password
            };
        }
    }
}
