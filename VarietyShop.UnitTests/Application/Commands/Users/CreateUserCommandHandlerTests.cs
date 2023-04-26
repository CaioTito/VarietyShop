using Moq;
using VarietyShop.Application.Commands.Users.CreateUser;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Interfaces.Services;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Users;

public class CreateUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly Mock<IAuthService> _authMock;
    private readonly CreateUserCommandHandler _createUserCommandHandler;
    public CreateUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _roleRepositoryMock = new Mock<IRoleRepository>();
        _authMock = new Mock<IAuthService>();
        _createUserCommandHandler = new CreateUserCommandHandler(_userRepositoryMock.Object, _roleRepositoryMock.Object, _authMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_ReturnUserId() 
    {
        //Arrange

        var createUserCommand = UserMock.CreateUserCommandFaker.Generate();

        //Act

        var id = await _createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

        //Assert

        Assert.True(id >= 0);

        _userRepositoryMock.Verify(u => u.AddAsync(It.IsAny<User>()), Times.Once);
    }
}
