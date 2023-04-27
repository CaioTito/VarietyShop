using Moq;
using VarietyShop.Application.Commands.Users.DeleteUser;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Users;

public class DeleteRoleCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly DeleteUserCommandHandler _deleteUserCommandHandler;
    public DeleteRoleCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _deleteUserCommandHandler = new DeleteUserCommandHandler(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_CallGetByIdAndSaveChanges()
    {
        //Arrange

        var deleteUserCommand = UserMock.DeleteUserCommandFaker.Generate();

        var user = UserMock.UserFaker.Generate();

        _userRepositoryMock.Setup(u => u.GetByIdAsync(It.IsAny<int>()).Result).Returns(user);

        //Act

        await _deleteUserCommandHandler.Handle(deleteUserCommand, new CancellationToken());

        //Assert

        _userRepositoryMock.Verify(u => u.GetByIdAsync(It.IsAny<int>()), Times.Once);
        _userRepositoryMock.Verify(u => u.SaveShangesAsync(), Times.Once);
    }
}
