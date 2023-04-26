using Moq;
using VarietyShop.Application.Queries.Users.GetAllUsers;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Queries.Users;

public class GetAllUsersQueryHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly GetAllUsersQuery _getAllUsersQuery;
    private readonly GetAllUsersQueryHandler _getAllUsersQueryHandler;
    public GetAllUsersQueryHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _getAllUsersQuery = new GetAllUsersQuery();
        _getAllUsersQueryHandler = new GetAllUsersQueryHandler(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task ThreeUsersExist_Executed_ReturnThreeUserViewModels()
    {
        //Arrange

        var users = UserMock.UserFaker.Generate(3);

        _userRepositoryMock.Setup(u => u.GetAllAsync().Result).Returns(users);

        //Act
        var userViewModelList = await _getAllUsersQueryHandler.Handle(_getAllUsersQuery, new CancellationToken());

        //Assert
        Assert.NotNull(userViewModelList);
        Assert.NotEmpty(userViewModelList);
        Assert.Equal(users.Count, userViewModelList.Count);

        _userRepositoryMock.Verify(u => u.GetAllAsync().Result, Times.Once);
    }
}
