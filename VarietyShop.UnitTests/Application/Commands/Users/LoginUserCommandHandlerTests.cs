using Moq;
using VarietyShop.Application.Commands.Users.LoginUser;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Services;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Users;

public class LoginUserCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IAuthService> _authServiceMock;
    private readonly LoginUserCommandHandler _loginUserCommandHandler;
    public LoginUserCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _authServiceMock = new Mock<IAuthService>();
        _loginUserCommandHandler = new LoginUserCommandHandler(_authServiceMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_ReturnString()
    {
        //Arrange

        var LoginUserCommand = UserMock.LoginUserCommandFaker.Generate();

        var user = UserMock.UserFaker.Generate();

        _authServiceMock.Setup(u => u.GeneratePasswordHash(It.IsAny<string>())).Returns(LoginUserCommand.Password);
        _unitOfWorkMock.Setup(u => u.Users.GetByPasswordAndEmailAsync(It.IsAny<string>(), It.IsAny<string>()).Result).Returns(user);
        _authServiceMock.Setup(u => u.GenerateJwtToken(It.IsAny<string>(), It.IsAny<List<Role>>())).Returns(LoginUserCommand.Password);

        //Act

        var token = await _loginUserCommandHandler.Handle(LoginUserCommand, new CancellationToken());

        //Assert

        Assert.IsType<string>(token);

        _authServiceMock.Verify(u => u.GeneratePasswordHash(It.IsAny<string>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.Users.GetByPasswordAndEmailAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        _authServiceMock.Verify(u => u.GenerateJwtToken(It.IsAny<string>(), It.IsAny<List<Role>>()), Times.Once);
    }

    [Fact]
    public async Task InputDataIsNotOk_Executed_ReturnNull()
    {
        //Arrange

        var LoginUserCommand = UserMock.LoginUserCommandFaker.Generate();

        User user = null;

        _authServiceMock.Setup(u => u.GeneratePasswordHash(It.IsAny<string>())).Returns(LoginUserCommand.Password);
        _unitOfWorkMock.Setup(u => u.Users.GetByPasswordAndEmailAsync(It.IsAny<string>(), It.IsAny<string>()).Result).Returns(user);

        //Act

        var token = await _loginUserCommandHandler.Handle(LoginUserCommand, new CancellationToken());

        //Assert

        Assert.Null(token);

        _authServiceMock.Verify(u => u.GeneratePasswordHash(It.IsAny<string>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.Users.GetByPasswordAndEmailAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }
}
