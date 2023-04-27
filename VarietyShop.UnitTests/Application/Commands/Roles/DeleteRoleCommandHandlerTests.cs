using Moq;
using VarietyShop.Application.Commands.Roles.DeleteRole;
using VarietyShop.Application.Commands.Users.DeleteUser;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Roles;

public class DeleteRoleCommandHandlerTests
{
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly DeleteRoleCommandHandler _deleteRoleCommandHandler;
    public DeleteRoleCommandHandlerTests()
    {
        _roleRepositoryMock = new Mock<IRoleRepository>();
        _deleteRoleCommandHandler = new DeleteRoleCommandHandler(_roleRepositoryMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_CallGetByIdAndSaveChanges()
    {
        //Arrange

        var deleteRoleCommand = RoleMock.DeleteRoleCommandFaker.Generate();

        var role = RoleMock.RoleWithUsersFaker.Generate();

        _roleRepositoryMock.Setup(u => u.GetByIdAsync(It.IsAny<int>()).Result).Returns(role);

        //Act

        await _deleteRoleCommandHandler.Handle(deleteRoleCommand, new CancellationToken());

        //Assert

        _roleRepositoryMock.Verify(u => u.GetByIdAsync(It.IsAny<int>()), Times.Once);
        _roleRepositoryMock.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
}
