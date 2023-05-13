using Moq;
using VarietyShop.Application.Commands.Roles.DeleteRole;
using VarietyShop.Application.Commands.Users.DeleteUser;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Roles;

public class DeleteRoleCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly DeleteRoleCommandHandler _deleteRoleCommandHandler;
    public DeleteRoleCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _deleteRoleCommandHandler = new DeleteRoleCommandHandler(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_CallGetByIdAndSaveChanges()
    {
        //Arrange

        var deleteRoleCommand = RoleMock.DeleteRoleCommandFaker.Generate();

        var role = RoleMock.RoleWithUsersFaker.Generate();

        _unitOfWorkMock.Setup(r => r.Roles.GetByIdAsync(It.IsAny<int>()).Result).Returns(role);

        //Act

        await _deleteRoleCommandHandler.Handle(deleteRoleCommand, new CancellationToken());

        //Assert

        _unitOfWorkMock.Verify(r => r.Roles.GetByIdAsync(It.IsAny<int>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
    }
}
