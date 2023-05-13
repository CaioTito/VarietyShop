using Moq;
using VarietyShop.Application.Commands.Users.DeleteUser;
using VarietyShop.Application.Commands.Users.UpdateUser;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Commands.Users;

public class UpdateUserCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly UpdateUserCommandHandler _updateUserCommandHandler;
    public UpdateUserCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _updateUserCommandHandler = new UpdateUserCommandHandler(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task InputDataIsOk_Executed_CallGetByIdAndSaveChanges()
    {
        //Arrange

        var updateUserCommand = UserMock.UpdateUserCommandFaker.Generate();

        var user = UserMock.UserFaker.Generate();

        _unitOfWorkMock.Setup(u => u.Users.GetByIdAsync(It.IsAny<int>()).Result).Returns(user);

        //Act

        await _updateUserCommandHandler.Handle(updateUserCommand, new CancellationToken());

        //Assert

        _unitOfWorkMock.Verify(u => u.Users.GetByIdAsync(It.IsAny<int>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
    }
}
