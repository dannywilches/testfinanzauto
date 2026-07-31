using FluentAssertions;
using Moq;
using TFA.Backend.Application.Commands.Auth;
using TFA.Backend.Application.Commands.CategoryCommand.CreateCategory;
using TFA.Backend.Application.DTOs.Auth;
using TFA.Backend.Application.Interfaces.Auth;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Repositories;
using Xunit;

namespace TFA.Backend.Tests.Commands.Auth
{
    public class LoginHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldLoginUser()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            var tokenService = new Mock<ITokenService>();

            userRepository
                .Setup(x => x.ValidateLogin(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new User
                {
                    Name = "admin",
                    Username = "admin",
                    Password = "123456"
                });

            tokenService
                .Setup(x => x.GenerateToken(
                    It.IsAny<User>()))
                .Returns(new TokenDto
                {
                    Token = "FAKE_TOKEN",
                    Type = "Bearer",
                    Expire = 599
                });

            var handler = new LoginCommandHandler(userRepository.Object, tokenService.Object);

            var command = new LoginCommand
            (
                "admin",
                "123456"
            );


            // Act
            var result = await handler.Handle(command);

            // Assert
            result.Should().NotBeNull();
            result.Token.Should().Be("FAKE_TOKEN");
            result.Type.Should().Be("Bearer");
            result.Expire.Should().Be(599);

            userRepository.Verify(
                x => x.ValidateLogin(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Once());

            tokenService.Verify(
                x => x.GenerateToken(
                    It.IsAny<User>()),
                Times.Once());
        }
    }
}
