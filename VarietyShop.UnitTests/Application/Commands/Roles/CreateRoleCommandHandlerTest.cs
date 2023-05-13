using Moq;
using VarietyShop.Application.Commands.Roles.CreateRole;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Roles;

public class CreateRoleCommandHandlerTest
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly CreateRoleCommandHandler _createRoleCommandHandler;
    public CreateRoleCommandHandlerTest()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _roleRepositoryMock = new Mock<IRoleRepository>();
        _createRoleCommandHandler = new CreateRoleCommandHandler(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_ReturnUserId()
    {
        //Arrange

        var createRoleCommand = RoleMock.CreateRoleCommandFaker.Generate();

        _unitOfWorkMock.SetupGet(uow => uow.Roles).Returns(_roleRepositoryMock.Object);

        //Act

        var id = await _createRoleCommandHandler.Handle(createRoleCommand, new CancellationToken());

        //Assert

        Assert.True(id >= 0);

        _unitOfWorkMock.Verify(r => r.Roles.AddAsync(It.IsAny<Role>()), Times.Once);
    }
}
