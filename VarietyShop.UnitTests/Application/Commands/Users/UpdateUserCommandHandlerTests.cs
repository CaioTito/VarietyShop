using Moq;
using VarietyShop.Application.Commands.Users.DeleteUser;
using VarietyShop.Application.Commands.Users.UpdateUser;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Users;

public class UpdateUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly UpdateUserCommandHandler _updateUserCommandHandler;
    public UpdateUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _updateUserCommandHandler = new UpdateUserCommandHandler(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_CallGetByIdAndSaveChanges()
    {
        //Arrange

        var updateUserCommand = UserMock.UpdateUserCommandFaker.Generate();

        var user = UserMock.UserFaker.Generate();

        _userRepositoryMock.Setup(u => u.GetByIdAsync(It.IsAny<int>()).Result).Returns(user);

        //Act

        await _updateUserCommandHandler.Handle(updateUserCommand, new CancellationToken());

        //Assert

        _userRepositoryMock.Verify(u => u.GetByIdAsync(It.IsAny<int>()), Times.Once);
        _userRepositoryMock.Verify(u => u.SaveShangesAsync(), Times.Once);
    }
}
