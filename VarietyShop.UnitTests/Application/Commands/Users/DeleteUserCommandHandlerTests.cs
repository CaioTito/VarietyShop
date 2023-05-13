using Moq;
using VarietyShop.Application.Commands.Users.DeleteUser;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Users;

public class DeleteRoleCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly DeleteUserCommandHandler _deleteUserCommandHandler;
    public DeleteRoleCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _deleteUserCommandHandler = new DeleteUserCommandHandler(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_CallGetByIdAndSaveChanges()
    {
        //Arrange

        var deleteUserCommand = UserMock.DeleteUserCommandFaker.Generate();

        var user = UserMock.UserFaker.Generate();

        _unitOfWorkMock.Setup(u => u.Users.GetByIdAsync(It.IsAny<int>()).Result).Returns(user);

        //Act

        await _deleteUserCommandHandler.Handle(deleteUserCommand, new CancellationToken());

        //Assert

        _unitOfWorkMock.Verify(u => u.Users.GetByIdAsync(It.IsAny<int>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
    }
}
