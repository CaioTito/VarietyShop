using Moq;
using VarietyShop.Application.Commands.Users.CreateUser;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Interfaces.Services;
using VarietyShop.Infra.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Users;

public class CreateUserCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly Mock<IAuthService> _authMock;
    private readonly CreateUserCommandHandler _createUserCommandHandler;
    public CreateUserCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _userRepositoryMock = new Mock<IUserRepository>();
        _roleRepositoryMock = new Mock<IRoleRepository>();
        _authMock = new Mock<IAuthService>();
        _createUserCommandHandler = new CreateUserCommandHandler(_unitOfWorkMock.Object, _authMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_ReturnUserId() 
    {
        //Arrange

        var createUserCommand = UserMock.CreateUserCommandFaker.Generate();

        _unitOfWorkMock.SetupGet(uow => uow.Users).Returns(_userRepositoryMock.Object);
        _unitOfWorkMock.SetupGet(uow => uow.Roles).Returns(_roleRepositoryMock.Object);

        //Act

        var id = await _createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

        //Assert

        Assert.True(id >= 0);

        _unitOfWorkMock.Verify(u => u.Users.AddAsync(It.IsAny<User>()), Times.Once);
    }
}
