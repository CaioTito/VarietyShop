using Bogus;
using Moq;
using VarietyShop.Application.Commands.Users.DeleteUser;
using VarietyShop.Application.Commands.Users.LoginUser;
using VarietyShop.Application.Commands.Users.UpdateUser;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Interfaces.Services;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Users;

public class LoginUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IAuthService> _authServiceMock;
    private readonly LoginUserCommandHandler _loginUserCommandHandler;
    public LoginUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _authServiceMock = new Mock<IAuthService>();
        _loginUserCommandHandler = new LoginUserCommandHandler(_authServiceMock.Object, _userRepositoryMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_ReturnString()
    {
        //Arrange

        var LoginUserCommand = UserMock.LoginUserCommandFaker.Generate();

        var user = UserMock.UserFaker.Generate();

        _authServiceMock.Setup(u => u.GeneratePasswordHash(It.IsAny<string>())).Returns(LoginUserCommand.Password);
        _userRepositoryMock.Setup(u => u.GetByPasswordAndEmailAsync(It.IsAny<string>(), It.IsAny<string>()).Result).Returns(user);
        _authServiceMock.Setup(u => u.GenerateJwtToken(It.IsAny<string>(), It.IsAny<List<Role>>())).Returns(LoginUserCommand.Password);

        //Act

        var token = await _loginUserCommandHandler.Handle(LoginUserCommand, new CancellationToken());

        //Assert

        Assert.IsType<string>(token);

        _authServiceMock.Verify(u => u.GeneratePasswordHash(It.IsAny<string>()), Times.Once);
        _userRepositoryMock.Verify(u => u.GetByPasswordAndEmailAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        _authServiceMock.Verify(u => u.GenerateJwtToken(It.IsAny<string>(), It.IsAny<List<Role>>()), Times.Once);
    }

    [Fact]
    public async Task InputDataIsNotOk_Executed_ReturnNull()
    {
        //Arrange

        var LoginUserCommand = UserMock.LoginUserCommandFaker.Generate();

        User user = null;

        _authServiceMock.Setup(u => u.GeneratePasswordHash(It.IsAny<string>())).Returns(LoginUserCommand.Password);
        _userRepositoryMock.Setup(u => u.GetByPasswordAndEmailAsync(It.IsAny<string>(), It.IsAny<string>()).Result).Returns(user);

        //Act

        var token = await _loginUserCommandHandler.Handle(LoginUserCommand, new CancellationToken());

        //Assert

        Assert.Null(token);

        _authServiceMock.Verify(u => u.GeneratePasswordHash(It.IsAny<string>()), Times.Once);
        _userRepositoryMock.Verify(u => u.GetByPasswordAndEmailAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }
}
