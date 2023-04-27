using Moq;
using VarietyShop.Application.Commands.Roles.CreateRole;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Roles;

public class CreateRoleCommandHandlerTest
{
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly CreateRoleCommandHandler _createRoleCommandHandler;
    public CreateRoleCommandHandlerTest()
    {
        _roleRepositoryMock = new Mock<IRoleRepository>();
        _createRoleCommandHandler = new CreateRoleCommandHandler(_roleRepositoryMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_ReturnUserId()
    {
        //Arrange

        var createRoleCommand = RoleMock.CreateRoleCommandFaker.Generate();

        //Act

        var id = await _createRoleCommandHandler.Handle(createRoleCommand, new CancellationToken());

        //Assert

        Assert.True(id >= 0);

        _roleRepositoryMock.Verify(u => u.AddAsync(It.IsAny<Role>()), Times.Once);
    }
}
