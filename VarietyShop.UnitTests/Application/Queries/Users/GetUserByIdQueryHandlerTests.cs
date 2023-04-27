using Moq;
using VarietyShop.Application.Queries.Users.GetAllUsers;
using VarietyShop.Application.Queries.Users.GetUserById;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Queries.Users;

public class GetRoleByIdQueryHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly GetUserByIdQuery _getUserByIdQuery;
    private readonly GetUserByIdQueryHandler _getUserByIdQueryHandler;
    public GetRoleByIdQueryHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _getUserByIdQuery = new GetUserByIdQuery(It.IsAny<int>());
        _getUserByIdQueryHandler = new GetUserByIdQueryHandler(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task IfUserIdExist_Executed_ReturnUserViewModel()
    {
        //Arrange

        var user = UserMock.UserFaker.Generate();

        _userRepositoryMock.Setup(u => u.GetByIdAsync(It.IsAny<int>()).Result).Returns(user);

        //Act
        var userViewModel = await _getUserByIdQueryHandler.Handle(_getUserByIdQuery, new CancellationToken());

        //Assert
        Assert.NotNull(userViewModel);

        _userRepositoryMock.Verify(u => u.GetByIdAsync(It.IsAny<int>()).Result, Times.Once);
    }
}
