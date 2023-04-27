using Moq;
using VarietyShop.Application.Queries.Roles.GetAllRoles;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.UnitTests.Mocks;

namespace VarietyShop.UnitTests.Application.Queries.Roles;

public class GetAllRolesQueryHandlerTests
{
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly GetAllRolesQuery _getAllRolesQuery;
    private readonly GetAllRolesQueryHandler _getAllRolesQueryHandler;
    public GetAllRolesQueryHandlerTests()
    {
        _roleRepositoryMock = new Mock<IRoleRepository>();
        _getAllRolesQuery = new GetAllRolesQuery();
        _getAllRolesQueryHandler = new GetAllRolesQueryHandler(_roleRepositoryMock.Object);
    }

    [Fact]
    public async Task ThreeRolesExist_Executed_ReturnThreeRolesViewModels()
    {
        //Arrange

        var roles = RoleMock.RoleWithoutUsersFaker.Generate(3);

        _roleRepositoryMock.Setup(u => u.GetAllAsync().Result).Returns(roles);

        //Act
        var roleViewModelList = await _getAllRolesQueryHandler.Handle(_getAllRolesQuery, new CancellationToken());

        //Assert
        Assert.NotNull(roleViewModelList);
        Assert.NotEmpty(roleViewModelList);
        Assert.Equal(roles.Count, roleViewModelList.Count);

        _roleRepositoryMock.Verify(u => u.GetAllAsync().Result, Times.Once);
    }
}
