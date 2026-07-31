using FluentAssertions;
using Moq;
using TFA.Backend.Application.Commands.CategoryCommand.CreateCategory;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Repositories;
using Xunit;

namespace TFA.Backend.Tests.Commands.Category
{
    public class CreateCategoryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateCategory()
        {
            // Arrange
            var repository = new Mock<ICategoryRepository>();

            repository
                .Setup(x => x.CreateCategory(
                    It.IsAny<Domain.Entities.Category>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Entities.Category
                {
                    CategoryName = "SERVIDORES",
                    Description = "Test Description",
                    Picture = "photo.png"
                });

            var handler = new CreateCategoryHandler(repository.Object);

            var command = new CreateCategoryCommand
            (
                Guid.NewGuid(),
                "SERVIDORES", 
                "Test Description",
                "photo.png"
            );

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();

            result.CategoryName.Should().Be("SERVIDORES");
        }
    }
}
