using Moq;
using VarietyShop.Application.Queries.Roles.GetRoleById;
using VarietyShop.Application.Queries.Users.GetUserById;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Queries.Roles;

public class GetRoleByIdQueryHandlerTests
{
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly GetRoleByIdQuery _getRoleByIdQuery;
    private readonly GetRoleByIdQueryHandler _getRoleByIdQueryHandler;
    public GetRoleByIdQueryHandlerTests()
    {
        _roleRepositoryMock = new Mock<IRoleRepository>();
        _getRoleByIdQuery = new GetRoleByIdQuery(It.IsAny<int>());
        _getRoleByIdQueryHandler = new GetRoleByIdQueryHandler(_roleRepositoryMock.Object);
    }

    [Fact]
    public async Task IfUserIdExist_Executed_ReturnRoleViewModel()
    {
        //Arrange

        var role = RoleMock.RoleWithoutUsersFaker.Generate();

        _roleRepositoryMock.Setup(u => u.GetByIdAsync(It.IsAny<int>()).Result).Returns(role);

        //Act
        var userViewModel = await _getRoleByIdQueryHandler.Handle(_getRoleByIdQuery, new CancellationToken());

        //Assert
        Assert.NotNull(userViewModel);

        _roleRepositoryMock.Verify(u => u.GetByIdAsync(It.IsAny<int>()).Result, Times.Once);
    }
}
