using Bogus;
using VarietyShop.Application.Commands.Roles.CreateRole;
using VarietyShop.Application.Commands.Roles.DeleteRole;
using VarietyShop.Domain.Entities;

namespace VarietyShop.UnitTests.Mocks;

public static class RoleMock
{
    public static Faker<Role> RoleWithUsersFaker => new Faker<Role>()
        .CustomInstantiator(f => (
            Role.From(
                f.Random.Word(),
                f.Random.Word(),
                f.Random.Bool(),
                UserMock.UserFaker.Generate(3)
            )
        ));

    public static Faker<Role> RoleWithoutUsersFaker => new Faker<Role>()
        .CustomInstantiator(f => (
            Role.From(
                f.Random.Word(),
                f.Random.Word(),
                f.Random.Bool()
            )
        ));

    public static Faker<CreateRoleCommand> CreateRoleCommandFaker =>
            new Faker<CreateRoleCommand>()
                .RuleFor(x => x.Name, f => f.Random.Word())
                .RuleFor(x => x.Active, f => f.Random.Bool());

    public static Faker<DeleteRoleCommand> DeleteRoleCommandFaker => new Faker<DeleteRoleCommand>()
        .CustomInstantiator(f => (
            new DeleteRoleCommand(f.Random.Int())
        ));
}

